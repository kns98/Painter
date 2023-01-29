// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.MultiSelectGhost
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  [Serializable]
  public class MultiSelectGhost : Ghost
  {
    private SolidBrush _brush;

    public MultiSelectGhost()
      : base((IShape) new Rectangle())
    {
      this._brush = new SolidBrush(Color.FromArgb(100, Color.LightBlue));
    }

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      if (!this.Visible)
        return;
      e.Graphics.FillRectangle((Brush) this._brush, System.Drawing.Rectangle.Round(new RectangleF(this.Location, this.Dimension)));
      e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(this.Geometric.GetBounds()));
    }

    protected SolidBrush DrawingBrush
    {
      get => this._brush;
      set => this._brush = value;
    }
  }
}
