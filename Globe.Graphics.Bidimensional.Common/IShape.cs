// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.IShape
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public interface IShape : ICloneable, IActions
  {
    event ShapeChangingHandler ShapeChanged;

    event MouseDownOnShape ShapeMouseDown;

    event MouseUpOnShape ShapeMouseUp;

    event MouseClickOnShape ShapeMouseClick;

    event MouseDoubleClickOnShape ShapeMouseDoubleClick;

    event MouseMoveOnShape ShapeMouseMove;

    event MouseWheel ShapeMouseWheel;

    event PaintOnShape ShapePaint;

    PointF Location { get; set; }

    SizeF Dimension { get; set; }

    PointF Center { get; set; }

    float Rotation { get; set; }

    bool Visible { get; set; }

    bool Locked { get; set; }

    bool Selected { get; set; }

    GraphicsPath Geometric { get; }

    Transformer Transformer { get; set; }

    Appearance Appearance { get; set; }

    bool Marked { get; set; }

    IShape Parent { get; }

    ContextMenuStrip Menu { get; set; }

    HitPositions HitTest(Point point);

    bool Contains(Point point);

    bool Contains(IShape shape);

    RectangleF[] GetMarkers();

    Rectangle[] GetGrabbers();

    int GetMarkerIndex(PointF point);

    PointF GetGrabberPoint(HitPositions hitPosition);
  }
}
