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
        /// Excel 2007 文件中各工作表共享的字符串
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
                        zs = Zip.GetZipInputStream(fileStream, "xl/sharedStrings.xml"); // 可能引发(FileNotFoundException)
                        // xl/sharedStrings.xml 文件的内容举例如下：
                        // <sst count="56" uniqueCount="2">
                        //   <si><t>任盈盈</t><phoneticPr fontId="1" type="noConversion" /></si>
                        //   <si><t /></si>
                        // </sst>
                        using (XmlReader reader = XmlReader.Create(zs))
                        {
                            while (reader.Read()) if (reader.IsStartElement("sst")) break;
                            sharedStrings = new string[Convert.ToInt32(reader.GetAttribute("uniqueCount"))];
                            for (int count = 0; ; count++)
                            {
                                reader.Read();                                               // 执行后(reader)的值: <si> or </sst>
                                if (!reader.IsStartElement("si")) break;
                                reader.ReadStartElement("si");                               // 执行后(reader)的值: <t>  or <t />
                                if (reader.IsStartElement("r"))
                                {
                                    reader.ReadToNextSibling("t");
                                    continue;
                                }
                                
                                sharedStrings[count] = reader.ReadElementString("t").Trim(); // 执行后(reader)的值: </si> or <与<t>同级的元素>

                                if (reader.NodeType != XmlNodeType.EndElement) reader.ReadToNextSibling("t"); // 执行后(reader)的值: </si>
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        sharedStrings = new string[0]; // 如果没有找到 xl/sharedStrings.xml 文件
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
