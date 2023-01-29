// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.DrawingPanel
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Core.Utilities;
using Globe.Graphics.Bidimensional.Common;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class DrawingPanel : Panel, IDocument
  {
    private bool _zoomCenter = true;
    private Globe.Graphics.Bidimensional.Common.Tool _tool = (Globe.Graphics.Bidimensional.Common.Tool) new Pointer();
    private float _zoom = 1f;
    private bool _enableWheelZoom = true;
    private ShapeCollection _shapes = new ShapeCollection();
    private GridManager _gridManager = new GridManager();

    public DrawingPanel()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this._shapes.ShapeChanged += new ShapeChangingHandler(this._shapes_ShapeChanged);
      this._shapes.ShapeMovementOccurred += new MovementHandler(this._shapes_ShapeMovementOccurred);
      this._shapes.ShapeAppearanceChanged += new AppearanceHandler(this._shapes_ShapeAppearanceChanged);
      this._gridManager.ResolutionChanged += new GridManager.ResolutionChangedHandler(this._gridManager_ResolutionChanged);
      this.Size = new Size(1000, 1000);
    }

    [Browsable(false)]
    public Globe.Graphics.Bidimensional.Common.Tool ActiveTool
    {
      get => this._tool;
      set => this._tool = value != null ? value : throw new ApplicationException();
    }

    public float Zoom
    {
      get => this._zoom;
      set
      {
        this._zoom = (double) value > 0.0 ? value : throw new ApplicationException();
        PointF point = PointF.Empty;
        point = this._zoomCenter ? new PointF((float) ((this.Location.X + this.Size.Width) / 2), (float) ((this.Location.Y + this.Size.Height) / 2)) : (PointF) this.PointToClient(Control.MousePosition);
        foreach (IShape shape in (Collection<IShape>) this._shapes)
        {
          bool selected = shape.Selected;
          bool locked = shape.Locked;
          shape.Selected = true;
          shape.Locked = false;
          shape.Transformer.Scale(this._zoom, this._zoom, point);
          shape.Selected = selected;
          shape.Locked = locked;
        }
        this.Invalidate();
      }
    }

    public bool EnableWheelZoom
    {
      get => this._enableWheelZoom;
      set => this._enableWheelZoom = value;
    }

    [Browsable(false)]
    public Control DrawingControl => (Control) this;

    [Browsable(false)]
    public ShapeCollection Shapes
    {
      get => this._shapes;
      set => this._shapes = value;
    }

    [Browsable(false)]
    public Cursor ActiveCursor
    {
      get => this.Cursor;
      set => this.Cursor = value;
    }

    [TypeConverter(typeof (GridManagerTypeConverter))]
    public GridManager GridManager
    {
      get => this._gridManager;
      protected set => this._gridManager = value;
    }

    public virtual void Undo()
    {
      if (History<ShapeCollection>.IsAtStart())
        return;
      this._shapes.Clear();
      this._shapes.AddRange(History<ShapeCollection>.Undo());
      this.Invalidate();
    }

    public virtual void Redo()
    {
      if (History<ShapeCollection>.IsAtEnd())
        return;
      this._shapes.Clear();
      this._shapes.AddRange(History<ShapeCollection>.Redo());
      this.Invalidate();
    }

    public virtual void Cut()
    {
      History<ShapeCollection>.Memorize(this._shapes);
      Clipboard<ShapeCollection>.Clip = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._shapes);
      this.Delete();
      this.Invalidate();
    }

    public virtual void Copy() => Clipboard<ShapeCollection>.Clip = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._shapes);

    public virtual void Paste()
    {
      History<ShapeCollection>.Memorize(this._shapes);
      foreach (IShape shape in (Collection<IShape>) Clipboard<ShapeCollection>.Clip)
      {
        shape.Location = new PointF(shape.Location.X + 10f, shape.Location.Y + 10f);
        this._shapes.Add(shape.Clone() as IShape);
      }
      this.Invalidate();
    }

    public virtual void Delete()
    {
      History<ShapeCollection>.Memorize(this._shapes);
      for (int index = 0; index < this._shapes.Count; ++index)
      {
        if (this._shapes[index].Selected)
        {
          this._shapes.Remove(this._shapes[index]);
          index = -1;
        }
      }
      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      this.Focus();
      this._tool.MouseDown((IDocument) this, e);
      base.OnMouseDown(e);
      this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      this._tool.MouseUp((IDocument) this, e);
      base.OnMouseUp(e);
      this.Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      this._tool.MouseMove((IDocument) this, e);
      base.OnMouseMove(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      if (!this._enableWheelZoom)
        return;
      this._zoomCenter = false;
      if (Math.Sign(e.Delta) == -1)
        this.Zoom = 0.9f;
      else if (Math.Sign(e.Delta) == 1)
        this.Zoom = 1.1f;
      this._zoomCenter = true;
      base.OnMouseWheel(e);
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape == null)
        return base.ProcessDialogKey(keyData);
      ShapeCollection shapeCollection = new ShapeCollection();
      Keys keys = keyData & Keys.KeyCode;
      if (Control.ModifierKeys == Keys.Control)
        shapeCollection.AddRange(Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._shapes));
      else
        shapeCollection.Add(Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape);
      float offsetX = this._gridManager.Resolution.Width;
      if ((double) this._gridManager.Resolution.Width == 0.0)
        offsetX = 1f;
      float offsetY = this._gridManager.Resolution.Height;
      if ((double) this._gridManager.Resolution.Height == 0.0)
        offsetY = 1f;
      switch (keys)
      {
        case Keys.Left:
          foreach (IShape shape in (Collection<IShape>) shapeCollection)
            shape.Transformer.Translate(-offsetX, 0.0f);
          this.Invalidate();
          break;
        case Keys.Up:
          foreach (IShape shape in (Collection<IShape>) shapeCollection)
            shape.Transformer.Translate(0.0f, -offsetY);
          this.Invalidate();
          break;
        case Keys.Right:
          foreach (IShape shape in (Collection<IShape>) shapeCollection)
            shape.Transformer.Translate(offsetX, 0.0f);
          this.Invalidate();
          break;
        case Keys.Down:
          foreach (IShape shape in (Collection<IShape>) shapeCollection)
            shape.Transformer.Translate(0.0f, offsetY);
          this.Invalidate();
          break;
      }
      return base.ProcessDialogKey(keyData);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.Painting(this._shapes, e);
      this._tool.Paint((IDocument) this, e);
    }

    protected void Painting(ShapeCollection shapes, PaintEventArgs e)
    {
      if (this._gridManager.Resolution != (SizeF) Size.Empty)
        ControlPaint.DrawGrid(e.Graphics, e.ClipRectangle, Size.Round(this._gridManager.Resolution), this.BackColor);
      foreach (IActions shape in (Collection<IShape>) shapes)
        shape.Paint((IDocument) this, e);
    }

    private void _shapes_ShapeChanged(IShape shape, object changing)
    {
      History<ShapeCollection>.Memorize(this._shapes);
      this.Invalidate(System.Drawing.Rectangle.Round(new RectangleF(new PointF(shape.Location.X - (float) shape.Appearance.GrabberDimension, shape.Location.Y - (float) shape.Appearance.GrabberDimension), new SizeF(shape.Dimension.Width + (float) shape.Appearance.GrabberDimension, shape.Dimension.Height + (float) shape.Appearance.GrabberDimension))));
    }

    private void _shapes_ShapeMovementOccurred(Transformer transformer)
    {
      History<ShapeCollection>.Memorize(this._shapes);
      this.Invalidate(System.Drawing.Rectangle.Round(new RectangleF(new PointF(transformer.Shape.Location.X - (float) transformer.Shape.Appearance.GrabberDimension, transformer.Shape.Location.Y - (float) transformer.Shape.Appearance.GrabberDimension), new SizeF(transformer.Shape.Dimension.Width + (float) transformer.Shape.Appearance.GrabberDimension, transformer.Shape.Dimension.Height + (float) transformer.Shape.Appearance.GrabberDimension))));
    }

    private void _shapes_ShapeAppearanceChanged(Globe.Graphics.Bidimensional.Common.Appearance appearance)
    {
      History<ShapeCollection>.Memorize(this._shapes);
      this.Invalidate(System.Drawing.Rectangle.Round(new RectangleF(new PointF(appearance.Shape.Location.X - (float) appearance.Shape.Appearance.GrabberDimension, appearance.Shape.Location.Y - (float) appearance.Shape.Appearance.GrabberDimension), new SizeF(appearance.Shape.Dimension.Width + (float) appearance.Shape.Appearance.GrabberDimension, appearance.Shape.Dimension.Height + (float) appearance.Shape.Appearance.GrabberDimension))));
    }

    private void _gridManager_ResolutionChanged(GridManager sender, SizeF oldValue, SizeF newValue)
    {
      this.GridManager.SnapToGrid(this._shapes);
      this.Invalidate();
    }
  }
}
