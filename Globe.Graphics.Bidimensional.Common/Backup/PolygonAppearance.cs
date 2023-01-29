// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.PolygonAppearance
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("polygonAppearance")]
  public class PolygonAppearance : Appearance
  {
    private Color _backgroundColor1 = Color.Transparent;
    private Color _backgroundColor2 = Color.Transparent;
    private float _gradientAngle;

    [XmlFieldSerializable("backgroundColor1String")]
    private string BackGroundColor1String
    {
      get => Globe.Core.Converters.ColorConverter.StringFromColor(this._backgroundColor1, ';');
      set => this._backgroundColor1 = Globe.Core.Converters.ColorConverter.ColorFromString(value, ';');
    }

    [XmlFieldSerializable("backgroundColor2String")]
    private string BackGroundColor2String
    {
      get => Globe.Core.Converters.ColorConverter.StringFromColor(this._backgroundColor2, ';');
      set => this._backgroundColor2 = Globe.Core.Converters.ColorConverter.ColorFromString(value, ';');
    }

    public override event AppearanceHandler AppearanceChanged;

    public virtual event BackgroundColor1Handler BackgroundColor1Changed;

    public virtual event BackgroundColor2Handler BackgroundColor2Changed;

    public virtual event GradientAngleHandler GradientAngleChanged;

    public PolygonAppearance()
    {
    }

    public PolygonAppearance(PolygonAppearance polygonAppearance)
      : base((Appearance) polygonAppearance)
    {
      this._backgroundColor1 = polygonAppearance._backgroundColor1;
      this._backgroundColor2 = polygonAppearance._backgroundColor2;
      this._gradientAngle = polygonAppearance._gradientAngle;
    }

    public Color BackgroundColor1
    {
      get => this._backgroundColor1;
      set
      {
        Color backgroundColor1 = this._backgroundColor1;
        this._backgroundColor1 = value;
        if (this.BackgroundColor1Changed != null && backgroundColor1 != this._backgroundColor1)
          this.BackgroundColor1Changed((Appearance) this, backgroundColor1, this._backgroundColor1);
        if (this.AppearanceChanged == null || !(backgroundColor1 != this._backgroundColor1))
          return;
        this.AppearanceChanged((Appearance) this);
      }
    }

    public Color BackgroundColor2
    {
      get => this._backgroundColor2;
      set
      {
        Color backgroundColor2 = this._backgroundColor2;
        this._backgroundColor2 = value;
        if (this.BackgroundColor2Changed != null && backgroundColor2 != this._backgroundColor2)
          this.BackgroundColor2Changed((Appearance) this, backgroundColor2, this._backgroundColor2);
        if (this.AppearanceChanged == null || !(backgroundColor2 != this._backgroundColor2))
          return;
        this.AppearanceChanged((Appearance) this);
      }
    }

    [XmlFieldSerializable("gradientAngle")]
    public float GradientAngle
    {
      get => this._gradientAngle;
      set
      {
        float gradientAngle = this._gradientAngle;
        this._gradientAngle = value;
        if (this.GradientAngleChanged != null && (double) gradientAngle != (double) this._gradientAngle)
          this.GradientAngleChanged((Appearance) this, gradientAngle, this._gradientAngle);
        if (this.AppearanceChanged == null || (double) gradientAngle == (double) this._gradientAngle)
          return;
        this.AppearanceChanged((Appearance) this);
      }
    }

    public override object Clone() => (object) new PolygonAppearance(this);

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      base.Paint(document, e);
      this.DrawBackground(document, e);
    }

    protected virtual void DrawBackground(IDocument document, PaintEventArgs e)
    {
      if (!this.IsValidGeometric(this.Shape.Geometric))
        return;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.Shape.Geometric.GetBounds(), this._backgroundColor1, this._backgroundColor2, this._gradientAngle, true))
        e.Graphics.FillPath((Brush) linearGradientBrush, this.Shape.Geometric);
    }
  }
}
