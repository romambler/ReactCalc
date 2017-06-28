namespace ReactCalc.Models
{
    public interface IDisplayOperation : IOperation
    {
        string DisplayName { get; }
        string Description { get; }
        string Author { get; }
    }
}
