// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.DrawSloppedLine
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class DrawSloppedLine : Globe.Graphics.Bidimensional.Common.Tool
  {
    private IShape _shape = (IShape) new CustomShape();
    private Collection<PointF> _points = new Collection<PointF>();

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      base.MouseUp(document, e);
      if (e.Button == MouseButtons.Left)
      {
        this._points.Add(document.GridManager.GetRoundedPoint((PointF) e.Location));
      }
      else
      {
        if (e.Button != MouseButtons.Right)
          return;
        IShape drawingShape = this.CreateDrawingShape();
        if (drawingShape == null)
          return;
        document.Shapes.Add(drawingShape);
        this._points.Clear();
      }
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      base.MouseMove(document, e);
      document.DrawingControl.Invalidate();
    }

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      if (this._points.Count == 0)
        return;
      PointF[] pointF = this.ToPointF(this._points);
      if (pointF == null)
        return;
      if (pointF.GetLength(0) > 1)
        e.Graphics.DrawLines(Pens.Black, pointF);
      e.Graphics.DrawLine(Pens.Black, this._points[this._points.Count - 1], document.GridManager.GetRoundedPoint((PointF) document.DrawingControl.PointToClient(Control.MousePosition)));
    }

    protected IShape DrawingShape => this._shape;

    protected Collection<PointF> Points => this._points;

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      document.ActiveCursor = Cursors.Cross;
      return true;
    }

    protected PointF[] ToPointF(Collection<PointF> collection)
    {
      if (collection == null || collection.Count == 0)
        return (PointF[]) null;
      PointF[] array = new PointF[collection.Count];
      collection.CopyTo(array, 0);
      return array;
    }

    protected virtual IShape CreateDrawingShape()
    {
      if (this._points.Count <= 1)
        return (IShape) null;
      if (this._points.Count == 2)
        this._shape = (IShape) new Line(this._points[0], this._points[1]);
      else
        this._shape.Geometric.AddLines(this.ToPointF(this._points));
      IShape drawingShape = this._shape.Clone() as IShape;
      drawingShape.Selected = true;
      return drawingShape;
    }
  }
}
