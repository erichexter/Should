using System;
using Xunit;
using Assert = Should.Core.Assertions.Assert;
using Should.Core.Exceptions;

namespace Should.Facts.Core
{
    public class GreaterThanOrEqualTests
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.AddDays(1);

        [Fact]
        public void One_is_greater_than_or_equal_to_one_should_pass()
        {
            Assert.GreaterThanOrEqual(1, 1);
        }

        [Fact]
        public void Two_is_greater_than_or_equal_to_one_should_pass()
        {
            Assert.GreaterThanOrEqual(2, 1);
        }
        
        [Fact]
        public void One_is_not_greater_than_or_equal_to_two_should_fail()
        {
            Assert.Throws<GreaterThanOrEqualException>(() => Assert.GreaterThanOrEqual(1, 2));
        }

        [Fact]
        public void Today_is_greater_than_or_equal_to_today_should_pass()
        {
            Assert.GreaterThanOrEqual(today, today);
        }
        
        [Fact]
        public void Tomorrow_is_greater_than_or_equal_to_today_should_pass()
        {
            Assert.GreaterThanOrEqual(tomorrow, today);
        }

        [Fact]
        public void Today_is_not_greater_than_or_equal_to_tomorrow_should_fail()
        {
            Assert.Throws<GreaterThanOrEqualException>(() => Assert.GreaterThanOrEqual(today, tomorrow));
        }

        [Fact]
        public void b_is_greater_than_or_equal_to_a_should_pass()
        {
            Assert.GreaterThanOrEqual("b", "a");
        }

        [Fact]
        public void a_is_not_greater_than_or_equal_to_b_should_fail()
        {
            Assert.Throws<GreaterThanOrEqualException>(() => Assert.GreaterThanOrEqual("a", "b"));
        }

        [Fact]
        public void a_is_greater_than_or_equal_to_A_using_case_sensitive_ordinal_comparer_should_pass()
        {
            Assert.GreaterThanOrEqual("a", "A", StringComparer.Ordinal);
        }

        [Fact]
        public void a_is_greater_than_or_equal_to_A_using_case_insensitive_ordinal_comparer_should_pass()
        {
            Assert.GreaterThanOrEqual("a", "A", StringComparer.OrdinalIgnoreCase);
        }
    }
}