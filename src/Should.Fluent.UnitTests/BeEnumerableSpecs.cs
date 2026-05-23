using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_enumerable_test_base : test_base<IEnumerable<string>>
    {
        protected static BeBase<IEnumerable<string>> be;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new List<string>(new[] { "foo" });
        }
    }

    public class should_be_enumerable_contex : be_enumerable_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_enumerable_context : be_enumerable_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_empty : should_be_enumerable_contex
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Empty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(0, target.Count()));
        }
    }

    [TestFixture]
    public class when_calling_not_empty : should_not_be_enumerable_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Empty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_iarenotequal()
        {
            Called(x => x.AreNotEqual(0, target.Count()));
        }
    }

    [TestFixture]
    public class when_calling_enumerable_null : should_be_enumerable_contex
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Null();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_isnull()
        {
            Called(x => x.IsNull(target));
        }
    }

    [TestFixture]
    public class when_calling_enumerable_not_null : should_not_be_enumerable_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Null();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_isnotnull()
        {
            Called(x => x.IsNotNull(target));
        }
    }
}
