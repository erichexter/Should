using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Should.Fluent.Model
{
    public class Count<T>
    {
        private readonly IShould<IEnumerable<T>> should;

        public Count(IShould<IEnumerable<T>> should)
        {
            this.should = should;
        }

        public IEnumerable<T> Exactly(int expectedCount)
        {
            return should.Apply(
                (t, a) => a.AreEqual(expectedCount, t.Count()),
                (t, a) => a.AreNotEqual(expectedCount, t.Count()));
        }

        public IEnumerable<T> AtLeast(int expectedMinimumCount)
        {
            return should.Apply(
                (t, a) => a.GreaterThanOrEqual(t.Count(), expectedMinimumCount),
                (t, a) => a.LessThan(t.Count(), expectedMinimumCount));
        }

        public IEnumerable<T> NoMoreThan(int expectedMaximumCount)
        {
            return should.Apply(
                (t, a) => a.LessThanOrEqual(t.Count(), expectedMaximumCount),
                (t, a) => a.GreaterThan(t.Count(), expectedMaximumCount));
        }

        public IEnumerable<T> Zero()
        {
            return Exactly(0);
        }

        public IEnumerable<T> One()
        {
            return Exactly(1);
        }
    }

    public class Count
    {
        private readonly IShould<ICollection> should;
        private readonly IAssertProvider assertProvider;

        public Count(IShould<ICollection> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public ICollection Exactly(int expectedCount)
        {
            return should.Apply(
                (t, a) => a.AreEqual(expectedCount, t.Count),
                (t, a) => a.AreNotEqual(expectedCount, t.Count));
        }

        public ICollection AtLeast(int expectedMinimumCount)
        {
            return should.Apply(
                (t, a) => a.GreaterThanOrEqual(expectedMinimumCount, t.Count),
                (t, a) => a.LessThan(expectedMinimumCount, t.Count));
        }

        public ICollection NoMoreThan(int expectedMaximumCount)
        {
            return should.Apply(
                (t, a) => a.LessThanOrEqual(expectedMaximumCount, t.Count),
                (t, a) => a.GreaterThan(expectedMaximumCount, t.Count));
        }

        public ICollection Zero()
        {
            return Exactly(0);
        }

        public ICollection One()
        {
            return Exactly(1);
        }
    }
}