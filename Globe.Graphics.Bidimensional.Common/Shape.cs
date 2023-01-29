// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Shape
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("shape")]
  public abstract class Shape : IShape, ICloneable, IActions
  {
    private PointF[] _geometricPoints;
    private byte[] _geometricTypes;
    internal float _rotation;
    private bool _visible = true;
    private bool _locked;
    private bool _selected;
    private GraphicsPath _geometric = new GraphicsPath();
    private Transformer _transformer;
    private Appearance _appearance = (Appearance) new PolygonAppearance();
    private bool _marked;
    private IShape _parent;
    private ContextMenuStrip _menu;

    [XmlFieldSerializable("geometricPoints")]
    private PointF[] GeometricPoints
    {
      get => this._geometric.PathPoints;
      set
      {
        this._geometricPoints = value;
        if (this._geometricPoints == null || this._geometricTypes == null)
          return;
        this._geometric = new GraphicsPath(this._geometricPoints, this._geometricTypes);
      }
    }

    [XmlFieldSerializable("geometricTypes")]
    private byte[] GeometricTypes
    {
      get => this._geometric.PathTypes;
      set
      {
        this._geometricTypes = value;
        if (this._geometricPoints == null || this._geometricTypes == null)
          return;
        this._geometric = new GraphicsPath(this._geometricPoints, this._geometricTypes);
      }
    }

    [XmlFieldSerializable("locationX")]
    private float LocationX
    {
      get => this.Location.X;
      set => this.Location = new PointF(value, this.Location.Y);
    }

    [XmlFieldSerializable("locationY")]
    private float LocationY
    {
      get => this.Location.Y;
      set => this.Location = new PointF(this.Location.X, value);
    }

    [XmlFieldSerializable("width")]
    private float Width
    {
      get => this.Dimension.Width;
      set => this.Dimension = new SizeF(value, this.Dimension.Height);
    }

    [XmlFieldSerializable("height")]
    private float Height
    {
      get => this.Dimension.Height;
      set => this.Dimension = new SizeF(this.Dimension.Width, value);
    }

    protected Shape() => this._transformer = new Transformer((IShape) this);

    protected Shape(Shape shape)
    {
      this._geometric = shape.Geometric.Clone() as GraphicsPath;
      this._transformer = new Transformer((IShape) this);
      this._appearance = shape.Appearance.Clone() as Appearance;
      this._visible = shape.Visible;
      this._locked = shape.Locked;
      this._selected = shape.Selected;
      this._marked = shape.Marked;
      this._menu = shape.Menu;
    }

    protected Shape(GraphicsPath geometric)
    {
      this._transformer = new Transformer((IShape) this);
      this._geometric = geometric.Clone() as GraphicsPath;
    }

    public abstract object Clone();

    public virtual void MouseDown(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseDown == null)
        return;
      this.ShapeMouseDown((IShape) this, document, e);
    }

    public virtual void MouseUp(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseUp == null)
        return;
      this.ShapeMouseUp((IShape) this, document, e);
    }

    public virtual void MouseClick(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseClick == null)
        return;
      this.ShapeMouseClick((IShape) this, document, e);
    }

    public virtual void MouseDoubleClick(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseDoubleClick == null)
        return;
      this.ShapeMouseDoubleClick((IShape) this, document, e);
    }

    public virtual void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseMove == null)
        return;
      this.ShapeMouseMove((IShape) this, document, e);
    }

    public virtual void MouseWheel(IDocument document, MouseEventArgs e)
    {
      if (this.ShapeMouseWheel == null)
        return;
      this.ShapeMouseWheel((IShape) this, document, e);
    }

    public virtual void Paint(IDocument document, PaintEventArgs e)
    {
      this._appearance.Shape = (IShape) this;
      this._appearance.Paint(document, e);
      if (this.ShapePaint == null)
        return;
      this.ShapePaint((IShape) this, document, e);
    }

    public virtual event ShapeChangingHandler ShapeChanged;

    public virtual event MouseDownOnShape ShapeMouseDown;

    public virtual event MouseUpOnShape ShapeMouseUp;

    public virtual event MouseClickOnShape ShapeMouseClick;

    public virtual event MouseDoubleClickOnShape ShapeMouseDoubleClick;

    public virtual event MouseMoveOnShape ShapeMouseMove;

    public virtual event Globe.Graphics.Bidimensional.Common.MouseWheel ShapeMouseWheel;

    public virtual event PaintOnShape ShapePaint;

    [TypeConverter(typeof (PointFTypeConverter))]
    public PointF Location
    {
      get => this._geometric.GetBounds().Location;
      set
      {
        if (value.IsEmpty || float.IsNaN(value.X) || float.IsNaN(value.Y) || float.IsInfinity(value.Y) || float.IsInfinity(value.Y))
          return;
        this._transformer.Translate(value.X - this.Location.X, value.Y - this.Location.Y);
      }
    }

    [TypeConverter(typeof (SizeFTypeConverter))]
    public SizeF Dimension
    {
      get => this._geometric.GetBounds().Size;
      set
      {
        if (value.IsEmpty)
          return;
        this._transformer.Scale(value.Width / this.Dimension.Width, value.Height / this.Dimension.Height);
      }
    }

    [TypeConverter(typeof (PointFTypeConverter))]
    public PointF Center
    {
      get => new PointF(this.Location.X + this.Dimension.Width / 2f, this.Location.Y + this.Dimension.Height / 2f);
      set => this._transformer.Translate((float) ((double) value.X - (double) this.Location.X - (double) this.Dimension.Width / 2.0), (float) ((double) value.Y - (double) this.Location.Y - (double) this.Dimension.Height / 2.0));
    }

    [XmlFieldSerializable("rotation")]
    public float Rotation
    {
      get => this._rotation;
      set
      {
        this._rotation += value;
        this._transformer.Rotate(value);
      }
    }

    [XmlFieldSerializable("visible")]
    public virtual bool Visible
    {
      get => this._visible;
      set => this._visible = value;
    }

    public virtual bool Locked
    {
      get => this._locked;
      set => this._locked = value;
    }

    public virtual bool Selected
    {
      get => this._selected;
      set => this._selected = value;
    }

    [Browsable(false)]
    public GraphicsPath Geometric => this._geometric;

    [Browsable(false)]
    public Transformer Transformer
    {
      get => this._transformer;
      set => this._transformer = value;
    }

    [XmlFieldSerializable("Appearance")]
    [TypeConverter(typeof (AppearanceTypeConverter))]
    public Appearance Appearance
    {
      get => this._appearance;
      set => this._appearance = value;
    }

    [XmlFieldSerializable("marked")]
    public bool Marked
    {
      get => this._marked;
      set
      {
        bool marked = this._marked;
        this._marked = value;
        if (this.ShapeChanged == null || marked == this._marked)
          return;
        this.ShapeChanged((IShape) this, (object) this._marked);
      }
    }

    [Browsable(false)]
    public IShape Parent
    {
      get => this._parent;
      internal set => this._parent = value;
    }

    [Browsable(false)]
    public ContextMenuStrip Menu
    {
      get => this._menu;
      set
      {
        this._menu = value;
        if (this.ShapeChanged == null)
          return;
        this.ShapeChanged((IShape) this, (object) this._menu);
      }
    }

    public virtual HitPositions HitTest(Point point)
    {
      HitPositions hitPositions = HitPositions.None;
      Rectangle[] grabbers = this.GetGrabbers();
      if (grabbers[0].Contains(point))
        hitPositions = HitPositions.TopLeft;
      else if (grabbers[1].Contains(point))
        hitPositions = HitPositions.Top;
      else if (grabbers[2].Contains(point))
        hitPositions = HitPositions.TopRight;
      else if (grabbers[3].Contains(point))
        hitPositions = HitPositions.Right;
      else if (grabbers[4].Contains(point))
        hitPositions = HitPositions.BottomRight;
      else if (grabbers[5].Contains(point))
        hitPositions = HitPositions.Bottom;
      else if (grabbers[6].Contains(point))
        hitPositions = HitPositions.BottomLeft;
      else if (grabbers[7].Contains(point))
        hitPositions = HitPositions.Left;
      else if (this.Contains(point))
        hitPositions = HitPositions.Center;
      return hitPositions;
    }

    public bool Contains(Point point) => this._geometric.GetBounds().Contains((PointF) point);

    public bool Contains(IShape shape) => this._geometric.GetBounds().Contains(shape.Geometric.GetBounds());

    public RectangleF[] GetMarkers()
    {
      if (this._geometric.PointCount == 0)
        return (RectangleF[]) null;
      RectangleF[] markers = new RectangleF[this._geometric.PointCount];
      for (int index = 0; index < this._geometric.PointCount; ++index)
        markers[index] = new RectangleF(this._geometric.PathPoints[index].X - (float) (this._appearance.MarkerDimension / 2), this._geometric.PathPoints[index].Y - (float) (this._appearance.MarkerDimension / 2), (float) this._appearance.MarkerDimension, (float) this._appearance.MarkerDimension);
      return markers;
    }

    public virtual Rectangle[] GetGrabbers()
    {
      Rectangle rectangle = Rectangle.Round(this._geometric.GetBounds());
      Rectangle[] grabbers = new Rectangle[8];
      grabbers[0].X = rectangle.X - this._appearance.GrabberDimension / 2;
      grabbers[0].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
      grabbers[0].Width = this._appearance.GrabberDimension;
      grabbers[0].Height = this._appearance.GrabberDimension;
      grabbers[1].X = rectangle.X + rectangle.Width / 2 - this._appearance.GrabberDimension / 2;
      grabbers[1].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
      grabbers[1].Width = this._appearance.GrabberDimension;
      grabbers[1].Height = this._appearance.GrabberDimension;
      grabbers[2].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
      grabbers[2].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
      grabbers[2].Width = this._appearance.GrabberDimension;
      grabbers[2].Height = this._appearance.GrabberDimension;
      grabbers[3].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
      grabbers[3].Y = rectangle.Y + rectangle.Height / 2 - this._appearance.GrabberDimension / 2;
      grabbers[3].Width = this._appearance.GrabberDimension;
      grabbers[3].Height = this._appearance.GrabberDimension;
      grabbers[4].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
      grabbers[4].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
      grabbers[4].Width = this._appearance.GrabberDimension;
      grabbers[4].Height = this._appearance.GrabberDimension;
      grabbers[5].X = rectangle.X + rectangle.Width / 2 - this._appearance.GrabberDimension / 2;
      grabbers[5].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
      grabbers[5].Width = this._appearance.GrabberDimension;
      grabbers[5].Height = this._appearance.GrabberDimension;
      grabbers[6].X = rectangle.X - this._appearance.GrabberDimension / 2;
      grabbers[6].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
      grabbers[6].Width = this._appearance.GrabberDimension;
      grabbers[6].Height = this._appearance.GrabberDimension;
      grabbers[7].X = rectangle.X - this._appearance.GrabberDimension / 2;
      grabbers[7].Y = rectangle.Y + rectangle.Height / 2 - this._appearance.GrabberDimension / 2;
      grabbers[7].Width = this._appearance.GrabberDimension;
      grabbers[7].Height = this._appearance.GrabberDimension;
      return grabbers;
    }

    public int GetMarkerIndex(PointF point)
    {
      RectangleF[] markers = this.GetMarkers();
      if (markers == null)
        return -1;
      for (int markerIndex = 0; markerIndex < markers.Length; ++markerIndex)
      {
        if (markers[markerIndex].Contains(point))
          return markerIndex;
      }
      return -1;
    }

    public virtual PointF GetGrabberPoint(HitPositions hitPosition)
    {
      if (hitPosition == HitPositions.Right || hitPosition == HitPositions.BottomRight || hitPosition == HitPositions.Bottom)
        return new PointF(this.Location.X, this.Location.Y);
      if (hitPosition == HitPositions.BottomLeft || hitPosition == HitPositions.Left)
        return new PointF(this.Location.X + this.Dimension.Width, this.Location.Y);
      if (hitPosition == HitPositions.TopLeft || hitPosition == HitPositions.Top || hitPosition == HitPositions.Left)
        return new PointF(this.Location.X + this.Dimension.Width, this.Location.Y + this.Dimension.Height);
      return hitPosition == HitPositions.TopRight ? new PointF(this.Location.X, this.Location.Y + this.Dimension.Height) : new PointF(0.0f, 0.0f);
    }
  }
}
