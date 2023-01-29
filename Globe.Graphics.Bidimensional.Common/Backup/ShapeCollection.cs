// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.ShapeCollection
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("shapes")]
  public class ShapeCollection : Collection<IShape>, ICollection, IEnumerable, ICloneable
  {
    public virtual event ShapeCollection.OnInsertedItem InsertedItem;

    public virtual event ShapeCollection.OnRemovedItem RemovedItem;

    public virtual event ShapeChangingHandler ShapeChanged;

    public virtual event MovementHandler ShapeMovementOccurred;

    public virtual event AppearanceHandler ShapeAppearanceChanged;

    public virtual object Clone()
    {
      ShapeCollection shapeCollection = new ShapeCollection();
      foreach (IShape shape in (Collection<IShape>) this)
        shapeCollection.Add(shape.Clone() as IShape);
      return (object) shapeCollection;
    }

    public void AddRange(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
        this.Add(shape);
    }

    public void BringToFront(IShape shape)
    {
      if (!this.Remove(shape))
        return;
      this.Add(shape);
    }

    public void SendToBack(IShape shape)
    {
      if (!this.Remove(shape))
        return;
      this.Insert(0, shape);
    }

    public static object[] ToObjects(ShapeCollection shapes)
    {
      if (shapes.Count == 0)
        return (object[]) null;
      object[] objects = new object[shapes.Count];
      for (int index = 0; index < shapes.Count; ++index)
        objects[index] = (object) shapes[index];
      return objects;
    }

    protected override void InsertItem(int index, IShape item)
    {
      base.InsertItem(index, item);
      if (this.InsertedItem != null)
        this.InsertedItem(item, index);
      item.ShapeChanged += new ShapeChangingHandler(this.item_ShapeChanged);
      item.Transformer.MovementOccurred += new MovementHandler(this.Transformer_MovementOccurred);
      item.Appearance.AppearanceChanged += new AppearanceHandler(this.Appearance_AppearanceOccurred);
    }

    protected override void RemoveItem(int index)
    {
      IShape shape = this[index];
      base.RemoveItem(index);
      if (this.RemovedItem != null)
        this.RemovedItem(shape, index);
      shape.ShapeChanged -= new ShapeChangingHandler(this.item_ShapeChanged);
      shape.Transformer.MovementOccurred -= new MovementHandler(this.Transformer_MovementOccurred);
      shape.Appearance.AppearanceChanged -= new AppearanceHandler(this.Appearance_AppearanceOccurred);
    }

    private void item_ShapeChanged(IShape shape, object changing)
    {
      if (this.ShapeChanged == null)
        return;
      this.ShapeChanged(shape, changing);
    }

    private void Transformer_MovementOccurred(Transformer transformer)
    {
      if (this.ShapeMovementOccurred == null)
        return;
      this.ShapeMovementOccurred(transformer);
    }

    private void Appearance_AppearanceOccurred(Appearance appearance)
    {
      if (this.ShapeAppearanceChanged == null)
        return;
      this.ShapeAppearanceChanged(appearance);
    }

    public delegate void OnInsertedItem(IShape shape, int index);

    public delegate void OnRemovedItem(IShape shape, int index);
  }
}
