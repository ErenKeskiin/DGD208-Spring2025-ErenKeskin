using System;
using System.Collections.Generic;
using DGD208_Spring2025_ErenKeskin.Pets;

namespace InteractivePetSimulator
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();
        private Player player = new Player(100);

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Interactive Pet Simulator ===");
                Console.WriteLine($"Money: {player.Money}");
                Console.WriteLine("                                 ");
                Console.WriteLine("1. Adopt a new pet");
                Console.WriteLine("2. Your Pets");
                Console.WriteLine("3. Buy Items");
                Console.WriteLine("4. Credits");
                Console.WriteLine("5. Exit");
                Console.WriteLine("       ");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    AdoptNewPet();
                }
                else if (input == "2")
                {
                    ViewPetStats();
                }
                else if (input == "3")
                {
                    BuyItems();
                }
                else if (input == "4")
                {
                    ShowCredits();
                }
                else if (input == "5")
                {
                    Console.WriteLine("Exiting the game...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                }
            }
        }

        private void AdoptNewPet()
        {
            Console.Clear();
            Console.WriteLine("Choose a pet type to adopt:");
            Console.WriteLine("                           ");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. MiniDragon");
            Console.WriteLine("              ");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            PetType petType;

            if (input == "1")
                petType = PetType.Dog;
            else if (input == "2")
                petType = PetType.Cat;
            else if (input == "3")
                petType = PetType.MiniDragon;
            else
            {
                Console.WriteLine("Invalid choice. Returning to main menu...");
                Console.ReadKey();
                return;
            }

            Pet newPet = new Pet(petType);
            pets.Add(newPet);
            Console.WriteLine($"You adopted a new {petType}!");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void ViewPetStats()
        {
            Console.Clear();

            if (pets.Count == 0)
            {
                Console.WriteLine("You have no pets.");
            }
            else
            {
                Console.WriteLine("Your pets:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"{pet.PetType}: Hunger = {pet.Stat.Hunger}, Sleep = {pet.Stat.Sleep}, Fun = {pet.Stat.Fun}");
                }
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void BuyItems()
        {
            var menu = new Menu<Item>("Shop - Buy Items", ItemDatabase.Items, item => item.ToString());
            var selectedItem = menu.ShowAndGetSelection();
            if (selectedItem == null) return;

            if (player.SpendMoney(selectedItem.Price))
            {
                if (pets.Count == 0)
                {
                    Console.WriteLine("You have no pets to use this item on.");
                    player.AddMoney(selectedItem.Price);
                    Console.ReadKey();
                    return;
                }

                var petMenu = new Menu<Pet>("Select Pet to Use Item", pets, pet => pet.ToString());
                var selectedPet = petMenu.ShowAndGetSelection();
                if (selectedPet == null)
                {
                    player.AddMoney(selectedItem.Price);
                    return;
                }

                if (!selectedItem.UsablePetTypes.Contains(selectedPet.PetType))
                {
                    Console.WriteLine($"This item cannot be used on {selectedPet.PetType}!");
                    player.AddMoney(selectedItem.Price);
                    Console.ReadKey();
                    return;
                }

                ApplyItemToPet(selectedItem, selectedPet);
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
            }
        }

        private void ApplyItemToPet(Item item, Pet pet)
        {
            Console.WriteLine($"Using {item.Name} on {pet.PetType}... Please wait...");
            System.Threading.Thread.Sleep(item.DurationSeconds * 1000);

            switch (item.Type)
            {
                case ItemType.Food:
                    pet.Stat.Hunger = Math.Min(100, pet.Stat.Hunger + item.StatIncrease);
                    break;
                case ItemType.Toy:
                    pet.Stat.Fun = Math.Min(100, pet.Stat.Fun + item.StatIncrease);
                    break;
                case ItemType.Bed:
                    pet.Stat.Sleep = Math.Min(100, pet.Stat.Sleep + item.StatIncrease);
                    break;
            }
            Console.WriteLine("Item applied! Pet stats updated.");
            Console.ReadKey();
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("=== Credits ===");
            Console.WriteLine("                         ");
            Console.WriteLine(" /\\_/\\\n( o.o )\n > ^ <");
            Console.WriteLine("                         ");
            Console.WriteLine("Developed by: Eren Keskin");
            Console.WriteLine("Student Number: 225040108");

            Console.WriteLine("       --DGD208--        ");
            Console.WriteLine("                         ");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}