// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.GhostAppearance
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("ghostAppearance")]
  public class GhostAppearance : PolygonAppearance
  {
    public GhostAppearance()
    {
    }

    public GhostAppearance(GhostAppearance ghostAppearance)
      : base((PolygonAppearance) ghostAppearance)
    {
    }

    public override object Clone() => (object) new GhostAppearance(this);

    protected override void DrawSelection(IDocument document, PaintEventArgs e)
    {
      if (!this.Shape.Visible || !this.IsValidGeometric(this.Shape.Geometric))
        return;
      Rectangle outsideRect = Rectangle.Round(this.Shape.Geometric.GetBounds());
      Rectangle insideRect = outsideRect;
      outsideRect.Inflate(this.GrabberDimension / 2, this.GrabberDimension / 2);
      insideRect.Inflate(-this.GrabberDimension / 2, -this.GrabberDimension / 2);
      ControlPaint.DrawSelectionFrame(e.Graphics, true, outsideRect, insideRect, document.DrawingControl.BackColor);
    }

    protected virtual void UpdateActivePen(Color backColor) => this.ActivePen = new Pen(Color.Black, 2f);
  }
}
