namespace Should.Fluent.Model
{
    public class BeNullableBool
    {
        private readonly Should<bool?, BeNullableBool> should;
        private readonly IAssertProvider assertProvider;

        public BeNullableBool(Should<bool?, BeNullableBool> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public bool? Null()
        {
            return Check.IsNull(should, assertProvider);
        }

        public bool? True()
        {
            if (!should.Target.HasValue)
            {
                assertProvider.Fail("Expected TRUE but was NULL.");
            }
            else
            {
                if (should.Negate)
                {
                    assertProvider.IsFalse(should.Target.Value);
                }
                else
                {
                    assertProvider.IsTrue(should.Target.Value);
                }
            }
            return should.Target;
        }

        public bool? False()
        {
            if (!should.Target.HasValue)
            {
                assertProvider.Fail("Expected FALSE but was NULL.");
            }
            else
            {
                if (should.Negate)
                {
                    assertProvider.IsTrue(should.Target.Value);
                }
                else
                {
                    assertProvider.IsFalse(should.Target.Value);
                }   
            }
            return should.Target;
        }
    }
}