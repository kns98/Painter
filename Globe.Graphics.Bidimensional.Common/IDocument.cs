// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.IDocument
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public interface IDocument
  {
    Control DrawingControl { get; }

    ShapeCollection Shapes { get; }

    Cursor ActiveCursor { get; set; }

    Tool ActiveTool { get; }

    GridManager GridManager { get; }
  }
}
