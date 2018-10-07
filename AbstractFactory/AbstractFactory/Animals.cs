using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Animal
    {
        public bool Life { get; set; }
        public int Power { get; set; }
        abstract public void Eat(Animal target);
    }

    public abstract class Herbivorous : Animal
    {
        public override void Eat(Animal target)
        {
            this.Power += 10;
            Console.WriteLine("Eat Grass");
        }
    }

    public abstract class Predator : Animal
    {
        public override void Eat(Animal target)
        {
            if (this.Power >= target.Power)
            {
                this.Power += 10;
                target.Life = false;
                Console.WriteLine("Successfully ate");
            }
            else
            {
                this.Power -= 10;
                Console.WriteLine("Too strong");
            }
        }
    }

    class Wildebeest : Herbivorous
    {
        public Wildebeest(int Power, bool Life)
        {
            this.Power = Power;
            this.Life = Life;
        }
        public override string ToString() => "Wildebeest (Herbivorous)";

    }

    class Bison : Herbivorous
    {
        public Bison(int Power, bool Life)
        {
            this.Power = Power;
            this.Life = Life;
        }
        public override string ToString() => "Bison (Herbivorous)";
    }

    class Lion : Predator
    {
        public Lion(int Power, bool Life)
        {
            this.Power = Power;
            this.Life = Life;
        }
        public override string ToString() => "Lion (Predator)";
    }

    class Wolf : Predator
    {
        public Wolf(int Power, bool Life)
        {
            this.Power = Power;
            this.Life = Life;
        }
        public override string ToString() => "Wolf (Predator)";
    }

}
