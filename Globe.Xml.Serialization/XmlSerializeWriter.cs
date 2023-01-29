// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlSerializeWriter
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System.Text.RegularExpressions;
using System.Xml;

namespace Globe.Xml.Serialization
{
  public class XmlSerializeWriter
  {
    private XmlDocument _xmlDocument = new XmlDocument();

    public XmlDocument XmlDocument
    {
      get => this._xmlDocument;
      set => this._xmlDocument = value;
    }

    public void WriteXml(string fileName, SerializableData serializableData)
    {
      this.CreateXmlDeclaration();
      this.WriteXml((XmlNode) this._xmlDocument, serializableData);
      this._xmlDocument.Save(fileName);
    }

    protected virtual void WriteXml(XmlNode xmlNode, SerializableData serializableData)
    {
      XmlElement element;
      try
      {
        element = this._xmlDocument.CreateElement(this.GetFormattedText(serializableData.TagName));
      }
      catch
      {
        throw new XmlSerializationException((object) this._xmlDocument, serializableData);
      }
      element.Attributes.Append(this.CreateXmlAttribute("value", serializableData.Value));
      element.Attributes.Append(this.CreateXmlAttribute("type", serializableData.Type));
      element.Attributes.Append(this.CreateXmlAttribute("assembly", serializableData.Assembly));
      element.Attributes.Append(this.CreateXmlAttribute("assemblyQualifiedName", serializableData.AssemblyQualifiedName));
      element.Attributes.Append(this.CreateXmlAttribute("name", serializableData.FieldName));
      xmlNode.AppendChild((XmlNode) element);
      foreach (SerializableData serializableData1 in serializableData.SerializableDataCollection)
        this.WriteXml((XmlNode) element, serializableData1);
    }

    protected virtual void CreateXmlDeclaration() => this._xmlDocument.AppendChild((XmlNode) this._xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "no"));

    protected XmlAttribute CreateXmlAttribute(string name, string value)
    {
      XmlAttribute attribute = this._xmlDocument.CreateAttribute(name);
      attribute.Value = value;
      return attribute;
    }

    protected virtual string GetFormattedText(string text)
    {
      foreach (Match match in new Regex("\\W").Matches(text))
        text = text.Replace(match.Value, string.Empty);
      return text;
    }
  }
}
