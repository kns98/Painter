// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Line
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using Globe.Xml.Serialization;
using System.Drawing;

namespace Globe.Graphics.Bidimensional.Base
{
  [XmlClassSerializable("line")]
  public class Line : Shape
  {
    public Line()
    {
      this.Geometric.AddLine(new PointF(0.0f, 0.0f), new PointF(1f, 1f));
      this.Appearance = (Appearance) new LineAppearance();
    }

    public Line(Line line)
      : base((Shape) line)
    {
      this.Appearance = (Appearance) new LineAppearance();
    }

    public Line(PointF start, PointF end)
    {
      if ((double) start.X == (double) end.X)
        end = new PointF(end.X + 1f, end.Y);
      if ((double) start.Y == (double) end.Y)
        end = new PointF(end.X, end.Y + 1f);
      this.Geometric.AddLine(start, end);
      this.Appearance = (Appearance) new LineAppearance();
    }

    public override object Clone() => (object) new Line(this);

    public override HitPositions HitTest(Point point)
    {
      float width = this.Dimension.Width;
      float height = this.Dimension.Height;
      if ((double) width == 1.0 || (double) height == 1.0)
      {
        using (Pen pen = new Pen(Color.Black, (float) this.Appearance.GrabberDimension))
        {
          if (this.Geometric.IsOutlineVisible(point, pen))
            return HitPositions.Center;
        }
      }
      return base.HitTest(point);
    }
  }
}
