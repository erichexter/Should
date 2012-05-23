using System.Collections.Generic;
using System.Linq;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeEnumerableExtensions
    {
        public static IEnumerable<T> Empty<T>(this IBe<IEnumerable<T>> be)
        {
            return be.Should.Apply(
                (t, a) => a.AreEqual(0, t.Count()),
                (t, a) => a.AreNotEqual(0, t.Count()));
        }

        public static IEnumerable<T> Null<T>(this IBe<IEnumerable<T>> be)
        {
            return Check.IsNull(be.Should);
        }
    }
}