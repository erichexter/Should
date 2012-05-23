using System.Collections;

namespace Should.Fluent.Model
{
    public class ShouldCollection : ShouldBase<ShouldCollection, ICollection, BeBase<ICollection>>
    {
        public ShouldCollection(ICollection target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public Count Count
        {
            get { return new Count(this, assertProvider); }
        }
    }
}