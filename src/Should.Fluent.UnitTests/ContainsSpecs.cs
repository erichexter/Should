using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class contain_test_base : test_base<IEnumerable<string>>
    {
        protected static Contain<string> contains;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new List<string>(new[] { "foo", "bar", "foo" });
        }
    }

    public class should_contain_context : contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            contains = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Contain;
        }
    }

    public class should_not_contain_context : contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            contains = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Not.Contain;
        }
    }

    [TestFixture]
    public class when_calling_any : should_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.Any(x => x == target.ToList()[0]);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_not_any : should_not_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.Any(x => x == "i'm not there");
        }

        [Test]
        public void should_return_self()
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
    public class when_calling_one : should_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.One(x => x == target.ToList()[1]);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_not_one : should_not_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.One(x => x == "i'm not there");
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_one_with_value : should_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.One(target.ToList()[1]);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_not_one_with_value : should_not_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.One("i'm not there");
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_item : should_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.Item(target.ToList()[1]);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_not_item : should_not_contain_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = contains.Item("i'm not there");
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    public static class EnumerableExtensions
    {
        public static ArrayList ToArrayList(this IEnumerable e)
        {
            var result = new ArrayList();
            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }
            return result;
        }
    }
}
