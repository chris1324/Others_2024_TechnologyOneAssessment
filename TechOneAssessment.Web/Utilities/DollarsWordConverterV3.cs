using TechOneAssessment.Web.Exceptions;

namespace TechOneAssessment.Web.Utilities
{
    public class DollarsWordConverterV3 : IDollarsWordConverter
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

        public string Convert(string value)
        {
            var dollar = new Dollar(value);
            var dollarsWord = DoConvertDollars(dollar);
            dollarsWord += dollar.IsOneDollar ? " DOLLAR" : " DOLLARS";

            var centsWord = DoConvertCents(dollar);
            centsWord += dollar.Cents == 1 ? " CENT" : " CENTS";

            var words = Concat();
            if (dollar.IsNegative) words = $"({words})";

            return words;

            string Concat()
            {
                if (!dollar.IsZeroDollar && dollar.Cents != 0)
                {
                    return dollarsWord + " AND " + centsWord;
                }
                else if (!dollar.IsZeroDollar && dollar.Cents == 0)
                {
                    return dollarsWord;
                }
                else if (dollar.IsZeroDollar && dollar.Cents != 0)
                {
                    return centsWord;
                }
                else
                {
                    return dollarsWord;
                }
            }
        }

        public string Convert(decimal value)
        {
            return Convert(value.ToString());
        }

        private string DoConvertCents(Dollar dollar)
        {
            if (dollar.Cents > 0)
            {
                return DoConvertFor0To99(dollar.Cents);
            }
            else
            {
                return null;
            }
        }

        private string DoConvertDollars(Dollar dollar)
        {
            if (dollar.IsZeroDollar) return "ZERO";

            var results = new List<string>();

            foreach (var part in dollar.Parts)
            {
                var currResults = DoConvertFor100To999(part.Value);
                var lastIndex = currResults.Count - 1;
                if (part.Term != null) currResults[lastIndex] += " " + part.Term;
                results.AddRange(currResults);
            }

            if (results.Count == 1)
            {
                return results[0];
            }
            else
            {
                var lastIndex = results.Count - 1;
                results[lastIndex] = "AND " + results[lastIndex];

                return string.Join(" ", results);
            }
        }

        private string DoConvertFor0To19(long value)
        {
            return _teens[value];
        }

        private string DoConvertFor0To99(long value)
        {
            if (value < 20)
            {
                return DoConvertFor0To19(value);
            }
            else
            {
                var remainder = value % 10;
                var word = _tens[value - remainder];
                if (remainder > 0) word += "-" + DoConvertFor0To19(remainder);

                return word;
            }
        }

        private List<string> DoConvertFor100To999(long value)
        {
            var results = new List<string>();

            if (value < 100)
            {
                results.Add(DoConvertFor0To99(value));
            }
            else
            {
                var remainder = value % 100;
                var word = DoConvertFor0To99((value - remainder) / 100) + " HUNDRED";
                results.Add(word);

                if (remainder > 0)
                {
                    var remainderWord = DoConvertFor0To99(remainder);
                    results.Add(remainderWord);
                }
            }

            return results;
        }

        private class Dollar
        {
            public Dollar(string value)
            {
                var isNegative = value.Contains("-");

                var dollarsValue = value.Contains('.') ? value.Split(".")[0] : value;
                dollarsValue = dollarsValue.Replace(",", "");
                dollarsValue = dollarsValue.Replace("-", "");

                var centsValue = value.Contains('.') ? value.Split(".")[1][..2] : value;
                var isValidCents = int.TryParse(centsValue, out var centsValueAsInt);
                if (!isValidCents) throw new InputException("Input format invalid");

                IsNegative = isNegative;
                IsZeroDollar = dollarsValue == "0";
                IsOneDollar = dollarsValue == "1";
                Cents = centsValueAsInt;
                Parts = new List<DollarPart>
                {
                    Parse(dollarsValue, 13, 15, "TRILLION"),
                    Parse(dollarsValue, 10, 12, "BILLION"),
                    Parse(dollarsValue, 7, 9, "MILLION"),
                    Parse(dollarsValue, 4, 6, "THOUSAND"),
                    Parse(dollarsValue, 3, 3, "HUNDRED"),
                    Parse(dollarsValue, 1, 2, null)
                }.Where(x => x != null).ToList(); ;
            }

            private static DollarPart Parse(string value, int startDigit, int endDigit, string term)
            {
                var maxIndex = value.Length - 1;
                var startIndex = maxIndex - (endDigit - 1);
                var length = endDigit - startDigit + 1;

                while (startIndex < 0)
                {
                    startIndex++;
                    length--;

                    if (length == 0) return null;
                }

                var resultAsString = value.Substring(startIndex, length);

                var isValid = int.TryParse(resultAsString, out var result);
                if (!isValid) throw new InputException("Input format invalid");

                if (result == 0) return null;

                return new DollarPart(result, term);
            }

            public bool IsNegative { get; }
            public bool IsZeroDollar { get; }
            public bool IsOneDollar { get; }
            public int Cents { get; }
            public IReadOnlyList<DollarPart> Parts { get; }
        }

        private class DollarPart
        {
            public DollarPart(int value, string term)
            {
                Value = value;
                Term = term;
            }

            public int Value { get; }
            public string Term { get; }
        }
    }
}