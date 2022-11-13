using System;

namespace AbstractClasses
{
    class Car: Vehicle
    {
        string comp = "Без компании",  // Производитель
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
                if (value >= 1768) rel_year = value;  // 1768 – год создания первого автомобиля
                else rel_year = 1768;
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

        public Car()
        {
            this.Comp = "Неизвестно";
            this.Name = "Неизвестно";
            this.Rel_year = 1768;
            this.Pas_num = 0;
            this.Cost = 0;
        }
        public Car(string x1, string x2, int x3, int x4, double x5)
        {
            this.Comp = x1;
            this.Name = x2;
            this.Rel_year = x3;
            this.Pas_num = x4;
            this.Cost = x5;
        }

        public override string PrintVehicle()
        {
            return $"Автомобиль {Name}\nПроизводитель {Comp}, Кол-во мест {Pas_num}, Год выпуска {Rel_year} г., Стоимость {Cost} руб.";
        }
    }
}