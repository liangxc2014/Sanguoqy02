using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawPathGizmos : MonoBehaviour 
{
    private XMLLoader<XMLDataPathInfo> pathInfo;
    private XMLLoader<XMLDataCityPoints> cityPoints;

    private bool m_isInit = false;

	// Use this for initialization
	void Awake () 
    {
        m_isInit = true;

        pathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);
        cityPoints = new XMLLoader<XMLDataCityPoints>(XMLConfigPath.CityPoints);
	}
	
    void OnDisable()
    {
        m_isInit = false;
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        if (!m_isInit || cityPoints == null || pathInfo == null) 
            return;    

        Gizmos.color = new Color(1, 0, 0, 1F);

        IEnumerator enumerator = cityPoints.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataCityPoints info = (XMLDataCityPoints)enumerator.Current;
            string[] linkPoints = info.Path.Split(',');
            for (int i = 0; i < linkPoints.Length - 1; i++)
            {
                if (linkPoints[i] == "") continue;
                XMLDataPathInfo p1 = pathInfo.GetInfoById(System.Convert.ToInt32(linkPoints[i]));
                XMLDataPathInfo p2 = pathInfo.GetInfoById(System.Convert.ToInt32(linkPoints[i + 1]));

                Vector3 point1 = Utility.GetPoint(p1.Position);
                Vector3 point2 = Utility.GetPoint(p2.Position);

                Gizmos.DrawLine(point1, point2);
             }
        }
    }
}
