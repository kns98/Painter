// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.GridManager
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Globe.Graphics.Bidimensional.Common
{
  public class GridManager
  {
    private SizeF _resolution = new SizeF(10f, 10f);

    public virtual event GridManager.ResolutionChangedHandler ResolutionChanged;

    public SizeF Resolution
    {
      get => this._resolution;
      set
      {
        SizeF resolution = this._resolution;
        this._resolution = value;
        if (this.ResolutionChanged == null || (double) resolution.Width == (double) this._resolution.Width && (double) resolution.Height == (double) this._resolution.Height)
          return;
        this.ResolutionChanged(this, resolution, this._resolution);
      }
    }

    public void SnapToGrid(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        bool selected = shape.Selected;
        bool locked = shape.Locked;
        shape.Selected = true;
        shape.Locked = false;
        shape.Location = this.GetRoundedPoint(shape.Location);
        shape.Dimension = this.GetRoundedSize(shape.Dimension);
        shape.Selected = selected;
        shape.Locked = locked;
      }
    }

    public float GetRoundedValue(float value, float resolution)
    {
      float roundedValue = (float) Math.Round((double) value + (double) resolution / 2.0);
      if ((double) resolution != 0.0)
        roundedValue -= roundedValue % resolution;
      return roundedValue;
    }

    public PointF GetRoundedPoint(PointF point)
    {
      PointF roundedPoint = new PointF((float) Math.Round((double) point.X + (double) this._resolution.Width / 2.0), (float) Math.Round((double) point.Y + (double) this._resolution.Height / 2.0));
      if ((double) this._resolution.Height != 0.0)
        roundedPoint = new PointF(roundedPoint.X, roundedPoint.Y - roundedPoint.Y % this._resolution.Height);
      if ((double) this._resolution.Width != 0.0)
        roundedPoint = new PointF(roundedPoint.X - roundedPoint.X % this._resolution.Width, roundedPoint.Y);
      return roundedPoint;
    }

    public SizeF GetRoundedSize(SizeF size)
    {
      SizeF roundedSize = new SizeF((float) Math.Round((double) size.Width + (double) this._resolution.Width / 2.0), (float) Math.Round((double) size.Height + (double) this._resolution.Height / 2.0));
      if ((double) this._resolution.Height != 0.0)
        roundedSize = new SizeF(roundedSize.Width, roundedSize.Height - roundedSize.Height % this._resolution.Height);
      if ((double) this._resolution.Width != 0.0)
        roundedSize = new SizeF(roundedSize.Width - roundedSize.Width % this._resolution.Width, roundedSize.Height);
      return roundedSize;
    }

    public delegate void ResolutionChangedHandler(
      GridManager sender,
      SizeF oldValue,
      SizeF newValue);
  }
}
