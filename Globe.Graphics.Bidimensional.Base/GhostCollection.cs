// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.GhostCollection
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Base
{
  [Serializable]
  public class GhostCollection : Ghost
  {
    private ShapeCollection _ghosts = new ShapeCollection();

    public GhostCollection()
    {
      this.Transformer.TranslateOccurred += new TranslateHandler(this.Transformer_TranslateOccurred);
      this.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
    }

    public GhostCollection(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
        this._ghosts.Add((IShape) new Ghost(shape));
      this.Transformer.TranslateOccurred += new TranslateHandler(this.Transformer_TranslateOccurred);
      this.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
    }

    public override object Clone()
    {
      GhostCollection ghostCollection = new GhostCollection();
      foreach (IShape ghost in (Collection<IShape>) this._ghosts)
        ghostCollection.Ghosts.Add(ghost.Clone() as IShape);
      return (object) ghostCollection;
    }

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      foreach (IActions ghost in (Collection<IShape>) this._ghosts)
        ghost.MouseDown(document, e);
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      foreach (IShape ghost in (Collection<IShape>) this._ghosts)
      {
        if (this.ShapeMouseUp != null)
          this.ShapeMouseUp(ghost, document, e);
        ghost.MouseUp(document, e);
      }
      if (this.ShapeMouseUp == null)
        return;
      this.ShapeMouseUp((IShape) this, document, e);
    }

    public override void MouseMove(IDocument document, MouseEventArgs e)
    {
      this.Selected = true;
      foreach (IActions ghost in (Collection<IShape>) this._ghosts)
        ghost.MouseMove(document, e);
    }

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      foreach (IActions ghost in (Collection<IShape>) this._ghosts)
        ghost.Paint(document, e);
    }

    public override event MouseUpOnShape ShapeMouseUp;

    public virtual ShapeCollection Ghosts
    {
      get => this._ghosts;
      set
      {
        this._ghosts.Clear();
        foreach (IShape shape in (Collection<IShape>) value)
          this._ghosts.Add((IShape) new Ghost(shape));
      }
    }

    private void Transformer_TranslateOccurred(
      Transformer transformer,
      float offsetX,
      float offsetY)
    {
      foreach (IShape ghost in (Collection<IShape>) this._ghosts)
        ghost.Transformer.Translate(offsetX, offsetY);
    }

    private void Transformer_RotateOccurred(Transformer transformer, float degree, PointF point)
    {
      foreach (IShape ghost in (Collection<IShape>) this._ghosts)
        ghost.Transformer.Rotate(degree, point);
    }
  }
}
