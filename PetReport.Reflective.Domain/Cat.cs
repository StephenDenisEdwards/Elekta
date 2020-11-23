namespace PetReport.Reflective.Domain
{
    public class Cat : Pet
    {
        public Cat(Owner owner) : base(owner)
        {
        }

        public int? NumberOfLives { get; set; }
    }
}