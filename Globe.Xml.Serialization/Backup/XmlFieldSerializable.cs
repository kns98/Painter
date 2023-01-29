// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlFieldSerializable
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;

namespace Globe.Xml.Serialization
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
  public class XmlFieldSerializable : XmlSerializable
  {
    public XmlFieldSerializable()
    {
    }

    public XmlFieldSerializable(string tagName)
      : base(tagName)
    {
    }
  }
}
