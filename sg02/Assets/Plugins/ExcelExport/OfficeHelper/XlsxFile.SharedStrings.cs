using System;
using System.IO;
using System.Xml;
using Skyiv.Ben.Common;

namespace Skyiv.OfficeHelper
{
    partial class XlsxFile
    {
        string[] sharedStrings;

        /// <summary>
        /// Excel 2007 �ļ��и�����������ַ���
        /// </summary>
        string[] SharedStrings
        {
            get
            {
                if (sharedStrings == null)
                {
                    Stream zs = null;
                    try
                    {
                        zs = Zip.GetZipInputStream(fileStream, "xl/sharedStrings.xml"); // ��������(FileNotFoundException)
                        // xl/sharedStrings.xml �ļ������ݾ������£�
                        // <sst count="56" uniqueCount="2">
                        //   <si><t>��ӯӯ</t><phoneticPr fontId="1" type="noConversion" /></si>
                        //   <si><t /></si>
                        // </sst>
                        using (XmlReader reader = XmlReader.Create(zs))
                        {
                            while (reader.Read()) if (reader.IsStartElement("sst")) break;
                            sharedStrings = new string[Convert.ToInt32(reader.GetAttribute("uniqueCount"))];
                            for (int count = 0; ; count++)
                            {
                                reader.Read();                                               // ִ�к�(reader)��ֵ: <si> or </sst>
                                if (!reader.IsStartElement("si")) break;
                                reader.ReadStartElement("si");                               // ִ�к�(reader)��ֵ: <t>  or <t />
                                if (reader.IsStartElement("r"))
                                {
                                    reader.ReadToNextSibling("t");
                                    continue;
                                }
                                
                                sharedStrings[count] = reader.ReadElementString("t").Trim(); // ִ�к�(reader)��ֵ: </si> or <��<t>ͬ����Ԫ��>

                                if (reader.NodeType != XmlNodeType.EndElement) reader.ReadToNextSibling("t"); // ִ�к�(reader)��ֵ: </si>
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        sharedStrings = new string[0]; // ���û���ҵ� xl/sharedStrings.xml �ļ�
                    }
                    finally
                    {
                        if (zs != null) zs.Close();
                    }
                }
                return sharedStrings;
            }
        }
    }
}
