using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Common
{
    public static class DInjectInit_ext
    {
        [DebuggerStepThrough]
        public static T GetLazyValueByrg<T>(this object obj, [CallerMemberName] string name = null)
        {
            throw null;
        }

        [DebuggerStepThrough]
        public static T GetStaticLazyValueByrg<T>([CallerMemberName] string name = null)
        {
            throw null;
        }
    }
}