// Decompiled with JetBrains decompiler
// Type: Globe.Graphics.Bidimensional.Common.SizeFTypeConverter
// Assembly: Globe.Graphics.Bidimensional.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F8F82BA-F69B-4DD3-987E-70E555D2DB06
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Graphics.Bidimensional.Common.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Globe.Graphics.Bidimensional.Common
{
  public class SizeFTypeConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (SizeF) || base.CanConvertTo(context, destinationType);

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      return destinationType == typeof (string) && value is SizeF sizeF ? (object) (sizeF.Width.ToString() + "; " + (object) sizeF.Height) : base.ConvertTo(context, culture, value, destinationType);
    }

    public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => true;

    public override object CreateInstance(
      ITypeDescriptorContext context,
      IDictionary propertyValues)
    {
      return propertyValues != null ? (object) new SizeF((float) propertyValues[(object) "Width"], (float) propertyValues[(object) "Height"]) : (object) null;
    }
  }
}
