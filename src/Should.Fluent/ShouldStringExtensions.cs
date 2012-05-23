using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class ShouldStringExtensions
    {
        public static string Contain(this IShould<string> should, string expectedSubstring)
        {
            return should.Apply(
                (t, a) => a.IsSubstringOf(t, expectedSubstring),
                (t, a) =>
                {
                    if (t.Contains(expectedSubstring))
                    {
                        a.Fail("Expected string '{0}' to not contain '{1}', but it did.", t, expectedSubstring);
                    }
                });
        }

        public static string StartWith(this IShould<string> should, string expectedSubstring)
        {
            return should.Apply(
                (t, a) =>
                {
                    if (!t.StartsWith(expectedSubstring))
                    {
                        a.Fail("Expected string '{0}' to start with '{1}', but it did not.", t, expectedSubstring);
                    }
                },
                (t, a) =>
                {
                    if (t.StartsWith(expectedSubstring))
                    {
                        a.Fail("Expected string '{0}' to not start with '{1}', but it did.", t, expectedSubstring);
                    }
                });
        }

        public static string EndWith(this IShould<string> should, string expectedSubstring)
        {
            return should.Apply(
                (t, a) =>
                {
                    if (!t.EndsWith(expectedSubstring))
                    {
                        a.Fail("Expected string '{0}' to end with '{1}', but it did not.", t, expectedSubstring);
                    }
                },
                (t, a) =>
                {
                    if (t.EndsWith(expectedSubstring))
                    {
                        a.Fail("Expected string '{0}' to not end with '{1}', but it did.", t, expectedSubstring);
                    }
                });
        }
    }
}