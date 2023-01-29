// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Resource
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Globe.Graphics.Bidimensional.Base
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [DebuggerNonUserCode]
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
          Resource.resourceMan = new ResourceManager("Globe.Graphics.Bidimensional.Base.Resource", typeof (Resource).Assembly);
        return Resource.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Resource.resourceCulture;
      set => Resource.resourceCulture = value;
    }

    internal static Icon Rotate => (Icon) Resource.ResourceManager.GetObject(nameof (Rotate), Resource.resourceCulture);
  }
}
