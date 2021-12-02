
using System.Collections.Generic;

namespace Lesson_1
{
    internal class FibonacciListClass
    {
        private List<int> _numbs;
        private static object _lock = new object();

        public List<int> Numbs
        {
            get
            {
                lock (_lock) { return _numbs; };
            }
            set
            {
                lock(_lock) { _numbs = value; }
            }
        }
    }
}
