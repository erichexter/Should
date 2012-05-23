using System;
using Machine.Specifications;
using Should.Core.Exceptions;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    public class when_should_be_greater_than_fails : integration_test_base
    {
        Because of = () => Try(() => 1.Should().Be.GreaterThan(2));
        Behaves_like<Throws<GreaterThanException>> yes;
    }

    public class when_should_be_greater_than_passes : integration_test_base
    {
        Because of = () => Try(() => 2.Should().Be.GreaterThan(1));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_greater_than_with_comparer_fails : integration_test_base
    {
        Because of = () => Try(() => "A".Should().Be.GreaterThan("a", StringComparer.Ordinal));
        Behaves_like<Throws<GreaterThanException>> yes;
    }

    public class when_should_be_greater_than_with_comparer_passes : integration_test_base
    {
        Because of = () => Try(() => "b".Should().Be.GreaterThan("A", StringComparer.OrdinalIgnoreCase));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_greater_than_or_equal_to_fails : integration_test_base
    {
        Because of = () => Try(() => 1.Should().Be.GreaterThanOrEqualTo(2));
        Behaves_like<Throws<GreaterThanOrEqualException>> yes;
    }

    public class when_should_be_greater_than_or_equal_to_passes : integration_test_base
    {
        Because of = () => Try(() => 1.Should().Be.GreaterThanOrEqualTo(1));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_greater_than_or_equal_to_with_comparer_fails : integration_test_base
    {
        Because of = () => Try(() => "A".Should().Be.GreaterThanOrEqualTo("a", StringComparer.Ordinal));
        Behaves_like<Throws<GreaterThanOrEqualException>> yes;
    }

    public class when_should_be_greater_than_or_equal_to_with_comparer_passes : integration_test_base
    {
        Because of = () => Try(() => "a".Should().Be.GreaterThanOrEqualTo("A", StringComparer.OrdinalIgnoreCase));
        Behaves_like<DoesNotThrow> yes;
    }
}