namespace DGD208_Spring2025_ErenKeskin.Pets
{
    public class Pet
    {
        public PetType PetType { get; set; }
        public PetStat Stat { get; set; }

        public Pet(PetType petType)
        {
            PetType = petType;
            Stat = new PetStat();
        }

        public override string ToString()
        {
            return $"{PetType} - Hunger: {Stat.Hunger}, Sleep: {Stat.Sleep}, Fun: {Stat.Fun}";
        }
    }
}