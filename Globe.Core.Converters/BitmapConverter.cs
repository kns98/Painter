// Decompiled with JetBrains decompiler
// Type: Globe.Core.Converters.BitmapConverter
// Assembly: Globe.Core.Converters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6A5650BC-15EA-4CC2-98C6-A2D9DD0832AB
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Core.Converters.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Globe.Core.Converters
{
  public class BitmapConverter
  {
    public static Bitmap BitmapFromBytes(byte[] bytes)
    {
      Bitmap bitmap = (Bitmap) null;
      if (bytes != null)
        bitmap = new Bitmap((Stream) new MemoryStream(bytes));
      return bitmap;
    }

    public static byte[] BytesFromBitmap(Bitmap bitmap)
    {
      try
      {
        return (byte[]) TypeDescriptor.GetConverter(bitmap.GetType()).ConvertTo((object) bitmap, typeof (byte[]));
      }
      catch
      {
        throw new ApplicationException();
      }
    }
  }
}
