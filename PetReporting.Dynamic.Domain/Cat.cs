namespace PetReporting.Dynamic.Domain
{
    public class Cat : Pet
    {
        public Cat(Owner owner) : base(owner)
        {
        }

        public int? NumberOfLives { get; set; }

        public override void Accept(IPetVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}