using System;
using System.Collections.Generic;
using System.Linq;

namespace Should.Fluent.Model
{
    //public class ContainQueryable<T>
    //{
    //    private readonly ShouldQueryable<T> should;
    //    private readonly IAssertProvider assertProvider;

    //    public ContainQueryable(ShouldQueryable<T> should, IAssertProvider assertProvider)
    //    {
    //        this.should = should;
    //        this.assertProvider = assertProvider;
    //    }

    //    public IEnumerable<T> Any(Func<T, bool> predicate)
    //    {
    //        if (should.Negate)
    //        {
    //            if (should.Target.Any(predicate))
    //            {
    //                assertProvider.Fail("Expecting 0 matching item in list.  Found {0}.", should.Target.Count());
    //            }
    //        }
    //        else
    //        {
    //            if (!should.Target.Any(predicate))
    //            {
    //                assertProvider.Fail("Expecting at least 1 matching item in list.  Found 0.");
    //            }
    //        }
    //        return should.Target.Where(predicate);
    //    }

    //    public T One(Func<T, bool> predicate)
    //    {
    //        var match = should.Target.Where(predicate);
    //        if (should.Negate)
    //        {
    //            if (match.Count() == 1)
    //            {
    //                assertProvider.Fail("Expecting other than 1 matching item in list.  Found {0}.", match.Count());
    //            }
    //            return default(T);
    //        }
    //        if (match.Count() != 1)
    //        {
    //            assertProvider.Fail("Expecting 1 matching item in list.  Found {0}.", match.Count());
    //        }
    //        return match.First();
    //    }

    //    public T One(T value)
    //    {
    //        return One(x => x.Equals(value));
    //    }

    //    public T Item(T item)
    //    {
    //        if (should.Negate)
    //        {
    //            assertProvider.NotContains(item, should.Target);
    //            return default(T);
    //        }
    //        assertProvider.Contains(item, should.Target);
    //        return item;
    //    }
    //}
}