using System;
using System.Runtime.CompilerServices;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class ThrowsTests
    {
        public class DoesNotThrow
        {
            [Fact]
            public void DoesNotThrowException()
            {
                bool methodCalled = false;

                Assert.DoesNotThrow(() => methodCalled = true);

                Assert.True(methodCalled);
            }
        }

        public class ThrowsGenericNoReturnValue
        {
            [Fact]
            public void ExpectExceptionButCodeDoesNotThrow()
            {
                try
                {
                    Assert.Throws<ArgumentException>(delegate { });
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Equal("(No exception was thrown)", exception.Actual);
                }
            }

            [Fact]
            public void ExpectExceptionButCodeThrowsDerivedException()
            {
                try
                {
                    Assert.Throws<Exception>(delegate { throw new InvalidOperationException(); });
                }
                catch (AssertException exception)
                {
                    Assert.Equal("Assert.Throws() Failure", exception.UserMessage);
                }
            }

            [Fact]
            public void StackTraceForThrowsIsOriginalThrowNotAssertThrows()
            {
                var wasFilterStackTraceAssemblyPrefix = AssertException.FilterStackTraceAssemblyPrefix;
                AssertException.FilterStackTraceAssemblyPrefix = "Should.Core";
                Assert.ThrowsDelegate throwsDelegate = ThrowingMethod;
                try
                {
                    Assert.Throws<InvalidCastException>(throwsDelegate);
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Contains(GetMethodFullName(throwsDelegate), exception.StackTrace);
                    Assert.DoesNotContain("Should.Core", exception.StackTrace);
                }
                finally
                {
                    AssertException.FilterStackTraceAssemblyPrefix = wasFilterStackTraceAssemblyPrefix;
                }
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            static void ThrowingMethod()
            {
                throw new ArgumentException();
            }

            [Fact]
            public void GotExpectedException()
            {
                ArgumentException ex =
                    Assert.Throws<ArgumentException>(delegate { throw new ArgumentException(); });

                Assert.NotNull(ex);
            }
        }

        public class ThrowsGenericWithReturnValue
        {
            [Fact]
            public void ExpectExceptionButCodeDoesNotThrow()
            {
                StubAccessor accessor = new StubAccessor();

                try
                {
                    Assert.Throws<ArgumentException>(() => accessor.SuccessfulProperty);
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Equal("(No exception was thrown)", exception.Actual);
                }
            }

            [Fact]
            public void ExpectExceptionButCodeThrowsDerivedException()
            {
                StubAccessor accessor = new StubAccessor();

                try
                {
                    Assert.Throws<Exception>(() => accessor.FailingProperty);
                }
                catch (AssertException exception)
                {
                    Assert.Equal("Assert.Throws() Failure", exception.UserMessage);
                }
            }

            [Fact]
            public void StackTraceForThrowsIsOriginalThrowNotAssertThrows()
            {
                var wasFilterStackTraceAssemblyPrefix = AssertException.FilterStackTraceAssemblyPrefix;
                AssertException.FilterStackTraceAssemblyPrefix = "Should.Core";
                StubAccessor accessor = new StubAccessor();
                Assert.ThrowsDelegateWithReturn throwsDelegateWithReturn = () => accessor.FailingProperty;
                try
                {
                    Assert.Throws<InvalidCastException>(throwsDelegateWithReturn);
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Contains(GetMethodFullName(throwsDelegateWithReturn), exception.StackTrace);
                    Assert.DoesNotContain("Should.Core", exception.StackTrace);
                }
                finally
                {
                    AssertException.FilterStackTraceAssemblyPrefix = wasFilterStackTraceAssemblyPrefix;
                }
            }

            [Fact]
            public void GotExpectedException()
            {
                StubAccessor accessor = new StubAccessor();

                InvalidOperationException ex =
                    Assert.Throws<InvalidOperationException>(() => accessor.FailingProperty);

                Assert.NotNull(ex);
            }
        }

        public class ThrowsNonGenericNoReturnValue
        {
            [Fact]
            public void ExpectExceptionButCodeDoesNotThrow()
            {
                try
                {
                    Assert.Throws(typeof(ArgumentException), delegate { });
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Equal("(No exception was thrown)", exception.Actual);
                }
            }

            [Fact]
            public void ExpectExceptionButCodeThrowsDerivedException()
            {
                try
                {
                    Assert.Throws(typeof(Exception), delegate { throw new InvalidOperationException(); });
                }
                catch (AssertException exception)
                {
                    Assert.Equal("Assert.Throws() Failure", exception.UserMessage);
                }
            }

            [Fact]
            public void GotExpectedException()
            {
                Exception ex =
                    Assert.Throws(typeof(ArgumentException), delegate { throw new ArgumentException(); });

                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
            }
        }

        public class ThrowsNonGenericWithReturnValue
        {
            [Fact]
            public void ExpectExceptionButCodeDoesNotThrow()
            {
                StubAccessor accessor = new StubAccessor();

                try
                {
                    Assert.Throws(typeof(ArgumentException), () => accessor.SuccessfulProperty);
                }
                catch (AssertActualExpectedException exception)
                {
                    Assert.Equal("(No exception was thrown)", exception.Actual);
                }
            }

            [Fact]
            public void ExpectExceptionButCodeThrowsDerivedException()
            {
                StubAccessor accessor = new StubAccessor();

                try
                {
                    Assert.Throws(typeof(Exception), () => accessor.FailingProperty);
                }
                catch (AssertException exception)
                {
                    Assert.Equal("Assert.Throws() Failure", exception.UserMessage);
                }
            }

            [Fact]
            public void GotExpectedException()
            {
                StubAccessor accessor = new StubAccessor();

                Exception ex =
                    Assert.Throws(typeof(InvalidOperationException), () => accessor.FailingProperty);

                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }
        }

        class StubAccessor
        {
            public int SuccessfulProperty { get; set; }

            public int FailingProperty
            {
                get { throw new InvalidOperationException(); }
            }
        }

        private static string GetMethodFullName(Delegate @delegate)
        {
            var methodInfo = @delegate.Method.GetBaseDefinition();
            return string.Format("{0}.{1}", methodInfo.ReflectedType.FullName.Replace("+", "."), methodInfo.Name);
        }
    }
}