namespace PetReporting.Dynamic.Domain
{
    public class Dog : Pet
    {
        public Dog(Owner owner) : base(owner)
        {
        }
        public override void Accept(IPetVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}