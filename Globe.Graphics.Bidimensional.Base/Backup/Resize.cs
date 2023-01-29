// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Resize
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class Resize : Select
  {
    private HitPositions _hitPosition;

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      foreach (IShape shape in (Collection<IShape>) document.Shapes)
      {
        this._hitPosition = shape.HitTest(e.Location);
        if (this._hitPosition != HitPositions.None)
        {
          this.Ghost.Shape = shape;
          this.UpdateSize((IShape) this.Ghost, shape.Location);
          this.Ghost.MouseDown(document, e);
          this.Ghost.Location = shape.Location;
        }
      }
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      base.MouseUp(document, e);
      if (this._hitPosition == HitPositions.Center || this._hitPosition == HitPositions.None || Select.LastSelectedShape == null)
        return;
      document.Shapes.Remove(Select.LastSelectedShape);
      Select.LastSelectedShape = this.Ghost.Shape.Clone() as IShape;
      document.Shapes.Add(Select.LastSelectedShape);
      Select.LastSelectedShape.Selected = true;
      Select.LastSelectedShape.Locked = false;
      Select.LastSelectedShape.Location = this.Ghost.Shape.Location;
      Select.LastSelectedShape.Dimension = this.Ghost.Shape.Dimension;
      this.Ghost.MouseUp(document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (!this.MousePressed)
      {
        base.MouseMove(document, e);
      }
      else
      {
        this.UpdateCursor(document, document.Shapes, e.Location);
        if (this._hitPosition == HitPositions.Center || this._hitPosition == HitPositions.None)
          return;
        this.UpdateLocation((IShape) this.Ghost, (PointF) e.Location);
        this.UpdateSize((IShape) this.Ghost, (PointF) e.Location);
        float x1;
        float x2;
        if ((double) this.Ghost.MirrorPoint.X > (double) e.X)
        {
          x1 = (float) e.X;
          x2 = this.Ghost.MirrorPoint.X;
        }
        else
        {
          x1 = this.Ghost.MirrorPoint.X;
          x2 = (float) e.X;
        }
        float y1;
        float y2;
        if ((double) this.Ghost.MirrorPoint.Y > (double) e.Y)
        {
          y1 = (float) e.Y;
          y2 = this.Ghost.MirrorPoint.Y;
        }
        else
        {
          y1 = this.Ghost.MirrorPoint.Y;
          y2 = (float) e.Y;
        }
        SizeF size = new SizeF(x2 - x1, y2 - y1);
        PointF point = new PointF(x1, y1);
        SizeF sizeF = this.AdjustSize(size, document.GridManager);
        this.Ghost.Location = this.AdjustLocation(point, document.GridManager);
        this.Ghost.Dimension = sizeF;
        this.Ghost.MouseMove(document, e);
      }
    }

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      if (this.Ghost == null)
        return;
      this.Ghost.Paint(document, e);
    }

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      bool flag = true;
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (this._hitPosition != HitPositions.None && this.MousePressed)
        {
          document.ActiveCursor = Cursors.Cross;
          return true;
        }
        switch (shape.HitTest(point))
        {
          case HitPositions.TopLeft:
            document.ActiveCursor = Cursors.SizeNWSE;
            return true;
          case HitPositions.Top:
            document.ActiveCursor = Cursors.SizeNS;
            return true;
          case HitPositions.TopRight:
            document.ActiveCursor = Cursors.SizeNESW;
            return true;
          case HitPositions.Right:
            document.ActiveCursor = Cursors.SizeWE;
            return true;
          case HitPositions.BottomRight:
            document.ActiveCursor = Cursors.SizeNWSE;
            return true;
          case HitPositions.Bottom:
            document.ActiveCursor = Cursors.SizeNS;
            return true;
          case HitPositions.BottomLeft:
            document.ActiveCursor = Cursors.SizeNESW;
            return true;
          case HitPositions.Left:
            document.ActiveCursor = Cursors.SizeWE;
            return true;
          default:
            document.ActiveCursor = Cursors.Default;
            flag = false;
            continue;
        }
      }
      return flag;
    }

    private PointF AdjustLocation(PointF point, GridManager gridManager)
    {
      if (this._hitPosition == HitPositions.Top || this._hitPosition == HitPositions.Bottom)
        point = new PointF(this.Ghost.Location.X, point.Y);
      if (this._hitPosition == HitPositions.Right || this._hitPosition == HitPositions.Left)
        point = new PointF(point.X, this.Ghost.Location.Y);
      return gridManager.GetRoundedPoint(point);
    }

    private SizeF AdjustSize(SizeF size, GridManager gridManager)
    {
      if (this._hitPosition == HitPositions.Top || this._hitPosition == HitPositions.Bottom)
        size = new SizeF(this.Ghost.Dimension.Width, size.Height);
      if (this._hitPosition == HitPositions.Right || this._hitPosition == HitPositions.Left)
        size = new SizeF(size.Width, this.Ghost.Dimension.Height);
      return gridManager.GetRoundedSize(size);
    }

    private SizeF UpdateSize(IShape shape, PointF currentLocation)
    {
      float num1 = shape.Dimension.Width;
      float num2 = shape.Dimension.Height;
      SizeF dimension;
      switch (this._hitPosition)
      {
        case HitPositions.TopLeft:
          num1 = (double) currentLocation.X >= (double) shape.Location.X ? (float) -((double) shape.Location.X - (double) currentLocation.X) : currentLocation.X - shape.Location.X;
          num2 = (double) currentLocation.Y >= (double) shape.Location.Y ? (float) -((double) shape.Location.Y - (double) currentLocation.Y) : currentLocation.Y - shape.Location.Y;
          this.Ghost.MirrorPoint = new PointF(this.Ghost.Location.X + this.Ghost.Dimension.Width, this.Ghost.Location.Y + this.Ghost.Dimension.Height);
          break;
        case HitPositions.Top:
          num1 = 0.0f;
          num2 = (double) currentLocation.Y >= (double) shape.Location.Y ? (float) -((double) shape.Location.Y - (double) currentLocation.Y) : currentLocation.Y - shape.Location.Y;
          this.Ghost.MirrorPoint = new PointF(this.Ghost.Location.X, this.Ghost.Location.Y + this.Ghost.Dimension.Height);
          break;
        case HitPositions.TopRight:
          num1 = (double) currentLocation.X <= (double) shape.Location.X + (double) shape.Dimension.Width ? shape.Location.X + shape.Dimension.Width - currentLocation.X : (float) -((double) currentLocation.X - (double) shape.Location.X - (double) shape.Dimension.Width);
          num2 = (double) currentLocation.Y >= (double) shape.Location.Y ? (float) -((double) shape.Location.Y - (double) currentLocation.Y) : currentLocation.Y - shape.Location.Y;
          this.Ghost.MirrorPoint = new PointF(this.Ghost.Location.X, this.Ghost.Location.Y + this.Ghost.Dimension.Height);
          break;
        case HitPositions.Right:
          num1 = (double) currentLocation.X <= (double) shape.Location.X + (double) shape.Dimension.Width ? shape.Location.X + shape.Dimension.Width - currentLocation.X : (float) -((double) currentLocation.X - (double) shape.Location.X - (double) shape.Dimension.Width);
          num2 = 0.0f;
          this.Ghost.MirrorPoint = new PointF(this.Ghost.Location.X, this.Ghost.Center.Y);
          break;
        case HitPositions.BottomRight:
          num1 = (double) currentLocation.X <= (double) shape.Location.X + (double) shape.Dimension.Width ? shape.Location.X + shape.Dimension.Width - currentLocation.X : (float) -((double) currentLocation.X - (double) shape.Location.X - (double) shape.Dimension.Width);
          num2 = (double) currentLocation.Y >= (double) shape.Location.Y - (double) shape.Dimension.Height ? shape.Location.Y + shape.Dimension.Height - currentLocation.Y : (float) -((double) currentLocation.Y - (double) shape.Location.Y - (double) shape.Dimension.Height);
          this.Ghost.MirrorPoint = currentLocation;
          break;
        case HitPositions.Bottom:
          num1 = 0.0f;
          num2 = (double) currentLocation.Y >= (double) shape.Location.Y - (double) shape.Dimension.Height ? shape.Location.Y + shape.Dimension.Height - currentLocation.Y : (float) -((double) currentLocation.Y - (double) shape.Location.Y - (double) shape.Dimension.Height);
          this.Ghost.MirrorPoint = new PointF(this.Ghost.Location.X, this.Ghost.Location.Y);
          break;
        case HitPositions.BottomLeft:
          double x1 = (double) currentLocation.X;
          PointF location = shape.Location;
          double x2 = (double) location.X;
          if (x1 < x2)
          {
            double x3 = (double) currentLocation.X;
            location = shape.Location;
            double x4 = (double) location.X;
            num1 = (float) (x3 - x4);
          }
          else
          {
            location = shape.Location;
            num1 = (float) -((double) location.X - (double) currentLocation.X);
          }
          double y1 = (double) currentLocation.Y;
          location = shape.Location;
          double num3 = (double) location.Y - (double) shape.Dimension.Height;
          if (y1 < num3)
          {
            double y2 = (double) currentLocation.Y;
            location = shape.Location;
            double y3 = (double) location.Y;
            double num4 = y2 - y3;
            dimension = shape.Dimension;
            double height = (double) dimension.Height;
            num2 = (float) -(num4 - height);
          }
          else
          {
            location = shape.Location;
            double y4 = (double) location.Y;
            dimension = shape.Dimension;
            double height = (double) dimension.Height;
            num2 = (float) (y4 + height) - currentLocation.Y;
          }
          Ghost ghost1 = this.Ghost;
          location = this.Ghost.Location;
          double x5 = (double) location.X;
          dimension = this.Ghost.Dimension;
          double width1 = (double) dimension.Width;
          double x6 = x5 + width1;
          location = this.Ghost.Location;
          double y5 = (double) location.Y;
          PointF pointF1 = new PointF((float) x6, (float) y5);
          ghost1.MirrorPoint = pointF1;
          break;
        case HitPositions.Left:
          double x7 = (double) currentLocation.X;
          PointF pointF2 = shape.Location;
          double x8 = (double) pointF2.X;
          if (x7 < x8)
          {
            double x9 = (double) currentLocation.X;
            pointF2 = shape.Location;
            double x10 = (double) pointF2.X;
            num1 = (float) (x9 - x10);
          }
          else
          {
            pointF2 = shape.Location;
            num1 = (float) -((double) pointF2.X - (double) currentLocation.X);
          }
          num2 = 0.0f;
          Ghost ghost2 = this.Ghost;
          pointF2 = this.Ghost.Location;
          double x11 = (double) pointF2.X;
          dimension = this.Ghost.Dimension;
          double width2 = (double) dimension.Width;
          double x12 = x11 + width2;
          pointF2 = this.Ghost.Center;
          double y6 = (double) pointF2.Y;
          PointF pointF3 = new PointF((float) x12, (float) y6);
          ghost2.MirrorPoint = pointF3;
          break;
      }
      dimension = shape.Dimension;
      double width3 = (double) dimension.Width - (double) num1;
      dimension = shape.Dimension;
      double height1 = (double) dimension.Height - (double) num2;
      return new SizeF((float) width3, (float) height1);
    }

    private PointF UpdateLocation(IShape shape, PointF currentLocation)
    {
      PointF pointF = currentLocation;
      switch (this._hitPosition)
      {
        case HitPositions.TopLeft:
          pointF = currentLocation;
          break;
        case HitPositions.Top:
          pointF.X = shape.Location.X;
          pointF.Y = currentLocation.Y;
          break;
        case HitPositions.TopRight:
          pointF.X = shape.Location.X;
          pointF.Y = currentLocation.Y;
          break;
        case HitPositions.Right:
          pointF.X = shape.Location.X;
          pointF.Y = shape.Location.Y;
          break;
        case HitPositions.BottomRight:
          pointF.X = shape.Location.X;
          pointF.Y = shape.Location.Y;
          break;
        case HitPositions.Bottom:
          pointF.X = shape.Location.X;
          pointF.Y = shape.Location.Y;
          break;
        case HitPositions.BottomLeft:
          pointF.X = currentLocation.X;
          pointF.Y = shape.Location.Y;
          break;
        case HitPositions.Left:
          pointF.X = currentLocation.X;
          pointF.Y = shape.Location.Y;
          break;
      }
      return pointF;
    }
  }
}
