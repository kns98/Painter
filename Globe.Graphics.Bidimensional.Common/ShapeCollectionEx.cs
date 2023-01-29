// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.ShapeCollectionEx
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("shapes")]
  public class ShapeCollectionEx : ShapeCollection
  {
    public virtual event TranslateHandler ShapeTranslateOccurred;

    public virtual event ScaleHandler ShapeScaleOccurred;

    public virtual event RotateHandler ShapeRotateOccurred;

    public virtual event DeformHandler ShapeDeformOccurred;

    public virtual event MirrorHorizontalHandler ShapeMirrorHorizontalOccurred;

    public virtual event MirrorVerticalHandler ShapeMirrorVerticalOccurred;

    public override object Clone()
    {
      ShapeCollectionEx shapeCollectionEx = new ShapeCollectionEx();
      foreach (IShape shape in (Collection<IShape>) this)
        shapeCollectionEx.Add(shape.Clone() as IShape);
      return (object) shapeCollectionEx;
    }

    protected override void InsertItem(int index, IShape item)
    {
      base.InsertItem(index, item);
      item.Transformer.TranslateOccurred += new TranslateHandler(this.Transformer_TranslateOccurred);
      item.Transformer.ScaleOccurred += new ScaleHandler(this.Transformer_ScaleOccurred);
      item.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
      item.Transformer.DeformOccurred += new DeformHandler(this.Transformer_DeformOccurred);
      item.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
      item.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
    }

    protected override void RemoveItem(int index)
    {
      IShape shape = this[index];
      base.RemoveItem(index);
      shape.Transformer.TranslateOccurred -= new TranslateHandler(this.Transformer_TranslateOccurred);
      shape.Transformer.ScaleOccurred -= new ScaleHandler(this.Transformer_ScaleOccurred);
      shape.Transformer.RotateOccurred -= new RotateHandler(this.Transformer_RotateOccurred);
      shape.Transformer.DeformOccurred -= new DeformHandler(this.Transformer_DeformOccurred);
      shape.Transformer.MirrorHorizontalOccurred -= new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
      shape.Transformer.MirrorVerticalOccurred -= new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
    }

    private void Transformer_TranslateOccurred(
      Transformer transformer,
      float offsetX,
      float offsetY)
    {
      if (this.ShapeTranslateOccurred == null)
        return;
      this.ShapeTranslateOccurred(transformer, offsetX, offsetY);
    }

    private void Transformer_ScaleOccurred(
      Transformer transformer,
      float scaleX,
      float scaleY,
      PointF point)
    {
      if (this.ShapeScaleOccurred == null)
        return;
      this.ShapeScaleOccurred(transformer, scaleX, scaleY, point);
    }

    private void Transformer_RotateOccurred(Transformer transformer, float degree, PointF point)
    {
      if (this.ShapeRotateOccurred == null)
        return;
      this.ShapeRotateOccurred(transformer, degree, point);
    }

    private void Transformer_DeformOccurred(
      Transformer transformer,
      int indexPoint,
      PointF newPoint)
    {
      if (this.ShapeDeformOccurred == null)
        return;
      this.ShapeDeformOccurred(transformer, indexPoint, newPoint);
    }

    private void Transformer_MirrorHorizontalOccurred(Transformer transformer, float x)
    {
      if (this.ShapeMirrorHorizontalOccurred == null)
        return;
      this.ShapeMirrorHorizontalOccurred(transformer, x);
    }

    private void Transformer_MirrorVerticalOccurred(Transformer transformer, float y)
    {
      if (this.ShapeMirrorVerticalOccurred == null)
        return;
      this.ShapeMirrorVerticalOccurred(transformer, y);
    }
  }
}
