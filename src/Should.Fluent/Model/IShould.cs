using System;

namespace Should.Fluent.Model
{
    public interface IShould<TTarget>
    {
        TTarget Apply(Action<TTarget, IAssertProvider> positiveCase, Action<TTarget, IAssertProvider> negativeCase);
        object Apply(Func<TTarget, IAssertProvider, object> positiveCase, Func<TTarget, IAssertProvider, object> negativeCase);
        TTarget Apply(Action<TTarget, IAssertProvider, bool> action);
    }
}