using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class ShouldDoubleExtensions
    {
        public static double Equal(this IShould<double> should, double expected, double tolerance)
        {
            return should.Apply(
                (t, a) => a.AreEqual(expected, t, tolerance),
                (t, a) => a.AreNotEqual(expected, t, tolerance)
            );
        }
    }
}