// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Ellipse
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using Globe.Xml.Serialization;

namespace Globe.Graphics.Bidimensional.Base
{
  [XmlClassSerializable("ellipse")]
  public class Ellipse : Shape
  {
    public Ellipse() => this.Geometric.AddEllipse(new System.Drawing.Rectangle(0, 0, 1, 1));

    public Ellipse(Ellipse ellipse)
      : base((Shape) ellipse)
    {
    }

    public override object Clone() => (object) new Ellipse(this);
  }
}
