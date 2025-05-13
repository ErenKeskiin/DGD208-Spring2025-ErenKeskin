namespace InteractivePetSimulator
{
    public enum PetType
    {
        Dog,
        Cat,
        Bird
    }

    public class Pet
    {
        public PetType PetType { get; set; }
        public int Hunger { get; set; }
        public int Sleep { get; set; }
        public int Fun { get; set; }

        public Pet(PetType petType)
        {
            PetType = petType;
            Hunger = 50;
            Sleep = 50;
            Fun = 50;
        }

        public override string ToString()
        {
            return $"{PetType} - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}";
        }
    }
}