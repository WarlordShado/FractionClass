using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCollection
{
    public class FracMath
    {
        public static int GCF(int num1, int num2)
        {
            while (num2 != 0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }

            return num1;
        }

        public static int LCM(int num1, int num2)
        {
            return num1 / GCF(num1, num2) * num2;
        }
    }
}
