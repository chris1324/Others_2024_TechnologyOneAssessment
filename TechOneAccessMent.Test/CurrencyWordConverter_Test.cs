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
        [InlineData("11.00", "ELEVEN DOLLARS")]
        [InlineData("12.00", "TWELVE DOLLARS")]
        [InlineData("13.00", "THIRTEEN DOLLARS")]
        [InlineData("14.00", "FOURTEEN DOLLARS")]
        [InlineData("15.00", "FIFTEEN DOLLARS")]
        [InlineData("16.00", "SIXTEEN DOLLARS")]
        [InlineData("17.00", "SEVENTEEN DOLLARS")]
        [InlineData("18.00", "EIGHTEEN DOLLARS")]
        [InlineData("19.00", "NINETEEN DOLLARS")]
        [InlineData("19.21", "NINETEEN DOLLARS AND TWENTY-ONE CENTS")]
        // 20.00 - 99.99 dollars
        [InlineData("20.00", "TWENTY DOLLARS")]
        [InlineData("21.00", "TWENTY-ONE DOLLARS")]
        [InlineData("30.00", "THIRTY DOLLARS")]
        [InlineData("31.00", "THIRTY-ONE DOLLARS")]
        [InlineData("40.00", "FORTY DOLLARS")]
        [InlineData("41.00", "FORTY-ONE DOLLARS")]
        [InlineData("50.00", "FIFTY DOLLARS")]
        [InlineData("51.00", "FIFTY-ONE DOLLARS")]
        [InlineData("60.00", "SIXTY DOLLARS")]
        [InlineData("61.00", "SIXTY-ONE DOLLARS")]
        [InlineData("70.00", "SEVENTY DOLLARS")]
        [InlineData("71.00", "SEVENTY-ONE DOLLARS")]
        [InlineData("80.00", "EIGHTY DOLLARS")]
        [InlineData("81.00", "EIGHTY-ONE DOLLARS")]
        [InlineData("90.00", "NINETY DOLLARS")]
        [InlineData("91.00", "NINETY-ONE DOLLARS")]
        [InlineData("91.21", "NINETY-ONE DOLLARS AND TWENTY-ONE CENTS")]
        // Hundred dollars
        [InlineData("100.00", "ONE HUNDRED DOLLARS")]
        [InlineData("191.21", "ONE HUNDRED AND NINETY-ONE DOLLARS AND TWENTY-ONE CENTS.")]
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