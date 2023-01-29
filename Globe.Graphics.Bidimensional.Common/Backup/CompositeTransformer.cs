// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.CompositeTransformer
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Globe.Graphics.Bidimensional.Common
{
  public class CompositeTransformer : Transformer
  {
    private CompositeShape _shape;

    public override event MovementHandler MovementOccurred;

    public override event TranslateHandler TranslateOccurred;

    public override event ScaleHandler ScaleOccurred;

    public override event RotateHandler RotateOccurred;

    public override event DeformHandler DeformOccurred;

    public override event MirrorHorizontalHandler MirrorHorizontalOccurred;

    public override event MirrorVerticalHandler MirrorVerticalOccurred;

    public CompositeTransformer(CompositeShape shape)
      : base((IShape) shape)
    {
      this._shape = shape != null ? shape : throw new ApplicationException();
    }

    public override void Translate(float offsetX, float offsetY)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      if (!this._shape.MovementContentBlocked)
      {
        foreach (IShape shape in (Collection<IShape>) this._shape.Shapes)
          shape.Transformer.Translate(offsetX, offsetY);
      }
      base.Translate(offsetX, offsetY);
      if (this.TranslateOccurred == null || (double) offsetX == 0.0 && (double) offsetY == 0.0)
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.TranslateOccurred((Transformer) this, offsetX, offsetY);
    }

    public override void Scale(float scaleX, float scaleY, PointF point)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      if (!this._shape.MovementContentBlocked)
      {
        foreach (IShape shape in (Collection<IShape>) this._shape.Shapes)
          shape.Transformer.Scale(scaleX, scaleY, point);
      }
      base.Scale(scaleX, scaleY, point);
      if (this.ScaleOccurred == null || (double) scaleX == 1.0 && (double) scaleY == 1.0)
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.ScaleOccurred((Transformer) this, scaleX, scaleY, point);
    }

    public override void Rotate(float degree, PointF point)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      if (!this._shape.MovementContentBlocked)
      {
        foreach (IShape shape in (Collection<IShape>) this._shape.Shapes)
          shape.Transformer.Rotate(degree, point);
      }
      base.Rotate(degree, point);
      if (this.RotateOccurred == null || (double) degree == 0.0)
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.RotateOccurred((Transformer) this, degree, point);
    }

    public override void Deform(int indexPoint, PointF newPoint)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      int num = 0;
      IShape shape = (IShape) null;
      for (int index = 0; index < this._shape.Shapes.Count; ++index)
      {
        shape = this._shape.Shapes[index];
        if (indexPoint >= shape.Geometric.PointCount + num)
          num += shape.Geometric.PointCount;
        else
          break;
      }
      if (shape == null || indexPoint == -1)
        return;
      shape.Transformer.Deform(indexPoint - num, newPoint);
      PointF pathPoint = this._shape.Geometric.PathPoints[indexPoint];
      base.Deform(indexPoint, newPoint);
      if (this.DeformOccurred == null || !(pathPoint != newPoint))
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.DeformOccurred((Transformer) this, indexPoint, newPoint);
    }

    public override void MirrorHorizontal(float x)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      foreach (IShape shape in (Collection<IShape>) this._shape.Shapes)
        shape.Transformer.MirrorHorizontal(x);
      this._shape.MovementContentBlocked = true;
      base.MirrorHorizontal(x);
      this._shape.MovementContentBlocked = false;
      if (this.MirrorHorizontalOccurred == null)
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.MirrorHorizontalOccurred((Transformer) this, x);
    }

    public override void MirrorVertical(float y)
    {
      if (this._shape.Parent == null && (!this._shape.Selected || this._shape.Locked))
        return;
      foreach (IShape shape in (Collection<IShape>) this._shape.Shapes)
        shape.Transformer.MirrorVertical(y);
      this._shape.MovementContentBlocked = true;
      base.MirrorVertical(y);
      this._shape.MovementContentBlocked = false;
      if (this.MirrorVerticalOccurred == null)
        return;
      if (this.MovementOccurred != null)
        this.MovementOccurred((Transformer) this);
      this.MirrorVerticalOccurred((Transformer) this, y);
    }
  }
}
