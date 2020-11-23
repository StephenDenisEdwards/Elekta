using System.Collections.Generic;

namespace PetReporting.Dynamic.Domain
{
    public class Pets
    {
        private List<Pet> _pets = new List<Pet>();

        public void Attach(Pet pet)
        {
            _pets.Add(pet);
        }

        public void Detach(Pet pet)
        {
            _pets.Remove(pet);
        }

        public void Accept(IPetVisitor petVisitor)
        {
            foreach (Pet e in _pets)
            {
                e.Accept(petVisitor);
            }
        }
    }
}