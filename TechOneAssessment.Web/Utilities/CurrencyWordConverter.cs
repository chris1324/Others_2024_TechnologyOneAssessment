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

        private static readonly List<Term> _terms = new()
        {
            new Term { Lower = (long) Math.Pow(10, 2), Upper = (long) Math.Pow(10, 3), Word = "HUNDRED" },
            new Term { Lower = (long) Math.Pow(10, 3), Upper = (long) Math.Pow(10, 6), Word = "THOUSAND" },
            new Term { Lower = (long) Math.Pow(10, 6), Upper = (long) Math.Pow(10, 9), Word = "MILLION" },
            new Term { Lower = (long) Math.Pow(10, 9), Upper = (long) Math.Pow(10, 12), Word = "BILLION" },
            new Term { Lower = (long) Math.Pow(10, 12), Upper = (long) Math.Pow(10, 15), Word = "TRILLION" }
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
            else
            {
                var term = _terms.FirstOrDefault(x => x.Lower <= value && value < x.Upper);
                if (term == null) throw new Exception("TODO");

                var remainder = value % term.Lower;
                var word = DoConvert((value - remainder) / term.Lower) + " " + term.Word;

                if (remainder > 0)
                {
                    var remainderWord = DoConvert(remainder);
                    if (remainderWord.Contains("AND"))
                    {
                        word += " " + remainderWord;
                    }
                    else
                    {
                        word += " AND " + remainderWord;
                    }
                }

                return word;
            }
        }

        private class Term
        {
            public long Lower { get; set; }
            public long Upper { get; set; }
            public string Word { get; set; }
        }
    }
}