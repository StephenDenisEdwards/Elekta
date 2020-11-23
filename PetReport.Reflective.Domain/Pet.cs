using System;
using PetReport.Reflective.Lib;

namespace PetReport.Reflective.Domain
{
    public abstract class Pet : ReportableReflective
    {
        protected Pet(Owner owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        // A pet HAS A Owner. We could also go with an Owner HAS A Pet
        public Owner Owner { get; protected set; }

        // Use proper case and camel cased names
        public int NumberOfVisits { get; set; }

        //public abstract string this[string key] { get; }
    }
}