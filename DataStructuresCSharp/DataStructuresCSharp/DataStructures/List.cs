using System;

namespace DataStructuresCSharp.DataStructures
{
    public class List<T>
    {
        private int _length;
        private int _size;
        private T[] _elements;

        public int Size => _size;
        public int Length => _length;

        public List() : this(0)
        {}
        
        public List(int size)
        {
            if (size < 0)
                throw new ArgumentException("List size must be greater than or equal to zero.");
            
            _size = size;
            _length = 0;
            _elements = new T[size];
        }

        public List(T[] startValues)
        {
            _elements = startValues;
            _size = startValues.Length;
            _length = startValues.Length;
        }

        public List(int size, T[] startValues)
        {
            _elements = startValues;
            _size = size;
            _length = startValues.Length;
        }

        public T this[int index]
        {
            get => Get(index);
            set => Insert(index, value);
        }

        public void Add(T obj)
        {
            if (_length >= Size)
                UpscaleSize();

            _elements[_length-1] = obj;
        }

        public void Insert(int index, T obj)
        {
            if (index == _length-1)
            {
                Add(obj);
                return;
            }
            
            if (_length >= Size)
                UpscaleSize();

            ShiftElementsRight(index);
            _elements[index] = obj;
        }

        public void Remove(T toRemove)
        {
            for (int i = 0; i < Length; i++)
            {
                T element = _elements[i];
                if (element.Equals(toRemove))
                {
                    _elements[i] = default(T);
                    ShiftElementsLeft(i);
                }
            }
        }
        
        public void RemoveAt(int index)
        {
            EnsureInsideBounds(index);
            _elements[index] = default(T);
            ShiftElementsLeft(index);
        }
        
        public T Get(int index)
        {
            return _elements[index];
        }
        
        public T Get()
        {
            return Get(_length-1);
        }

        private void EnsureInsideBounds(int index)
        {
            if (index < 0 || index > Size)
                throw new ArgumentOutOfRangeException();
        }

        private void ShiftElementsLeft(int start)
        {
            for (int i = start; i < Length; i++)
            {
                if (i > 0)
                {
                    _elements[i - 1] = _elements[i];
                }
            }

            _elements[--_length] = default(T);
        }
        
        private void ShiftElementsRight(int start)
        {
            for (int i = Length-1; i >= start; i--)
            {
                if (i < Length-1)
                {
                    _elements[i + 1] = _elements[i];
                }
            }

            _elements[start] = default(T);
        }

        private void UpscaleSize()
        {
            T[] newData = new T[++_size];
            for (int i = 0; i < _length; i++)
            {
                newData[i] = _elements[i];
            }

            _elements = newData;
            _length++;
        }
        
        private void DownscaleSize()
        {
            T[] newData = new T[--_size];
            for (int i = 0; i < _size; i++)
            {
                newData[i] = _elements[i];
            }

            _length--;
            _elements = newData;
        }
    }
}