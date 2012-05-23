using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeBoolExtensions
    {
        public static bool True(this IBe<bool> be)
        {
            return be.Should.Apply(
                (t, a) => a.IsTrue(t),
                (t, a) => a.IsFalse(t));
        }

        public static bool False(this IBe<bool> be)
        {
            return be.Should.Apply(
                (t, a) => a.IsFalse(t),
                (t, a) => a.IsTrue(t));
        }
    }
}