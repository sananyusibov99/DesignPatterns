using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Car
    {
        public string Name { get; set; }

        public Body Body { get; set; }
        public Engine Engine { get; set; }
        public Wheels Wheels { get; set; }


        public void Info()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Car name: {Name}");
            Console.WriteLine($"\nCar Parts:");
            Console.WriteLine($"Body: {Body.ToString()}");
            Console.WriteLine($"Engine: {Engine.ToString()}");
            Console.WriteLine($"Head: {Wheels.ToString()}");
            Console.WriteLine("-----------------------\n");
        }
    }

    class CarCreator
    {
        public void Create(CarBuilder carBuilder)
        {
            carBuilder.EquipBody();
            carBuilder.EquipEngine();
            carBuilder.EquipWheel();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SedanBuilder sedan = new SedanBuilder();
            CoupeBuilder coupe = new CoupeBuilder();
            StationWagonBuilder stationWagon = new StationWagonBuilder();
            HatchbackBuilder hatchback = new HatchbackBuilder();

            CarCreator carCreator = new CarCreator();

            carCreator.Create(sedan);
            Car car1 = sedan.Car;
            car1.Name = "Daewoo Lanos";
            car1.Info();

            carCreator.Create(coupe);
            Car car2 = coupe.Car;
            car2.Name = "Ford Probe ";
            car2.Info();

            carCreator.Create(stationWagon);
            Car car3 = stationWagon.Car;
            car3.Name = "UAZ Patriot ";
            car3.Info();

            carCreator.Create(hatchback);
            Car car4 = hatchback.Car;
            car4.Name = "Hyundai Getz ";
            car4.Info();
        }
    }
}
