using System.Collections;

namespace Should.Fluent.Model
{
    public class BeCollection
    {
        private readonly ShouldCollection should;
        private readonly IAssertProvider assertProvider;

        public BeCollection(ShouldCollection should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public ICollection Empty()
        {
            if (should.Negate)
            {
                assertProvider.AreNotEqual(0, should.Target.Count);
            }
            else
            {
                assertProvider.AreEqual(0, should.Target.Count);
            }
            return should.Target;
        }

        public ICollection Null()
        {
            return Check.IsNull(should, assertProvider);
        }
    }
}