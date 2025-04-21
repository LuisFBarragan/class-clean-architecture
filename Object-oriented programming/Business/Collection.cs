using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_oriented_programming.Business
{
    public class Collection<T>
    {
        private T[] _elements;
        private int _limit;
        private int _index;

        public Collection(int limit)
        {
            _limit = limit;
            _index = 0;
            _elements = new T[_limit];
        }

        public void Add(T element)
        {
            if (_index<_limit) {
                _elements[_index] = element;
                _index++;
            }
        }

        public T[] Get()
            => _elements;
    }
}
