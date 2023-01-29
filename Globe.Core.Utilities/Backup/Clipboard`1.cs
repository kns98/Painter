// Decompiled with JetBrains decompiler
// Type: Globe.Core.Utilities.Clipboard`1
// Assembly: Globe.Core.Utilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB57B126-840D-4A5C-95F5-14E35B72A1A7
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Core.Utilities.dll

using System;

namespace Globe.Core.Utilities
{
  public static class Clipboard<State> where State : ICloneable
  {
    private static ICloneable _clip;

    public static State Clip
    {
      get => (State) Clipboard<State>._clip.Clone();
      set => Clipboard<State>._clip = (ICloneable) value.Clone();
    }
  }
}
