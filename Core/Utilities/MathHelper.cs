namespace Core.Utilities
{
    public static class MathHelper
    {
        public static int GetFactorial(int fact)
        {
            if (fact == 0)
                return 1;
            return fact * GetFactorial(fact - 1);
        }
    }
}