namespace SillyCLID.Utilities
{
    public static class Extensions
    {
        public static string FixCase(this string str)
        {
            var retVal = "";
            var words = str.Split(' ');
            foreach (var word in words)
            {
                retVal += FixWord(word) + " ";
            }

            return retVal.Trim();
        }

        private static string FixWord(this string word)
        {
            if (word.Length == 0)
                return String.Empty;
            else if (word.Length == 1)
                return word.ToUpper();
            else
                return char.ToUpper(word[0]) + word.Substring(1);
        }
    }}
