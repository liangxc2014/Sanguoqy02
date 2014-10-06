using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Xml;

public class GeneratePathInfo 
{
    private static readonly int m_step = 8;
    private static readonly string m_configPath = "Assets/Resources/Config/XML/PathInfo.xml";

    [MenuItem("Tools/Path Info")]
    static void Execute()
    {
        if (Selection.objects.Length == 0) return;

        Object o = Selection.objects[0];
        if (!(o is Texture2D)) return;

        // 获取所有路径点
        List<Vector2> listPoints = new List<Vector2>();
        Dictionary<Vector2, int> dicPositonToID = new Dictionary<Vector2, int>();

        Texture2D source = (Texture2D)AssetDatabase.LoadAssetAtPath(AssetDatabase.GetAssetPath(o), typeof(Texture2D));
        for (int i = 0; i < source.width; i += m_step)
        {
            for (int j = 0; j < source.height; j += m_step)
            {
                Color color = source.GetPixel(i, j);
                if (color.r > 0.5f && color.g > 0.5f && color.b > 0.5f)
                {
                    Vector2 point = new Vector2(i, j);
                    listPoints.Add(point);
                    dicPositonToID.Add(point, listPoints.Count);
                }
            }
        }
        
        // 分析路径点之间的关系
        List<List<int>> listRelation = new List<List<int>>();
        int[] xOff = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] yOff = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };

        for (int i = 0; i < listPoints.Count; i++)
        {
            Vector2 currentPoint = listPoints[i];
            listRelation.Add(new List<int>());
            for (int j = 0; j < 8; j++)
            {
                Vector2 point = new Vector2(currentPoint.x + xOff[j] * m_step, currentPoint.y + yOff[j] * m_step);
                if (dicPositonToID.ContainsKey(point))
                {
                    listRelation[i].Add(dicPositonToID[point]);
                }
            }
        }

        XmlDocument xmlDoc = new XmlDocument();

        XmlDeclaration xmldecl;
        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
        xmldecl.Encoding = "UTF-8";
        xmlDoc.AppendChild(xmldecl);

        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        for (int i = 0; i < listPoints.Count; i++)
        {
            XmlElement node = xmlDoc.CreateElement("RECORD");
            node.SetAttribute("ID", (i + 1).ToString());
            node.SetAttribute("Position", ((int)listPoints[i].x).ToString() + "," + ((int)listPoints[i].y).ToString());

            string link = "";
            for (int j = 0; j < listRelation[i].Count - 1; j++)
            {
                link += listRelation[i][j] + ",";
            }
            if (listRelation[i].Count > 0)
            {
                link += "" + listRelation[i][listRelation[i].Count - 1];
            }
            node.SetAttribute("LinkPoints", link);

            rootElement.AppendChild(node);
        }

        xmlDoc.Save(m_configPath);
    }
}
