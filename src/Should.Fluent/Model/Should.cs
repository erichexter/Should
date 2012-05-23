namespace Should.Fluent.Model
{
    public class Should<TTarget, TBe> : ShouldBase<Should<TTarget, TBe>, TTarget, TBe>
    {
        public Should(TTarget target, IAssertProvider assertProvider) : base(target, assertProvider) { }
    }
}