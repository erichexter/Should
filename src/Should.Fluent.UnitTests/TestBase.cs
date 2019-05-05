﻿using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Moq;
using Xunit;
using IT = Moq.It;

//NOTE: Explcitly call methods on ShouldExtensions to prevent collisions with m-spec extension methods
namespace Should.Fluent.UnitTests
{
    public class test_base
    {
        protected static Mock<IAssertProvider> mockAssertProvider;

        private Establish context = () =>
        {
            mockAssertProvider = new MockFactory(MockBehavior.Loose).Create<IAssertProvider>();
        };

        protected static void Called(Expression<Action<IAssertProvider>> action)
        {
            mockAssertProvider.Verify(action);
        }

        protected static void NotCalled(Expression<Action<IAssertProvider>> action)
        {
            mockAssertProvider.Verify(action, Times.Never());
        }

        protected static void Fail(string message)
        {
            Called(x => x.Fail(message));
        }

        protected static void Fail(string message, object arg1)
        {
            Called(x => x.Fail(message, arg1));
        }

        protected static void Fail(string message, object arg1, object arg2)
        {
            Called(x => x.Fail(message, arg1, arg2));
        }

        protected static void NotFail()
        {
            NotCalled(x => x.Fail(IT.IsAny<string>(), IT.IsAny<object>()));
            NotCalled(x => x.Fail(IT.IsAny<string>()));
        }

        protected static void ExpectThrow(Expression<Action<IAssertProvider>> action)
        {
            mockAssertProvider.Setup(action).Throws<Exception>();
        }
    }

    public class test_base<T> : test_base
    {
        protected static T target;
        protected static T result;

        protected static void VerifyResultType<TExpetected>()
        {
            Assert.IsType<TExpetected>(result);
        }

        protected static void VerifyResult(object actual)
        {
            Assert.Equal(actual, result);
        }
    }

    public class mocked_assert_provider_context : test_base
    {
        Establish context = () => ShouldExtensions.AssertProvider = mockAssertProvider.Object;
        Cleanup after_all = ShouldExtensions.ResetAssertProvider;
    }

    public class mocked_assert_provider_context<T> : test_base<T>
    {
        Establish context = () => ShouldExtensions.AssertProvider = mockAssertProvider.Object;
        Cleanup after_all = ShouldExtensions.ResetAssertProvider;
    }

    public class Foo
    {
        private readonly string value;

        public Foo(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}