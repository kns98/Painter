// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlSerializable
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;

namespace Globe.Xml.Serialization
{
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
  public abstract class XmlSerializable : Attribute
  {
    private string _tagName = string.Empty;

    public XmlSerializable()
    {
    }

    public XmlSerializable(string tagName) => this._tagName = tagName;

    public string TagName => this._tagName;
  }
}
