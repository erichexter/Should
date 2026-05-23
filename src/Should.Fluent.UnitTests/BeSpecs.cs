using System;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_test_base : test_base<string>
    {
        protected static Be<string> be;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = "foo";
        }
    }

    public class should_be_context : be_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<string, Be<string>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_context : be_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<string, Be<string>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_null : should_be_context
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
    public class when_calling_not_null : should_not_be_context
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
        public void should_assert_isnotnull()
        {
            Called(x => x.IsNotNull(target));
        }
    }

    [TestFixture]
    public class when_calling_generic_oftype : should_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.OfType<string>();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isinstanceoftype()
        {
            Called(x => x.IsInstanceOfType(target, typeof(string)));
        }
    }

    [TestFixture]
    public class when_calling_not_generic_oftype : should_not_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.OfType<string>();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isnotinstanceoftype()
        {
            Called(x => x.IsNotInstanceOfType(target, typeof(string)));
        }
    }

    [TestFixture]
    public class when_calling_oftype : should_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.OfType(typeof(string));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isinstanceoftype()
        {
            Called(x => x.IsInstanceOfType(target, typeof(string)));
        }
    }

    [TestFixture]
    public class when_calling_not_oftype : should_not_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.OfType(typeof(string));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isnotinstanceoftype()
        {
            Called(x => x.IsNotInstanceOfType(target, typeof(string)));
        }
    }

    [TestFixture]
    public class when_calling_sameas : should_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.SameAs(target);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isinstanceoftype()
        {
            Called(x => x.AreSame(target, target));
        }
    }

    [TestFixture]
    public class when_calling_not_sameas : should_not_be_context
    {
        static string expected = "not same";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            expected = "not same";
            result = be.SameAs(expected);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isnotinstanceoftype()
        {
            Called(x => x.AreNotSame(expected, target));
        }
    }

    [TestFixture]
    public class when_calling_inrange : should_be_context
    {
        static string low = "a";
        static string high = "b";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            low = "a";
            high = "b";
            result = be.InRange(low, high);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.InRange(target, low, high));
        }
    }

    [TestFixture]
    public class when_calling_not_inrange : should_not_be_context
    {
        static string low = "a";
        static string high = "z";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            low = "a";
            high = "z";
            result = be.InRange(low, high);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.NotInRange(target, low, high));
        }
    }

    [TestFixture]
    public class when_calling_assignablefrom : should_be_context
    {
        static Type expectedType = typeof(object);

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            expectedType = typeof(object);
            result = be.AssignableFrom(expectedType);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.AssignableFrom(target, expectedType));
        }
    }

    [TestFixture]
    public class when_calling_not_assignablefrom : should_not_be_context
    {
        static Type expectedType = typeof(object);

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            expectedType = typeof(object);
            result = be.AssignableFrom(expectedType);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.NotAssignableFrom(target, expectedType));
        }
    }

    [TestFixture]
    public class when_calling_assignablefrom_generic : should_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.AssignableFrom<object>();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.AssignableFrom(target, typeof(object)));
        }
    }

    [TestFixture]
    public class when_calling_not_assignablefrom_generic : should_not_be_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.AssignableFrom<object>();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_inrange()
        {
            Called(x => x.NotAssignableFrom(target, typeof(object)));
        }
    }
}
