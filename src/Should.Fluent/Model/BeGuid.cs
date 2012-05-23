using System;

namespace Should.Fluent.Model
{
    public class BeGuid
    {
        private readonly Should<Guid, BeGuid> should;
        private readonly IAssertProvider assertProvider;

        public BeGuid(Should<Guid, BeGuid> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public Guid Empty()
        {
            if (should.Negate)
            {
                assertProvider.AreNotEqual(Guid.Empty, should.Target);
            }
            else
            {
                assertProvider.AreEqual(Guid.Empty, should.Target);
            }
            return should.Target;
        }
    }
}