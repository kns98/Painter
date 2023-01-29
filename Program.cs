// Decompiled with JetBrains decompiler
// Type: Painter.Program
// Assembly: Painter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6C7491-0546-43BD-B8DF-DE31170BE9D0
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Painter.exe

using System;
using System.Windows.Forms;

namespace Painter
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
