using System;

namespace HashTable
{
    public class Element
    {
        public Element JoinedElement;
        public object Key { get; private set; }
        public object Value { get; private set; }

        public Element(object key, object value)
        {
            Key = key;
            Value = value;
            if (Key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public void ChangeValue(object value)
        {
            Value = value;
        }
    }

    public class HashTable
    {
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public int Size;
        public Element[] massive;
        public HashTable(int size)
        {
            massive = new Element[size];
            Size = size;
        }

        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            
            var newElem = new Element(key, value);
            var hash = key.GetHashCode();
            hash = Math.Abs(hash) % Size;
            var oldElem = massive[hash];
            if (oldElem is null)
                massive[hash] = newElem;
            else
            {
                while (true)
                {
                    if (oldElem.Key.Equals(key))
                    {
                        oldElem.ChangeValue(value);
                        break;
                    }
                    if (oldElem.JoinedElement is null)
                    {
                        oldElem.JoinedElement = newElem;
                        break;
                    }
                    else
                    {
                        oldElem = oldElem.JoinedElement;
                    }
                }
            }
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключ
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public object GetValueByKey(object key)
        {
            foreach(var e in massive)
            {
                if (e.Key.Equals(key))
                    return e.Value;
            }
            return null;
        }
    }
}