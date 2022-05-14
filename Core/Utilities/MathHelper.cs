using System;

namespace Core.Utilities
{
    public static class MathHelper
    {
        public static int GetFactorial(int fact)
        {
            return fact switch
            {
                < 0 => throw new ArgumentException("Number should be greater than 0"),
                0 => 1,
                > 19 => throw new OverflowException("Overflow occurs above 19 factorial INTEGER"),
                _ => fact * GetFactorial(fact - 1)
            };
        }
    }
}