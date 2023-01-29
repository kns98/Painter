// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.DataMember
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Reflection;

namespace Globe.Xml.Serialization
{
  public class DataMember
  {
    private MemberInfo _dataInfo;
    private Type _typeInfo;

    public DataMember(MemberInfo dataInfo, Type typeInfo)
    {
      this._dataInfo = dataInfo;
      this._typeInfo = typeInfo;
    }

    public MemberInfo DataInfo => this._dataInfo;

    public Type TypeInfo => this._typeInfo;
  }
}
