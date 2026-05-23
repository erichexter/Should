using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;
using Should.Fluent.Model;
using IT = Moq.It;

namespace Should.Fluent.UnitTests
{
    [TestFixture]
    public class when_calling_object_should_be_null : mocked_assert_provider_context<object>
    {
        static readonly object actual = "foo";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = actual.Should().Be.Null();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.IsNull(actual));
        }

        [Test]
        public void result_is_actual()
        {
            VerifyResult(actual);
        }

        [Test]
        public void result_is_an_object()
        {
            VerifyResultType<object>();
        }
    }

    [TestFixture]
    public class when_calling_string_should_not_be_null : mocked_assert_provider_context<object>
    {
        const string actual = "foo";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = actual.Should().Not.Be.Null();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.IsNotNull(actual));
        }

        [Test]
        public void result_is_actual()
        {
            VerifyResult(actual);
        }

        [Test]
        public void result_is_a_string()
        {
            VerifyResultType<string>();
        }
    }

    public class should_contain_test_base : mocked_assert_provider_context<IEnumerable<string>>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new List<string> { "one", "two", "three", "four" };
        }
    }

    [TestFixture]
    public class when_calling_should_contain_one : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Contain.One(x => x == "one");
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
    public class when_calling_should_contain_item : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Contain.Item(target.ToList()[0]);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_should_count_exactly : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Count.Exactly(4);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_should_not_count_exactly : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Not.Count.Exactly(3);
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_chaining : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target
                .Should().Count.Exactly(4)
                .Should().Contain.Item("two");
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_should_contain_one_and_none_found : should_contain_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Contain.One("one bazillion");
        }

        [Test]
        public void should_call_fail()
        {
            Called(x => x.Fail(IT.IsAny<string>(), 0));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_bool_should_be_true : mocked_assert_provider_context<bool>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = true;
            result = target.Should().Be.True();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.IsTrue(target));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    public class behaves_like_nullable_bool_true : mocked_assert_provider_context<bool?>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = true;
        }
    }

    [TestFixture]
    public class when_calling_nullable_bool_should_be_true : behaves_like_nullable_bool_true
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Be.True();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.IsTrue(target!.Value));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_nullable_bool_should_not_be_null : behaves_like_nullable_bool_true
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = target.Should().Not.Be.Null();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.IsNotNull(target));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_guid_should_be_empty : mocked_assert_provider_context<Guid>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = Guid.Empty;
            result = target.Should().Be.Empty();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(Guid.Empty, target));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_guid_should_not_be_empty : mocked_assert_provider_context<Guid>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = Guid.NewGuid();
            result = target.Should().Not.Be.Empty();
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreNotEqual(Guid.Empty, target));
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }
    }

    [TestFixture]
    public class when_calling_string_should_be_covertable_to : mocked_assert_provider_context
    {
        static string actual;
        static Guid result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            actual = Guid.NewGuid().ToString();
            result = actual.Should().Be.ConvertableTo<Guid>();
        }

        [Test]
        public void result_is_actual_converted()
        {
            var converter = TypeDescriptor.GetConverter(typeof(Guid));
            var expected = (Guid)converter.ConvertFrom(actual)!;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_string_should_not_be_covertable_to : mocked_assert_provider_context
    {
        const string actual = "foo";
        static int result;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = actual.Should().Not.Be.ConvertableTo<int>();
        }

        [Test]
        public void result_is_default()
        {
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }
}
