using System.Collections.Generic;

namespace InteractivePetSimulator
{
    public static class ItemDatabase
    {
        public static List<Item> Items = new List<Item>
        {
            new Item("Dog Food   ", ItemType.Food, 20, 20, 2),
            new Item("Cat Food   ", ItemType.Food, 20, 20, 2),
            new Item("Dragon Food", ItemType.Food, 20, 20, 2),
            new Item("Ball       ", ItemType.Toy, 25, 15, 2),
            new Item("Plastic Toy", ItemType.Toy, 30, 20, 2 ),
            new Item("Plush Toy  ", ItemType.Toy, 20, 10, 2 ),
            new Item("Soft Bed   ", ItemType.Bed, 40, 30, 5)
        };
    }
}