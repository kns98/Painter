// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.SerializableDataDecomposer
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Globe.Xml.Serialization
{
  public class SerializableDataDecomposer : SerializableDataController
  {
    public virtual void Decompose(object data)
    {
      if (data == null)
        throw new XmlSerializationException(data, (SerializableData) null);
      this.FindXmlSerializableClassAttribute(data, this.SerializableDataInfo);
    }

    protected virtual bool FindXmlSerializableClassAttribute(
      object data,
      SerializableData serializableData)
    {
      Type type = data.GetType();
      XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(type);
      if (serializableAttribute == null)
        return false;
      this.CreateSerializableData(data, serializableData);
      Collection<DataMember> dataMembers = new Collection<DataMember>();
      this.FillDataMembers(type, dataMembers, true, serializableAttribute.Deep, this.GetFlags(type, serializableAttribute));
      this.FindClassFields(data, serializableData, dataMembers);
      return true;
    }

    protected virtual bool FillCollection(object data, SerializableData serializableData)
    {
      if (!this.IsCollection(data))
        return false;
      foreach (object data1 in (IEnumerable) (data as ICollection))
      {
        SerializableData serializableData1 = new SerializableData();
        XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(data1.GetType());
        if (!this.FindXmlSerializableClassAttribute(data1, serializableData1))
        {
          Type type = data1.GetType();
          Collection<DataMember> dataMembers = new Collection<DataMember>();
          this.FillDataMembers(type, dataMembers, false, this.IsDeepSerializable(type), this.GetFlags(type, serializableAttribute));
          if (dataMembers.Count != 0)
          {
            this.CreateSerializableData(data1, serializableData1);
            this.FindClassFields(data1, serializableData1, dataMembers);
          }
          else
            continue;
        }
        serializableData.SerializableDataCollection.Add(serializableData1);
      }
      return true;
    }

    protected virtual void FillDataMembers(
      Type type,
      Collection<DataMember> dataMembers,
      bool custom,
      bool deep,
      BindingFlags flags)
    {
      type.FindMembers(MemberTypes.Field | MemberTypes.Property, flags, custom ? new MemberFilter(this.CustomSearching) : new MemberFilter(this.Searching), (object) dataMembers);
      if (type.BaseType.Equals(typeof (object)) || type.BaseType.Equals(typeof (ValueType)) || type.BaseType == null || !deep)
        return;
      this.FillDataMembers(type.BaseType, dataMembers, custom, deep, flags);
    }

    protected virtual bool FillDataMembers(
      MemberInfo memberInfo,
      Collection<DataMember> dataMembers)
    {
      if (memberInfo.MemberType == MemberTypes.Field)
      {
        FieldInfo fieldInfo = (FieldInfo) memberInfo;
        DataMember dataMember = new DataMember(memberInfo, fieldInfo.FieldType);
        dataMembers.Add(dataMember);
        return true;
      }
      if (memberInfo.MemberType != MemberTypes.Property)
        return false;
      PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
      DataMember dataMember1 = new DataMember(memberInfo, propertyInfo.PropertyType);
      dataMembers.Add(dataMember1);
      return true;
    }

    protected virtual bool CustomSearching(MemberInfo memberInfo, object dataMembersFinder)
    {
      if (!(dataMembersFinder is Collection<DataMember> dataMembers) || memberInfo.GetCustomAttributes(typeof (XmlFieldSerializable), true).GetLength(0) != 1)
        return false;
      foreach (DataMember dataMember in dataMembers)
      {
        if (dataMember.DataInfo.ToString() == memberInfo.ToString())
          return false;
      }
      return this.FillDataMembers(memberInfo, dataMembers);
    }

    protected virtual bool Searching(MemberInfo memberInfo, object dataMembersFinder) => dataMembersFinder is Collection<DataMember> dataMembers && this.FillDataMembers(memberInfo, dataMembers);

    protected virtual void FindClassFields(
      object data,
      SerializableData serializableData,
      Collection<DataMember> dataMembers)
    {
      Type type = data.GetType();
      for (int index = 0; index < dataMembers.Count; ++index)
      {
        SerializableData serializableData1 = new SerializableData();
        if (this.GetXmlClassSerializableAttribute(dataMembers[index].TypeInfo) != null)
        {
          object data1 = type.InvokeMember(dataMembers[index].DataInfo.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.GetProperty, (Binder) null, data, (object[]) null);
          serializableData1.FieldName = dataMembers[index].DataInfo.Name;
          if (!this.FindXmlSerializableClassAttribute(data1, serializableData1))
            continue;
        }
        else
        {
          serializableData1 = this.CreateSerializableData(data, dataMembers[index]);
          if (serializableData1 == null)
            continue;
        }
        serializableData.SerializableDataCollection.Add(serializableData1);
      }
      this.FillCollection(data, serializableData);
    }

    protected virtual SerializableData CreateSerializableData(object data, DataMember dataMember)
    {
      bool flag = true;
      XmlFieldSerializable serializableAttribute = this.GetXmlFieldSerializableAttribute(dataMember.DataInfo);
      if (serializableAttribute == null || serializableAttribute.TagName == string.Empty)
        flag = false;
      SerializableData serializableData = new SerializableData();
      BindingFlags flags = this.GetFlags(data.GetType());
      PropertyInfo property = this.GetProperty(dataMember.DataInfo.ReflectedType, dataMember.DataInfo.Name, flags);
      object data1;
      if (property != null && property.CanRead)
      {
        data1 = property.GetGetMethod(true).Invoke(data, (object[]) null);
      }
      else
      {
        FieldInfo field = this.GetField(dataMember.DataInfo.ReflectedType, dataMember.DataInfo.Name, flags);
        if (field == null)
          return (SerializableData) null;
        data1 = field.GetValue(data);
      }
      serializableData.Type = dataMember.TypeInfo.FullName;
      serializableData.Assembly = dataMember.TypeInfo.Assembly.ToString();
      serializableData.AssemblyQualifiedName = dataMember.TypeInfo.AssemblyQualifiedName;
      serializableData.Value = data1 != null ? data1.ToString() : string.Empty;
      serializableData.TagName = flag ? serializableAttribute.TagName : dataMember.TypeInfo.Name;
      serializableData.FieldName = dataMember.DataInfo.Name;
      this.FillCollection(data1, serializableData);
      return serializableData;
    }

    protected virtual void CreateSerializableData(object data, SerializableData serializableData)
    {
      Type type = data.GetType();
      bool flag = true;
      XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(type);
      if (serializableAttribute == null || serializableAttribute.TagName == string.Empty)
        flag = false;
      serializableData.Type = type.FullName;
      serializableData.Assembly = type.Assembly.ToString();
      serializableData.AssemblyQualifiedName = type.AssemblyQualifiedName;
      serializableData.Value = flag ? string.Empty : data.ToString();
      serializableData.TagName = flag ? serializableAttribute.TagName : type.Name;
    }

    protected override BindingFlags GetFlags(Type type, XmlClassSerializable attribute) => base.GetFlags(type, attribute) | BindingFlags.GetField | BindingFlags.GetProperty;
  }
}
