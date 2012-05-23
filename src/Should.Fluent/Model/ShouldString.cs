namespace Should.Fluent.Model
{
    public class ShouldString : ShouldBase<ShouldString, string, BeString>
    {
        public ShouldString(string target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public string Contain(string expectedSubstring)
        {
            if (Negate)
            {
                if (Target.Contains(expectedSubstring))
                {
                    assertProvider.Fail("Expected string '{0}' to not contain '{1}', but it did.", Target, expectedSubstring);
                }
            }
            else
            {
                assertProvider.IsSubstringOf(Target, expectedSubstring);   
            }
            return Target;
        }

        public string StartWith(string expectedSubstring)
        {
            if (Negate)
            {
                if (Target.StartsWith(expectedSubstring))
                {
                    assertProvider.Fail("Expected string '{0}' to not start with '{1}', but it did.", Target, expectedSubstring);
                }
            }
            else
            {
                if (!Target.StartsWith(expectedSubstring))
                {
                    assertProvider.Fail("Expected string '{0}' to start with '{1}', but it did not.", Target, expectedSubstring);
                }
            }
            return Target;
        }

        public string EndWith(string expectedSubstring)
        {
            if (Negate)
            {
                if (Target.EndsWith(expectedSubstring))
                {
                    assertProvider.Fail("Expected string '{0}' to not end with '{1}', but it did.", Target, expectedSubstring);
                }  
            }
            else
            {
                if (!Target.EndsWith(expectedSubstring))
                {
                    assertProvider.Fail("Expected string '{0}' to end with '{1}', but it did not.", Target, expectedSubstring);
                }    
            }
            return Target;
        }
    }
}