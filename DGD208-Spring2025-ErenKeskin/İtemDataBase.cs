using System.Collections.Generic;
using DGD208_Spring2025_ErenKeskin.Pets;
using DGD208_Spring2025_ErenKeskin.Pets;

namespace InteractivePetSimulator
{
    public static class ItemDatabase
    {
        public static List<Item> Items = new List<Item>
        {
            new Item("Dog Food ( Meat )", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Dog }),
            new Item("Dog Food ( Bones )", ItemType.Food, 20, 20, 3, new List<PetType>{ PetType.Dog }),
            new Item("Cat Food ( Fish )", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Cat }),
            new Item("Gecko Food ( Flour Worm )", ItemType.Food, 20, 20, 2, new List<PetType>{PetType.Gecko }),
            new Item("Dragon Food ( Small Bones )", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.MiniDragon }),
            new Item("Turtle Food ( Lettuce )", ItemType.Food, 20, 20, 2, new List<PetType>{PetType.Turtle}),
            new Item("Snake Food ( Mouse )", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Snake }),
            new Item("Goldfish Food ( Fish Flakes )", ItemType.Food, 20, 20, 2, new List<PetType>{ PetType.Goldfish }),
            new Item("Ball", ItemType.Toy, 25, 15, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Plastic Toy", ItemType.Toy, 30, 20, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Plush Toy", ItemType.Toy, 20, 10, 2, new List<PetType>{ PetType.Dog, PetType.Cat }),
            new Item("Soft Bed", ItemType.Bed, 40, 30, 5, new List<PetType>{ PetType.Dog, PetType.Cat, PetType.MiniDragon }),
            new Item("Water Bowl", ItemType.Bed, 30, 20, 5, new List<PetType>{ PetType.Dog, PetType.Cat, PetType.MiniDragon, PetType.Snake, PetType.Goldfish, PetType.Turtle, PetType.Gecko }),
            new Item("Heater", ItemType.Bed, 30, 20, 5, new List<PetType>{ PetType.Dog, PetType.Cat, PetType.Snake, PetType.Gecko })
        };
    }
}