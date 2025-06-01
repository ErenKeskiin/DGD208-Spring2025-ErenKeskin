using System.Collections.Generic;
using DGD208_Spring2025_ErenKeskin.Pets;

namespace InteractivePetSimulator
{
    public static class ItemDatabase
    {
        public static List<Item> Items = new List<Item>
        {
            new Item("Dog Food", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Dog }),
            new Item("Cat Food", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Cat }),
            new Item("Dragon Food", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.MiniDragon }),
            new Item("Ball", ItemType.Toy, 25, 15, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Plastic Toy", ItemType.Toy, 30, 20, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Plush Toy", ItemType.Toy, 20, 10, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Soft Bed", ItemType.Bed, 40, 30, 5, new List<PetType>{ PetType.Dog, PetType.Cat, PetType.MiniDragon })
        };
    }
}