using System;

namespace Lib_2
{
    public class Lib_2
    {

        public static int sumB15(int[] x) 
        {
            int y = 0;
            for (int i = 0;i < x.Length;i++)
            {
                if (x[i] >15)
                {
                    y += x[i];
                }
            }
            return y;
        }
    }
}