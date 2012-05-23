using System.Collections.Generic;
using System.Linq;

namespace Should.Fluent.Model
{
    public class ShouldDictionary<TKey, TValue> : ShouldEnumerableBase<KeyValuePair<TKey, TValue>, ShouldDictionary<TKey, TValue>>
    {
        public ShouldDictionary(IEnumerable<KeyValuePair<TKey, TValue>> target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public IEnumerable<KeyValuePair<TKey, TValue>> ContainKey(TKey key)
        {
            var match = target.Where(x => x.Key.Equals(key));
            if (negate)
            {
                if (match.Any())
                {
                    assertProvider.Fail("Expected dictionary not to contain key '{0}' but it does.", key);
                }
            }
            else
            {
                if (!match.Any())
                {
                    assertProvider.Fail("Expected dictionary to contain key '{0}' but it does not.", key);
                }
            }
            return target;
        }
    }
}