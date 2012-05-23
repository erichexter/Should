namespace Should.Fluent.Model
{
    public class BeDouble
    {
        private readonly ShouldDouble should;
        private readonly IAssertProvider assertProvider;

        public BeDouble(ShouldDouble should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public double Positive()
        {
            if (should.Negate)
            {
                assertProvider.LessOrEqual(0, should.Target);
            }
            else
            {
                assertProvider.Greater(0, should.Target);
            }
            return should.Target;
        }

        public double Negative()
        {
            if (should.Negate)
            {
                assertProvider.GreaterOrEqual(0, should.Target);
            }
            else
            {
                assertProvider.Less(0, should.Target);
            }
            return should.Target;
        }
    }
}