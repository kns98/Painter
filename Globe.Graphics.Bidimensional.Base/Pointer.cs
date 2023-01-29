// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Pointer
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class Pointer : Resize
  {
    private Globe.Graphics.Bidimensional.Common.Tool _tool = (Globe.Graphics.Bidimensional.Common.Tool) new Move();

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      base.MouseDown(document, e);
      switch (this.SelectShape(document.Shapes, e.Location))
      {
        case HitPositions.None:
          this._tool = (Globe.Graphics.Bidimensional.Common.Tool) new MultiSelect();
          break;
        case HitPositions.Center:
          this._tool = (Globe.Graphics.Bidimensional.Common.Tool) new Move();
          break;
        default:
          this._tool = (Globe.Graphics.Bidimensional.Common.Tool) new Resize();
          break;
      }
      this._tool.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this._tool.MouseUp(document, e);
      base.MouseUp(document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      this._tool.MouseMove(document, e);
      base.MouseMove(document, e);
      this.UpdateCursor(document, document.Shapes, e.Location);
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this._tool.Paint(document, e);

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (shape.HitTest(point) != HitPositions.Center && shape.HitTest(point) != HitPositions.All && shape.HitTest(point) != HitPositions.None)
          return !this.MousePressed && base.UpdateCursor(document, shapes, point);
        if (shape.HitTest(this.MouseDownPoint) == HitPositions.Center && shape.Selected && this.MousePressed)
        {
          document.ActiveCursor = Cursors.SizeAll;
          return true;
        }
      }
      if (this.MousePressed)
        return false;
      document.ActiveCursor = Cursors.Default;
      return false;
    }
  }
}
