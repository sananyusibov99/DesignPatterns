using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //=================================
    abstract class Body
    {
        public string Type { get; set; }
    }

    class Sedan : Body
    {
        public Sedan()
        {
            Type = "Sedan";
        }

        public override string ToString() => "Sedan";
    }

    class Coupe : Body
    {
        public Coupe()
        {
            Type = "Coupe";
        }

        public override string ToString() => "Coupe";
    }

    class StationWagon : Body
    {
        public StationWagon()
        {
            Type = "StationWagon";
        }

        public override string ToString() => "StationWagon";
    }

    class Hatchback : Body
    {
        public Hatchback()
        {
            Type = "Hatchback";
        }

        public override string ToString() => "Hatchback";
    }
    //=================================

    abstract class Engine
    {
        public int Power { get; set; }
    }

    class SedanEngine : Engine
    {
        public SedanEngine()
        {
            Power = 98;
        }

        public override string ToString() => "98 L.s";
    }

    class CoupeEngine : Engine
    {
        public CoupeEngine()
        {
            Power = 160;
        }

        public override string ToString() => "160 L.s";
    }

    class StationWagonEngine : Engine
    {
        public StationWagonEngine()
        {
            Power = 120;
        }

        public override string ToString() => "120 L.s";
    }

    class HatchbackEngine : Engine
    {
        public HatchbackEngine()
        {
            Power = 66;
        }

        public override string ToString() => "66 L.s";
    }
    //=================================

    abstract class Wheels
    {
        public int Radius { get; set; }
    }

    class SmallWheel : Wheels
    {
        public SmallWheel()
        {
            Radius = 13;
        }

        public override string ToString() => "13 R";
    }

    class MediumWheel : Wheels
    {
        public MediumWheel()
        {
            Radius = 14;
        }

        public override string ToString() => "14 R";
    }

    class LargeWheel : Wheels
    {
        public LargeWheel()
        {
            Radius = 16;
        }

        public override string ToString() => "16 R";
    }


}
