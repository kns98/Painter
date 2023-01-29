// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.SerializableDataComposer
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace Globe.Xml.Serialization
{
  public class SerializableDataComposer : SerializableDataController
  {
    public virtual object Compose(SerializableData serializableData)
    {
      object data = this.CreateObject(serializableData);
      this.FillObject(ref data, serializableData);
      return data;
    }

    protected virtual object CreateObject(SerializableData serializableData)
    {
      object obj = Activator.CreateInstance(this.GetType(serializableData) ?? throw new XmlSerializationException((object) null, serializableData), (object[]) null);
      if (obj is ObjectHandle objectHandle)
        obj = objectHandle.Unwrap();
      return obj;
    }

    protected virtual void FillObject(ref object data, SerializableData serializableData)
    {
      foreach (SerializableData serializableData1 in serializableData.SerializableDataCollection)
        this.FillObjectField(data, data.GetType(), serializableData1);
    }

    protected virtual void FillObjectField(
      object data,
      Type type,
      SerializableData serializableData)
    {
      object newObject = this.GetNewObject(serializableData);
      this.Filler(data, type, new object[1]{ newObject }, serializableData);
    }

    protected virtual object GetNewObject(SerializableData serializableData)
    {
      Type type = this.GetType(serializableData);
      return !type.IsArray ? (!this.IsCollection(type) ? this.GetObject(serializableData) : this.CreateCollection(serializableData)) : this.CreateArray(serializableData);
    }

    protected virtual void Filler(
      object dataToFill,
      Type type,
      object[] parameters,
      SerializableData serializableData)
    {
      XmlClassSerializable serializableAttribute = this.GetXmlClassSerializableAttribute(type);
      bool flag = this.IsDeepSerializable(type);
      BindingFlags flags = this.GetFlags(type, serializableAttribute);
      PropertyInfo property = this.GetProperty(type, serializableData.FieldName, flags);
      FieldInfo field = this.GetField(type, serializableData.FieldName, flags);
      try
      {
        if (property != null && property.CanWrite || field != null && !field.IsLiteral)
          type.InvokeMember(serializableData.FieldName, flags, (Binder) null, dataToFill, parameters);
        else if (!type.BaseType.Equals(typeof (object)) && type.BaseType != null && flag)
        {
          this.FillObjectField(dataToFill, type.BaseType, serializableData);
        }
        else
        {
          if (!this.IsCollection(type) || this.IsArray(type))
            return;
          this.InvokeAddingMethod(dataToFill, parameters);
        }
      }
      catch
      {
        throw new XmlSerializationException(dataToFill, serializableData, property, field);
      }
    }

    protected virtual object GetObject(SerializableData serializableData)
    {
      object data1 = (object) null;
      int typeCode = (int) Type.GetTypeCode(this.GetType(serializableData));
      object data2;
      if (this.IsCreateableSerializableData(serializableData))
      {
        data2 = this.CreateObject(serializableData);
      }
      else
      {
        try
        {
          data2 = this.ConvertType(serializableData);
        }
        catch
        {
          throw new XmlSerializationException(data1, serializableData);
        }
      }
      this.FillObject(ref data2, serializableData);
      return data2;
    }

    protected virtual object CreateArray(SerializableData serializableData)
    {
      object data = (object) null;
      try
      {
        Type type = this.GetType(serializableData.SerializableDataCollection[0]);
        Array instance = Array.CreateInstance(type, serializableData.SerializableDataCollection.Count);
        for (int index = 0; index < serializableData.SerializableDataCollection.Count; ++index)
        {
          object obj = this.IsBaseType(type) ? this.ConvertType(serializableData.SerializableDataCollection[index]) : this.Compose(serializableData.SerializableDataCollection[index]);
          instance.SetValue(obj, index);
        }
        data = (object) instance;
        this.FillObject(ref data, serializableData);
      }
      catch
      {
        throw new XmlSerializationException(data, serializableData);
      }
      return data;
    }

    protected virtual object CreateCollection(SerializableData serializableData)
    {
      object dataToFill = this.CreateObject(serializableData);
      dataToFill.GetType();
      foreach (SerializableData serializableData1 in serializableData.SerializableDataCollection)
      {
        object obj = this.Compose(serializableData1);
        this.Filler(dataToFill, dataToFill.GetType(), new object[1]
        {
          obj
        }, serializableData1);
      }
      return dataToFill;
    }

    protected virtual void InvokeAddingMethod(object invoker, object[] parameters)
    {
      MethodInfo method = invoker.GetType().GetMethod("Add");
      if (method == null)
        throw new XmlSerializationException(invoker, (SerializableData) null);
      try
      {
        method.Invoke(invoker, parameters);
      }
      catch
      {
        throw new XmlSerializationException(invoker, (SerializableData) null);
      }
    }

    protected virtual bool IsCreateableSerializableData(SerializableData serializableData)
    {
      Type type = this.GetType(serializableData);
      TypeCode typeCode = Type.GetTypeCode(type);
      ConstructorInfo[] constructors = type.GetConstructors();
      if (constructors.Length == 0 && !type.IsValueType)
        return false;
      foreach (MethodBase methodBase in constructors)
      {
        if (methodBase.GetParameters().Length == 0)
          return true;
      }
      return typeCode == TypeCode.Object;
    }

    protected virtual object ConvertType(SerializableData serializableData)
    {
      object obj = (object) null;
      switch (Type.GetTypeCode(this.GetType(serializableData)))
      {
        case TypeCode.Empty:
          obj = !(serializableData.Value == string.Empty) ? (object) Convert.ToBoolean(serializableData.Value) : (object) null;
          break;
        case TypeCode.DBNull:
          obj = !(serializableData.Value == string.Empty) ? (object) Convert.ToBoolean(serializableData.Value) : (object) null;
          break;
        case TypeCode.Boolean:
          obj = !(serializableData.Value == string.Empty) ? (object) bool.Parse(serializableData.Value) : (object) false;
          break;
        case TypeCode.Char:
          obj = !(serializableData.Value == string.Empty) ? (object) char.Parse(serializableData.Value) : (object) char.MinValue;
          break;
        case TypeCode.SByte:
          obj = !(serializableData.Value == string.Empty) ? (object) sbyte.Parse(serializableData.Value) : (object) sbyte.MinValue;
          break;
        case TypeCode.Byte:
          obj = !(serializableData.Value == string.Empty) ? (object) byte.Parse(serializableData.Value) : (object) 0;
          break;
        case TypeCode.Int16:
          obj = !(serializableData.Value == string.Empty) ? (object) short.Parse(serializableData.Value) : (object) short.MinValue;
          break;
        case TypeCode.UInt16:
          obj = !(serializableData.Value == string.Empty) ? (object) ushort.Parse(serializableData.Value) : (object) (ushort) 0;
          break;
        case TypeCode.Int32:
          obj = !(serializableData.Value == string.Empty) ? (object) int.Parse(serializableData.Value) : (object) int.MinValue;
          break;
        case TypeCode.UInt32:
          obj = !(serializableData.Value == string.Empty) ? (object) uint.Parse(serializableData.Value) : (object) 0U;
          break;
        case TypeCode.Int64:
          obj = !(serializableData.Value == string.Empty) ? (object) long.Parse(serializableData.Value) : (object) long.MinValue;
          break;
        case TypeCode.UInt64:
          obj = !(serializableData.Value == string.Empty) ? (object) ulong.Parse(serializableData.Value) : (object) 0UL;
          break;
        case TypeCode.Single:
          obj = !(serializableData.Value == string.Empty) ? (object) float.Parse(serializableData.Value) : (object) float.MinValue;
          break;
        case TypeCode.Double:
          obj = !(serializableData.Value == string.Empty) ? (object) double.Parse(serializableData.Value) : (object) double.MinValue;
          break;
        case TypeCode.Decimal:
          obj = !(serializableData.Value == string.Empty) ? (object) Decimal.Parse(serializableData.Value) : (object) Decimal.MinValue;
          break;
        case TypeCode.DateTime:
          obj = !(serializableData.Value == string.Empty) ? (object) DateTime.Parse(serializableData.Value) : (object) DateTime.Now;
          break;
        case TypeCode.String:
          obj = (object) serializableData.Value;
          break;
      }
      return obj;
    }

    protected override BindingFlags GetFlags(Type type, XmlClassSerializable attribute) => base.GetFlags(type, attribute) | BindingFlags.SetField | BindingFlags.SetProperty;
  }
}
