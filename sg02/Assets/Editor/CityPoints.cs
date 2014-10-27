using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Xml;
using System.Collections;

public class CityPoints 
{
    private static readonly string m_configPath = "Assets/Resources/Config/XML/CityPoints.xml"; 

    [MenuItem("Tools/生成城市的位置信息")]
    static void Execute()
    {
        if (Selection.activeTransform == null) return;
        if (Selection.activeTransform.name != "CityPoints") return;

        Transform[] points = Selection.activeTransform.GetComponentsInChildren<Transform>();
        if (points.Length == 0) return;

        XMLLoader<XMLDataPathInfo> pathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);

        XmlDocument xmlDoc = new XmlDocument();

        XmlDeclaration xmldecl;
        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
        xmldecl.Encoding = "UTF-8";
        xmlDoc.AppendChild(xmldecl);

        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].name == "CityPoints") continue;

            XmlElement node = xmlDoc.CreateElement("RECORD");
            node.SetAttribute("ID", points[i].name);

            Vector3 position = points[i].transform.position;
            position.x = ((int)position.x / GeneratePathInfo.m_step) * GeneratePathInfo.m_step;
            position.y = ((int)position.y / GeneratePathInfo.m_step) * GeneratePathInfo.m_step;

            string p = "";
            int index = 0;

            bool isFind = false;
            int[] xStep = new int[]{0, 8, 8, 8, 0, -8, -8, -8};
            int[] yStep = new int[]{8, 8, 0, -8, -8, -8, 0, 8};
            for (int n = 0; n < 8; n++)
            {
                p = ((int)(position.x + xStep[n])).ToString() + "," + ((int)(position.y + yStep[n])).ToString();

                IEnumerator enumerator = pathInfo.Data.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XMLDataPathInfo current = pathInfo.GetInfoById(enumerator.Current);
                    if (current.Position == p)
                    {
                        isFind = true;
                        index = (int)enumerator.Current;
                        break;
                    }
                }
                if (isFind) break;
            }
            
            if (!isFind)
            {
                Debug.Log("城市点 " + points[i].name + " 不在寻路点上!" + p);
                EditorUtility.DisplayDialog("失败", "城市点 " + points[i].name + " 不在寻路点上!" + p, "确定");
                return;
            }

            node.SetAttribute("PositionIndex", index.ToString());

            rootElement.AppendChild(node);
        }

        xmlDoc.Save(m_configPath);

        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("成功", "城市位置信息生成完成!", "确定");
    }
}
