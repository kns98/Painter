// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.Serializer
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

namespace Globe.Xml.Serialization
{
  public class Serializer
  {
    private XmlSerializeWriter _serializeWriter = new XmlSerializeWriter();
    private XmlSerializeReader _serializeReader = new XmlSerializeReader();
    private SerializableDataComposer _composer = new SerializableDataComposer();
    private SerializableDataDecomposer _decomposer = new SerializableDataDecomposer();

    public XmlSerializeWriter SerializeWriter
    {
      get => this._serializeWriter;
      set => this._serializeWriter = value;
    }

    public XmlSerializeReader SerializeReader
    {
      get => this._serializeReader;
      set => this._serializeReader = value;
    }

    public SerializableDataComposer Composer
    {
      get => this._composer;
      set => this._composer = value;
    }

    public SerializableDataDecomposer Decomposer
    {
      get => this._decomposer;
      set => this._decomposer = value;
    }

    public virtual void Reset()
    {
      this._composer.SerializableDataInfo.Reset();
      this._decomposer.SerializableDataInfo.Reset();
      this._serializeReader.XmlDocument.RemoveAll();
      this._serializeWriter.XmlDocument.RemoveAll();
    }

    public virtual void Serialize(string fileName, object data)
    {
      this._decomposer.Decompose(data);
      this._serializeWriter.WriteXml(fileName, this._decomposer.SerializableDataInfo);
    }

    public virtual object Deserialize(string fileName)
    {
      this._serializeReader.ReadXml(fileName, this._decomposer.SerializableDataInfo);
      return this._composer.Compose(this._decomposer.SerializableDataInfo);
    }
  }
}
