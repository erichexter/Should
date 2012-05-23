using System;

namespace Should.Fluent.Model
{
    public class BeDateTime
    {
        private readonly ShouldDateTime should;
        private readonly IAssertProvider assertProvider;

        public BeDateTime(ShouldDateTime should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public DateTime Today()
        {
            if (should.Negate)
            {
                assertProvider.AreNotEqual(DateTime.Today, should.Target.Date);
            }
            else
            {
                assertProvider.AreEqual(DateTime.Today, should.Target.Date);
            }
            return should.Target;
        }
    }
}