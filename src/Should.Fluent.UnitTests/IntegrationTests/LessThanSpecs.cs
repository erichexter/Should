using System;
using Machine.Specifications;
using Should.Core.Exceptions;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    public class when_should_be_less_than_fails : integration_test_base
    {
        Because of = () => Try(() => 2.Should().Be.LessThan(1));
        Behaves_like<Throws<LessThanException>> yes;
    }

    public class when_should_be_less_than_passes : integration_test_base
    {
        Because of = () => Try(() => 1.Should().Be.LessThan(2));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_less_than_with_comparer_fails : integration_test_base
    {
        Because of = () => Try(() => "a".Should().Be.LessThan("A", StringComparer.Ordinal));
        Behaves_like<Throws<LessThanException>> yes;
    }

    public class when_should_be_less_than_with_comparer_passes : integration_test_base
    {
        Because of = () => Try(() => "A".Should().Be.LessThan("b", StringComparer.OrdinalIgnoreCase));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_less_than_or_equal_to_fails : integration_test_base
    {
        Because of = () => Try(() => 2.Should().Be.LessThanOrEqualTo(1));
        Behaves_like<Throws<LessThanOrEqualException>> yes;
    }

    public class when_should_be_less_than_or_equal_to_passes : integration_test_base
    {
        Because of = () => Try(() => 1.Should().Be.LessThanOrEqualTo(1));
        Behaves_like<DoesNotThrow> yes;
    }

    public class when_should_be_less_than_or_equal_to_with_comparer_fails : integration_test_base
    {
        Because of = () => Try(() => "a".Should().Be.LessThanOrEqualTo("A", StringComparer.Ordinal));
        Behaves_like<Throws<LessThanOrEqualException>> yes;
    }

    public class when_should_be_less_than_or_equal_to_with_comparer_passes : integration_test_base
    {
        Because of = () => Try(() => "A".Should().Be.LessThanOrEqualTo("a", StringComparer.OrdinalIgnoreCase));
        Behaves_like<DoesNotThrow> yes;
    }
}
