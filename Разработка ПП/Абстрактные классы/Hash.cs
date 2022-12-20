using System;
using System.Collections;

namespace AbstractClasses
{
    class Hash  : IEnumerable, ICloneable
    {
        protected ArrayList keys;
        protected List<Vehicle> values;
        int position = -1;

        public int CountElems  // Свойтво Count, возможно не работает
        {
            get
            {
                return values.Count;
            }
        }

       private int IndexOfKey(object? key)
       {
            return keys.IndexOf(key);
       }

        public Hash()  // Создание пустой коллекции
        {
            this.keys = new ArrayList();
            this.values = new List<Vehicle>();
        }

        public Hash(int capacity)  // Создание пустой коллекции с заданной емкостью
        {
            this.keys = new ArrayList(capacity);
            this.values = new List<Vehicle>(capacity);
        }

        public Hash(Hash h)  // Создание коллекции, инициализируемой элементами другой коллекции
        {
            this.keys = new ArrayList();
            this.values = new List<Vehicle>();
            for (int i = 0; i < h.CountElems; i++)
            {
                this.keys.Add(h.keys[i]);
                this.values.Add(h.values[i]);
            }
        }

        public void AddElem(object key, Vehicle t)  // Добавление элемента
        {
            this.keys.Add(key);
            this.values.Add(t);
        }

        public void AddRangeElems(Hash h)  // Добавление нескольких элементов
        {
            this.keys.AddRange(h.keys);
            this.values.AddRange(h.values);
        }

        public void RemoveElem(object key)  // Тут надо как-то удалить элемент
        {
            int index = IndexOfKey(key);
            this.values.Remove(values[index]);
            this.keys.Remove(keys[index]);
        }

        public void RemoveRangeElems(Hash h)  // Тут надо как-то удалить несколько элементов
        {
            int index = IndexOfKey(h.keys[0]);
            int countElem = h.CountElems;
            this.keys.RemoveRange(index, countElem);
            this.values.RemoveRange(index, countElem);
            // перебор по ключам и удаление через RemoveElem
        }

        public void ClearHash()  // Тут надо как-то удалить все элементы
        {
            RemoveRangeElems(this);
            // RemoveRange через this
        }

        public object? FindElem(Vehicle value)  // Тут надо как-то найти элемент по значению
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == value) 
                {
                    return values[i];
                }
            }
            return -1;
        }

        public object Clone()
        {
            return new Hash(this);
        }

        public interface IEnumerable
        {
            IEnumerator GetEnumerator();
        }

        public IEnumerator GetEnumerator() => values.GetEnumerator();

        public bool MoveNext()
        {
            if (position < CountElems - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        } // перемещение на одну позицию вперед в контейнере элементов

        public object Current
        {
            get
            {
                if (position == -1 || position >= CountElems)
                    throw new ArgumentException();
                return values[position];
            }
        }  // текущий элемент в контейнере

        public void Reset() => position = -1; // перемещение в начало контейнера
        
    }
}
