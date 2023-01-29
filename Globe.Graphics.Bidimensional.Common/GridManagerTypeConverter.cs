// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.GridManagerTypeConverter
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.ComponentModel;
using System.Globalization;

namespace Globe.Graphics.Bidimensional.Common
{
  public class GridManagerTypeConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (GridManager) || base.CanConvertTo(context, destinationType);

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType != typeof (string) || !(value is GridManager))
        return base.ConvertTo(context, culture, value, destinationType);
      return (object) Resource.GridManager;
    }
  }
}
