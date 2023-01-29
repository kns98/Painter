// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.CompositeShape
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using Globe.Xml.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  [XmlClassSerializable("compositeShape")]
  public class CompositeShape : Shape
  {
    private ShapeCollection _shapes = new ShapeCollection();
    private bool _movementContentBlocked;

    public CompositeShape()
    {
      this.Transformer = (Transformer) new CompositeTransformer(this);
      this._shapes.InsertedItem += new ShapeCollection.OnInsertedItem(this._shapes_InsertedItem);
      this._shapes.RemovedItem += new ShapeCollection.OnRemovedItem(this._shapes_RemovedItem);
    }

    public CompositeShape(CompositeShape compositeShape)
      : base((Shape) compositeShape)
    {
      this.Transformer = (Transformer) new CompositeTransformer(this);
      this._shapes.InsertedItem += new ShapeCollection.OnInsertedItem(this._shapes_InsertedItem);
      this._shapes.RemovedItem += new ShapeCollection.OnRemovedItem(this._shapes_RemovedItem);
      this.Geometric.Reset();
      foreach (ICloneable shape in (Collection<IShape>) compositeShape.Shapes)
        this._shapes.Add(shape.Clone() as IShape);
    }

    public override object Clone() => (object) new CompositeShape(this);

    public override void Paint(IDocument document, PaintEventArgs e)
    {
      foreach (IShape shape in (Collection<IShape>) this._shapes)
      {
        shape.Appearance.Shape = shape;
        shape.Appearance.Paint(document, e);
      }
      this.Appearance.Shape = (IShape) this;
      this.Appearance.Paint(document, e);
    }

    [XmlFieldSerializable("shapes")]
    public ShapeCollection Shapes
    {
      get => this._shapes;
      private set
      {
        if (value == null)
          return;
        this._shapes.AddRange(value);
      }
    }

    [XmlFieldSerializable("movementContentBlocked")]
    public bool MovementContentBlocked
    {
      get => this._movementContentBlocked;
      set => this._movementContentBlocked = value;
    }

    private void _shapes_InsertedItem(IShape shape, int index)
    {
      (shape as Shape).Parent = (IShape) this;
      this.Geometric.AddPath(shape.Geometric, false);
    }

    private void _shapes_RemovedItem(IShape shape, int index)
    {
      (shape as Shape).Parent = (IShape) null;
      this.Geometric.Reset();
      foreach (IShape shape1 in (Collection<IShape>) this._shapes)
        this.Geometric.AddPath(shape1.Geometric, false);
    }
  }
}
