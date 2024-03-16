using System.Diagnostics.Eventing.Reader;

namespace TechOneAssessment.Web.Utilities
{
    public static class CurrencyWordConverter
    {
        private static readonly Dictionary<long, string> _units = new()
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

        public static string Convert(decimal amount)
        {
            var amountAbs = Math.Abs(amount);
            var dollars = (long)Math.Floor(amountAbs);
            var cents = (long)Math.Floor((amountAbs - dollars) * 100);

            var dollarsWord = DoConvert(dollars);
            dollarsWord += dollars == 1 ? " DOLLAR" : " DOLLARS";

            var centsWord = DoConvert(cents);
            centsWord += cents == 1 ? " CENT" : " CENTS";

            var words = Build();
            if (amount < 0) words = $"({words})";

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

        private static string DoConvert(long amount)
        {
            if (amount < 20)
            {
                return _units[amount];
            }
            else if (amount < 100)
            {
                var remainder = amount % 10;
                var result = _tens[amount - remainder];

                if (remainder > 0)
                {
                    result += "-" + DoConvert(remainder);
                }

                return result;
            }
            else if (amount < 1000)
            {
                var remainder = amount % 100;
                var result = DoConvert((amount - remainder) / 100) + " HUNDRED";

                if (remainder > 0)
                {
                    result += " " + DoConvert(remainder);
                }

                return result;
            }
            else if (amount < 10000)
            {
                var remainder = amount % 1000;
                var result = DoConvert((amount - remainder) / 1000) + " THOUSAND";

                if (remainder > 0)
                {
                    result += " " + DoConvert(remainder);
                }

                return result;
            }
            else
            {
                return "";
            }
        }
    }
}