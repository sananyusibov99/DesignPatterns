using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class AnimalCreator
    {
        public IAnimalFactory AnimalFactory { get; set; }

        public void AddHerbivorous(List<Animal> animals)
        {
            animals.Add(AnimalFactory.CreateHerbivorous());
        }

        public void AddPredator(List<Animal> animals)
        {
            animals.Add(AnimalFactory.CreatePredator());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            AnimalCreator animalCreator = new AnimalCreator();

            AddAnimals(animalCreator, animals);
            int ans = 1;
            while (ans != 0)
            {
                Console.Clear();
                Console.WriteLine("1. Show Animals");
                Console.WriteLine("2. Feed Herbivorous");
                Console.WriteLine("3. Feed Predators");
                Console.WriteLine("4. Add animals");

                ans = Int32.Parse(Console.ReadLine());
                if (ans == 1)
                {
                    ShowAnimals(animals);
                }
                else if (ans == 2)
                {
                    FeedHerbivorous(animals);
                }
                else if (ans == 3)
                {
                    //Will fix later
                    //FeedPredators(animals);
                }
                else if (ans == 4)
                {
                    AddAnimals(animalCreator, animals);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ShowAnimals(List<Animal> animals)
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Power);
                Console.WriteLine(item.Life);
                Console.WriteLine();
            }
        }

        public static void FeedHerbivorous(List<Animal> animals)
        {
            foreach (var item in animals)
            {
                if (item is Herbivorous)
                {
                    item.Power += 10;
                }
            }
        }

        /*
        public static void FeedPredators(List<Animal> animals)
        {
            List<Animal> copyOfAnimals = new List<Animal>();
            copyOfAnimals = animals;
            foreach (var Predator in copyOfAnimals)
            {
                if (Predator is Predator)
                {
                    try
                    {
                        foreach (var Herbivorous in copyOfAnimals)
                        {
                            if (Herbivorous is Herbivorous)
                            {
                                if (Herbivorous.Power <= Predator.Power)
                                {
                                    animals.Remove(Herbivorous);
                                }

                            }
                        }
                        Predator.Power += 10;
                    }
                    catch { }
                }
            }
        }
        */

        public static void AddAnimals(AnimalCreator animalCreator, List<Animal> animals)
        {
            animalCreator.AnimalFactory = new AfricaFactory();

            animalCreator.AddHerbivorous(animals);
            animalCreator.AddHerbivorous(animals);
            animalCreator.AddHerbivorous(animals);

            animalCreator.AddPredator(animals);
            animalCreator.AddPredator(animals);

            animalCreator.AnimalFactory = new AmericaFactory();

            animalCreator.AddHerbivorous(animals);
            animalCreator.AddHerbivorous(animals);

            animalCreator.AddPredator(animals);
            animalCreator.AddPredator(animals);
            animalCreator.AddPredator(animals);
        }
    }


}

