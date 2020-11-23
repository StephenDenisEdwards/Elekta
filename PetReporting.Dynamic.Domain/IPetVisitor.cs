namespace PetReporting.Dynamic.Domain
{
    /// <summary>
    /// The Pet 'Visitor' interface
    /// </summary>
    public interface IPetVisitor
    {
        void Visit(Dog element);
        void Visit(Cat element);
    }
}