namespace BeerRecipes.Core.Data
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
    }
}
