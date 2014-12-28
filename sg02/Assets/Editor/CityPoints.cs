using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Xml;
using System.Collections;
using System.Linq;

public class CityPoints 
{
    private static readonly string m_configPath = "Assets/Resources/Config/XML/CityPoints.xml"; 

    [MenuItem("Tools/生成城市的位置信息", false, 0)]
    static void Execute()
    {
        if (Selection.activeTransform == null) return;
        if (Selection.activeTransform.childCount == 0) return;
        if (Selection.activeTransform.name != "CityPoints") return;

        Transform root = Selection.activeTransform;
        Transform[] points = new Transform[root.childCount];
        for (int i = 0; i < root.childCount; i++)
        {
            points[i] = root.GetChild(i);
        }

        XMLLoader<XMLDataPathInfo> pathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);
        XMLLoader<XMLDataCity> cityInfo = new XMLLoader<XMLDataCity>(XMLConfigPath.City);

        XmlDocument xmlDoc = new XmlDocument();

        XmlDeclaration xmldecl;
        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
        xmldecl.Encoding = "UTF-8";
        xmlDoc.AppendChild(xmldecl);

        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        int cityNum = points.Length;
        int[] cityPoints = new int[cityNum];
        int[] cityID = new int[cityNum];

        int step = GeneratePathInfo.m_step;
        int[] xStep = new int[] { 0, 0, step, step, step, 0, -step, -step, -step };
        int[] yStep = new int[] { 0, step, step, 0, -step, -step, -step, 0, step };

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].name == "") continue;
            if (!cityInfo.Data.ContainsKey(System.Convert.ToInt32(points[i].name))) continue;

            Vector3 position = points[i].transform.position;
            position.x = ((int)position.x / step) * step;
            position.y = ((int)position.y / step) * step;

            string p = "";
            int index = 0;

            bool isFind = false;
            
            for (int n = 0; n < 9; n++)
            {
                p = ((int)(position.x + xStep[n])).ToString() + "," + ((int)(position.y + yStep[n])).ToString();

                IEnumerator enumerator = pathInfo.Data.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XMLDataPathInfo current = pathInfo.GetInfoById((int)enumerator.Current);
                    if (current.Position == p)
                    {
                        isFind = true;
                        index = (int)enumerator.Current;
                        int id = System.Convert.ToInt32(points[i].name);
                        cityID[i] = id;
                        cityPoints[i] = index;
                        break;
                    }
                }
                if (isFind) break;
            }
            
            if (!isFind)
            {
                string errorMessage = "城市点 " + points[i].name + " 不在寻路点上!" + p;
                Debug.LogError(errorMessage);
                EditorUtility.DisplayDialog("失败", errorMessage, "确定");
                return;
            }
        }

        //输出城市间的路线
        int ID = 1;
        for (int i = 0; i < cityNum-1; i++)
        {
            for (int j = i + 1; j < cityNum; j++)
            {
                List<int> path = PathFinding.GetPath(cityPoints[i], cityPoints[j], pathInfo.Data);

                XMLDataCity currentInfo = cityInfo.GetInfoById(cityID[i]);
                XMLDataCity nextInfo = cityInfo.GetInfoById(cityID[j]);
                if (path == null)
                {
                    string errorMessage = "城市 " + currentInfo.Name + " 到城市 " + nextInfo.Name + " 的路不通!";
                    Debug.LogError(errorMessage);
                    EditorUtility.DisplayDialog("失败", errorMessage, "确定");
                    return;
                }

                // 去掉不是相邻的城市的点
                bool flag = false;
                for (int n = 0; n < path.Count; n++)
                {
                    for (int k = 0; k < cityNum; k++)
                    {
                        if (k == i || k == j) continue;
                        Vector3 p1 = Utility.GetPoint(pathInfo.GetInfoById(cityPoints[k]).Position);
                        Vector3 p2 = Utility.GetPoint(pathInfo.GetInfoById(path[n]).Position);
                        if (Vector3.Distance(p1, p2) < 4 * step)
                        {
                            flag = true;
                        }
                    }
                }
                
                if (flag) continue;

                int[] intArr = path.ToArray();
                string[] strArr = intArr.Select(v => v.ToString()).ToArray();
                string pathstr = string.Join(",", strArr);

                XmlElement node = xmlDoc.CreateElement("RECORD");
                node.SetAttribute("ID", ID.ToString());
                node.SetAttribute("FromCity", cityID[i].ToString());
                node.SetAttribute("ToCity", cityID[j].ToString());
                node.SetAttribute("FromPoint", cityPoints[i].ToString());
                node.SetAttribute("ToPoint", cityPoints[j].ToString());
                node.SetAttribute("Path", pathstr);

                rootElement.AppendChild(node);

                ID++;
                EditorUtility.DisplayProgressBar("Processing", currentInfo.Name, 1.0f * i / cityNum);
            }
        }

        xmlDoc.Save(m_configPath);
        AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("成功", "城市位置信息生成完成!", "确定");
    }
}
