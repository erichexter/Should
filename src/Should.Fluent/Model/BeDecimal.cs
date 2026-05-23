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
                assertProvider.LessThanOrEqual(should.Target, 0);
            }
            else
            {
                assertProvider.GreaterThan(should.Target, 0);
            }
            return should.Target;
        }

        public double Negative()
        {
            if (should.Negate)
            {
                assertProvider.GreaterThanOrEqual(should.Target, 0);
            }
            else
            {
                assertProvider.LessThan(should.Target, 0);
            }
            return should.Target;
        }
    }
}
