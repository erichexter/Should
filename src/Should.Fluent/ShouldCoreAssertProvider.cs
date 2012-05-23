using System;
using System.Collections.Generic;
using Should.Core;
using Should.Core.Assertions;
using Should.Core.Exceptions;

namespace Should.Fluent
{
    public class ShouldCoreAssertProvider : IAssertProvider
    {
        public void AreEqual(object expected, object actual)
        {
            Assert.Equal(expected, actual);
        }

        public void AreNotEqual(object expected, object actual)
        {
            Assert.NotEqual(expected, actual);
        }

        public void AreEqual(double expected, double actual, double tolerance)
        {
            Assert.Equal(expected, actual, tolerance);
        }

        public void AreNotEqual(double expected, double actual, double tolerance)
        {
            Assert.NotEqual(expected, actual, tolerance);
        }

        public void AreEqual(DateTime expected, DateTime actual, TimeSpan tolerance)
        {
            Assert.Equal(expected, actual, tolerance);
        }

        public void AreNotEqual(DateTime expected, DateTime actual, TimeSpan tolerance)
        {
            Assert.NotEqual(expected, actual, tolerance);
        }

        public void AreEqual(DateTime expected, DateTime actual, DatePrecision precision)
        {
            Assert.Equal(expected, actual, precision);
        }

        public void AreNotEqual(DateTime expected, DateTime actual, DatePrecision precision)
        {
            Assert.NotEqual(expected, actual, precision);
        }

        public void GreaterThan<T>(T left, T right)
        {
            Assert.GreaterThan(left, right);
        }

        public void GreaterThan<T>(T left, T right, IComparer<T> comparer)
        {
            Assert.GreaterThan(left, right, comparer);
        }

        public void GreaterThanOrEqual<T>(T left, T right)
        {
            Assert.GreaterThanOrEqual(left, right);
        }

        public void GreaterThanOrEqual<T>(T left, T right, IComparer<T> comparer)
        {
            Assert.GreaterThanOrEqual(left, right, comparer);
        }

        public void LessThan(double left, double right)
        {
            Assert.LessThan(left, right);
        }

        public void LessThanOrEqual(double left, double right)
        {
            Assert.LessThanOrEqual(left, right);
        }

        public void LessThan<T>(T left, T right)
        {
            Assert.LessThan(left, right);
        }

        public void LessThan<T>(T left, T right, IComparer<T> comparer)
        {
            Assert.LessThan(left, right, comparer);
        }

        public void LessThanOrEqual<T>(T left, T right)
        {
            Assert.LessThanOrEqual(left, right);
        }

        public void LessThanOrEqual<T>(T left, T right, IComparer<T> comparer)
        {
            Assert.LessThanOrEqual(left, right, comparer);
        }

        public void IsNotNull(object value)
        {
            Assert.NotNull(value);
        }

        public void IsNull(object value)
        {
            Assert.Null(value);
        }

        public void IsFalse(bool value)
        {
            Assert.False(value);
        }

        public void IsTrue(bool value)
        {
            Assert.True(value);
        }

        public void Fail(string messageFormat, params object[] args)
        {
            args = args ?? new object[0];
            throw new AssertException(string.Format(messageFormat, args));
        }

        public void Contains<T>(T item, IEnumerable<T> enumerable)
        {
            Assert.Contains(item, enumerable);
        }

        public void NotContains<T>(T item, IEnumerable<T> enumerable)
        {
            Assert.DoesNotContain(item, enumerable);
        }

        public void GreaterThan(double left, double right)
        {
            throw new NotImplementedException();
        }

        public void GreaterThanOrEqual(double left, double right)
        {
            throw new NotImplementedException();
        }

        public void AreSame(object expected, object actual)
        {
            Assert.Same(expected, actual);
        }

        public void AreNotSame(object expected, object actual)
        {
            Assert.NotSame(expected, actual);
        }

        public void IsSubstringOf(string actual, string expectedSubstring)
        {
            Assert.Contains(expectedSubstring, actual);
        }

        public void IsInstanceOfType(object actual, Type expectedType)
        {
            Assert.IsType(expectedType, actual);
        }

        public void IsNotInstanceOfType(object actual, Type expectedType)
        {
            Assert.IsNotType(expectedType, actual);
        }

        public void InRange<T>(T target, T low, T high)
        {
            Assert.InRange(target, low, high);
        }

        public void NotInRange<T>(T target, T low, T high)
        {
            Assert.NotInRange(target, low, high);
        }

        public void AssignableFrom<T>(T target, Type expectedType)
        {
            Assert.IsAssignableFrom(expectedType, target);
        }

        public void NotAssignableFrom<T>(T target, Type expectedType)
        {
            try
            {
                Assert.IsAssignableFrom(expectedType, target);
                throw new AssertException(string.Format("Expected {0} to NOT be assignable from {1}, but it is.", target.GetType(), expectedType));
            }
            catch (IsAssignableFromException) { }
        }
    }
}