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
        /// Execl 2007 �ļ��еĹ�����
        /// </summary>
        public sealed class Sheet : IDisposable
        {
            string[] sharedStrings; // ������������ַ���
            Stream stream;          // ���ڶ�ȡ����������ļ���
            XmlReader reader;       // ���ڶ�ȡ��������� XML ���ݶ�ȡ��
            string dimension;       // ��������ķ�Χ���磺��A1������B2:C4��
            int rowCount;           // �����������Ч����
            string name;            // �������������

            public string Dimension { get { return dimension; } }
            public int RowCount { get { return rowCount; } }
            public string Name { get { return name; } }

            /// <summary>
            /// ��ʾ Excel 2007 �ļ��еĹ��������Ĺ��캯��
            /// </summary>
            /// <param name="name">�������������</param>
            /// <param name="fileName">������� XML �ļ���</param>
            /// <param name="sharedStrings">������������ַ���</param>
            /// <param name="fileStream">��ʾ���� Excel 2007 �ļ�����</param>
            public Sheet(string name, string fileName, string[] sharedStrings, Stream fileStream)
            {
                this.name = name;
                this.sharedStrings = sharedStrings;
                stream = Zip.GetZipInputStream(fileStream, "xl/" + fileName);
                reader = XmlReader.Create(stream);
                while (reader.Read()) if (reader.IsStartElement("dimension")) break;
                dimension = reader.GetAttribute("ref"); // ��������ķ�Χ��<dimension ref="B2:C4" />
                rowCount = GetRowCount(dimension); // ���ݹ�����ķ�Χ������Ч����
                if (rowCount < 3)
                    return;

                while (reader.Read()) if (reader.IsStartElement("sheetData")) break;
            }

            /// <summary>
            /// ��ȡ�����������һ��
            /// </summary>
            /// <returns>��ȡ���еĸ��ֶε����ݡ�����Ѿ�û�пɶ������򷵻� null��</returns>
            public string[] ReadRow()
            {
                // ��ʾ������� XML �ļ�(�磺xl/worksheets/sheet1.xml)�����ݾ������£�
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
                // ע�⣺�ڸ� XML �ļ��п���ʡ��ĳЩ���кͿյ�Ԫ�񣬶�������������Щ���кͿյ�Ԫ��
                // �������������� XML �ļ��еĿ��С�<row />���Ϳյ�Ԫ��<c />����
                if (!reader.IsStartElement("row")) reader.Read();
                if (!reader.IsStartElement("row")) return null; // û�пɶ�����
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
                    reader.Read(); // ִ�к�(reader)��ֵ: <c> or </row> or (other for <row />)
                    if (!reader.IsStartElement("c")) // û�пɶ��ĵ�Ԫ��
                    {
                        for (int i = index; i < colNum; i++)
                        {
                            list.Add("0");
                        }
                        break;
                    }

                    if (reader.IsEmptyElement)
                    {
                        list.Add("0"); // �յ�Ԫ��<c />��
                        index++;
                    }
                    else                                     // ��<c><v>1</v></c>��
                    {
                        string attr = reader.GetAttribute("t"); // �����<c>��Ԫ�صġ�t�����Բ�Ϊ�գ���<v>��Ԫ�ص�ֵָ�������������ַ���
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

                        reader.ReadStartElement("c"); // ִ�к�(reader)��ֵ: ��<c>��Ԫ�صĵ�һ����Ԫ��
                        if (!reader.IsStartElement("v")) reader.ReadToNextSibling("v"); // ִ�к�(reader)��ֵ: <v> or <v />

                        index++;
                        list.Add(GetValue(attr, reader.ReadElementString("v"))); // ִ�к�(reader)��ֵ: </c> or <��<v>ͬ����Ԫ��>
                        if (reader.NodeType != XmlNodeType.EndElement) reader.ReadToNextSibling("v"); // ִ�к�(reader)��ֵ: </c>
                    }
                }

                return list.ToArray();
            }

            /// <summary>
            /// ���ݹ�����ķ�Χ������Ч����
            /// </summary>
            /// <param name="dimension">������ķ�Χ���磺��A1������B2:C4��</param>
            /// <returns>��Ч����</returns>
            int GetRowCount(string dimension)
            {
                if (string.IsNullOrEmpty(dimension)) return -1;
                string[] ss = dimension.Split(':');
                if (ss.Length == 1) return 1;
                if (ss.Length != 2) return -1;
                return GetRowNumber(ss[1]) - GetRowNumber(ss[0]) + 1;
            }

            /// <summary>
            /// ���ݵ�Ԫ���������㵥Ԫ����к�
            /// </summary>
            /// <param name="str">��Ԫ������꣬�硰C4��</param>
            /// <returns>��Ԫ����к�</returns>
            int GetRowNumber(string str)
            {
                int i;
                for (i = 0; i < str.Length; i++) if (char.IsDigit(str, i)) break;
                return int.Parse(str.Substring(i));
            }

            /// <summary>
            /// ������Ԫ���ֵ�������Ǹ�����������ַ���
            /// </summary>
            /// <param name="attr">��<c>��Ԫ�صġ�t�����Ե�ֵ</param>
            /// <param name="value">��<v>��Ԫ�ص�ֵ</param>
            /// <returns>��Ԫ���ֵ</returns>
            string GetValue(string attr, string value)
            {
                if (attr != null)
                {
                    int index;
                    if (!int.TryParse(value, out index)) throw new Exception("�����ַ�������(" + value + ")����������");
                    if (index < 0 || index >= sharedStrings.Length) throw new Exception("�����ַ�������("
                      + index + ")������(0)��(" + (sharedStrings.Length - 1) + ")֮��");
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
