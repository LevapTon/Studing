using System;

namespace AbstractClasses
{
    abstract class Vehicle: IComparable
    {
        abstract public double Cost{get;set;}
        abstract public int Rel_year{get;set;}
        abstract public int Pas_num{get;set;}
        abstract public string Name{get;set;}
        abstract public string Comp{get;set;}

        abstract public string PrintVehicle();

        public int CompareTo(object? o)
        {
            if(o is Plane plane) return Cost.CompareTo(plane.Cost);
            if(o is Car car) return Cost.CompareTo(car.Cost);
            if(o is Ship ship) return Cost.CompareTo(ship.Cost);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        public bool SearchByCapacity(int capacity)
        {
            if (this.Pas_num >= capacity) return true;
            else return false;
        }
    }
}