// Decompiled with JetBrains decompiler
// Type: Globe.Core.Utilities.History`1
// Assembly: Globe.Core.Utilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB57B126-840D-4A5C-95F5-14E35B72A1A7
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Globe.Core.Utilities.dll

using System;
using System.Collections.ObjectModel;

namespace Globe.Core.Utilities
{
  public static class History<State> where State : ICloneable
  {
    private static int _cursor = 0;
    private static Collection<State> _history = new Collection<State>();
    private static int _buffer = 50;

    public static int Buffer
    {
      get => History<State>._buffer;
      set
      {
        History<State>._buffer = value;
        if (History<State>._buffer > 10)
          return;
        History<State>._buffer = 10;
      }
    }

    public static bool IsAtStart() => History<State>._cursor == 0 || History<State>._history.Count == 0;

    public static bool IsAtEnd() => History<State>._cursor == History<State>._history.Count - 1 || History<State>._history.Count == 0;

    public static void Delete()
    {
      History<State>._history.Clear();
      History<State>._cursor = 0;
    }

    public static void Memorize(State state)
    {
      History<State>._history.Add((State) state.Clone());
      History<State>._cursor = History<State>._history.Count - 1;
    }

    public static State Undo()
    {
      if (History<State>._cursor > 0)
        --History<State>._cursor;
      return (State) History<State>._history[History<State>._cursor].Clone();
    }

    public static State Redo()
    {
      if (History<State>._cursor < History<State>._history.Count - 1)
        ++History<State>._cursor;
      return (State) History<State>._history[History<State>._cursor].Clone();
    }
  }
}
