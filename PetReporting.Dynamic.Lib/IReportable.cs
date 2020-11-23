namespace PetReporting.Dynamic.Lib
{
    public interface IReportable
    {
        object this[string key] { get; }
    }
}