using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_context : test_base<string>
    {
        protected static Should<string, BeBase<string>> should;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = "foo";
            should = new Should<string, BeBase<string>>(target, mockAssertProvider.Object);
        }
    }

    [TestFixture]
    public class when_calling_equal : should_context
    {
        const string expected = "foo";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Equal(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreEqual(expected, target));
        }
    }

    [TestFixture]
    public class when_calling_not_equal : should_context
    {
        const string expected = "bar";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.Equal(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_arenotequal()
        {
            Called(x => x.AreNotEqual(expected, target));
        }
    }

    public class should_string_context : test_base
    {
        protected static Should<string, BeBase<string>> should;
        protected static string target = "foo";
        protected static string result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            should = new Should<string, BeBase<string>>(target, mockAssertProvider.Object);
        }
    }

    [TestFixture]
    public class when_calling_starts_with : should_string_context
    {
        const string expected = "f";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.StartWith(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_starts_with_fail : should_string_context
    {
        const string expected = "x";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.StartWith(expected);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected string '{0}' to start with '{1}', but it did not.", target, expected);
        }
    }

    [TestFixture]
    public class when_calling_not_starts_with : should_string_context
    {
        const string expected = "x";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.StartWith(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_not_starts_with_fail : should_string_context
    {
        const string expected = "f";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.StartWith(expected);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected string '{0}' to not start with '{1}', but it did.", target, expected);
        }
    }

    [TestFixture]
    public class when_calling_end_with : should_string_context
    {
        const string expected = "o";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.EndWith(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_ends_with_fail : should_string_context
    {
        const string expected = "x";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.EndWith(expected);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected string '{0}' to end with '{1}', but it did not.", target, expected);
        }
    }

    [TestFixture]
    public class when_calling_not_ends_with : should_string_context
    {
        const string expected = "x";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.EndWith(expected);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_not_ends_with_fail : should_string_context
    {
        const string expected = "o";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.EndWith(expected);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected string '{0}' to not end with '{1}', but it did.", target, expected);
        }
    }

    [TestFixture]
    public class when_calling_contain : should_string_context
    {
        const string expected = "oo";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Contain(expected);
        }

        [Test]
        public void should_assert_issubstringof()
        {
            Called(x => x.IsSubstringOf(target, expected));
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_not_contain : should_string_context
    {
        protected static string expected = "x";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            expected = "x";
            result = should.Not.Contain(expected);
        }

        [Test]
        public void should_not_assert_issubstringof()
        {
            NotCalled(x => x.IsSubstringOf(target, expected));
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_not_contain_fails : should_string_context
    {
        protected static string expected = "oo";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            expected = "oo";
            result = should.Not.Contain(expected);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected string '{0}' to not contain '{1}', but it did.", target, expected);
        }
    }
}
