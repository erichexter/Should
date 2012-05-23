namespace Should.Fluent.Model
{
    public class BeBase<TTarget> : IBe<TTarget>
    {
        protected readonly IShould<TTarget> should;

        public BeBase(IShould<TTarget> should)
        {
            this.should = should;
        }

        IShould<TTarget> IBe<TTarget>.Should
        {
            get { return should; }
        }
    }
}