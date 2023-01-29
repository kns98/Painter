// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.XmlClassSerializable
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System;
using System.Reflection;

namespace Globe.Xml.Serialization
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
  public class XmlClassSerializable : XmlSerializable
  {
    private bool _deep = true;
    private BindingFlags _flags;

    public XmlClassSerializable()
    {
    }

    public XmlClassSerializable(string tagName)
      : base(tagName)
    {
    }

    public XmlClassSerializable(string tagName, bool deep)
      : base(tagName)
    {
      this._deep = deep;
    }

    public XmlClassSerializable(string tagName, bool deep, BindingFlags flags)
      : base(tagName)
    {
      this._deep = deep;
      this._flags = flags;
    }

    public bool Deep => this._deep;

    public BindingFlags Flags => this._flags;
  }
}
