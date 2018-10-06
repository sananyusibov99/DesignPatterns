using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class CarBuilder
    {
        public Car Car { get; protected set; }

        public CarBuilder()
        {
            Car = new Car();
        }

        public abstract void EquipBody();
        public abstract void EquipEngine();
        public abstract void EquipWheel();

    }

    //============= Sedan ===============
    class SedanBuilder : CarBuilder
    {
        public override void EquipBody()
        {
            Car.Body = new Sedan();
        }

        public override void EquipEngine()
        {
            Car.Engine = new SedanEngine();
        }

        public override void EquipWheel()
        {
            Car.Wheels = new SmallWheel();
        }
    }

    //============= Coupe ===============
    class CoupeBuilder : CarBuilder
    {
        public override void EquipBody()
        {
            Car.Body = new Coupe();
        }

        public override void EquipEngine()
        {
            Car.Engine = new CoupeEngine();
        }

        public override void EquipWheel()
        {
            Car.Wheels = new MediumWheel();
        }
    }

    //============= Station Wagon ===============
    class StationWagonBuilder : CarBuilder
    {
        public override void EquipBody()
        {
            Car.Body = new StationWagon();
        }

        public override void EquipEngine()
        {
            Car.Engine = new StationWagonEngine();
        }

        public override void EquipWheel()
        {
            Car.Wheels = new LargeWheel();
        }
    }

    //============= Hatchback ===============
    class HatchbackBuilder : CarBuilder
    {
        public override void EquipBody()
        {
            Car.Body = new Hatchback();
        }

        public override void EquipEngine()
        {
            Car.Engine = new HatchbackEngine();
        }

        public override void EquipWheel()
        {
            Car.Wheels = new SmallWheel();
        }
    }
}
