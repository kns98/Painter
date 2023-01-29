// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Draw
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public abstract class Draw : Globe.Graphics.Bidimensional.Common.Tool
  {
    private Color _drawingColor = Color.LightBlue;

    public Draw() => this.Ghost = new Ghost((IShape) new Rectangle());

    public Color DrawingColor
    {
      get => this._drawingColor;
      set => this._drawingColor = value;
    }

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      this.Ghost.MirrorPoint = (PointF) e.Location;
      this.Ghost.Location = new PointF((float) this.MouseDownPoint.X, (float) this.MouseDownPoint.Y);
      this.Ghost.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this.Ghost.MouseUp(document, e);
      base.MouseUp(document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (!this.MousePressed)
        return;
      document.DrawingControl.Invalidate();
      this.Ghost.MouseMove(document, e);
      int x1;
      int x2;
      if (this.MouseDownPoint.X > e.X)
      {
        x1 = e.X;
        x2 = this.MouseDownPoint.X;
      }
      else
      {
        x1 = this.MouseDownPoint.X;
        x2 = e.X;
      }
      int y1;
      int y2;
      if (this.MouseDownPoint.Y > e.Y)
      {
        y1 = e.Y;
        y2 = this.MouseDownPoint.Y;
      }
      else
      {
        y1 = this.MouseDownPoint.Y;
        y2 = e.Y;
      }
      this.Ghost.Location = document.GridManager.GetRoundedPoint((PointF) new Point(x1, y1));
      this.Ghost.Dimension = document.GridManager.GetRoundedSize((SizeF) new Size(x2 - x1, y2 - y1));
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this.Ghost.Paint(document, e);
  }
}
