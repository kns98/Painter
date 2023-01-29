// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.DrawFreeLine
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class DrawFreeLine : DrawSloppedLine
  {
    private float _offset = 5f;

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this.MousePressed = false;
      IShape drawingShape = this.CreateDrawingShape();
      if (drawingShape == null)
        return;
      document.Shapes.Add(drawingShape);
      this.Points.Clear();
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      if (!this.MousePressed)
        return;
      PointF point1 = new PointF((float) e.Location.X, (float) e.Location.Y);
      PointF roundedPoint = document.GridManager.GetRoundedPoint(point1);
      if (this.Points.Count > 0)
      {
        PointF point2 = this.Points[this.Points.Count - 1];
        if ((double) Math.Abs(point2.X - roundedPoint.X) < (double) this._offset && (double) Math.Abs(point2.Y - roundedPoint.Y) < (double) this._offset)
          return;
      }
      this.Points.Add(roundedPoint);
      base.MouseMove(document, e);
    }

    public float Offset
    {
      get => this._offset;
      set => this._offset = value;
    }
  }
}
