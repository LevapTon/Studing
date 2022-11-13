using System;

namespace AbstractClasses
{
    class Ship: Vehicle
    {
        string comp = "Без компании",  // Производитель
            home_port = "Без порта",  // Порт приписки
            name = "Без названия";  // Наименование
        int pas_num,  // Количество пассажиров
            rel_year;  // Год выпуска
        double cost;  // Стоимость

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value; 
            }
        }
        public override string Comp
        {
            get
            {
                return comp;
            }
            set
            {
                comp = value; 
            }
        }
        public string Home_port
        {
            get
            {
                return home_port;
            }
            set
            {
                home_port = value; 
            }
        }
        public override int Pas_num
        {
            get
            {
                return pas_num;
            }
            set
            {
                if (value >= 0) pas_num = value;
                else pas_num = 0;
            }
        }
        public override int Rel_year
        {
            get
            {
                return rel_year;
            }
            set
            {
                if (value >= 1858) rel_year = value;  // 1858 – год создания первого стального корабля
                else rel_year = 1858;
            }
        }
        public override double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value >= 0) cost = value;
                else cost = 0;
            }
        }

        public Ship()
        {
            this.Comp = "Неизвестно";
            this.Name = "Неизвестно";
            this.Home_port = "Неизвестно";
            this.Rel_year = 1858;
            this.Pas_num = 0;
            this.Cost = 0;
        }
        public Ship(string x1, string x2, string x3, int x4, int x5, double x6)
        {
            this.Comp = x1;
            this.Name = x2;
            this.Home_port = x3;
            this.Rel_year = x4;
            this.Pas_num = x5;
            this.Cost = x6;
        }

        public override string PrintVehicle()
        {
            string str1 = $"Корабль {Name}\nПроизводитель {Comp}, Порт приписки {Home_port}, ";
            string str2 = $"Кол-во мест {Pas_num}, Год выпуска {Rel_year} г., Стоимость {Cost} руб.";
            return str1 + str2;
        }
    }
}