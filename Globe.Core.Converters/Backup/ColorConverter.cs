// Decompiled with JetBrains decompiler
// Type: Globe.Core.Converters.ColorConverter
// Assembly: Globe.Core.Converters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6A5650BC-15EA-4CC2-98C6-A2D9DD0832AB
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Core.Converters.dll

using System;
using System.Drawing;

namespace Globe.Core.Converters
{
  public class ColorConverter
  {
    public static Color ColorFromString(string argb, char separator)
    {
      string[] strArray = argb.Split(separator);
      Color white = Color.White;
      try
      {
        return Color.FromArgb(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
      }
      catch
      {
        throw new ApplicationException();
      }
    }

    public static string StringFromColor(Color color, char separator) => color.A.ToString() + (object) separator + color.R.ToString() + (object) separator + color.G.ToString() + (object) separator + color.B.ToString();
  }
}
