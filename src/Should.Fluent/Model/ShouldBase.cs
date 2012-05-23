using System;

namespace Should.Fluent.Model
{
    public class ShouldBase<T, TTarget, TBe> : IShould<TTarget> where T : ShouldBase<T, TTarget, TBe>
    {
        protected readonly IAssertProvider assertProvider;
        protected TTarget target;
        protected bool negate;

        public ShouldBase(TTarget target, IAssertProvider assertProvider)
        {
            this.assertProvider = assertProvider;
            this.target = target;
        }

        public T Not
        {
            get
            {
                negate = !negate;
                return (T)this;
            }
        }

        public TBe Be
        {
            get { return (TBe)Activator.CreateInstance(typeof(TBe), this); }
        }

        public TTarget Equal(TTarget expected)
        {
            return ((IShould<TTarget>)this).Apply(
                (t, a) => a.AreEqual(expected, t),
                (t, a) => a.AreNotEqual(expected, target));
        }

        TTarget IShould<TTarget>.Apply(Action<TTarget, IAssertProvider> positiveCase, Action<TTarget, IAssertProvider> negativeCase)
        {
            if (negate)
            {
                negativeCase(target, assertProvider);
            }
            else
            {
                positiveCase(target, assertProvider);
            }
            return target;
        }

        object IShould<TTarget>.Apply(Func<TTarget, IAssertProvider, object> positiveCase, Func<TTarget, IAssertProvider, object> negativeCase)
        {
            return negate 
                ? negativeCase(target, assertProvider) 
                : positiveCase(target, assertProvider);
        }

        public TTarget Apply(Action<TTarget, IAssertProvider, bool> action)
        {
            action(target, assertProvider, negate);
            return target;
        }
    }
}