using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaProject
{
    

    public class Calculator
    {
        public Func<int, int, int> PlusFunction() 
        {
            //возвращают указатель на некоторый метод, который будет воспроизводить нашу операцию
            Func<int, int, int> func = (x, y) => x + y;
            return func;
        }

        public Func<int, int, int> MinusFunction() 
        {
            Func<int, int, int> func = (x, y) => x - y;
            return func;
        }
    }
}
