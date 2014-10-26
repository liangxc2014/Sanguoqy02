using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;

public class XMLLoader<T> where T : class
{
    private const BindingFlags FieldBindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.SetField;

	protected Dictionary<object, object> m_data;

    private string m_xmlName;

    private string m_keyName = "ID";

	public Dictionary<object, object> Data { get { return m_data; } }

    public XMLLoader(string XmlName, string keyName)
    {
        m_keyName = keyName;
        LoadXML(XmlName);
    }

	public XMLLoader(string XmlName)
	{
        LoadXML(XmlName);
	}

    public void LoadXML(string XmlName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        m_xmlName = XmlName;
        TextAsset textAsset = (TextAsset)ResourcesManager.Instance.Load(XmlName);
        if (textAsset == null)
        {
            Debug.LogError("xml file is not exist! File:" + XmlName);
            return;
        }
        try
        {
            xmlDoc.LoadXml(textAsset.text.ToString().Trim());
        }
        catch (XmlException e)
        {
            Debug.LogError("Function:XMLLoader,File:" + XmlName + ",message:" + e.Message);
            return;
        }

        m_data = new Dictionary<object, object>();

        if (xmlDoc != null)
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.ChildNodes;
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNode node = list[i];
                    if (node.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }
                    XmlElement element = (XmlElement)node;

                    object id;
                    var info = ParseXmlParamsValue(typeof(T), element, out id);
                    if (m_data.ContainsKey(id))
                    {
                        Debug.LogError("XMLLoader: " + XmlName + ",重复ID:" + id);
                        continue;
                    }

                    m_data.Add(id, info);
                }
            }
        }
    }

	public T GetInfoById(object id)
	{
		if (m_data.ContainsKey(id))
		{
			return (T)m_data[id];
		}
		else
		{
            string error = string.Format("The key is not found,name={0}, key={1}", m_xmlName, id);
            Debug.LogError(error);
			return null;
		}
	}

	private object ParseXmlParamsValue(Type type, XmlElement element, out object id)
	{
		object obj = Activator.CreateInstance(type);
        id = 0;

        // 公共属性个数为0, 一般为基础类型
        if (type.IsPrimitive || type == typeof(string))
        {
            string text = element.InnerText;
            if (text != "")
            {
                obj = Convert.ChangeType(text, type);
            }

            return obj;
        }

        IDictionary<string, FieldInfo> fields = ReflectionFields(obj.GetType());
        IEnumerator<FieldInfo> valueEnumerator = fields.Values.GetEnumerator();
        while (valueEnumerator.MoveNext())
        {
            FieldInfo field = valueEnumerator.Current;
            if (null == field) continue;
            
			try
			{
                object value = null;

				if(field.FieldType.IsArray)
				{
                    XmlNodeList childList = element.GetElementsByTagName(field.Name);

                    value = Array.CreateInstance(field.FieldType.GetElementType(), childList.Count);
                    object temp;
                    for (int i = 0; i < childList.Count; i++)
                    {
                        object childObj = ParseXmlParamsValue(field.FieldType.GetElementType(), (XmlElement)childList[i], out temp);
                        ((Array)value).SetValue(childObj, i);
                    }
				}
                else if (!element.HasAttribute(field.Name))
                {
                    if (element.HasChildNodes && element[field.Name] != null)
                    {
                        object temp;
                        XmlElement childXML = element[field.Name];
                        value = ParseXmlParamsValue(field.FieldType, childXML, out temp);
                    }
                    else
                    {
                        string text = element.InnerText;
                        if (text != "")
                        {
                            value = Convert.ChangeType(text, field.FieldType);
                        }
                    }
                }
                else
                {
                    value = Convert.ChangeType(element.GetAttribute(field.Name), field.FieldType);
                }
				
				field.SetValue(obj, value);
				
				if (field.Name == m_keyName)
					id = value;
				
			}
			catch (Exception ex)
			{
                Debug.LogError(string.Format("ParseXmlParamsValue is failed! xml={0}, prepertyName={1}, value={2}, targetType={3}, errorDetail:{4}", m_xmlName, field.Name, element.GetAttribute(field.Name), field.FieldType, ex.StackTrace));
			}
        }
		
		return obj;
	}

    /// <summary>
    /// 找出一个类型的属性;
    /// </summary>
    public IDictionary<string, FieldInfo> ReflectionFields(Type t)
    {
        FieldInfo[] fields = t.GetFields(FieldBindingFlags);
        IDictionary<string, FieldInfo> map = new Dictionary<string, FieldInfo>(fields.Length);
        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo f = fields[i];
            string name = f.Name;
            int pos;
            if (name[0] == '<' && (pos = name.IndexOf('>')) > 1)
                name = name.Substring(1, pos - 1); // Auto-Property (\<.+\>) <ab>
            map[name] = f;
        }

        return map;
    }
}
