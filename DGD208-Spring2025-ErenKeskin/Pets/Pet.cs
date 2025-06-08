using System;

namespace DGD208_Spring2025_ErenKeskin.Pets
{
    public class Pet
    {
        public PetType PetType { get; set; }
        public PetStat Stat { get; set; }

        
        public event EventHandler<PetEventArgs> PetDied;

        public Pet(PetType petType)
        {
            PetType = petType;
            Stat = new PetStat();
        }

        
        public void DecreaseStats()
        {
            Stat.Hunger = Math.Max(0, Stat.Hunger - 1);
            Stat.Sleep = Math.Max(0, Stat.Sleep - 1);
            Stat.Fun = Math.Max(0, Stat.Fun - 1);

            if (Stat.Hunger == 0 || Stat.Sleep == 0 || Stat.Fun == 0)
            {
                PetDied?.Invoke(this, new PetEventArgs(this));
            }
        }

        public override string ToString()
        {
            return $"{PetType} - Hunger: {Stat.Hunger}, Sleep: {Stat.Sleep}, Fun: {Stat.Fun}";
        }
    }

    public class PetEventArgs : EventArgs
    {
        public Pet Pet { get; }
        public PetEventArgs(Pet pet)
        {
            Pet = pet;
        }
    }
}