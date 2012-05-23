using System;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeNullableBoolExtensions
    {
        public static bool? Null(this IBe<bool?> be)
        {
            return Check.IsNull(be.Should);
        }

        public static bool? True(this IBe<bool?> be)
        {
            Action<bool?, IAssertProvider> positiveCase = (t, a) =>
            {
                if (!t.HasValue)
                {
                    a.Fail("Expected TRUE but was NULL.");
                }
                else
                {
                    a.IsTrue(t.Value);
                }
            };
            Action<bool?, IAssertProvider> negativeCase = (t, a) =>
            {
                if (t.HasValue)
                {
                    a.IsFalse(t.Value);
                }
            };
            return be.Should.Apply(positiveCase, negativeCase);
        }

        public static bool? False(this IBe<bool?> be)
        {
            Action<bool?, IAssertProvider> positiveCase = (t, a) =>
            {
                if (!t.HasValue)
                {
                    a.Fail("Expected FALSE but was NULL.");
                }
                else
                {
                    a.IsFalse(t.Value);                        
                }
            };
            Action<bool?, IAssertProvider> negativeCase = (t, a) =>
            {
                if (t.HasValue)
                {
                    a.IsTrue(t.Value);
                }
            };
            return be.Should.Apply(positiveCase, negativeCase);
        }
    }
}