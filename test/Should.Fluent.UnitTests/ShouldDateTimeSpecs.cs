using System;
using Machine.Specifications;
using NUnit.Framework;
using Should.Core;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_datetime_mocked_context : test_base<DateTime>
    {
        protected static Should<DateTime, BeBase<DateTime>> should;
        protected static DateTime expected = new DateTime(1);
        protected static TimeSpan tolerance = TimeSpan.FromTicks(1);
        protected static DatePrecision precision = DatePrecision.Hour;

        Establish context = () =>
        {
            target = new DateTime(1);
            should = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object);
        };
    }

    public class when_calling_datetime_equal_with_tolerance : should_datetime_mocked_context
    {
        Because of = () => result = should.Equal(expected, tolerance);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreEqual(expected, target, tolerance));
    }

    public class when_calling_datetime_not_equal_with_tolerance : should_datetime_mocked_context
    {
        Because of = () => result = should.Not.Equal(expected, tolerance);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreNotEqual(expected, target, tolerance));
    }

    public class when_calling_datetime_equal_with_precision : should_datetime_mocked_context
    {
        Because of = () => result = should.Equal(expected, precision);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreEqual(expected, target, precision));
    }

    public class when_calling_datetime_with_not_equal_with_precision : should_datetime_mocked_context
    {
        Because of = () => result = should.Not.Equal(expected, precision);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreNotEqual(expected, target, precision));
    }
}