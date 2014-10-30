using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Xml;

public class GeneratePathInfo 
{
    public static readonly int m_step = 4;
    private static readonly string m_configPath = "Assets/Resources/Config/XML/PathInfo.xml";

    [MenuItem("Tools/生成路径信息")]
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
                    point.x -= source.width / 2;
                    point.y -= source.height / 2;
                    listPoints.Add(point);
                    dicPositonToID.Add(point, listPoints.Count);
                }
            }
        }
        
        // 分析路径点之间的关系,找出相邻的点
        List<List<int>> listRelation = new List<List<int>>();
        int[] xOff = new int[] { 0, m_step, m_step, m_step, 0, -m_step, -m_step, -m_step };
        int[] yOff = new int[] { m_step, m_step, 0, -m_step, -m_step, -m_step, 0, m_step };

        for (int i = 0; i < listPoints.Count; i++)
        {
            Vector2 currentPoint = listPoints[i];
            listRelation.Add(new List<int>());
            for (int j = 0; j < 8; j++)
            {
                Vector2 point = new Vector2(currentPoint.x + xOff[j], currentPoint.y + yOff[j]);
                if (dicPositonToID.ContainsKey(point))
                {
                    listRelation[i].Add(dicPositonToID[point]);
                }
            }
        }

        // 去掉噪点
//         for (int i = 0; i < listPoints.Count; i++)
//         {
//             for (int j = listRelation[i].Count - 1; j >= 0; j--)
//             {
//                 int relaIndex = listRelation[i][j] - 1;
//                 Vector2 direction = listPoints[i] - listPoints[relaIndex];
//                 float angle1 = Vector2.Angle(direction, Vector2.right);
//                 if (direction.y < 0)
//                     angle1 = 360 - angle1;
//                 bool flag = false;
//                 for (int k = 0; k < listRelation[relaIndex].Count; k++)
//                 {
//                     int nextIndex = listRelation[relaIndex][k] - 1;
//                     direction = listPoints[relaIndex] - listPoints[nextIndex];
//                     float angle2 = Vector2.Angle(direction, Vector2.right);
//                     if (direction.y < 0)
//                         angle2 = 360 - angle2;
//                     if (Mathf.Abs(angle1 - angle2) < 90)
//                     {
//                         flag = true;
//                         break;
//                     }
//                 }
//                 if (flag == false)
//                 {
//                     listRelation[i].RemoveAt(j);
//                     listRelation[relaIndex].Remove(i + 1);
//                 }
//             }
//         }

        XmlDocument xmlDoc = new XmlDocument();

        XmlDeclaration xmldecl;
        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
        xmldecl.Encoding = "UTF-8";
        xmlDoc.AppendChild(xmldecl);

        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        int ID = 1;
        for (int i = 0; i < listPoints.Count; i++)
        {
            XmlElement node = xmlDoc.CreateElement("RECORD");

            node.SetAttribute("ID", ID.ToString());
            ID++;

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

        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("成功", "地图路径信息生成完成!", "确定");
    }
}
