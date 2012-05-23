namespace Should.Fluent.Model
{
    public class BeBool
    {
        private readonly Should<bool, BeBool> should;
        private readonly IAssertProvider assertProvider;

        public BeBool(Should<bool, BeBool> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public bool True()
        {
            if (should.Negate)
            {
                assertProvider.IsFalse(should.Target);
            }
            else
            {
                assertProvider.IsTrue(should.Target);
            }
            return should.Target;
        }

        public bool False()
        {
            if (should.Negate)
            {
                assertProvider.IsTrue(should.Target);
            }
            else
            {
                assertProvider.IsFalse(should.Target);
            }
            return should.Target;
        }
    }
}