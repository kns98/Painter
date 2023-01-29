// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlSerializationException
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Reflection;

namespace Globe.Xml.Serialization
{
  public class XmlSerializationException : ApplicationException
  {
    private object _data;
    private SerializableData _serializableData;
    private PropertyInfo _propertyInfo;
    private FieldInfo _fieldInfo;

    public XmlSerializationException(object data, SerializableData serializableData)
    {
      this._data = data;
      this._serializableData = serializableData;
    }

    public XmlSerializationException(
      object data,
      SerializableData serializableData,
      PropertyInfo propertyInfo,
      FieldInfo fieldInfo)
    {
      this._data = data;
      this._serializableData = serializableData;
      this._propertyInfo = propertyInfo;
      this._fieldInfo = fieldInfo;
    }

    public object DataInfo => this._data;

    public SerializableData SerializableDataInfo => this._serializableData;

    public PropertyInfo Property => this._propertyInfo;

    public FieldInfo Field => this._fieldInfo;

    public override string Message
    {
      get
      {
        string str1 = base.Message + (this._data != null ? this.GetFormattedText(Resource.Data) + this._data.ToString() : this.GetFormattedText(Resource.NoData));
        string str2;
        if (this._serializableData == null)
          str2 = this.GetFormattedText(Resource.NoSerializableData);
        else
          str2 = this.GetFormattedText(Resource.SerializableData) + this.GetFormattedText(Resource.Assembly) + this._serializableData.Assembly + this.GetFormattedText(Resource.AssemblyQualifiedName) + this._serializableData.AssemblyQualifiedName + this.GetFormattedText(Resource.FieldName) + this._serializableData.FieldName + this.GetFormattedText(Resource.TagName) + this._serializableData.TagName + this.GetFormattedText(Resource.Type) + this._serializableData.Type + this.GetFormattedText(Resource.Value) + this._serializableData.Value + this.GetFormattedText(Resource.SerializableDataCollectionCount) + this._serializableData.SerializableDataCollection.Count.ToString();
        string str3 = str1 + str2;
        string str4 = string.Empty;
        if (this._propertyInfo != null)
          str4 = Resource.PropertyInfo + " " + this._propertyInfo.Name + ": " + (this._propertyInfo.CanRead ? Resource.Readeable : Resource.NoReadeable + "\n") + Resource.PropertyInfo + " " + this._propertyInfo.Name + ": " + (this._propertyInfo.CanWrite ? Resource.Writeable : Resource.NoWriteable + "\n");
        string str5 = string.Empty;
        if (this._fieldInfo != null)
          str5 = Resource.FieldInfo + " " + this._fieldInfo.Name + ": " + (this._fieldInfo.IsLiteral ? Resource.Constant : Resource.NoConstant + "\n");
        return str3 + str4 + str5;
      }
    }

    protected string GetFormattedText(string text) => "\n" + text + ": ";
  }
}
