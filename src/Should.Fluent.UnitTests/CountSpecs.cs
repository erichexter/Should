using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class count_base : test_base<IEnumerable<string>>
    {
        protected static Count<string> count;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new List<string>(new[] { "foo", "bar", "foo" });
        }
    }

    public class should_count_context : count_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Count;
        }
    }

    public class should_not_count_context : should_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Not.Count;
        }
    }

    [TestFixture]
    public class when_calling_exactly : should_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.Exactly(3);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(3, 3));
        }
    }

    [TestFixture]
    public class when_calling_not_exactly : should_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.Exactly(4);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_arenotequal()
        {
            Called(x => x.AreNotEqual(4, 3));
        }
    }

    [TestFixture]
    public class when_calling_at_least : should_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.AtLeast(2);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_greaterthanorequal()
        {
            Called(x => x.GreaterThanOrEqual(3, 2));
        }
    }

    [TestFixture]
    public class when_calling_not_at_least : should_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.AtLeast(4);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_greaterthanorequal()
        {
            Called(x => x.LessThan(3, 4));
        }
    }

    [TestFixture]
    public class when_calling_no_more_than : should_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.NoMoreThan(3);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_lessthanorequal()
        {
            Called(x => x.LessThanOrEqual(3, 3));
        }
    }

    [TestFixture]
    public class when_calling_zero : should_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.Zero();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(0, 3));
        }
    }

    [TestFixture]
    public class when_calling_not_zero : should_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = count.Zero();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_arenotequal()
        {
            Called(x => x.AreNotEqual(0, 3));
        }
    }

    public class collection_context : test_base<ICollection>
    {
        protected static Count count;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new MyCollection(10);
        }
    }

    public class should_collection_count_context : collection_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count = new ShouldCollection(target, mockAssertProvider.Object).Count;
        }
    }

    public class should_collection_not_count_context : collection_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count = new ShouldCollection(target, mockAssertProvider.Object).Not.Count;
        }
    }

    [TestFixture]
    public class when_called_exactly : should_collection_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.Exactly(10);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(10, 10));
        }
    }

    [TestFixture]
    public class when_called_atleast : should_collection_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.AtLeast(10);
        }

        [Test]
        public void should_call_greater_or_equal()
        {
            Called(x => x.GreaterThanOrEqual(10, 10));
        }
    }

    [TestFixture]
    public class when_called_no_more_than : should_collection_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.NoMoreThan(10);
        }

        [Test]
        public void should_call_less_than_or_equal()
        {
            Called(x => x.LessThanOrEqual(10, 10));
        }
    }

    [TestFixture]
    public class when_called_zero : should_collection_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.Zero();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(0, 10));
        }
    }

    [TestFixture]
    public class when_called_not_exactly : should_collection_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.Exactly(10);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreNotEqual(10, 10));
        }
    }

    [TestFixture]
    public class when_called_not_at_least : should_collection_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.AtLeast(10);
        }

        [Test]
        public void should_call_less_than()
        {
            Called(x => x.LessThan(10, 10));
        }
    }

    [TestFixture]
    public class when_called_not_no_more_than : should_collection_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.NoMoreThan(10);
        }

        [Test]
        public void should_call_greater_than()
        {
            Called(x => x.GreaterThan(10, 10));
        }
    }

    [TestFixture]
    public class when_called_not_zero : should_collection_not_count_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            count.Zero();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreNotEqual(0, 10));
        }
    }

    public class MyCollection : ICollection
    {
        private readonly int count;

        public MyCollection(int count)
        {
            this.count = count;
        }

        public IEnumerator GetEnumerator()
        {
            return null;
        }

        public void CopyTo(Array array, int index)
        {
        }

        public int Count
        {
            get { return count; }
        }

        public object SyncRoot
        {
            get { return null; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }
    }
}
