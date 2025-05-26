namespace DGD208_Spring2025_ErenKeskin.Pets
{
    public class PetStat
    {
        public int Hunger { get; set; }
        public int Sleep { get; set; }
        public int Fun { get; set; }

        public PetStat(int hunger = 50, int sleep = 50, int fun = 50)
        {
            Hunger = hunger;
            Sleep = sleep;
            Fun = fun;
        }
    }
}