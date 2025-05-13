using System;
using System.Collections.Generic;

namespace InteractivePetSimulator
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Interactive Pet Simulator ===");
                Console.WriteLine("                                 ");
                Console.WriteLine("1. Adopt a new pet");
                Console.WriteLine("2. Pet Stats");
                Console.WriteLine("3. Credits");
                Console.WriteLine("4. Exit");
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
                    ShowCredits();
                }
                else if (input == "4")
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
            Console.WriteLine("3. Mini Dragon");
            Console.WriteLine("              ");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            PetType petType;

            if (input == "1")
                petType = PetType.Dog;
            else if (input == "2")
                petType = PetType.Cat;
            else if (input == "3")
                petType = PetType.Bird;
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
                    Console.WriteLine($"{pet.PetType}: Hunger = {pet.Hunger}, Sleep = {pet.Sleep}, Fun = {pet.Fun}");
                }
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("=== Credits ===");
            Console.WriteLine("               ");
            Console.WriteLine("Developed by: Eren Keskin");
            Console.WriteLine("Student Number: 225040108");
            Console.WriteLine("--DGD208--");
            Console.WriteLine("          ");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}