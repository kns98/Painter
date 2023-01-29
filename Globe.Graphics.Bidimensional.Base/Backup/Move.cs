// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Move
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class Move : Select
  {
    private Point _oldPoint = Point.Empty;

    public Move() => this.Ghost = (Ghost) new GhostCollection();

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      (this.Ghost as GhostCollection).Ghosts = Select.GetSelectedShapes(document.Shapes);
      (this.Ghost as GhostCollection).ShapeMouseUp += new MouseUpOnShape(this.Move_ShapeMouseUp);
      this.Ghost.MouseDown(document, e);
      this.UpdateCursor(document, Select.GetSelectedShapes(document.Shapes), e.Location);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Ghost.MouseUp(document, e);
      base.MouseUp(document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      base.MouseMove(document, e);
      if (!this.MousePressed)
        return;
      PointF roundedPoint = document.GridManager.GetRoundedPoint((PointF) e.Location);
      this.Ghost.Transformer.Translate(roundedPoint.X - (float) this._oldPoint.X, roundedPoint.Y - (float) this._oldPoint.Y);
      this.Ghost.MouseMove(document, e);
      this._oldPoint = Point.Round(roundedPoint);
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this.Ghost.Paint(document, e);

    public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
    {
      bool flag = false;
      foreach (IShape shape in (Collection<IShape>) shapes)
        flag = shape.HitTest(this.MouseDownPoint) != HitPositions.None && shape.Selected && this.MousePressed;
      document.ActiveCursor = !flag ? Cursors.Default : Cursors.SizeAll;
      return flag;
    }

    protected virtual ShapeCollection GetGhostableShapes(ShapeCollection shapes)
    {
      ShapeCollection ghostableShapes = new ShapeCollection();
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (shape.Selected && !shape.Locked)
          ghostableShapes.Add(shape);
      }
      return ghostableShapes;
    }

    protected virtual void Move_ShapeMouseUp(IShape shape, IDocument document, MouseEventArgs e)
    {
      if (!(shape is Ghost ghost) || ghost is GhostCollection || ghost.ReferenceShape == null)
        return;
      ghost.ReferenceShape.Location = ghost.Location;
    }
  }
}
