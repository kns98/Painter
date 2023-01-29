// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.CustomShape
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System.Drawing.Drawing2D;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("customShape")]
  public class CustomShape : Shape
  {
    public CustomShape()
    {
    }

    public CustomShape(CustomShape customShape)
      : base((Shape) customShape)
    {
    }

    public CustomShape(GraphicsPath geometric)
      : base(geometric)
    {
    }

    public override object Clone() => (object) new CustomShape(this);
  }
}
