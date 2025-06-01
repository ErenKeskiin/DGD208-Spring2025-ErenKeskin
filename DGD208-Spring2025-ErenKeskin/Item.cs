using System.Collections.Generic;
using DGD208_Spring2025_ErenKeskin.Pets;

namespace InteractivePetSimulator
{
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int Price { get; }
        public int StatIncrease { get; }
        public int DurationSeconds { get; }
        public List<PetType> UsablePetTypes { get; }

        public Item(string name, ItemType type, int price, int statIncrease, int durationSeconds, List<PetType> usablePetTypes)
        {
            Name = name;
            Type = type;
            Price = price;
            StatIncrease = statIncrease;
            DurationSeconds = durationSeconds;
            UsablePetTypes = usablePetTypes;
        }

        public override string ToString()
        {
            return $"{Name} (Type: {Type}, Price: {Price}, +{StatIncrease}, {DurationSeconds}s)";
        }
    }
}