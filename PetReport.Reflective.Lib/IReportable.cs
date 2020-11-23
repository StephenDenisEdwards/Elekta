namespace PetReport.Reflective.Lib
{
    public interface IReportable
    {
        object this[string key] { get; }
    }
}