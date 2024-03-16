using TechOneAssessment.Web.Utilities;

namespace TechOneAccessMent.Test
{
    public class CurrencyWordConverter_Test
    {
        [Theory]
        // < 0 dollars
        [InlineData("-2.00", "(ONE DOLLARS)")]
        [InlineData("-1.00", "(ONE DOLLAR)")]
        // 0.00 - 0.99 dollars
        [InlineData("0.00", "ZERO DOLLARS")]
        [InlineData("0.01", "ONE CENT")]
        [InlineData("0.02", "TWO CENTS")]
        // 1.00 - 9.99 dollars
        [InlineData("1.00", "ONE DOLLAR")]
        [InlineData("2.00", "TWO DOLLARS")]
        // 10.00 - 19.99 dollars
        [InlineData("11.0", "ELEVEN DOLLARS")]
        [InlineData("12.0", "TWELVE DOLLARS")]
        [InlineData("13.0", "THIRTEEN DOLLARS")]
        [InlineData("14.0", "FOURTEEN DOLLARS")]
        [InlineData("15.0", "FIFTEEN DOLLARS")]
        [InlineData("16.0", "SIXTEEN DOLLARS")]
        [InlineData("17.0", "SEVENTEEN DOLLARS")]
        [InlineData("18.0", "EIGHTEEN DOLLARS")]
        [InlineData("19.0", "NINETEEN DOLLARS")]
        // 20.00 - 99.99 dollars
        [InlineData("20.0", "TWENTY DOLLARS")]
        [InlineData("21.0", "TWENTY-ONE DOLLARS")]
        [InlineData("30.0", "THIRTY DOLLARS")]
        [InlineData("31.0", "THIRTY-ONE DOLLARS")]
        [InlineData("40.0", "FORTY DOLLARS")]
        [InlineData("41.0", "FORTY-ONE DOLLARS")]
        [InlineData("50.0", "FIFTY DOLLARS")]
        [InlineData("51.0", "FIFTY-ONE DOLLARS")]
        [InlineData("60.0", "SIXTY DOLLARS")]
        [InlineData("61.0", "SIXTY-ONE DOLLARS")]
        [InlineData("70.0", "SEVENTY DOLLARS")]
        [InlineData("71.0", "SEVENTY-ONE DOLLARS")]
        [InlineData("80.0", "EIGHTY DOLLARS")]
        [InlineData("81.0", "EIGHTY-ONE DOLLARS")]
        [InlineData("90.0", "NINETY DOLLARS")]
        [InlineData("91.0", "NINETY-ONE DOLLARS")]
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