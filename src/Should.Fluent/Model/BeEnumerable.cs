using System.Collections.Generic;
using System.Linq;

namespace Should.Fluent.Model
{
    public class BeEnumerable<T>
    {
        private readonly ShouldEnumerable<T> should;
        private readonly IAssertProvider assertProvider;

        public BeEnumerable(ShouldEnumerable<T> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public IEnumerable<T> Empty()
        {
            if (should.Negate)
            {
                assertProvider.AreNotEqual(0, should.Target.Count());
            }
            else
            {
                assertProvider.AreEqual(0, should.Target.Count());
            }
            return should.Target;
        }

        public IEnumerable<T> Null()
        {
            return Check.IsNull(should, assertProvider);
        }
    }
}