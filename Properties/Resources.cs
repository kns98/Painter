// Decompiled with JetBrains decompiler
// Type: Painter.Properties.Resources
// Assembly: Painter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6C7491-0546-43BD-B8DF-DE31170BE9D0
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Painter.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Painter.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Painter.Properties.Resources.resourceMan, (object) null))
          Painter.Properties.Resources.resourceMan = new ResourceManager("Painter.Properties.Resources", typeof (Painter.Properties.Resources).Assembly);
        return Painter.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Painter.Properties.Resources.resourceCulture;
      set => Painter.Properties.Resources.resourceCulture = value;
    }
  }
}
