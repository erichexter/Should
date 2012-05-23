using System;
using System.Collections.Generic;
using System.Linq;

namespace Should.Fluent.Model
{
    public class Contain<T>
    {
        private readonly IShould<IEnumerable<T>> should;

        public Contain(IShould<IEnumerable<T>> should)
        {
            this.should = should;
        }

        public IEnumerable<T> Any(Func<T, bool> predicate)
        {
            return should.Apply(
                (t, a) =>
                {
                    if (t.Any(predicate) == false)
                    {
                        a.Fail("Expecting at least 1 matching item in list.  Found 0.");
                    }
                },
                (t, a) =>
                {
                    if (t.Any(predicate))
                    {
                        a.Fail("Expecting 0 matching item in list.  Found {0}.", t.Count());
                    }
                });
        }

        public IEnumerable<T> One(Func<T, bool> predicate)
        {
            return should.Apply(
                (t, a) =>
                {
                    var count = t.Where(predicate).Count();
                    if (count != 1)
                    {
                        a.Fail("Expecting 1 matching item in list.  Found {0}.", count);
                    }
                },
                (t, a) =>
                {
                    var count = t.Where(predicate).Count();
                    if (count == 1)
                    {
                        a.Fail("Expecting other than 1 matching item in list.  Found {0}.", count);
                    }
                });
        }

        public IEnumerable<T> One(T value)
        {
            return One(x => x.Equals(value));
        }

        public IEnumerable<T> Item(T item)
        {
            return should.Apply(
                (t, a) => a.Contains(item, t),
                (t, a) => a.NotContains(item, t));
        }
    }
}