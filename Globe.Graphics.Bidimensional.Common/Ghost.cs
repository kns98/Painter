// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Ghost
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public class Ghost : Globe.Graphics.Bidimensional.Common.Shape
  {
    private IShape _memoryShape;
    private IShape _shape;
    private IShape _referenceShape;
    private PointF _mirrorPoint = PointF.Empty;
    private HorizontalVersors _horizontalVersor = HorizontalVersors.LeftRight;
    private VerticalVersors _verticalVersor = VerticalVersors.TopBottom;
    private bool _horizontalMirror = true;
    private bool _verticalMirror = true;

    public Ghost()
    {
      this.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
      this.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
      this.Appearance = (Appearance) new GhostAppearance();
    }

    public Ghost(IShape shape)
    {
      this._referenceShape = shape;
      this._memoryShape = shape.Clone() as IShape;
      this._shape = this._memoryShape.Clone() as IShape;
      this.Geometric.Reset();
      this.Geometric.AddPath(shape.Geometric, false);
      this.Selected = false;
      this.Visible = false;
      this.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
      this.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
      this.Appearance = (Appearance) new GhostAppearance();
    }

    public Ghost(Ghost ghost)
      : base((Globe.Graphics.Bidimensional.Common.Shape) ghost)
    {
      this._referenceShape = ghost.Shape;
      this._memoryShape = ghost.Shape.Clone() as IShape;
      this._shape = this._memoryShape.Clone() as IShape;
      this.Geometric.Reset();
      this.Geometric.AddPath(ghost.Shape.Geometric, false);
      ghost.Selected = false;
      ghost.Visible = false;
      this.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
      this.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
      this.Appearance = (Appearance) new GhostAppearance();
    }

    public override object Clone() => (object) new Ghost(this);

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      this._shape = this._memoryShape.Clone() as IShape;
      this.Geometric.Reset();
      this.Geometric.AddPath(this._shape.Geometric, false);
      this.Visible = false;
      this.Selected = false;
      this.InitializeVersors(this._shape.HitTest(e.Location));
      base.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      base.MouseUp(document, e);
      this.Visible = false;
      this._mirrorPoint = (PointF) Point.Empty;
      this._horizontalVersor = HorizontalVersors.LeftRight;
      this._verticalVersor = VerticalVersors.TopBottom;
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      base.MouseMove(document, e);
      this.Visible = true;
      this.Selected = true;
      this.UpdateVersors(this._mirrorPoint, e.Location);
      this._shape.Location = this.Location;
      this._shape.Dimension = this.Dimension;
      document.DrawingControl.Invalidate();
    }

    public override bool Selected
    {
      get => base.Selected;
      set
      {
        base.Selected = value;
        if (this._shape == null)
          return;
        this._shape.Selected = value;
      }
    }

    public override bool Visible
    {
      get => base.Visible;
      set
      {
        base.Visible = value;
        if (this._shape == null)
          return;
        this._shape.Visible = value;
      }
    }

    public virtual IShape Shape
    {
      get => this._shape;
      set
      {
        this._referenceShape = value != null ? value : throw new ApplicationException();
        this._memoryShape = value.Clone() as IShape;
        this._shape = this._memoryShape.Clone() as IShape;
        this.Geometric.Reset();
        this.Geometric.AddPath(value.Geometric, false);
        this.Selected = false;
        this.Visible = false;
      }
    }

    public IShape ReferenceShape => this._referenceShape;

    public PointF MirrorPoint
    {
      get => this._mirrorPoint;
      set
      {
        if (!(this._mirrorPoint == PointF.Empty))
          return;
        this._mirrorPoint = value;
      }
    }

    public HorizontalVersors HorizontalVersor
    {
      get => this._horizontalVersor;
      set => this._horizontalVersor = value;
    }

    public VerticalVersors VerticalVersor
    {
      get => this._verticalVersor;
      set => this._verticalVersor = value;
    }

    protected bool HorizontalMirror
    {
      get => this._horizontalMirror;
      set => this._horizontalMirror = value;
    }

    protected bool VerticalMirror
    {
      get => this._verticalMirror;
      set => this._verticalMirror = value;
    }

    protected virtual void UpdateVersors(PointF mirrorPoint, Point currentPoint)
    {
      if (this._mirrorPoint == PointF.Empty)
        return;
      HorizontalVersors horizontalVersor = this.GetHorizontalVersor(currentPoint);
      VerticalVersors verticalVersor = this.GetVerticalVersor(currentPoint);
      if (this._horizontalVersor != horizontalVersor && horizontalVersor != HorizontalVersors.Undefined && this._horizontalMirror)
      {
        this.Transformer.MirrorHorizontal(mirrorPoint.X);
        this._horizontalVersor = horizontalVersor;
      }
      if (this._verticalVersor == verticalVersor || verticalVersor == VerticalVersors.Undefined || !this._verticalMirror)
        return;
      this.Transformer.MirrorVertical(mirrorPoint.Y);
      this._verticalVersor = verticalVersor;
    }

    protected HorizontalVersors GetHorizontalVersor(Point point)
    {
      if ((double) point.X < (double) this._mirrorPoint.X)
        return HorizontalVersors.RightLeft;
      return (double) point.X > (double) this._mirrorPoint.X ? HorizontalVersors.LeftRight : HorizontalVersors.Undefined;
    }

    protected VerticalVersors GetVerticalVersor(Point point)
    {
      if ((double) point.Y < (double) this._mirrorPoint.Y)
        return VerticalVersors.BottomTop;
      return (double) point.Y > (double) this._mirrorPoint.Y ? VerticalVersors.TopBottom : VerticalVersors.Undefined;
    }

    protected void InitializeVersors(HitPositions hitPosition)
    {
      this._horizontalMirror = true;
      this._verticalMirror = true;
      switch (hitPosition)
      {
        case HitPositions.TopLeft:
          this._horizontalVersor = HorizontalVersors.RightLeft;
          this._verticalVersor = VerticalVersors.BottomTop;
          break;
        case HitPositions.Top:
          this._horizontalVersor = HorizontalVersors.LeftRight;
          this._verticalVersor = VerticalVersors.BottomTop;
          this._horizontalMirror = false;
          break;
        case HitPositions.TopRight:
          this._horizontalVersor = HorizontalVersors.LeftRight;
          this._verticalVersor = VerticalVersors.BottomTop;
          break;
        case HitPositions.Right:
          this._horizontalVersor = HorizontalVersors.LeftRight;
          this._verticalVersor = VerticalVersors.TopBottom;
          this._verticalMirror = false;
          break;
        case HitPositions.BottomRight:
          this._horizontalVersor = HorizontalVersors.LeftRight;
          this._verticalVersor = VerticalVersors.TopBottom;
          break;
        case HitPositions.Bottom:
          this._horizontalVersor = HorizontalVersors.LeftRight;
          this._verticalVersor = VerticalVersors.TopBottom;
          this._horizontalMirror = false;
          break;
        case HitPositions.BottomLeft:
          this._horizontalVersor = HorizontalVersors.RightLeft;
          this._verticalVersor = VerticalVersors.TopBottom;
          break;
        case HitPositions.Left:
          this._horizontalVersor = HorizontalVersors.RightLeft;
          this._verticalVersor = VerticalVersors.TopBottom;
          this._verticalMirror = false;
          break;
      }
    }

    private void Transformer_MirrorHorizontalOccurred(Transformer transformer, float x)
    {
      if (this._shape == null)
        return;
      this._shape.Transformer.MirrorHorizontal(x);
    }

    private void Transformer_MirrorVerticalOccurred(Transformer transformer, float y)
    {
      if (this._shape == null)
        return;
      this._shape.Transformer.MirrorVertical(y);
    }
  }
}
