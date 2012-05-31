using System;
using System.Collections.Generic;
using System.Text;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class EqualTests
    {
        public class ArrayTests
        {
            [Fact]
            public void Array()
            {
                string[] expected = { "@", "a", "ab", "b" };
                string[] actual = { "@", "a", "ab", "b" };

                Assert.Equal(expected, actual);
                Assert.Throws<NotEqualException>(() => Assert.NotEqual(expected, actual));
            }

            [Fact]
            public void ArraysOfDifferentLengthsAreNotEqual()
            {
                string[] expected = { "@", "a", "ab", "b", "c" };
                string[] actual = { "@", "a", "ab", "b" };

                Assert.Throws<EqualException>(() => Assert.Equal(expected, actual));
                Assert.NotEqual(expected, actual);
            }

            [Fact]
            public void ArrayValuesAreDifferentNotEqual()
            {
                string[] expected = { "@", "d", "v", "d" };
                string[] actual = { "@", "a", "ab", "b" };

                Assert.Throws<EqualException>(() => Assert.Equal(expected, actual));
                Assert.NotEqual(expected, actual);
            }

            [Fact]
            public void NullValuesInArraysCreateCorrectExceptionMessage()
            {
                Exception ex = Record.Exception(
                    () => Assert.Equal(new [] { null, "hello" }, new [] { null, "world" }));

                Assert.IsType<EqualException>(ex);
                Assert.Equal("Assert.Equal() Failure\r\nPosition: First difference is at position 1\r\nExpected: System.String[] { (null), hello }\r\nActual:   System.String[] { (null), world }", ex.Message);
            }
        }

        public class DoubleInfinityTests
        {
            [Fact]
            public void DoubleNegativeInfinityEqualsNegativeInfinity()
            {
                Assert.Equal(Double.NegativeInfinity, Double.NegativeInfinity);
            }

            [Fact]
            public void DoubleNegativeInfinityNotEquals()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(1.23, Double.NegativeInfinity));
            }

            [Fact]
            public void DoublePositiveInfinityEqualsPositiveInfinity()
            {
                Assert.Equal(Double.PositiveInfinity, Double.PositiveInfinity);
            }

            [Fact]
            public void DoublePositiveInfinityNotEquals()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(1.23, Double.PositiveInfinity));
            }

            [Fact]
            public void DoublePositiveInfinityNotEqualsNegativeInfinity()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(Double.NegativeInfinity, Double.PositiveInfinity));
            }
        }

        public class EnumerableTests
        {
            [Fact]
            public void Select_should_equal_Select()
            {
                IEnumerable<int> items = IntGenerator.Range(1, 12);
                IEnumerable<int> others = IntGenerator.Range(1, 12);

                Assert.Equal(items, others);
            }

            [Fact]
            public void When_comparing_enumerables_of_equitable_objects_Should_use_IEquitable_Equals_for_each_item()
            {
                var obj1 = new EquatableObject();
                var obj2 = new EquatableObject();
                var list1 = new List<EquatableObject> { obj1, obj2 };

                var obj3 = new EquatableObject();
                var obj4 = new EquatableObject();
                var list2 = new List<EquatableObject> { obj3, obj4 };

                Record.Exception(() => Assert.Equal(list1, list2));

                Assert.True(obj1.Equals__Called);
                Assert.True(obj2.Equals__Called);
                Assert.Equal(obj2.Equals_Other, obj3);
                Assert.Equal(obj2.Equals_Other, obj4);
            }

            [Fact]
            public void When_comparing_enumerables_of_custom_equality_objects_Should_use_custom_equals_on_the_base_object_for_each_item()
            {
                var obj1 = new CustomEqualityObject();
                var obj2 = new DerivedCustomEqualityObject();
                var list1 = new List<CustomEqualityObject> { obj1, obj2 };

                var obj3 = new DerivedCustomEqualityObject();
                var obj4 = new CustomEqualityObject();
                var list2 = new List<CustomEqualityObject> { obj3, obj4 };

                Record.Exception(() => Assert.Equal(list1, list2));

                Assert.True(obj1.EqualsCalled);
                Assert.True(obj4.EqualsCalled);
                Assert.Equal(obj1.EqualsCalledOn, obj3);
                Assert.Equal(obj4.EqualsCalledOn, obj2);
            }

            class IntGenerator
            {
                public static IEnumerable<int> Range(int start, int end)
                {
                    for (int i = start; i <= end; i++)
                        yield return i;
                }
            }
        }

        public class EquatableObject : IEquatable<EquatableObject>
        {
            public bool Equals__Called;
            public EquatableObject Equals_Other;

            public bool Equals(EquatableObject other)
            {
                Equals__Called = true;
                Equals_Other = other;

                return true;
            }
        }

        public class DerivedEquatableObject : EquatableObject
        {
        }

        public class EquatableObjectTests
        {
            [Fact]
            public void CallsIEquatable()
            {
                EquatableObject obj1 = new EquatableObject();
                EquatableObject obj2 = new EquatableObject();

                Assert.Equal(obj1, obj2);

                Assert.True(obj1.Equals__Called);
                Assert.Same(obj2, obj1.Equals_Other);
            }

            [Fact]
            public void When_copmaring_derived_IEquitable_object_Should_equate()
            {
                EquatableObject baseObj = new EquatableObject();
                DerivedEquatableObject derivedObj = new DerivedEquatableObject();

                Assert.Equal(baseObj, derivedObj);
                Assert.True(baseObj.Equals__Called);
            }

            [Fact]
            public void When_comparing_base_Generic_IComparable_object_Should_equate()
            {
                EquatableObject baseObj = new EquatableObject();
                DerivedEquatableObject derivedObj = new DerivedEquatableObject();

                Assert.Equal(derivedObj, baseObj);
                Assert.True(baseObj.Equals__Called);
            }

        }

        public class NaNTests
        {
            [Fact]
            public void EqualsNaNFails()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(Double.NaN, 1.234));
            }

            [Fact]
            public void NanEqualsFails()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(1.234, Double.NaN));
            }

            [Fact]
            public void NanEqualsNaNSucceeds()
            {
                Assert.Equal(Double.NaN, Double.NaN);
            }
        }

        public class NullTests
        {
            [Fact]
            public void EqualsNull()
            {
                Assert.Equal<object>(null, null);
            }

            [Fact]
            public void FailsWhenActualIsNullExpectedIsNot()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(new object(), null));
            }

            [Fact]
            public void FailsWhenExpectedIsNullActualIsNot()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(null, new object()));
            }
        }

        public class ToleranceTests
        {
            [Fact]
            public void Equal_GivenSameNumberAndToleranceOfZero_Succeeds()
            {
                Assert.Equal(1.0, 1.0, 0.0);
            }

            [Fact]
            public void Equal_WhenNumbersAreWithinTolerance_Succeeds()
            {
                Assert.Equal(1.1, 1.2, 0.1);
            }

            [Fact]
            public void Equal_WhenNumbersAreOutsideTolerance_Fails()
            {
                Xunit.Assert.Throws<EqualException>(() => Assert.Equal(1.1, 1.3, 0.1));
            }

            [Fact]
            public void Equal_UserMessageIsInTheExceptionMessage()
            {
                string userMessage = "my message";
                
                var ex = Xunit.Assert.Throws<EqualException>(() =>
                {
                    Assert.Equal(1.1, 1.3, 0.1, userMessage);
                });

                Xunit.Assert.Contains(userMessage, ex.Message);
            }

            [Fact]
            public void Equal_ToleranceValueIsInTheExceptionMessage()
            {
                double tolerance = 0.1;

                var exception = Xunit.Assert.Throws<EqualException>(() =>
                {
                    Assert.Equal(1.1, 1.3, tolerance);
                });
                
                Xunit.Assert.Contains("+/- " + tolerance, exception.Message);
            }

            [Fact]
            public void NotEqual_GivenSameNumberAndToleranceOfZero_Fails()
            {
                Xunit.Assert.Throws<NotEqualException>(() => Assert.NotEqual(1.0, 1.0, 0));
            }

            [Fact]
            public void NotEqual_WhenNumbersAreWithinTolerance_Fails()
            {
                Xunit.Assert.Throws<NotEqualException>(() => Assert.NotEqual(1.1, 1.2, 0.1));
            }

            [Fact]
            public void NotEqual_WhenNumbersAreOutsideTolerance_Succeeds()
            {
                Assert.NotEqual(1.1, 1.3, 0.1);
            }

            [Fact]
            public void NotEqual_UserMessageIsInTheExceptionMessage()
            {
                string userMessage = "my message";

                var ex = Xunit.Assert.Throws<NotEqualException>(() =>
                {
                    Assert.NotEqual(1.0, 1.0, 0, userMessage);
                });

                Xunit.Assert.Contains(userMessage, ex.Message);
            }

            [Fact]
            public void NotEqual_ToleranceValueIsInTheExceptionMessage()
            {
                double tolerance = 0.1;

                var exception = Xunit.Assert.Throws<NotEqualException>(() =>
                {
                    Assert.NotEqual(1.0, 1.0, tolerance);
                });

                Xunit.Assert.Contains("+/- " + tolerance, exception.Message);
            }
        }

        public class NumericTests
        {
            [Fact]
            public void DecimalEqualsFails()
            {
                decimal expected = 25;
                decimal actual = 42;

                Assert.Throws<EqualException>(() => Assert.Equal(expected, actual));
            }

            [Fact]
            public void DoubleEqualsFails()
            {
                double expected = 25.3;
                double actual = 42.0;

                Assert.Throws<EqualException>(() => Assert.Equal(expected, actual));
            }

            [Fact]
            public void EqualsByte()
            {
                byte valueType = 35;
                Byte referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<byte>(valueType, 35);
                Assert.Equal<byte>(referenceValue, 35);
            }

            [Fact]
            public void EqualsDecimal()
            {
                decimal valueType = 35;
                Decimal referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<decimal>(valueType, 35);
                Assert.Equal(valueType, 35M);
                Assert.Equal<decimal>(referenceValue, 35);
            }

            [Fact]
            public void EqualsInt16()
            {
                short valueType = 35;
                Int16 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<short>(valueType, 35);
                Assert.Equal<short>(referenceValue, 35);
            }

            [Fact]
            public void EqualsInt32()
            {
                int valueType = 35;
                Int32 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal(valueType, 35);
                Assert.Equal(referenceValue, 35);
            }

            [Fact]
            public void EqualsInt64()
            {
                long valueType = 35;
                Int64 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<long>(valueType, 35);
                Assert.Equal<long>(referenceValue, 35);
            }

            [Fact]
            public void EqualsSByte()
            {
                sbyte valueType = 35;
                SByte referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<sbyte>(valueType, 35);
                Assert.Equal<sbyte>(referenceValue, 35);
            }

            [Fact]
            public void EqualsUInt16()
            {
                ushort valueType = 35;
                UInt16 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<ushort>(valueType, 35);
                Assert.Equal<ushort>(referenceValue, 35);
            }

            [Fact]
            public void EqualsUInt32()
            {
                uint valueType = 35;
                UInt32 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<uint>(valueType, 35);
                Assert.Equal<uint>(referenceValue, 35);
            }

            [Fact]
            public void EqualsUInt64()
            {
                ulong valueType = 35;
                UInt64 referenceValue = 35;

                Assert.True(valueType == referenceValue);
                Assert.Equal(referenceValue, valueType);
                Assert.Equal<ulong>(valueType, 35);
                Assert.Equal<ulong>(referenceValue, 35);
            }

            [Fact]
            public void Int32Int64Comparison()
            {
                long l64 = 0;
                int i32 = 0;
                Assert.Equal<long>(l64, i32);
            }

            [Fact]
            public void IntegerLongComparison()
            {
                Assert.Equal<long>(1L, 1);
                Assert.Equal<long>(1, 1L);
            }

            [Fact]
            public void LongEquals()
            {
                Assert.Equal(2L, 2L);
            }

            [Fact]
            public void LongEqualsFails()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(3L, 2L));
            }

            [Fact]
            public void UInt64EqualsFails()
            {
                UInt64 expected = 25;
                UInt64 actual = 42;

                Assert.Throws<EqualException>(() => Assert.Equal(expected, actual));
            }
        }

        public class SingleInfinityTests
        {
            [Fact]
            public void SingleNegativeInfinityEqualsNegativeInfinity()
            {
                Assert.Equal(Single.NegativeInfinity, Single.NegativeInfinity);
            }

            [Fact]
            public void SingleNumberNotEqualNegativeInfinity()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(1.23f, Single.NegativeInfinity));
            }

            [Fact]
            public void SingleNumberNotEqualPositiiveInfinity()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(1.23f, Single.PositiveInfinity));
            }

            [Fact]
            public void SinglePositiveInfinityEqualsPositiveInfinity()
            {
                Assert.Equal(Single.PositiveInfinity, Single.PositiveInfinity);
            }

            [Fact]
            public void SinglePositiveInfinityNotEqualNegativeInfinity()
            {
                Assert.Throws<EqualException>(() => Assert.Equal(Single.NegativeInfinity, Single.PositiveInfinity));
            }
        }

        public class StringTests
        {
            [Fact]
            public void EqualsFail()
            {
                Assert.Throws<EqualException>(() => Assert.Equal("expected", "actual"));
            }

            [Fact]
            public void EqualsString()
            {
                string testString = "Test String";
                string expected = testString;
                string actual = testString;

                Assert.True(actual == expected);
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void EqualStringWithTrailingNull()
            {
                Exception ex = Record.Exception(() => Assert.Equal("foo", "foo\0"));

                Assert.IsType<EqualException>(ex);
            }

            [Fact]
            public void EqualsStringIgnoreCase()
            {
                string expected = "TestString";
                string actual = "testString";

                Assert.False(actual == expected);
                Assert.NotEqual(expected, actual);
                Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
            }

            [Fact]
            public void String()
            {
                string s1 = "test";
                string s2 = new StringBuilder(s1).ToString();

                Assert.True(s1.Equals(s2));
                Assert.Equal(s2, s1);
            }
        }

        public class NullableValueTypesTests
        {
            [Fact]
            public void NullableValueTypesCanBeNull()
            {
                DateTime? dt1 = null;
                DateTime? dt2 = null;

                Assert.Equal(dt1, dt2);
            }
        }

        public class DerivedTypeTests
        {
            [Fact]
            public void When_comparing_object_with_overriden_equality_behavior_to_derived_object_Should_use_overriden_behavior()
            {
                var obj = new CustomEqualityObject();
                var derivedObj = new DerivedCustomEqualityObject();
                Assert.Equal(obj, derivedObj);

                Assert.True(obj.EqualsCalled);
                Assert.Equal(obj.EqualsCalledOn, derivedObj);
            }

            [Fact]
            public void When_comparing_object_with_default_equality_behavior_to_derived_class_Should_fail()
            {
                var obj = new DefaultEqualityObject();
                var derivedObj = new DerivedDefaultEqualityObject();
                var ex = Record.Exception(() => Assert.Equal(obj, derivedObj));
                Assert.IsType<EqualException>(ex);
            }
        }

        class CustomEqualityObject
        {
            public bool EqualsCalled;
            public object EqualsCalledOn;

            public override bool Equals(object obj)
            {
                EqualsCalled = true;
                EqualsCalledOn = obj;
                return true;
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }

        class DerivedCustomEqualityObject : CustomEqualityObject
        {
        }

        class DefaultEqualityObject
        {
        }

        class DerivedDefaultEqualityObject : DefaultEqualityObject
        {
        }
    }
}