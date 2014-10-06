using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Skyiv.Ben.Common;

namespace Skyiv.OfficeHelper
{
    partial class XlsxFile
    {
        /// <summary>
        /// Execl 2007 文件中的工作表
        /// </summary>
        public sealed class Sheet : IDisposable
        {
            string[] sharedStrings; // 各工作表共享的字符串
            Stream stream;          // 用于读取本工作表的文件流
            XmlReader reader;       // 用于读取本工作表的 XML 数据读取器
            string dimension;       // 本工作表的范围，如：“A1”、“B2:C4”
            int rowCount;           // 本工作表的有效行数
            string name;            // 本工作表的名称

            public string Dimension { get { return dimension; } }
            public int RowCount { get { return rowCount; } }
            public string Name { get { return name; } }

            /// <summary>
            /// 表示 Excel 2007 文件中的工作表的类的构造函数
            /// </summary>
            /// <param name="name">本工作表的名称</param>
            /// <param name="fileName">工作表的 XML 文件名</param>
            /// <param name="sharedStrings">各工作表共享的字符串</param>
            /// <param name="fileStream">表示整个 Excel 2007 文件的流</param>
            public Sheet(string name, string fileName, string[] sharedStrings, Stream fileStream)
            {
                this.name = name;
                this.sharedStrings = sharedStrings;
                stream = Zip.GetZipInputStream(fileStream, "xl/" + fileName);
                reader = XmlReader.Create(stream);
                while (reader.Read()) if (reader.IsStartElement("dimension")) break;
                dimension = reader.GetAttribute("ref"); // 本工作表的范围：<dimension ref="B2:C4" />
                rowCount = GetRowCount(dimension); // 根据工作表的范围计算有效行数
                if (rowCount < 3)
                    return;

                while (reader.Read()) if (reader.IsStartElement("sheetData")) break;
            }

            /// <summary>
            /// 读取本工作表的中一行
            /// </summary>
            /// <returns>读取的行的各字段的内容。如果已经没有可读的行则返回 null。</returns>
            public string[] ReadRow()
            {
                // 表示工作表的 XML 文件(如：xl/worksheets/sheet1.xml)的内容举例如下：
                // <worksheet>
                //   <dimension ref="B2:C4" />
                //   <sheetData>
                //     <row r="2" spans="2:3" />
                //     <row r="4" spans="2:3">
                //       <c r="B4" />
                //       <c r="C4" t="s"><v>1</v></c>
                //     </row>
                //   </sheetData>
                // </worksheet>
                // 注意：在该 XML 文件中可能省略某些空行和空单元格，而本方法忽略这些空行和空单元格。
                // 但本方法不忽略 XML 文件中的空行“<row />”和空单元格“<c />”。
                if (!reader.IsStartElement("row")) reader.Read();
                if (!reader.IsStartElement("row")) return null; // 没有可读的行
                List<string> list = new List<string>();
                int index = 0;
                int row = System.Convert.ToInt32(reader.GetAttribute("r"));
                int colNum = System.Convert.ToInt32(reader.GetAttribute("spans").Split(':')[1]);
                string[] rowNames = new string[colNum];
                for (int i = 0; i < colNum; i++)
                {
                    if (i < 26)
                    {
                        rowNames[i] = System.Convert.ToChar('A' + i).ToString() + row.ToString();
                    }
                    else
                    {
                        rowNames[i] = System.Convert.ToChar('A' + i / 26 - 1).ToString() + System.Convert.ToChar('A' + i % 26).ToString() + row.ToString();
                    }
                }

                while (true)
                {
                    reader.Read(); // 执行后(reader)的值: <c> or </row> or (other for <row />)
                    if (!reader.IsStartElement("c")) // 没有可读的单元格
                    {
                        for (int i = index; i < colNum; i++)
                        {
                            list.Add("0");
                        }
                        break;
                    }

                    if (reader.IsEmptyElement)
                    {
                        list.Add("0"); // 空单元格“<c />”
                        index++;
                    }
                    else                                     // “<c><v>1</v></c>”
                    {
                        string attr = reader.GetAttribute("t"); // 如果“<c>”元素的“t”属性不为空，则“<v>”元素的值指向各工作表共享的字符串
                        string r = reader.GetAttribute("r");

                        for (int i = index; i < colNum; i++)
                        {
                            string str = rowNames[i];
                            if (string.Compare(r, str, true) == 0)
                            {
                                break;
                            }

                            index++;
                            list.Add("0");
                        }

                        reader.ReadStartElement("c"); // 执行后(reader)的值: “<c>”元素的第一个子元素
                        if (!reader.IsStartElement("v")) reader.ReadToNextSibling("v"); // 执行后(reader)的值: <v> or <v />

                        index++;
                        list.Add(GetValue(attr, reader.ReadElementString("v"))); // 执行后(reader)的值: </c> or <与<v>同级的元素>
                        if (reader.NodeType != XmlNodeType.EndElement) reader.ReadToNextSibling("v"); // 执行后(reader)的值: </c>
                    }
                }

                return list.ToArray();
            }

            /// <summary>
            /// 根据工作表的范围计算有效行数
            /// </summary>
            /// <param name="dimension">工作表的范围，如：“A1”、“B2:C4”</param>
            /// <returns>有效行数</returns>
            int GetRowCount(string dimension)
            {
                if (string.IsNullOrEmpty(dimension)) return -1;
                string[] ss = dimension.Split(':');
                if (ss.Length == 1) return 1;
                if (ss.Length != 2) return -1;
                return GetRowNumber(ss[1]) - GetRowNumber(ss[0]) + 1;
            }

            /// <summary>
            /// 根据单元格的坐标计算单元格的行号
            /// </summary>
            /// <param name="str">单元格的坐标，如“C4”</param>
            /// <returns>单元格的行号</returns>
            int GetRowNumber(string str)
            {
                int i;
                for (i = 0; i < str.Length; i++) if (char.IsDigit(str, i)) break;
                return int.Parse(str.Substring(i));
            }

            /// <summary>
            /// 给出单元格的值，可能是各工作表共享的字符串
            /// </summary>
            /// <param name="attr">“<c>”元素的“t”属性的值</param>
            /// <param name="value">“<v>”元素的值</param>
            /// <returns>单元格的值</returns>
            string GetValue(string attr, string value)
            {
                if (attr != null)
                {
                    int index;
                    if (!int.TryParse(value, out index)) throw new Exception("共享字符串索引(" + value + ")必须是整数");
                    if (index < 0 || index >= sharedStrings.Length) throw new Exception("共享字符串索引("
                      + index + ")必须在(0)到(" + (sharedStrings.Length - 1) + ")之间");
                    value = sharedStrings[index];
                }
                return value;
            }

            public void Dispose()
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                reader = null;
                stream = null;
            }
        }
    }
}
