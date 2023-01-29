// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Base.GroupEngine
// Assembly: Globe.Graphics.Bidimensional.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 436CCC83-C100-4539-9295-89CEC6F29395
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Base.dll

using Globe.Graphics.Bidimensional.Common;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Globe.Graphics.Bidimensional.Base
{
  public static class GroupEngine
  {
    public static void Group(IDocument document)
    {
      ShapeCollection selectedShapes = Select.GetSelectedShapes(document.Shapes);
      CompositeShape compositeShape = new CompositeShape();
      compositeShape.Selected = true;
      foreach (IShape shape in (Collection<IShape>) selectedShapes)
      {
        shape.Selected = false;
        compositeShape.Shapes.Add(shape);
        document.Shapes.Remove(shape);
      }
      document.Shapes.Add((IShape) compositeShape);
    }

    public static void Ungroup(IDocument document)
    {
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape is CompositeShape compositeShape)
        {
          document.Shapes.Remove((IShape) compositeShape);
          foreach (IShape shape in (Collection<IShape>) compositeShape.Shapes)
          {
            shape.Selected = true;
            document.Shapes.Add(shape);
          }
          while (compositeShape.Shapes.Count != 0)
            compositeShape.Shapes.RemoveAt(0);
        }
      }
    }

    public static void AlignLefts(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Location = new PointF(Select.LastSelectedShape.Location.X, selectedShape.Location.Y);
      }
    }

    public static void AlignRights(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Location = new PointF(Select.LastSelectedShape.Location.X + Select.LastSelectedShape.Dimension.Width - selectedShape.Dimension.Width, selectedShape.Location.Y);
      }
    }

    public static void AlignTops(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Location = new PointF(selectedShape.Location.X, Select.LastSelectedShape.Location.Y);
      }
    }

    public static void AlignBottoms(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Location = new PointF(selectedShape.Location.X, Select.LastSelectedShape.Location.Y + Select.LastSelectedShape.Dimension.Height - selectedShape.Dimension.Height);
      }
    }

    public static void MakeSameWidth(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Dimension = new SizeF(Select.LastSelectedShape.Dimension.Width, selectedShape.Dimension.Height);
      }
    }

    public static void MakeSameHeight(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Dimension = new SizeF(selectedShape.Dimension.Width, Select.LastSelectedShape.Dimension.Height);
      }
    }

    public static void MakeSameSize(IDocument document)
    {
      if (Select.LastSelectedShape == null)
        return;
      foreach (IShape selectedShape in (Collection<IShape>) Select.GetSelectedShapes(document.Shapes))
      {
        if (selectedShape != Select.LastSelectedShape)
          selectedShape.Dimension = Select.LastSelectedShape.Dimension;
      }
    }
  }
}
