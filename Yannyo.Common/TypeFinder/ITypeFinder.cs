#if NET1
#else
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yannyo.Common.TypeFinder
{
    public interface ITypeFinder
    {
        IList<Assembly> GetFilteredAssemblyList();
    }
}
#endif