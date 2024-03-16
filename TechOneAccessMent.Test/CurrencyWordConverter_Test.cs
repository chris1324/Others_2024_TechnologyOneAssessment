using TechOneAssessment.Web.Utilities;

namespace TechOneAccessMent.Test
{
    public class CurrencyWordConverter_Test
    {
        [Theory]
        public void Convert(string valueAsString, string expectedResult)
        {
            // Arrange
            var value = decimal.Parse(valueAsString);

            // Act
            var result = CurrencyWordConverter.Convert(value);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}