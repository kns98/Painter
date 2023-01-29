// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Rotate
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class Rotate : Select
  {
    private float _degree;
    private Image _hand = new Image();
    private Point _oldMouseLocation = new Point();
    private bool _centered = true;
    private float _step = 50f;

    public Rotate()
    {
      this._hand.Bitmap = Resource.Rotate.ToBitmap();
      this._hand.Selected = true;
      this._hand.Dimension = (SizeF) new Size(9, 9);
      this.Ghost = (Ghost) new GhostCollection();
    }

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      if (Control.ModifierKeys != Keys.Control)
      {
        base.MouseDown(document, e);
      }
      else
      {
        this._centered = false;
        this.MousePressed = true;
        this.MouseDownPoint = e.Location;
        int num = (int) this.SelectShape(document.Shapes, e.Location);
        foreach (IActions shape in (Collection<IShape>) document.Shapes)
          shape.MouseDown(document, e);
      }
      (this.Ghost as GhostCollection).Ghosts = Select.GetSelectedShapes(document.Shapes);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      foreach (IShape shape in (Collection<IShape>) document.Shapes)
      {
        PointF point = PointF.Empty;
        point = !this._centered ? (PointF) this.MouseDownPoint : new PointF((float) ((double) shape.Location.X + (double) shape.Dimension.Width / 2.0 - 3.0), (float) ((double) shape.Location.Y + (double) shape.Dimension.Height / 2.0 - 3.0));
        shape.Transformer.Rotate(this._degree, point);
      }
      base.MouseUp(document, e);
      this._degree = 0.0f;
      this._centered = true;
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (!this.MousePressed)
        return;
      PointF point = PointF.Empty;
      point = !this._centered || Select.LastSelectedShape == null ? (PointF) this.MouseDownPoint : new PointF((float) ((double) Select.LastSelectedShape.Location.X + (double) Select.LastSelectedShape.Dimension.Width / 2.0 - 3.0), (float) ((double) Select.LastSelectedShape.Location.Y + (double) Select.LastSelectedShape.Dimension.Height / 2.0 - 3.0));
      float degree = this.GetDegree(point.X, (float) this._oldMouseLocation.X, (float) e.X, this._step);
      this._degree += degree;
      this.Ghost.Transformer.Rotate(degree, point);
      this.Ghost.MouseMove(document, e);
      document.DrawingControl.Invalidate();
      this._oldMouseLocation = e.Location;
      base.MouseMove(document, e);
    }

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      base.Paint(document, e);
      if (!this.MousePressed)
        return;
      PointF pointF = PointF.Empty;
      pointF = !this._centered || Select.LastSelectedShape == null ? (PointF) this.MouseDownPoint : new PointF((float) ((double) Select.LastSelectedShape.Location.X + (double) Select.LastSelectedShape.Dimension.Width / 2.0 - 3.0), (float) ((double) Select.LastSelectedShape.Location.Y + (double) Select.LastSelectedShape.Dimension.Height / 2.0 - 3.0));
      this._hand.Location = pointF;
      this._hand.Paint(document, e);
      this.Ghost.Paint(document, e);
    }

    public bool Centered => this._centered;

    public float Step
    {
      get => this._step;
      set
      {
        this._step = value;
        if ((double) this._step < 1.0)
          this._step = 1f;
        if ((double) this._step <= 360.0)
          return;
        this._step = 360f;
      }
    }

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      bool flag = false;
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (shape.HitTest(point) != HitPositions.None)
        {
          document.ActiveCursor = Cursors.Hand;
          flag = true;
          break;
        }
      }
      return flag;
    }

    protected float GetDegree(float referenceX, float oldX, float currentX, float step)
    {
      float degree = (currentX - referenceX) / step;
      if ((double) currentX > (double) referenceX)
      {
        if ((double) oldX > (double) currentX)
          degree = -degree;
      }
      else if ((double) oldX < (double) currentX)
        degree = -degree;
      return degree;
    }
  }
}
