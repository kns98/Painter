// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.SerializableData
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System.Collections.ObjectModel;

namespace Globe.Xml.Serialization
{
  public class SerializableData
  {
    private string _fieldName = string.Empty;
    private string _type = string.Empty;
    private string _assembly = string.Empty;
    private string _assemblyQualifiedName = string.Empty;
    private string _value = string.Empty;
    private string _tagName = string.Empty;
    private Collection<SerializableData> _serializableDataCollection = new Collection<SerializableData>();

    public string FieldName
    {
      get => this._fieldName;
      set => this._fieldName = value;
    }

    public string Type
    {
      get => this._type;
      set => this._type = value;
    }

    public string Assembly
    {
      get => this._assembly;
      set => this._assembly = value;
    }

    public string AssemblyQualifiedName
    {
      get => this._assemblyQualifiedName;
      set => this._assemblyQualifiedName = value;
    }

    public string Value
    {
      get => this._value;
      set => this._value = value;
    }

    public string TagName
    {
      get => this._tagName;
      set => this._tagName = value;
    }

    public Collection<SerializableData> SerializableDataCollection => this._serializableDataCollection;

    public virtual void Reset()
    {
      this.FieldName = string.Empty;
      this.TagName = string.Empty;
      this.Assembly = string.Empty;
      this.AssemblyQualifiedName = string.Empty;
      this.Type = string.Empty;
      this.Value = string.Empty;
      this.SerializableDataCollection.Clear();
    }
  }
}
