namespace TechOneAssessment.Web.Utilities
{
    public static class CurrencyWordConverter
    {
        private static readonly Dictionary<long, string> _teens = new()
        {
            { 0, "ZERO" },
            { 1, "ONE" },
            { 2, "TWO" },
            { 3, "THREE" },
            { 4, "FOUR" },
            { 5, "FIVE" },
            { 6, "SIX" },
            { 7, "SEVEN" },
            { 8, "EIGHT" },
            { 9, "NINE" },
            { 10, "TEN" },
            { 11, "ELEVEN" },
            { 12, "TWELVE" },
            { 13, "THIRTEEN" },
            { 14, "FOURTEEN" },
            { 15, "FIFTEEN" },
            { 16, "SIXTEEN" },
            { 17, "SEVENTEEN" },
            { 18, "EIGHTEEN" },
            { 19, "NINETEEN" }
        };

        private static readonly Dictionary<long, string> _tens = new()
        {
            { 0, "ZERO" },
            { 10, "TEN" },
            { 20, "TWENTY" },
            { 30, "THIRTY" },
            { 40, "FORTY" },
            { 50, "FIFTY" },
            { 60, "SIXTY" },
            { 70, "SEVENTY" },
            { 80, "EIGHTY" },
            { 90, "NINETY" }
        };

        public static string Convert(decimal value)
        {
            var valueAbs = Math.Abs(value);

            var dollars = (long)Math.Floor(valueAbs);
            var dollarsWord = DoConvert(dollars);
            dollarsWord += dollars == 1 ? " DOLLAR" : " DOLLARS";

            var cents = (long)Math.Floor((valueAbs - dollars) * 100);
            var centsWord = DoConvert(cents);
            centsWord += cents == 1 ? " CENT" : " CENTS";

            var words = Build();
            if (value < 0) words = $"({words})";

            return words;

            string Build()
            {
                if (dollars != 0 && cents != 0)
                {
                    return dollarsWord + " AND " + centsWord;
                }
                else if (dollars != 0 && cents == 0)
                {
                    return dollarsWord;
                }
                else if (dollars == 0 && cents != 0)
                {
                    return centsWord;
                }
                else
                {
                    return dollarsWord;
                }
            }
        }

        private static string DoConvert(long value)
        {
            if (value < 20)
            {
                return _teens[value];
            }
            else if (value < 100)
            {
                var remainder = value % 10;
                var word = _tens[value - remainder];
                if (remainder > 0) word += "-" + DoConvert(remainder);

                return word;
            }
            else if (value < 1000)
            {
                var remainder = value % 100;
                var word = DoConvert((value - remainder) / 100) + " HUNDRED";
                if (remainder > 0) word = Concat(word, DoConvert(remainder));

                return word;
            }
            else if (value < 1000000)
            {
                var remainder = value % 1000;
                var word = DoConvert((value - remainder) / 1000) + " THOUSAND";
                if (remainder > 0) word = Concat(word, DoConvert(remainder));

                return word;
            }
            else if (value < 1000000000)
            {
                var remainder = value % 1000000;
                var word = DoConvert((value - remainder) / 1000000) + " MILLION";
                if (remainder > 0) word = Concat(word, DoConvert(remainder));

                return word;
            }
            else
            {
                // TODO : Handle
                return "";
            }

            string Concat(string word, string remainderWord)
            {
                // TODO : Refactor ?
                if (remainderWord.Contains("AND"))
                {
                    return word + " " + remainderWord;
                }
                else
                {
                    return word + " AND " + remainderWord;
                }
            }
        }
    }
}