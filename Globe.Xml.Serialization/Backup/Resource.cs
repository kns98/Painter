// Decompiled with JetBrains decompiler
// Type: Globe.Xml.Serialization.Resource
// Assembly: Globe.Xml.Serialization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F03CB37A-5778-4CF6-AFBC-3612D958D9BD
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Xml.Serialization.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Globe.Xml.Serialization
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resource
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resource()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Resource.resourceMan, (object) null))
          Resource.resourceMan = new ResourceManager("Globe.Xml.Serialization.Resource", typeof (Resource).Assembly);
        return Resource.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Resource.resourceCulture;
      set => Resource.resourceCulture = value;
    }

    internal static string Assembly => Resource.ResourceManager.GetString(nameof (Assembly), Resource.resourceCulture);

    internal static string AssemblyQualifiedName => Resource.ResourceManager.GetString(nameof (AssemblyQualifiedName), Resource.resourceCulture);

    internal static string Constant => Resource.ResourceManager.GetString(nameof (Constant), Resource.resourceCulture);

    internal static string Data => Resource.ResourceManager.GetString(nameof (Data), Resource.resourceCulture);

    internal static string FieldInfo => Resource.ResourceManager.GetString(nameof (FieldInfo), Resource.resourceCulture);

    internal static string FieldName => Resource.ResourceManager.GetString(nameof (FieldName), Resource.resourceCulture);

    internal static string NoConstant => Resource.ResourceManager.GetString(nameof (NoConstant), Resource.resourceCulture);

    internal static string NoData => Resource.ResourceManager.GetString(nameof (NoData), Resource.resourceCulture);

    internal static string NoReadeable => Resource.ResourceManager.GetString(nameof (NoReadeable), Resource.resourceCulture);

    internal static string NoSerializableData => Resource.ResourceManager.GetString(nameof (NoSerializableData), Resource.resourceCulture);

    internal static string NoWriteable => Resource.ResourceManager.GetString(nameof (NoWriteable), Resource.resourceCulture);

    internal static string PropertyInfo => Resource.ResourceManager.GetString(nameof (PropertyInfo), Resource.resourceCulture);

    internal static string Readeable => Resource.ResourceManager.GetString(nameof (Readeable), Resource.resourceCulture);

    internal static string SerializableData => Resource.ResourceManager.GetString(nameof (SerializableData), Resource.resourceCulture);

    internal static string SerializableDataCollectionCount => Resource.ResourceManager.GetString(nameof (SerializableDataCollectionCount), Resource.resourceCulture);

    internal static string TagName => Resource.ResourceManager.GetString(nameof (TagName), Resource.resourceCulture);

    internal static string Type => Resource.ResourceManager.GetString(nameof (Type), Resource.resourceCulture);

    internal static string Value => Resource.ResourceManager.GetString(nameof (Value), Resource.resourceCulture);

    internal static string Writeable => Resource.ResourceManager.GetString(nameof (Writeable), Resource.resourceCulture);
  }
}
