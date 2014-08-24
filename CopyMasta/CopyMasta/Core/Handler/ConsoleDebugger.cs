﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyMasta.Core.Handler
{
    public class ConsoleDebugger : IHandler
    {
        public void Handle(KeyState state)
        {
            Console.WriteLine("Alt: {0}\tCtrl: {1}\tShift: {2}\tLetters: {3}",
                              state.MetaKeys.HasFlag(MetaKeys.Alt) ? "1" : "0",
                              state.MetaKeys.HasFlag(MetaKeys.Ctrl) ? "1" : "0",
                              state.MetaKeys.HasFlag(MetaKeys.Shift) ? "1" : "0",
                              string.Join(", ", state.Keys));
        }
    }
}