// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Tool
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public abstract class Tool : IActions
  {
    private bool _mousePressed;
    private Point _mouseDownPoint = Point.Empty;
    private Point _mouseUpPoint = Point.Empty;
    private Ghost _ghost = new Ghost();

    public bool MousePressed
    {
      get => this._mousePressed;
      protected set => this._mousePressed = value;
    }

    public Point MouseDownPoint
    {
      get => this._mouseDownPoint;
      set => this._mouseDownPoint = value;
    }

    public Point MouseUpPoint
    {
      get => this._mouseUpPoint;
      set => this._mouseUpPoint = value;
    }

    protected Ghost Ghost
    {
      get => this._ghost;
      set => this._ghost = value;
    }

    public virtual void MouseDown(IDocument document, MouseEventArgs e)
    {
      this._mousePressed = true;
      this._mouseDownPoint = e.Location;
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseDown(document, e);
    }

    public virtual void MouseUp(IDocument document, MouseEventArgs e)
    {
      this._mousePressed = false;
      this._mouseUpPoint = e.Location;
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseUp(document, e);
    }

    public virtual void MouseClick(IDocument document, MouseEventArgs e)
    {
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseClick(document, e);
    }

    public virtual void MouseDoubleClick(IDocument document, MouseEventArgs e)
    {
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseDoubleClick(document, e);
    }

    public virtual void MouseMove(IDocument document, MouseEventArgs e)
    {
      this.UpdateCursor(document, document.Shapes, e.Location);
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseMove(document, e);
    }

    public virtual void MouseWheel(IDocument document, MouseEventArgs e)
    {
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.MouseWheel(document, e);
    }

    public virtual void Paint(IDocument document, PaintEventArgs e)
    {
      foreach (IActions shape in (Collection<IShape>) document.Shapes)
        shape.Paint(document, e);
    }

    public virtual bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point) => false;
  }
}
