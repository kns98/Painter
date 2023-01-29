// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.Image
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Core.Converters;
using Globe.Graphics.Bidimensional.Common;
using Globe.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  [XmlClassSerializable("image")]
  public class Image : Shape
  {
    private Bitmap _bitmap;

    [XmlFieldSerializable("imageBytes")]
    private byte[] ImageBytes
    {
      get => BitmapConverter.BytesFromBitmap(this._bitmap);
      set => this._bitmap = BitmapConverter.BitmapFromBytes(value);
    }

    public Image() => this.Geometric.AddLine(new Point(0, 0), new Point(1, 1));

    public Image(Image image)
      : base((Shape) image)
    {
      this._bitmap = image._bitmap.Clone() as Bitmap;
    }

    public Image(Bitmap bitmap)
    {
      this.Geometric.AddLine(new Point(0, 0), new Point(1, 1));
      this._bitmap = bitmap.Clone() as Bitmap;
    }

    public override object Clone() => (object) new Image(this);

    public override void Paint(IDocument document, PaintEventArgs e) => e.Graphics.DrawImage((System.Drawing.Image) this._bitmap, this.Location);

    public Bitmap Bitmap
    {
      get => this._bitmap;
      set => this._bitmap = value;
    }
  }
}
