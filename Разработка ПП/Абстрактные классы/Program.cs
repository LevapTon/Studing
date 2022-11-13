using System;
using System.Collections.Generic;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Plane("Гражданские самолёты Сухого", "Sukhoi Superjet 100", 2007, 108, 2167920000),
                new Plane("Airbus S.A.S.", "Airbus A380", 2005, 525, 29447580000), 
                new Plane("Boeing", "Boeing 787 Dreamliner", 2009, 250, 14952626000),
                new Plane("Airbus", "Airbus A321", 1994 , 185, 5660680000),
                new Plane("КБ Ильюшина", "Ил-96", 1988 , 435, 85000000000),
                new Car("Ульяновский автозавод", "УАЗ-3163 «Patriot»", 2005, 5, 1188400),
                new Car("GM Daewoo", "Chevrolet Lacetti", 2002, 5, 400000), 
                new Car("КАМАЗ", "KAMAZ-5490", 2013, 3, 3500000),
                new Car("Daimler AG", "Mercedes-Benz S-Class (C217)", 2015 , 2, 6950000),
                new Car("Горьковский автомобильный завод", "ГАЗель NEXT A65R52-80", 1988 , 22, 4500000),
                new Ship("ÖSWAG", "NAZCA", "Москва", 2020, 8, 275000000),
                new Ship("арок", "кора", "", 2005, 100, 29447580000), 
                new Ship("Boeing", "Boeing 787 Dreamliner", "", 2009, 250, 14952626000),
                new Ship("Airbus", "Airbus A321", "", 1994 , 185, 5660680000),
                new Ship("КБ Ильюшина", "Ил-96", "", 1988 , 435, 85000000000),
            };

            Console.WriteLine("Список, отсортированный по году выпуска:");
            vehicles.Sort((a, b) => a.Rel_year.CompareTo(b.Rel_year));
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine(vehicles[i].PrintVehicle());
            }
            Console.WriteLine();
            Console.WriteLine("Список, отсортированный по цене:");
            vehicles.Sort();
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine(vehicles[i].PrintVehicle());
            }
            Console.WriteLine();
            Console.Write("Введите необхоимое количество пассажиров: ");
            int capacity = Convert.ToInt32(Console.ReadLine());
            vehicles.Sort((a, b) => a.Pas_num.CompareTo(b.Pas_num));
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].SearchByCapacity(capacity)) Console.WriteLine(vehicles[i].PrintVehicle());
            }
        }
    }
    
}