using System;
using System.IO;
using System.Xml;
using Skyiv.Ben.Common;

namespace Skyiv.OfficeHelper
{
  /// <summary>
  /// Excel �ļ�
  /// </summary>
  sealed partial class XlsxFile : IDisposable
  {
    string fileName; // Excel �ļ����ļ���
    Sheet[] sheets;  // Excel �ļ��ĸ�������
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
    /// Excel �ļ��Ĺ��캯��
    /// </summary>
    /// <param name="fileName">Excel �ļ����ļ���</param>
    public XlsxFile(string fileName)
    {
      this.fileName = fileName;
    }

    /// <summary>
    /// Excel �ļ��ĸ�������
    /// </summary>
    public Sheet[] Sheets
    {
      get
      {
        if (sheets == null)
        {
          using (Stream zs = Zip.GetZipInputStream(fileStream, "xl/workbook.xml"))
          {
            // xl/workbook.xml �ļ������ݾ������£�
            // <workbook>
            //   <sheets>
            //     <sheet name="����" sheetId="1" r:id="rId1" />
            //     <sheet name="����" sheetId="2" r:id="rId2" />
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
    /// ���ݡ���ʶ��������ʾ������� XML �ļ���
    /// </summary>
    /// <param name="id">��ʶ</param>
    /// <returns>��ʾ������� XML �ļ���</returns>
    string GetXmlFileName(string id)
    {
      string value;
      using (Stream zs = Zip.GetZipInputStream(fileStream, "xl/_rels/workbook.xml.rels"))
      {
        // xl/_rels/workbook.xml.rels �ļ������ݾ������£�
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
