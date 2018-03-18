namespace Bionet4.Data.Contracts
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
