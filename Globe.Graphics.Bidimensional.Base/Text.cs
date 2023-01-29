// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Text
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using Globe.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Globe.Graphics.Bidimensional.Base
{
  [XmlClassSerializable("text")]
  public class Text : Shape
  {
    private float _fontSize;
    private FontStyle _fontStyle;
    private GraphicsUnit _fontGraphicUnit = GraphicsUnit.Pixel;
    private string _fontFamily = string.Empty;
    private float _degree;
    private string _displayedText = nameof (Text);
    private Font _font = new Font(FontFamily.GenericSansSerif, 12f);
    private StringFormat _stringFormat = new StringFormat(StringFormatFlags.NoWrap);

    [XmlFieldSerializable("fontSize")]
    private float FontSize
    {
      get => this._font.Size;
      set
      {
        this._fontSize = value;
        this.UpdateAfterLoad();
      }
    }

    [XmlFieldSerializable("fontStyle")]
    private int FontStyleEnum
    {
      get => (int) this._font.Style;
      set
      {
        this._fontStyle = (FontStyle) value;
        this.UpdateAfterLoad();
      }
    }

    [XmlFieldSerializable("fontGraphicsUnit")]
    private int FontGraphicUnitEnum
    {
      get => (int) this._font.Unit;
      set
      {
        this._fontGraphicUnit = (GraphicsUnit) value;
        this.UpdateAfterLoad();
      }
    }

    [XmlFieldSerializable("fontFamily")]
    private string FontFamilyString
    {
      get => this._font.FontFamily.GetName(0);
      set
      {
        this._fontFamily = value;
        this.UpdateAfterLoad();
      }
    }

    private void UpdateAfterLoad()
    {
      if ((double) this._fontSize > 0.0 && this._fontFamily != string.Empty)
        this._font = new Font(new FontFamily(this._fontFamily), this._fontSize, this._fontStyle, this._fontGraphicUnit);
      this.UpdateText();
    }

    public Text()
    {
      this.Geometric.AddString(this._displayedText, this._font.FontFamily, (int) this._font.Style, this._font.Size, this.Geometric.GetBounds(), this._stringFormat);
      this.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
    }

    public Text(Text text)
      : base((Shape) text)
    {
      this._displayedText = text.DisplayedText;
      this._font = text.Font.Clone() as Font;
      this._stringFormat = text.StringFormat.Clone() as StringFormat;
      this._degree = text._degree;
      this.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
    }

    public Text(string text, Font font, StringFormat stringFormat)
    {
      if (text != string.Empty)
        this._displayedText = text;
      this._font = font;
      this._stringFormat = stringFormat;
      this.Geometric.AddString(text, this._font.FontFamily, (int) this._font.Style, this._font.Size, this.Geometric.GetBounds(), this._stringFormat);
      this.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
    }

    public override object Clone() => (object) new Text(this);

    [XmlFieldSerializable("displayedText")]
    public string DisplayedText
    {
      get => this._displayedText;
      set
      {
        this._displayedText = value;
        this.UpdateText();
      }
    }

    public Font Font
    {
      get => this._font;
      set
      {
        this._font = value;
        this.UpdateText();
      }
    }

    public StringFormat StringFormat
    {
      get => this._stringFormat;
      set
      {
        this._stringFormat = value;
        this.UpdateText();
      }
    }

    protected virtual void UpdateText()
    {
      SizeF dimension = this.Dimension;
      PointF location = this.Location;
      float rotation = this.Rotation;
      this.Geometric.Reset();
      this.Geometric.AddString(this._displayedText, this._font.FontFamily, (int) this._font.Style, this._font.Size, this.Geometric.GetBounds(), this._stringFormat);
      Matrix matrix = new Matrix();
      matrix.Rotate(this._degree);
      this.Geometric.Transform(matrix);
      if ((double) this._degree != (double) rotation)
        this.Rotation = this._degree;
      this.Dimension = dimension;
      this.Location = location;
    }

    private void Transformer_RotateOccurred(Transformer transformer, float degree, PointF point) => this._degree += degree;
  }
}
