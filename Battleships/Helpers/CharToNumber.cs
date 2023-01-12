namespace Battleships.Helpers
{
    public static class CharToNumber
    {
        public static int ToInt(char c)
        {
            return char.ToUpper(c) - 64;
        }

        public static char FromInt(int i)
        {
            return (char)(i + 64);
        }
    }
}
