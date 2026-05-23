using System;
using NUnit.Framework;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    public class integration_test_base
    {
        protected static Exception exception;

        [SetUp]
        public virtual void SetUp()
        {
            exception = null;
        }

        protected static void Try(Action assertAction)
        {
            try
            {
                assertAction();
                exception = null;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }
    }
}
