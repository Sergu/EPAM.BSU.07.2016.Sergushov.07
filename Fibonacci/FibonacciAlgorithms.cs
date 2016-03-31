using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Fibonacci
{
    public static class FibonacciAlgorithms
    {
        public static IEnumerable GetFibonacciNumber()
        {
            long numb1 = 1;
            long numb2 = 2;
            long fibanachiNumber;
            while (true)
            {
                yield return fibanachiNumber = numb1;
                long temp = numb2;
                numb2 = numb1 + numb2;
                numb1 = temp;
            }
        }
    }
}
