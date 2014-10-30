using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawPathGizmos : MonoBehaviour 
{
    private XMLLoader<XMLDataPathInfo> pathInfo;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        if (pathInfo == null)
            pathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);

        Gizmos.color = new Color(1, 0, 0, 1F);

        IEnumerator enumerator = pathInfo.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataPathInfo info = (XMLDataPathInfo)enumerator.Current;
            string[] linkPoints = info.LinkPoints.Split(',');
            for (int i = 0; i < linkPoints.Length; i++)
            {
                if (linkPoints[i] == "") continue;
                XMLDataPathInfo point = pathInfo.GetInfoById(System.Convert.ToInt32(linkPoints[i]));

                string[] point1 = info.Position.Split(',');
                string[] point2 = point.Position.Split(',');

                Gizmos.DrawLine(
                    new Vector3(System.Convert.ToInt32(point1[0]), System.Convert.ToInt32(point1[1])),
                    new Vector3(System.Convert.ToInt32(point2[0]), System.Convert.ToInt32(point2[1])));
            }
        }
    }
}
