using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DGD208_Spring2025_ErenKeskin.Pets;

namespace InteractivePetSimulator
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();
        private Player player = new Player(1000);

        private CancellationTokenSource statDecreaseCts;

        public void Start()
        {
            statDecreaseCts = new CancellationTokenSource();
            StartPetStatDecreaseLoopAsync(statDecreaseCts.Token);

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== Interactive Pet Simulator ===");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Money: {player.Money}");
                Console.ResetColor();
                Console.WriteLine();


                lock (pets)
                {
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("You have no pets.");
                    }
                    else
                    {
                        Console.WriteLine("Your Pets:");
                        foreach (var pet in pets)
                        {
                            Console.WriteLine($"{pet.PetType}: Hunger = {pet.Stat.Hunger}, Sleep = {pet.Stat.Sleep}, Fun = {pet.Stat.Fun}");
                        }
                    }
                }
                Console.WriteLine();

                Console.WriteLine("1. Adopt a new pet");
                Console.WriteLine("2. Buy Items");
                Console.WriteLine("3. Credits");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    AdoptNewPet();
                }
                else if (input == "2")
                {
                    BuyItems();
                }
                else if (input == "3")
                {
                    ShowCredits();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Exiting the game...");
                    statDecreaseCts.Cancel();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                }
            }
        }

        private async void StartPetStatDecreaseLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(3000, token);

                lock (pets)
                {
                    
                    foreach (var pet in pets.ToList())
                    {
                        pet.DecreaseStats();
                    }
                }
            }
        }

        private void AdoptNewPet()
        {
            Console.Clear();
            Console.WriteLine("Choose a pet type to adopt:");
            Console.WriteLine();
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. MiniDragon");
            Console.WriteLine("4. Snake");
            Console.WriteLine("5. GoldFish");
            Console.WriteLine("6. Turtle");
            Console.WriteLine("7. Gecko");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            PetType petType;

            if (input == "1")
                petType = PetType.Dog;
            else if (input == "2")
                petType = PetType.Cat;
            else if (input == "3")
                petType = PetType.MiniDragon;
            else if (input == "4")
                petType = PetType.Snake;
            else if (input == "5")
                petType = PetType.Goldfish;
            else if (input == "6")
                petType = PetType.Turtle;
            else if (input == "7")
                petType = PetType.Gecko;
            else
            {
                Console.WriteLine("Invalid choice. Returning to main menu...");
                Console.ReadKey();
                return;
            }

            var newPet = new Pet(petType);
            newPet.PetDied += Pet_PetDied; 

            lock (pets)
            {
                pets.Add(newPet);
            }
            Console.WriteLine($"You adopted a new {petType}!");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        
        private void Pet_PetDied(object sender, PetEventArgs e)
        {
            lock (pets)
            {
                pets.Remove(e.Pet);
            }
            Console.WriteLine($"Your {e.Pet.PetType} has died due to a stat reaching 0!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void BuyItems()
        {
           
            var usableItems = ItemDatabase.Items.Where(item => pets.Any(pet => item.UsablePetTypes.Contains(pet.PetType))).ToList();

            var menu = new Menu<Item>("Shop - Buy Items", usableItems, item => item.ToString());
            var selectedItem = menu.ShowAndGetSelection();
            if (selectedItem == null) return;

            if (player.SpendMoney(selectedItem.Price))
            {
                lock (pets)
                {
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("You have no pets to use this item on.");
                        player.AddMoney(selectedItem.Price);
                        Console.ReadKey();
                        return;
                    }

                    
                    var petMenu = new Menu<Pet>("Select Pet to Use Item", pets.Where(pet => selectedItem.UsablePetTypes.Contains(pet.PetType)).ToList(), pet => pet.ToString());
                    var selectedPet = petMenu.ShowAndGetSelection();
                    if (selectedPet == null)
                    {
                        player.AddMoney(selectedItem.Price);
                        return;
                    }

                    ApplyItemToPet(selectedItem, selectedPet);
                }
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║         INTERACTIVE PET SIMULATOR - CREDITS      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("         /\\_/\\    ");
            Console.WriteLine("        ( o.o )   ");
            Console.WriteLine("         > ^ <    ");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Developed by : Eren Keskin");
            Console.WriteLine("  Student No   : 225040108");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  DGD208 - 2025 Spring");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  GitHub: github.com/ErenKeskiin/DGD208-Spring2025-ErenKeskin");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}