// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.SerializableDataController
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Collections;
using System.Reflection;

namespace Globe.Xml.Serialization
{
  public abstract class SerializableDataController
  {
    private SerializableData _serializableDataInfo = new SerializableData();

    public SerializableData SerializableDataInfo => this._serializableDataInfo;

    protected XmlClassSerializable GetXmlClassSerializableAttribute(Type type)
    {
      object[] customAttributes = type.GetCustomAttributes(typeof (XmlClassSerializable), true);
      if (customAttributes.GetLength(0) != 1)
        return (XmlClassSerializable) null;
      ConstructorInfo[] constructors = type.GetConstructors();
      if (constructors.Length == 0 && !type.IsValueType)
        return (XmlClassSerializable) null;
      foreach (MethodBase methodBase in constructors)
      {
        if (methodBase.GetParameters().Length == 0)
          return customAttributes[0] as XmlClassSerializable;
      }
      return customAttributes[0] as XmlClassSerializable;
    }

    protected XmlFieldSerializable GetXmlFieldSerializableAttribute(Type type)
    {
      object[] customAttributes = type.GetCustomAttributes(typeof (XmlFieldSerializable), true);
      return customAttributes.GetLength(0) != 1 ? (XmlFieldSerializable) null : customAttributes[0] as XmlFieldSerializable;
    }

    protected XmlFieldSerializable GetXmlFieldSerializableAttribute(MemberInfo memberInfo)
    {
      object[] customAttributes = memberInfo.GetCustomAttributes(typeof (XmlFieldSerializable), true);
      return customAttributes.GetLength(0) != 1 ? (XmlFieldSerializable) null : customAttributes[0] as XmlFieldSerializable;
    }

    protected bool IsCollection(object data) => data is ICollection;

    protected bool IsCollection(Type type) => type != null && type.GetInterface("System.Collections.ICollection") != null;

    protected bool IsArray(Type type)
    {
      if (type == null)
        return false;
      return type.Equals(typeof (Array)) || this.IsArray(type.BaseType);
    }

    protected PropertyInfo GetProperty(Type type, string name, BindingFlags flags)
    {
      foreach (MemberInfo member in type.FindMembers(MemberTypes.Property, flags, (MemberFilter) null, (object) null))
      {
        if (member.Name == name)
          return member as PropertyInfo;
      }
      return (PropertyInfo) null;
    }

    protected FieldInfo GetField(Type type, string name, BindingFlags flags)
    {
      foreach (MemberInfo member in type.FindMembers(MemberTypes.Field, flags, (MemberFilter) null, (object) null))
      {
        if (member.Name == name)
          return member as FieldInfo;
      }
      return (FieldInfo) null;
    }

    protected Type GetType(SerializableData serializableData) => Type.GetType(serializableData.AssemblyQualifiedName);

    protected virtual BindingFlags GetFlags(Type type, XmlClassSerializable attribute)
    {
      bool flag = this.IsDeepSerializable(type);
      BindingFlags flags = attribute == null || attribute.Flags == BindingFlags.Default ? BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic : attribute.Flags;
      if (!this.IsBaseType(type) && (attribute == null || attribute.Flags == BindingFlags.Default))
        flags |= BindingFlags.Instance;
      else if (this.IsBaseType(type))
        flags = BindingFlags.Static | BindingFlags.Public;
      if (attribute == null || attribute.Flags == BindingFlags.Default)
      {
        if (!flag)
          flags |= BindingFlags.DeclaredOnly;
        else
          flags |= BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
      }
      return flags;
    }

    protected virtual BindingFlags GetFlags(Type type)
    {
      XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(type);
      return this.GetFlags(type, serializableAttribute);
    }

    protected virtual bool IsDeepSerializable(Type type)
    {
      XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(type);
      return serializableAttribute != null && serializableAttribute.Deep;
    }

    protected virtual bool IsBaseType(Type type)
    {
      if (type == null)
        return true;
      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Empty:
        case TypeCode.DBNull:
        case TypeCode.Boolean:
        case TypeCode.Char:
        case TypeCode.SByte:
        case TypeCode.Byte:
        case TypeCode.Int16:
        case TypeCode.UInt16:
        case TypeCode.Int32:
        case TypeCode.UInt32:
        case TypeCode.Int64:
        case TypeCode.UInt64:
        case TypeCode.Single:
        case TypeCode.Double:
        case TypeCode.Decimal:
        case TypeCode.DateTime:
        case TypeCode.String:
          return true;
        default:
          return false;
      }
    }
  }
}
