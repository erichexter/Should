using Machine.Specifications;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class when_extending_IBe
    {
        It should_handle_positive_case = () => "xxx".Should().Be.NoLongerThan(3);
        It should_handle_negative_case = () => "xxx".Should().Not.Be.NoLongerThan(2);
    }

    public class when_extending_bestring
    {
        It should_handle_positive_case = () => new Foo("bar").Should().Be.Bar();
        It should_handle_negative_case = () => new Foo("baz").Should().Not.Be.Bar();
    }

    public class when_extending_be
    {
        It should_handle_positive_case = () => 1.Should().Be.One();
        It should_handle_negative_case = () => 2.Should().Not.Be.One();
    }

    public static class BeExtensions
    {
        public static void One<T>(this Be<T> be)
        {
            be.Equals(1);
        }
    }

    public static class BeStringExtensions
    {
        public static void NoLongerThan(this IBe<string> be, int maxLength)
        {
            be.Should.Apply(
                (t, a) => a.LessThanOrEqual(t.Length, maxLength),
                (t, a) => a.GreaterThan(t.Length, maxLength));
        }
    }

    public class BeFoo : BeBase<Foo>
    {
        public BeFoo(IShould<Foo> should) : base(should) { }

        public Foo Bar()
        {
            const string exepected = "bar";
            return should.Apply(
                (t, a) => a.AreEqual(exepected, t.ToString()),
                (t, a) => a.AreNotEqual(exepected, t.ToString()));
        }
    }

    public static class ShouldCustomExtensions
    {
        public static Should<Foo, BeFoo> Should(this Foo f)
        {
            return new Should<Foo, BeFoo>(f, new ShouldCoreAssertProvider());
        }
    }
}