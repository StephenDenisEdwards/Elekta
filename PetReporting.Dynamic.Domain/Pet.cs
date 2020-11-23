using System;

namespace PetReporting.Dynamic.Domain
{
    public abstract class Pet : ReportableVisitorAcceptAnd
    {
        protected Pet(Owner owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public Owner Owner { get; protected set; }

        public int NumberOfVisits { get; set; }
    }
}