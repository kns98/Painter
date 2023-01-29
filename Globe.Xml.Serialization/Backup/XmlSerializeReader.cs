// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlSerializeReader
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System.Xml;

namespace Globe.Xml.Serialization
{
  public class XmlSerializeReader
  {
    private XmlDocument _xmlDocument = new XmlDocument();

    public XmlDocument XmlDocument
    {
      get => this._xmlDocument;
      set => this._xmlDocument = value;
    }

    public object ReadXml(string fileName, SerializableData serializableData)
    {
      this._xmlDocument.Load(fileName);
      try
      {
        this.ReadXml(this._xmlDocument.ChildNodes[1], serializableData);
      }
      catch
      {
        throw new XmlSerializationException((object) this._xmlDocument, serializableData);
      }
      return (object) serializableData;
    }

    protected virtual void ReadXml(XmlNode xmlNode, SerializableData serializableData)
    {
      XmlAttribute attribute1 = xmlNode.Attributes["name"];
      XmlAttribute attribute2 = xmlNode.Attributes["type"];
      XmlAttribute attribute3 = xmlNode.Attributes["assembly"];
      XmlAttribute attribute4 = xmlNode.Attributes["assemblyQualifiedName"];
      string name = xmlNode.Name;
      XmlAttribute attribute5 = xmlNode.Attributes["value"];
      serializableData.TagName = name;
      serializableData.Type = attribute2.Value;
      serializableData.Assembly = attribute3.Value;
      serializableData.AssemblyQualifiedName = attribute4.Value;
      serializableData.FieldName = attribute1.Value;
      serializableData.Value = attribute5.Value;
      foreach (XmlNode childNode in xmlNode.ChildNodes)
      {
        SerializableData serializableData1 = new SerializableData();
        serializableData.SerializableDataCollection.Add(serializableData1);
        this.ReadXml(childNode, serializableData1);
      }
    }
  }
}
