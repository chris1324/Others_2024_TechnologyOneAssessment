namespace TechOneAssessment.Web.Utilities
{
    public static class StringExtensions
    {
        public static string ReplaceAt(this string str, int index, string substring)
        {
            if (index < 0 || index >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            return str.Substring(0, index) + substring + str.Substring(index + 1);
        }
    }
}