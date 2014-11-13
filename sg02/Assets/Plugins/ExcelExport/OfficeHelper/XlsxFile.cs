using System;
using System.IO;
using System.Xml;
using Skyiv.Ben.Common;

namespace Skyiv.OfficeHelper
{
  /// <summary>
  /// Excel 文件
  /// </summary>
  sealed partial class XlsxFile : IDisposable
  {
    string fileName; // Excel 文件的文件名
    Sheet[] sheets;  // Excel 文件的各工作表
    FileStream fileStream { 
        get 
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                if (e != null)
                    Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            return fs; 
        } 
    }

    /// <summary>
    /// Excel 文件的构造函数
    /// </summary>
    /// <param name="fileName">Excel 文件的文件名</param>
    public XlsxFile(string fileName)
    {
      this.fileName = fileName;
    }

    /// <summary>
    /// Excel 文件的各工作表
    /// </summary>
    public Sheet[] Sheets
    {
      get
      {
        if (sheets == null)
        {
          using (Stream zs = Zip.GetZipInputStream(fileStream, "xl/workbook.xml"))
          {
            // xl/workbook.xml 文件的内容举例如下：
            // <workbook>
            //   <sheets>
            //     <sheet name="好人" sheetId="1" r:id="rId1" />
            //     <sheet name="坏人" sheetId="2" r:id="rId2" />
            //   </sheets>
            // </workboo>
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(zs);
            XmlNodeList elms = xmlDocument.DocumentElement["sheets"].ChildNodes;
            sheets = new Sheet[1];
            for (int i = 0; i < 1; i++)
            {
              XmlAttributeCollection attrs = elms[i].Attributes;
              sheets[i] = new Sheet(attrs["name"].Value, GetXmlFileName(attrs["r:id"].Value), SharedStrings, fileStream);
            }
          }
        }
        return sheets;
      }
    }

    /// <summary>
    /// 根据“标识”给出表示工作表的 XML 文件名
    /// </summary>
    /// <param name="id">标识</param>
    /// <returns>表示工作表的 XML 文件名</returns>
    string GetXmlFileName(string id)
    {
      string value;
      using (Stream zs = Zip.GetZipInputStream(fileStream, "xl/_rels/workbook.xml.rels"))
      {
        // xl/_rels/workbook.xml.rels 文件的内容举例如下：
        // <Relationships>
        //   <Relationship Id="rId1" Target="worksheets/sheet1.xml" />
        //   <Relationship Id="rId2" Target="worksheets/sheet2.xml" />
        // </Relationships>
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(zs);
        value = XmlHelper.GetElementById(xmlDocument, id).Attributes["Target"].Value;
      }
      return value;
    }

    public void Dispose()
    {
      if (sheets == null) return;
      foreach (Sheet sheet in sheets) sheet.Dispose();
    }
  }
}
