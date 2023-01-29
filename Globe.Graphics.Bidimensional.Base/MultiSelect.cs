// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.MultiSelect
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  public class MultiSelect : Draw
  {
    public event MultiSelect.OnSelectedShapes SelectedShapes;

    public MultiSelect() => this.Ghost = (Ghost) new MultiSelectGhost();

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      if (Control.ModifierKeys != Keys.Control && e.Button != MouseButtons.Right)
        Select.UnselectAll(document.Shapes);
      base.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      this.SelectIntersectedShapes(document.Shapes);
      if (this.SelectedShapes != null)
        this.SelectedShapes((Globe.Graphics.Bidimensional.Common.Tool) this, Select.GetSelectedShapes(document.Shapes));
      base.MouseUp(document, e);
    }

    public override void Paint(IDocument document, PaintEventArgs e) => this.Ghost.Paint(document, e);

    private void SelectIntersectedShapes(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (this.Ghost.Geometric.GetBounds().IntersectsWith(shape.Geometric.GetBounds()))
          shape.Selected = true;
      }
    }

    public delegate void OnSelectedShapes(Globe.Graphics.Bidimensional.Common.Tool tool, ShapeCollection shapes);
  }
}
