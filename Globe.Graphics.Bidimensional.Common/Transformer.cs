// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Transformer
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Globe.Graphics.Bidimensional.Common
{
  public class Transformer
  {
    private IShape _shape;

    public virtual event MovementHandler MovementOccurred;

    public virtual event TranslateHandler TranslateOccurred;

    public virtual event ScaleHandler ScaleOccurred;

    public virtual event RotateHandler RotateOccurred;

    public virtual event DeformHandler DeformOccurred;

    public virtual event MirrorHorizontalHandler MirrorHorizontalOccurred;

    public virtual event MirrorVerticalHandler MirrorVerticalOccurred;

    public Transformer(IShape shape) => this._shape = shape != null ? shape : throw new ApplicationException();

    public virtual void Translate(float offsetX, float offsetY)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      using (Matrix matrix = new Matrix())
      {
        matrix.Translate(offsetX, offsetY);
        this._shape.Geometric.Transform(matrix);
      }
      if (this.TranslateOccurred != null && ((double) offsetX != 0.0 || (double) offsetY != 0.0))
        this.TranslateOccurred(this, offsetX, offsetY);
      if (this.MovementOccurred == null || (double) offsetX == 0.0 && (double) offsetY == 0.0)
        return;
      this.MovementOccurred(this);
    }

    public void Scale(float scaleX, float scaleY) => this.Scale(scaleX, scaleY, HitPositions.BottomRight);

    public void Scale(float scaleX, float scaleY, HitPositions reference)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked) || reference == HitPositions.None || reference == HitPositions.Center)
        return;
      PointF grabberPoint = this._shape.GetGrabberPoint(reference);
      this.Scale(scaleX, scaleY, grabberPoint);
    }

    public virtual void Scale(float scaleX, float scaleY, PointF point)
    {
      if (point.IsEmpty || (double) scaleX <= 0.1 || float.IsNaN(scaleX) || float.IsInfinity(scaleX) || (double) scaleY <= 0.1 || float.IsNaN(scaleY) || float.IsInfinity(scaleY))
        return;
      using (Matrix matrix = new Matrix())
      {
        matrix.Translate(-point.X, -point.Y, MatrixOrder.Append);
        matrix.Scale(scaleX, scaleY, MatrixOrder.Append);
        matrix.Translate(point.X, point.Y, MatrixOrder.Append);
        this._shape.Geometric.Transform(matrix);
      }
      if (this.ScaleOccurred != null)
        this.ScaleOccurred(this, scaleX, scaleY, point);
      if (this.MovementOccurred == null)
        return;
      this.MovementOccurred(this);
    }

    public void Rotate(float degree)
    {
      PointF point = new PointF(this._shape.Location.X + this._shape.Dimension.Width / 2f, this._shape.Location.Y + this._shape.Dimension.Height / 2f);
      this.Rotate(degree, point);
    }

    public virtual void Rotate(float degree, PointF point)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      using (Matrix matrix = new Matrix())
      {
        matrix.RotateAt(degree, point);
        this._shape.Geometric.Transform(matrix);
      }
      if (this.RotateOccurred != null && (double) degree != 0.0)
        this.RotateOccurred(this, degree, point);
      if (this.MovementOccurred == null || (double) degree == 0.0)
        return;
      this.MovementOccurred(this);
    }

    public virtual void Deform(int indexPoint, PointF newPoint)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked) || indexPoint == -1 || this._shape.Geometric.PathData.Points.Length == 0)
        return;
      PointF[] pts = new PointF[this._shape.Geometric.PathData.Points.Length];
      this._shape.Geometric.PathData.Points.CopyTo((Array) pts, 0);
      PointF pointF = pts[indexPoint];
      pts[indexPoint] = newPoint;
      GraphicsPath addingPath = new GraphicsPath(pts, this._shape.Geometric.PathTypes);
      this._shape.Geometric.Reset();
      this._shape.Geometric.AddPath(addingPath, false);
      if (this.DeformOccurred != null && pointF != newPoint)
        this.DeformOccurred(this, indexPoint, newPoint);
      if (this.MovementOccurred == null || !(pointF != newPoint))
        return;
      this.MovementOccurred(this);
    }

    public virtual void CopyPoint(int indexPoint, bool before, PointF newPoint, byte pointType)
    {
    }

    public virtual void MirrorHorizontal(float x)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      PointF pointF = new PointF(2f * x - this._shape.Location.X - this._shape.Dimension.Width, this._shape.Location.Y);
      using (Matrix matrix = new Matrix(-1f, 0.0f, 0.0f, 1f, 0.0f, 0.0f))
        this._shape.Geometric.Transform(matrix);
      this.Translate(pointF.X - this._shape.Location.X, pointF.Y - this._shape.Location.Y);
      if (this.MirrorHorizontalOccurred != null)
        this.MirrorHorizontalOccurred(this, x);
      if (this.MovementOccurred == null)
        return;
      this.MovementOccurred(this);
    }

    public void MirrorHorizontal() => this.MirrorHorizontal(this._shape.Center.X);

    public virtual void MirrorVertical(float y)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      PointF pointF = new PointF(this._shape.Location.X, 2f * y - this._shape.Location.Y - this._shape.Dimension.Height);
      using (Matrix matrix = new Matrix(1f, 0.0f, 0.0f, -1f, 0.0f, 0.0f))
        this._shape.Geometric.Transform(matrix);
      this.Translate(pointF.X - this._shape.Location.X, pointF.Y - this._shape.Location.Y);
      if (this.MirrorVerticalOccurred != null)
        this.MirrorVerticalOccurred(this, y);
      if (this.MovementOccurred == null)
        return;
      this.MovementOccurred(this);
    }

    public void MirrorVertical() => this.MirrorVertical(this._shape.Center.Y);

    [Browsable(false)]
    public IShape Shape => this._shape;
  }
}
