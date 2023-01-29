// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.CopyPoint
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class CopyPoint : Deform
  {
    private Ellipse _newPoint = new Ellipse();

    public CopyPoint()
    {
      this._newPoint.Selected = true;
      this._newPoint.Visible = false;
      this._newPoint.Location = (PointF) Control.MousePosition;
      this._newPoint.Dimension = new SizeF(10f, 10f);
    }

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      if (Control.ModifierKeys != Keys.Control)
        return;
      base.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this.UpdateShape();
      this.Shape = (IShape) null;
      this.IndexPoint = -1;
      this._newPoint.Visible = false;
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      this.UpdateCursor(document, document.Shapes, e.Location);
      if (this.Shape == null || this.IndexPoint == -1 || Control.ModifierKeys != Keys.Control)
        return;
      this._newPoint.Visible = true;
      this._newPoint.Center = document.GridManager.GetRoundedPoint((PointF) e.Location);
      document.DrawingControl.Invalidate();
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this._newPoint.Paint(document, e);

    protected virtual void UpdateShape()
    {
      if (this.Shape == null || this.IndexPoint == -1)
        return;
      this.Shape.Transformer.CopyPoint(this.IndexPoint, true, this._newPoint.Center, this.Shape.Geometric.PathTypes[this.IndexPoint]);
    }
  }
}
