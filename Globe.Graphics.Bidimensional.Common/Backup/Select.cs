// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.Select
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Globe.Graphics.Bidimensional.Common
{
  public class Select : Tool
  {
    private static IShape _lastSelectedShape;

    public event Select.OnSelectedShapes SelectedShapes;

    public override void MouseDown(IDocument document, MouseEventArgs e)
    {
      base.MouseDown(document, e);
      if (this.SelectShape(document.Shapes, e.Location) == HitPositions.None)
        Select.UnselectAll(document.Shapes);
      if (this.SelectedShapes != null)
        this.SelectedShapes((Tool) this, Select.GetSelectedShapes(document.Shapes));
      document.GridManager.SnapToGrid(Select.GetSelectedShapes(document.Shapes));
    }

    public override void MouseUp(IDocument document, MouseEventArgs e)
    {
      base.MouseUp(document, e);
      document.ActiveCursor = Cursors.Default;
    }

    public static IShape LastSelectedShape
    {
      get => Select._lastSelectedShape;
      set => Select._lastSelectedShape = value;
    }

    public static void SelectAll(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
        shape.Selected = true;
    }

    public static void UnselectAll(ShapeCollection shapes)
    {
      foreach (IShape shape in (Collection<IShape>) shapes)
        shape.Selected = false;
    }

    public static ShapeCollection GetSelectedShapes(ShapeCollection shapes)
    {
      ShapeCollection selectedShapes = new ShapeCollection();
      foreach (IShape shape in (Collection<IShape>) shapes)
      {
        if (shape.Selected)
          selectedShapes.Add(shape);
      }
      return selectedShapes;
    }

    protected HitPositions SelectShape(ShapeCollection shapes, Point point)
    {
      if (Control.ModifierKeys != Keys.Control)
        Select.UnselectAll(shapes);
      for (int index = shapes.Count - 1; index >= 0; --index)
      {
        IShape shape = shapes[index];
        HitPositions hitPositions = shape.HitTest(point);
        if (hitPositions != HitPositions.None)
        {
          shapes.BringToFront(shape);
          shape.Selected = true;
          Select._lastSelectedShape = shape;
          return hitPositions;
        }
      }
      return HitPositions.None;
    }

    public delegate void OnSelectedShapes(Tool tool, ShapeCollection shapes);
  }
}
