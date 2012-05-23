namespace Should.Fluent.Model
{
    public class ShouldDouble : ShouldBase<ShouldDouble, double, BeDouble>
    {
        public ShouldDouble(double target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public double Equal(double expected, double tolerance)
        {
            if (Negate)
            {
                assertProvider.AreNotEqual(expected, Target, tolerance);
            }
            else
            {
                assertProvider.AreEqual(expected, Target, tolerance);
            }
            return Target;
        }
    }
}