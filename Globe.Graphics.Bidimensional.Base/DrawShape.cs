// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.DrawShape
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class DrawShape : Draw
  {
    public DrawShape(GraphicsPath geometric) => this.Ghost = new Ghost((IShape) new CustomShape(geometric.Clone() as GraphicsPath));

    public DrawShape(IShape shape) => this.Ghost = new Ghost(shape);

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      PointF roundedPoint = document.GridManager.GetRoundedPoint((PointF) e.Location);
      this.Ghost.Location = roundedPoint;
      this.Ghost.MirrorPoint = roundedPoint;
      this.Ghost.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this.Ghost.MouseUp(document, e);
      IShape shape = this.Ghost.Shape.Clone() as IShape;
      shape.Visible = true;
      shape.Selected = true;
      document.Shapes.Add(shape);
      base.MouseUp(document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (!this.MousePressed)
        return;
      base.MouseMove(document, e);
      this.Ghost.MouseMove(document, e);
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this.Ghost.Paint(document, e);
  }
}
