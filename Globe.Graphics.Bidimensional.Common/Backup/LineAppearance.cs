// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.LineAppearance
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("lineAppearance")]
  public class LineAppearance : Appearance
  {
    public LineAppearance()
    {
    }

    public LineAppearance(LineAppearance lineAppearance)
      : base((Appearance) lineAppearance)
    {
    }

    public override object Clone() => (object) new LineAppearance(this);
  }
}
