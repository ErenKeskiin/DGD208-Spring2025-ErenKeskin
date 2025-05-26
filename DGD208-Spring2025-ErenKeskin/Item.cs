namespace InteractivePetSimulator
{
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int Price { get; }
        public int StatIncrease { get; }
        public int DurationSeconds { get; }

        public Item(string name, ItemType type, int price, int statIncrease, int durationSeconds)
        {
            Name = name;
            Type = type;
            Price = price;
            StatIncrease = statIncrease;
            DurationSeconds = durationSeconds;
        }

        public override string ToString()
        {
            return $"{Name} (Type: {Type}, Price: {Price}, +{StatIncrease}, {DurationSeconds}s)";
        }
    }
}