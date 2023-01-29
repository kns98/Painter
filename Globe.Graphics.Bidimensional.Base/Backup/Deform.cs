// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Deform
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class Deform : Select
  {
    private int _indexPoint = -1;
    private IShape _shape;

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      this.SelectIndexPointShapeCouple(document.Shapes, (PointF) e.Location);
      if (this._shape == null)
        return;
      this.Ghost.Shape = this._shape;
      this.Ghost.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      base.MouseUp(document, e);
      if (this._shape == null)
        return;
      this.Ghost.MouseUp(document, e);
      this._shape.Transformer.Deform(this._indexPoint, document.GridManager.GetRoundedPoint((PointF) e.Location));
      this._shape = (IShape) null;
      this._indexPoint = -1;
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      this.UpdateCursor(document, document.Shapes, e.Location);
      if (this._shape == null || this._indexPoint == -1)
        return;
      this.Ghost.MouseMove(document, e);
      this.Ghost.Transformer.Deform(this._indexPoint, document.GridManager.GetRoundedPoint((PointF) e.Location));
      document.DrawingControl.Invalidate();
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this.Ghost.Paint(document, e);

    protected int IndexPoint
    {
      get => this._indexPoint;
      set => this._indexPoint = value;
    }

    protected IShape Shape
    {
      get => this._shape;
      set => this._shape = value;
    }

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      if (this.MousePressed || Select.LastSelectedShape == null)
        return false;
      foreach (RectangleF marker in Select.LastSelectedShape.GetMarkers())
      {
        if (marker.Contains((PointF) point))
        {
          document.ActiveCursor = Cursors.Cross;
          return true;
        }
      }
      document.ActiveCursor = Cursors.Default;
      return false;
    }

    protected void SelectIndexPointShapeCouple(ShapeCollection shapes, PointF point)
    {
      if (Select.LastSelectedShape == null)
        return;
      this._shape = Select.LastSelectedShape;
      this._indexPoint = this._shape.GetMarkerIndex(point);
    }
  }
}
