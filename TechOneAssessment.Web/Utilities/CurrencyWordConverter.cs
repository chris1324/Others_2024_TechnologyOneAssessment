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
            { 8, "ENIGHT" },
            { 9, "NINE" },
            { 10, "TEN" },
            { 11, "ELEVEN" },
            { 12, "TWELVE" },
            { 13, "THIRTEEN" },
            { 14, "FOURTEEN" },
            { 15, "FIFTEEN" },
            { 16, "SIXTEEN" },
            { 17, "SEVENTEEN" },
            { 18, "EIGHTENN" },
            { 19, "NINETEEN" }
        };

        private static readonly Dictionary<long, string> _tens = new()
        {
            { 0, "ZERO" },
            { 1, "TEN" },
            { 2, "TWENTY" },
            { 3, "THIRTY" },
            { 4, "FORTY" },
            { 5, "FIFTY" },
            { 6, "SIXTY" },
            { 7, "SEVENTY" },
            { 8, "EIGHTY" },
            { 9, "NINETY" }
        };

        public static string Convert(decimal amount)
        {
        }

        private static string DoConvert(long amount)
        {
        }
    }
}