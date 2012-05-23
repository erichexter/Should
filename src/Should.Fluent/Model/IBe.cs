namespace Should.Fluent.Model
{
    public interface IBe<TTarget>
    {
        IShould<TTarget> Should { get; }
    }
}