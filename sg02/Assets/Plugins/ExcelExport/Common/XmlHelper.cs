using System;
using System.Xml;

namespace Skyiv.Ben.Common
{
  static class XmlHelper
  {
    public static XmlElement GetElementById(XmlDocument xmlDocument, string id)
    {
      foreach (XmlElement elm in xmlDocument.DocumentElement.ChildNodes)
      {
        XmlAttribute attr = elm.Attributes["Id"];
        if (attr != null && attr.Value == id) return elm;
      }
      throw new ArgumentException("xml �ĵ����޴˱�ʶ: " + id) ;
    }
  }
}
