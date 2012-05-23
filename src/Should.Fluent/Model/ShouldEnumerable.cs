using System.Collections.Generic;

namespace Should.Fluent.Model
{
    public class ShouldEnumerableBase<T, TShould> : ShouldBase<TShould, IEnumerable<T>, BeBase<IEnumerable<T>>> where TShould : ShouldEnumerableBase<T, TShould>
    {
        public ShouldEnumerableBase(IEnumerable<T> target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public Contain<T> Contain
        {
            get { return new Contain<T>(this); }
        }

        public Count<T> Count
        {
            get { return new Count<T>(this); }
        }
    }

    public class ShouldEnumerable<T> : ShouldEnumerableBase<T, ShouldEnumerable<T>>
    {
        public ShouldEnumerable(IEnumerable<T> target, IAssertProvider assertProvider) : base(target, assertProvider) { }
    }
}