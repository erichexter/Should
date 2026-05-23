using System.Collections.Generic;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_dictionary_context : test_base
    {
        protected static ShouldDictionary<int, int> should;
        protected static IDictionary<int, int> target;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new Dictionary<int, int>();
            should = new ShouldDictionary<int, int>(target, mockAssertProvider.Object);
        }
    }

    [TestFixture]
    public class when_getting_count : should_dictionary_context
    {
        static Count<KeyValuePair<int, int>> result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target.Add(1, 1);
            result = should.Count;
        }

        [Test]
        public void count_should_not_be_null()
        {
            Assert.IsNotNull(result);
        }
    }

    [TestFixture]
    public class when_getting_contain : should_dictionary_context
    {
        static Contain<KeyValuePair<int, int>> result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target.Add(1, 1);
            result = should.Contain;
        }

        [Test]
        public void contain_should_not_be_null()
        {
            Assert.IsNotNull(result);
        }
    }

    [TestFixture]
    public class when_calling_contains_key : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target.Add(1, 1);
            result = should.ContainKey(1);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void result_is_same_as_target()
        {
            Assert.AreSame(target, result);
        }
    }

    [TestFixture]
    public class when_calling_not_contains_key : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target.Add(1, 1);
            result = should.Not.ContainKey(2);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void result_is_same_as_target()
        {
            Assert.AreSame(target, result);
        }
    }

    [TestFixture]
    public class when_calling_contains_key_but_not_contains : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target.Add(1, 1);
            result = should.ContainKey(2);
        }

        [Test]
        public void result_is_same_as_target()
        {
            Assert.AreSame(target, result);
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected dictionary to contain key '{0}' but it does not.", 2);
        }
    }
}
