using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic.Domain.Tests
{
    public class TestPet : Pet
    {
        public TestPet(Owner owner) : base(owner)
        {
        }

        public override void Accept(IPetVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}