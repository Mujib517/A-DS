using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Demo
{
    //Answer query by calculating sum between certain index range
    public class ArrayQueries
    {
        private int[] _arr;
        public int[] Arr
        {
            get { return _arr; }
            set
            {
                _arr = value;
                for (var i = 1; i < _arr.Length; i++)
                {
                    _arr[i] = _arr[i] + _arr[i - 1];
                }
            }
        }

        //O(N+Q)
        public int Solution1(int start, int end)
        {
            //edge conditions
            if (start < 0) start = 0;
            if (end >= _arr.Length) end = _arr.Length - 1;

            if (start == 0) return _arr[end];
            return _arr[end] - _arr[start - 1];
        }
    }
}
