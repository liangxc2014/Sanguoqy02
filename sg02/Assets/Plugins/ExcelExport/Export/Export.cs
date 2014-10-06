using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Skyiv.OfficeHelper;

public sealed partial class Export
{
    string m_fileName;
    XlsxFile.Sheet m_sheet;

    List<string> m_listProperty;
    List<string> m_listDescript;
    List<string> m_listType;

    public Export (string fileName)
    {
        m_fileName = fileName;

        Init();
    }

    public void Init()
    {
        m_listProperty = new List<string>();
        m_listDescript = new List<string>();
        m_listType = new List<string>();

        using (XlsxFile xlsxFile = new XlsxFile(m_fileName))
        {
            using (XlsxFile.Sheet sheet = xlsxFile.Sheets[0])
            {
                m_sheet = sheet;
                if (m_sheet.RowCount < 3)
                {
                    Console.WriteLine("文件:" + m_fileName + " 格式错误!");
                    return;
                }

                m_listProperty.AddRange(m_sheet.ReadRow());
                m_listDescript.AddRange(m_sheet.ReadRow());
                m_listType.AddRange(m_sheet.ReadRow());

                for (int i = 0; i < m_listType.Count; i++)
                {
                    if (string.Compare(m_listType[i], "string", true) != 0
                        && string.Compare(m_listType[i], "int", true) != 0
                        && string.Compare(m_listType[i], "float", true) != 0)
                    {
                        Console.WriteLine("文件:" + m_fileName + "第 " + i + " 列元素的类型错误! string int float");
                        return;
                    }
                }

                ExportToXML();
                ExportToCSharp();
            }
        }
    }

    void ExportToXML()
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlDeclaration xmldecl;
        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
        xmldecl.Encoding = "UTF-8";
        xmlDoc.AppendChild(xmldecl);

        //XmlElement root = doc.DocumentElement;
        //doc.InsertBefore(xmldecl, root);

        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        string[] fields = m_sheet.ReadRow();
        while (fields != null) 
        {
            XmlElement node = xmlDoc.CreateElement("RECORD");
            for (int i = 0; i < m_listProperty.Count; i++)
            {
                if (m_listType[i] == "string" && fields[i] == "0")
                {
                    node.SetAttribute(m_listProperty[i], "");
                }
                else
                {
                    node.SetAttribute(m_listProperty[i], fields[i]);
                }
            }
            if (node.GetAttribute("ID") != "" && node.GetAttribute("ID") != "0")
            {
                rootElement.AppendChild(node);
            }
            
            fields = m_sheet.ReadRow();
        }

        string dirName = Path.GetDirectoryName(m_fileName);
        string fileName = Path.GetFileNameWithoutExtension(m_fileName);
        //string xmlPath = m_fileName.Substring(0, m_fileName.Length - (".xlsx").Length) + ".xml";
        string xmlDir = dirName + "/../" + "XML/";
        DirectoryInfo di = new DirectoryInfo(xmlDir);
        if (!di.Exists)
            Directory.CreateDirectory(xmlDir);

        string xmlPath = xmlDir + fileName + ".xml";

        xmlDoc.Save(xmlPath);
    }

    void ExportToCSharp()
    {
        string className = "XMLData" + Path.GetFileNameWithoutExtension(m_fileName);
        string dirName = "Assets/Scripts/XML/Entity/";
        string filePath = dirName + className + ".cs";

        FileStream fs = new FileStream(filePath, FileMode.Create); 
        StreamWriter sw = new StreamWriter(fs, Encoding.Default);

        sw.WriteLine("\n");
        sw.WriteLine("public class " + className + "\n" + "{");

        for (int i = 0; i < m_listProperty.Count; i++)
        {
            sw.WriteLine("\t/// <summary>\n\t/// " + m_listDescript[i] + "\n\t/// </summary>");
            sw.WriteLine("\tpublic " + m_listType[i] + " " + m_listProperty[i] + ";\n");
        }

        sw.WriteLine("}\n");
        
        sw.Close(); 
        fs.Close();
    }
}
