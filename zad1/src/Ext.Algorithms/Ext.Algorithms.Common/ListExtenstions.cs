using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.Common
{
    public static class ListExtenstions
    {
        public static void ForEach<T>(this List<T> list, Action<T, int> action)
        {
            int iteration = 0;
            foreach (var item in list)
            {
                action.Invoke(item, iteration);
                iteration++;
            }
        }
    }
}
