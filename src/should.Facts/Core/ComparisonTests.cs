using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class ComparisonTests
    {
        [Fact]
        public void comparison_asserts_should_use_greaterthan_and_lessthan_overloads_for_classes_that_do_not_implement_icomparable_or_icomparableT()
        {
            Assert.GreaterThan(new DerivedFromOverloadsComparisonOperators(2), new OverloadsComparisonOperators(1));
            Assert.GreaterThanOrEqual(new OverloadsComparisonOperators(2), new DerivedFromOverloadsComparisonOperators(1));
            Assert.GreaterThanOrEqual(new DerivedFromOverloadsComparisonOperators(2), new OverloadsComparisonOperators(2));

            Assert.LessThan(new OverloadsComparisonOperators(1), new DerivedFromOverloadsComparisonOperators(2));
            Assert.LessThanOrEqual(new DerivedFromOverloadsComparisonOperators(1), new OverloadsComparisonOperators(2));
            Assert.LessThanOrEqual(new OverloadsComparisonOperators(2), new DerivedFromOverloadsComparisonOperators(2));
        }

        [Fact]
        public void comparison_asserts_should_use_greaterthanorequal_and_lessthanorequal_overloads_for_classes_that_do_not_implement_icomparableor_icomparableT()
        {
            Assert.GreaterThan(new DerivedFromOverloadsComparisonEqualOperators(2), new OverloadsComparisonEqualOperators(1));
            Assert.GreaterThanOrEqual(new OverloadsComparisonEqualOperators(2), new DerivedFromOverloadsComparisonEqualOperators(1));
            Assert.GreaterThanOrEqual(new DerivedFromOverloadsComparisonEqualOperators(2), new OverloadsComparisonEqualOperators(2));

            Assert.LessThan(new OverloadsComparisonEqualOperators(1), new DerivedFromOverloadsComparisonEqualOperators(2));
            Assert.LessThanOrEqual(new DerivedFromOverloadsComparisonEqualOperators(1), new OverloadsComparisonEqualOperators(2));
            Assert.LessThanOrEqual(new OverloadsComparisonEqualOperators(2), new DerivedFromOverloadsComparisonEqualOperators(2));
        }

        [Fact]
        public void should_test_equality_if_niether_icomparable_and_icomparableT_are_implemented()
        {
            var obj = new ClassWithNoComparisonBehavior();
            Assert.GreaterThanOrEqual(obj, obj);
        }

        public class ClassWithInnerValue
        {
            protected readonly int value;

            public ClassWithInnerValue(int value)
            {
                this.value = value;
            }
        }

        public class OverloadsComparisonOperators : ClassWithInnerValue
        {
            public OverloadsComparisonOperators(int value) : base(value) { }

            public static bool operator >(OverloadsComparisonOperators left, OverloadsComparisonOperators right)
            {
                return left.value > right.value;
            }

            public static bool operator <(OverloadsComparisonOperators left, OverloadsComparisonOperators right)
            {
                return left.value < right.value;
            }
        }

        public class DerivedFromOverloadsComparisonOperators : OverloadsComparisonOperators
        {
            public DerivedFromOverloadsComparisonOperators(int value) : base(value) { }
        }

        public class OverloadsComparisonEqualOperators : ClassWithInnerValue
        {
            public OverloadsComparisonEqualOperators(int value) : base(value) { }

            public static bool operator >=(OverloadsComparisonEqualOperators left, OverloadsComparisonEqualOperators right)
            {
                return left.value >= right.value;
            }

            public static bool operator <=(OverloadsComparisonEqualOperators left, OverloadsComparisonEqualOperators right)
            {
                return left.value <= right.value;
            }
        }

        public class DerivedFromOverloadsComparisonEqualOperators : OverloadsComparisonEqualOperators
        {
            public DerivedFromOverloadsComparisonEqualOperators(int value) : base(value) { }
        }

        public class ClassWithNoComparisonBehavior
        {
            
        }
    }
}