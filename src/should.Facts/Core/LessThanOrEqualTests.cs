using System;
using Xunit;
using Assert = Should.Core.Assertions.Assert;
using Should.Core.Exceptions;

namespace Should.Facts.Core
{
    public class LessThanOrEqualTests
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.AddDays(1);

        [Fact]
        public void One_is_less_than_or_equal_to_one_should_pass()
        {
            Assert.LessThanOrEqual(1, 1);
        }

        [Fact]
        public void One_is_less_than_or_equal_to_two_should_pass()
        {
            Assert.LessThanOrEqual(1, 2);
        }

        [Fact]
        public void Two_is_not_less_than_or_equal_to_one_should_fail()
        {
            Assert.Throws<LessThanOrEqualException>(() => Assert.LessThanOrEqual(2, 1));
        }

        [Fact]
        public void Today_is_less_than_or_equal_to_today_should_pass()
        {
            Assert.LessThanOrEqual(today, today);
        }

        [Fact]
        public void Today_is_less_than_or_equal_to_tomorrow_should_pass()
        {
            Assert.LessThanOrEqual(today, tomorrow);
        }

        [Fact]
        public void Tomorrow_is_not_less_than_or_equal_to_today_should_fail()
        {
            Assert.Throws<LessThanOrEqualException>(() => Assert.LessThanOrEqual(tomorrow, today));
        }

        [Fact]
        public void a_is_less_than_or_equal_to_b_should_pass()
        {
            Assert.LessThanOrEqual("a", "b");
        }

        [Fact]
        public void b_is_not_less_than_or_equal_to_a_should_fail()
        {
            Assert.Throws<LessThanOrEqualException>(() => Assert.LessThanOrEqual("b", "a"));
        }

        [Fact]
        public void A_is_less_than_or_equal_to_a_using_case_sensitive_ordinal_comparer_should_pass()
        {
            Assert.LessThanOrEqual("A", "a", StringComparer.Ordinal);
        }

        [Fact]
        public void A_is_less_than_or_equal_to_a_using_case_insensitive_ordinal_comparer_should_pass()
        {
            Assert.LessThanOrEqual("A", "a", StringComparer.OrdinalIgnoreCase);
        }
    }
}