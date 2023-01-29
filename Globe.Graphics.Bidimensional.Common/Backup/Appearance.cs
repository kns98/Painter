// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Appearance
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
  [XmlClassSerializable("appearance")]
  public abstract class Appearance : ICloneable
  {
    private IShape _shape;
    private int _markerDimension = 4;
    private Color _markerColor = Color.Black;
    private Pen _activePen = new Pen(Color.Black);
    private Color _borderColor = Color.Black;
    private float _borderWidth = 1f;
    private int _grabberDimension = 6;

    [XmlFieldSerializable("penWidth")]
    private float PenWidth
    {
      get => this._activePen.Width;
      set => this._activePen.Width = value;
    }

    [XmlFieldSerializable("PenColorString")]
    private string PenColorString
    {
      get => Globe.Core.Converters.ColorConverter.StringFromColor(this._activePen.Color, ';');
      set => this._activePen.Color = Globe.Core.Converters.ColorConverter.ColorFromString(value, ';');
    }

    [XmlFieldSerializable("borderColorString")]
    private string BorderColorString
    {
      get => Globe.Core.Converters.ColorConverter.StringFromColor(this._borderColor, ';');
      set => this._borderColor = Globe.Core.Converters.ColorConverter.ColorFromString(value, ';');
    }

    [XmlFieldSerializable("markerColorString")]
    private string MarkerColorString
    {
      get => Globe.Core.Converters.ColorConverter.StringFromColor(this._markerColor, ';');
      set => this._markerColor = Globe.Core.Converters.ColorConverter.ColorFromString(value, ';');
    }

    public virtual event AppearanceHandler AppearanceChanged;

    public virtual event MarkerDimensionHandler MarkerDimensionChanged;

    public virtual event MarkerColorHandler MarkerColorChanged;

    public virtual event BorderColorHandler BorderColorChanged;

    public virtual event BorderWidthHandler BorderWidthChanged;

    public virtual event GrabberDimensionHandler GrabberDimensionChanged;

    public virtual event ActivePenHandler ActivePenChanged;

    public Appearance()
    {
    }

    public Appearance(Appearance appearance)
    {
      this._markerDimension = appearance._markerDimension;
      this._markerColor = appearance._markerColor;
      this._borderColor = appearance._borderColor;
      this._borderWidth = appearance._borderWidth;
      this._grabberDimension = appearance._grabberDimension;
      this._activePen = appearance._activePen.Clone() as Pen;
    }

    [Browsable(false)]
    public IShape Shape
    {
      get => this._shape;
      set => this._shape = value;
    }

    [XmlFieldSerializable("markerDimension")]
    public int MarkerDimension
    {
      get => this._markerDimension;
      set
      {
        int markerDimension = this._markerDimension;
        this._markerDimension = value;
        if (this._markerDimension < 4)
          this._markerDimension = 4;
        if (this.MarkerDimensionChanged != null && markerDimension != this._markerDimension)
          this.MarkerDimensionChanged(this, markerDimension, this._markerDimension);
        if (this.AppearanceChanged == null || markerDimension == this._markerDimension)
          return;
        this.AppearanceChanged(this);
      }
    }

    public Color MarkerColor
    {
      get => this._markerColor;
      set
      {
        Color markerColor = this._markerColor;
        this._markerColor = value;
        if (this.MarkerColorChanged != null && markerColor != this._markerColor)
          this.MarkerColorChanged(this, markerColor, this._markerColor);
        if (this.AppearanceChanged == null || !(markerColor != this._markerColor))
          return;
        this.AppearanceChanged(this);
      }
    }

    [Browsable(false)]
    public Pen ActivePen
    {
      get => this._activePen;
      set
      {
        if (this._activePen == null)
          throw new ApplicationException();
        if (this.ActivePenChanged != null && this._activePen != value)
          this.ActivePenChanged(this, this._activePen, value);
        if (this.AppearanceChanged != null && this._activePen != value)
          this.AppearanceChanged(this);
        this._activePen = value;
      }
    }

    public Color BorderColor
    {
      get => this._borderColor;
      set
      {
        Color borderColor = this._borderColor;
        this._borderColor = value;
        if (this._activePen != null)
          this._activePen.Color = value;
        if (this.BorderColorChanged != null && borderColor != this._borderColor)
          this.BorderColorChanged(this, borderColor, this._borderColor);
        if (this.AppearanceChanged == null || !(borderColor != this._borderColor))
          return;
        this.AppearanceChanged(this);
      }
    }

    [XmlFieldSerializable("borderWidth")]
    public float BorderWidth
    {
      get => this._borderWidth;
      set
      {
        float borderWidth = this._borderWidth;
        this._borderWidth = value;
        if (this._activePen != null)
          this._activePen.Width = value;
        if (this.BorderWidthChanged != null && (double) borderWidth != (double) this._borderWidth)
          this.BorderWidthChanged(this, borderWidth, this._borderWidth);
        if (this.AppearanceChanged == null || (double) borderWidth == (double) this._borderWidth)
          return;
        this.AppearanceChanged(this);
      }
    }

    [XmlFieldSerializable("grabberDimension")]
    public int GrabberDimension
    {
      get => this._grabberDimension;
      set
      {
        int grabberDimension = this._grabberDimension;
        this._grabberDimension = value;
        if (this._grabberDimension < 3)
          this._grabberDimension = 3;
        if (this.GrabberDimensionChanged != null && grabberDimension != this._grabberDimension)
          this.GrabberDimensionChanged(this, grabberDimension, this._grabberDimension);
        if (this.AppearanceChanged == null || grabberDimension == this._grabberDimension)
          return;
        this.AppearanceChanged(this);
      }
    }

    public abstract object Clone();

    public virtual void Paint(IDocument document, PaintEventArgs e)
    {
      if (!this._shape.Visible || !this.IsValidGeometric(this._shape.Geometric))
        return;
      float width = this._shape.Dimension.Width;
      float height = this._shape.Dimension.Height;
      if ((double) width == 1.0)
        e.Graphics.DrawLine(this._activePen, Point.Round(new PointF(this._shape.Location.X, this._shape.Location.Y)), Point.Round(new PointF(this._shape.Location.X, this._shape.Location.Y + this._shape.Dimension.Height)));
      else if ((double) height == 1.0)
        e.Graphics.DrawLine(this._activePen, Point.Round(new PointF(this._shape.Location.X, this._shape.Location.Y)), Point.Round(new PointF(this._shape.Location.X + this._shape.Dimension.Width, this._shape.Location.Y)));
      else
        e.Graphics.DrawPath(this._activePen, this._shape.Geometric);
      this.DrawSelection(document, e);
      this.DrawMarkers(document, e);
    }

    protected virtual void DrawSelection(IDocument document, PaintEventArgs e)
    {
      if (!this._shape.Selected || !this.IsValidGeometric(this._shape.Geometric))
        return;
      Rectangle outsideRect = Rectangle.Round(this._shape.Geometric.GetBounds());
      Rectangle insideRect = outsideRect;
      outsideRect.Inflate(this._grabberDimension / 2, this._grabberDimension / 2);
      insideRect.Inflate(-this._grabberDimension / 2, -this._grabberDimension / 2);
      ControlPaint.DrawSelectionFrame(e.Graphics, true, outsideRect, insideRect, document.DrawingControl.BackColor);
      Color color = Color.Black;
      if (Select.LastSelectedShape == this._shape)
        color = ControlPaint.LightLight(color);
      using (SolidBrush solidBrush = new SolidBrush(color))
      {
        foreach (Rectangle grabber in this._shape.GetGrabbers())
          e.Graphics.FillRectangle((Brush) solidBrush, grabber);
      }
    }

    protected virtual void DrawMarkers(IDocument document, PaintEventArgs e)
    {
      if (!this._shape.Marked || !this.IsValidGeometric(this._shape.Geometric))
        return;
      foreach (PointF pathPoint in this._shape.Geometric.PathPoints)
      {
        RectangleF rectangleF = new RectangleF(pathPoint.X - (float) (this.MarkerDimension / 2), pathPoint.Y - (float) (this.MarkerDimension / 2), (float) this.MarkerDimension, (float) this.MarkerDimension);
        using (Brush brush = (Brush) new SolidBrush(this.MarkerColor))
          e.Graphics.FillRectangle(brush, Rectangle.Round(rectangleF));
      }
    }

    protected bool IsValidGeometric(GraphicsPath geometric) => (double) geometric.GetBounds().Size.Width != 0.0 && (double) geometric.GetBounds().Size.Height != 0.0;
  }
}
