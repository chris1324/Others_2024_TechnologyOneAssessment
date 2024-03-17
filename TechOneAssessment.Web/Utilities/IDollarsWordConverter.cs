namespace TechOneAssessment.Web.Utilities
{
    public interface IDollarsWordConverter
    {
        string Convert(decimal value);
        string Convert(string value);
    }
}