// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.IActions
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public interface IActions
  {
    void MouseDown(IDocument document, MouseEventArgs e);

    void MouseUp(IDocument document, MouseEventArgs e);

    void MouseClick(IDocument document, MouseEventArgs e);

    void MouseDoubleClick(IDocument document, MouseEventArgs e);

    void MouseMove(IDocument document, MouseEventArgs e);

    void MouseWheel(IDocument document, MouseEventArgs e);

    void Paint(IDocument document, PaintEventArgs e);
  }
}
