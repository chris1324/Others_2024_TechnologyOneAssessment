using TechOneAssessment.Web.Utilities;

namespace TechOneAccessMent.Test
{
    public abstract class DollarsWordConverter_Test
    {
        [Theory]
        [InlineData("123.45", "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
        // < 0 dollars
        [InlineData("-2.00", "(TWO DOLLARS)")]
        [InlineData("-1.00", "(ONE DOLLAR)")]
        [InlineData("-0.01", "(ONE CENT)")]
        // 0.00 - 0.99 dollars
        [InlineData("0.00", "ZERO DOLLARS")]
        [InlineData("0.01", "ONE CENT")]
        [InlineData("0.02", "TWO CENTS")]
        // 1.00 - 9.99 dollars
        [InlineData("1.00", "ONE DOLLAR")]
        [InlineData("2.00", "TWO DOLLARS")]
        [InlineData("3.00", "THREE DOLLARS")]
        [InlineData("4.00", "FOUR DOLLARS")]
        [InlineData("5.00", "FIVE DOLLARS")]
        [InlineData("6.00", "SIX DOLLARS")]
        [InlineData("7.00", "SEVEN DOLLARS")]
        [InlineData("8.00", "EIGHT DOLLARS")]
        [InlineData("9.00", "NINE DOLLARS")]
        [InlineData("9.05", "NINE DOLLARS AND FIVE CENTS")]
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
        [InlineData("201.21", "TWO HUNDRED AND ONE DOLLARS AND TWENTY-ONE CENTS")]
        [InlineData("290.21", "TWO HUNDRED AND NINETY DOLLARS AND TWENTY-ONE CENTS")]
        [InlineData("291.21", "TWO HUNDRED AND NINETY-ONE DOLLARS AND TWENTY-ONE CENTS")]
        // Thousand dollars
        [InlineData("1,000.00", "ONE THOUSAND DOLLARS")]
        [InlineData("2,013.00", "TWO THOUSAND AND THIRTEEN DOLLARS")]
        [InlineData("2,900.21", "TWO THOUSAND AND NINE HUNDRED DOLLARS AND TWENTY-ONE CENTS")]
        [InlineData("2,913.21", "TWO THOUSAND NINE HUNDRED AND THIRTEEN DOLLARS AND TWENTY-ONE CENTS")]
        // Ten Thousand dollars
        [InlineData("10,000.00", "TEN THOUSAND DOLLARS")]
        [InlineData("22,013.00", "TWENTY-TWO THOUSAND AND THIRTEEN DOLLARS")]
        [InlineData("22,900.00", "TWENTY-TWO THOUSAND AND NINE HUNDRED DOLLARS")]
        [InlineData("22,913.21", "TWENTY-TWO THOUSAND NINE HUNDRED AND THIRTEEN DOLLARS AND TWENTY-ONE CENTS")]
        // Hundred Thousand dollars
        [InlineData("100,000.00", "ONE HUNDRED THOUSAND DOLLARS")]
        [InlineData("231,002.23", "TWO HUNDRED THIRTY-ONE THOUSAND AND TWO DOLLARS AND TWENTY-THREE CENTS")]
        [InlineData("200,212.23", "TWO HUNDRED THOUSAND TWO HUNDRED AND TWELVE DOLLARS AND TWENTY-THREE CENTS")]
        [InlineData("231,232.23", "TWO HUNDRED THIRTY-ONE THOUSAND TWO HUNDRED AND THIRTY-TWO DOLLARS AND TWENTY-THREE CENTS")]
        // Million dollars
        [InlineData("1,000,000.00", "ONE MILLION DOLLARS")]
        [InlineData("5,000,337.22", "FIVE MILLION THREE HUNDRED AND THIRTY-SEVEN DOLLARS AND TWENTY-TWO CENTS")]
        [InlineData("5,631,000.22", "FIVE MILLION SIX HUNDRED AND THIRTY-ONE THOUSAND DOLLARS AND TWENTY-TWO CENTS")]
        [InlineData("5,631,001.22", "FIVE MILLION SIX HUNDRED THIRTY-ONE THOUSAND AND ONE DOLLARS AND TWENTY-TWO CENTS")]
        [InlineData("5,631,337.22", "FIVE MILLION SIX HUNDRED THIRTY-ONE THOUSAND THREE HUNDRED AND THIRTY-SEVEN DOLLARS AND TWENTY-TWO CENTS")]
        // Ten Million dollars and above
        [InlineData("10,000,000.00", "TEN MILLION DOLLARS")]
        [InlineData("100,000,000.00", "ONE HUNDRED MILLION DOLLARS")]
        [InlineData("1,000,000,000.00", "ONE BILLION DOLLARS")]
        [InlineData("10,000,000,000.00", "TEN BILLION DOLLARS")]
        [InlineData("100,000,000,000.00", "ONE HUNDRED BILLION DOLLARS")]
        [InlineData("1,000,000,000,000.00", "ONE TRILLION DOLLARS")]
        [InlineData("10,000,000,000,000.00", "TEN TRILLION DOLLARS")]
        [InlineData("100,000,000,000,000.00", "ONE HUNDRED TRILLION DOLLARS")]
        public void Convert_GivenNumericDollars_ConvertToExpectedWords(string valueAsString, string expectedResult)
        {
            // Arrange
            var value = decimal.Parse(valueAsString);

            // Act
            var sut = CreateSut();
            var result = sut.Convert(value);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        protected abstract IDollarsWordConverter CreateSut();
    }
}