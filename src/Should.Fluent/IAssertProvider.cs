using System;
using System.Collections.Generic;
using Should.Core;

namespace Should.Fluent
{
    public interface IAssertProvider
    {
        void AreEqual(object expected, object actual);
        void AreNotEqual(object expected, object actual);
        void AreEqual(double expected, double actual, double tolerance);
        void AreNotEqual(double expected, double actual, double tolerance);
        void AreEqual(DateTime expected, DateTime actual, TimeSpan tolerance);
        void AreNotEqual(DateTime expected, DateTime actual, TimeSpan tolerance);
        void AreEqual(DateTime expected, DateTime actual, DatePrecision precision);
        void AreNotEqual(DateTime expected, DateTime actual, DatePrecision precision);
        void IsNotNull(object value);
        void IsNull(object value);
        void IsFalse(bool value);
        void IsTrue(bool value);
        void Fail(string messageFormat, params object[] args);
        void Contains<T>(T item, IEnumerable<T> enumerable);
        void NotContains<T>(T item, IEnumerable<T> enumerable);
        void GreaterThan(double left, double right);
        void GreaterThanOrEqual(double left, double right);
        void GreaterThan<T>(T left, T right);
        void GreaterThan<T>(T left, T right, IComparer<T> comparer);
        void GreaterThanOrEqual<T>(T left, T right);
        void GreaterThanOrEqual<T>(T left, T right, IComparer<T> comparer);
        void LessThan(double left, double right);
        void LessThanOrEqual(double left, double right);
        void LessThan<T>(T left, T right);
        void LessThan<T>(T left, T right, IComparer<T> comparer);
        void LessThanOrEqual<T>(T left, T right);
        void LessThanOrEqual<T>(T left, T right, IComparer<T> comparer);
        void AreSame(object expected, object actual);
        void AreNotSame(object expected, object actual);
        void IsSubstringOf(string actual, string expectedSubstring);
        void IsInstanceOfType(object actual, Type expectedType);
        void IsNotInstanceOfType(object actual, Type expectedType);
        void InRange<T>(T target, T low, T high);
        void NotInRange<T>(T target, T low, T high);
        void AssignableFrom<T>(T target, Type expectedType);
        void NotAssignableFrom<T>(T target, Type expectedType);
    }
}