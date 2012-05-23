using System;

namespace Should.Fluent.Model
{
    public class BeNullableDateTime
    {
        private readonly Should<DateTime?, BeNullableDateTime> should;
        private readonly IAssertProvider assertProvider;

        public BeNullableDateTime(Should<DateTime?, BeNullableDateTime> should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public DateTime? Null()
        {
            return Check.IsNull(should, assertProvider);
        }

        public DateTime? Today()
        {
            if (!should.Target.HasValue)
            {
                assertProvider.Fail("Expected TODAY but was NULL.");
            }
            else
            {
                if (should.Negate)
                {
                    assertProvider.AreNotEqual(DateTime.Today, should.Target.Value.Date);
                }
                else
                {
                    assertProvider.AreEqual(DateTime.Today, should.Target.Value.Date);
                }
            }
            return should.Target;
        }
    }
}