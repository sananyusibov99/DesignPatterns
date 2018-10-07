using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IAnimalFactory
    {
        Herbivorous CreateHerbivorous();
        Predator CreatePredator();
    }

    class AfricaFactory : IAnimalFactory
    {
        public Herbivorous CreateHerbivorous()
        {
            return new Wildebeest(150, true);
        }

        public Predator CreatePredator()
        {
            return new Lion(200, true);
        }
    }

    class AmericaFactory : IAnimalFactory
    {
        public Herbivorous CreateHerbivorous()
        {
            return new Bison(450, true);
        }

        public Predator CreatePredator()
        {
            return new Wolf(80, true);
        }
    }

}
