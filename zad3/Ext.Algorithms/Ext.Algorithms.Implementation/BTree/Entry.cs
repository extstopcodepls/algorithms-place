using System;

namespace Ext.Algorithms.Implementation.BTree
{
    public class Entry<TK, TP> : IEquatable<Entry<TK, TP>>
    {
        public TK Key { get; set; }

        public TP Pointer { get; set; }

        public bool Equals(Entry<TK, TP> other)
        {
            return Key.Equals(other.Key) && Pointer.Equals(other.Pointer);
        }

        public override string ToString()
        {
            return Pointer.ToString();
        }
    }
}
