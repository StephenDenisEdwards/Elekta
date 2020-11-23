using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic.Domain
{
    public abstract class ReportableVisitorAcceptAnd : Reportable
    {
        public abstract void Accept(IPetVisitor visitor);
    }
}