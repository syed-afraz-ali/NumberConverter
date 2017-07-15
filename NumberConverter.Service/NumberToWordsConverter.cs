using System;
using System.Linq;
using System.Text;

namespace NumberConverter.Service
{
    public class NumberToWordsConverter : INumberToWordsConverter
    {
        private readonly String[] DENOM =
        {
            "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion",
            "Octillion", "Nonillion", "Decillion", "Undecillion", "Duodecillion", "Tredecillion", "Quattuordecillion",
            "Sexdecillion", "Septendecillion", "Octodecillion", "Novemdecillion", "Vigintillion"
        };

        private readonly String[] TENS =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        private readonly String[] UNDER_TWENTY =
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
            "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        public String ConvertToWords(String number)
        {
            ValidateInput(number);

            var integerPart = GetIntegerPart(number);

            var result = ConvertIntegerPart(integerPart) + " Dollars";

            if (NumberContainsDecimal(number))
            {
                result = result + " And " + ConvertDecimalPart(number);
            }

            return result;
        }

        private String GetIntegerPart(String number)
        {
            if (number.Contains('.'))
                return number.Substring(0, number.LastIndexOf('.'));
            else
                return number;
        }

        private String ConvertIntegerPart(String number)
        {
            var value = Convert.ToDouble(number);

            if (value == 0)
                return "Zero";

            if (value < 20)
                return ConvertNumberUnderTwenty(number);

            if (value < 100)
                return ConvertNumberUnderHundred(number);

            if (value < 1000)
                return ConvertNumberUnderThousand(number);

            return ConvertNumberOverThousand(number);
        }

        private void ValidateInput(String number)
        {
            try
            {
                var value = Convert.ToDouble(number);

                if (value < 0)
                    throw new Exception("Amount cannot be negative");

                if (NumberContainsDecimal(number))
                {
                    var decimalPart = number.Substring(number.LastIndexOf('.') + 1);

                    if (decimalPart.Length > 2)
                        throw new Exception("You can only enter number upto two decimal places");
                }
            }
            catch (FormatException)
            {
                throw new Exception("The number that you entered is invalid");
            }
            catch (OverflowException)
            {
                throw new Exception("Unfortunately this number is too big for me!");
            }
        }

        private String ConvertNumberUnderTwenty(String value)
        {
            var index = Convert.ToInt32(value);
            return UNDER_TWENTY[index];
        }

        private String ConvertNumberUnderHundred(String number)
        {
            var result = new StringBuilder();

            var tenthDigit = Convert.ToInt32(number[0].ToString());
            var lastDigitValue = number[1].ToString();

            result.Append(TENS[tenthDigit]);

            if (StringDoesNotContainOnlyZeros(lastDigitValue))
                result.Append("-" + ConvertNumberUnderTwenty(lastDigitValue));

            return result.ToString();
        }

        private String ConvertNumberUnderThousand(String number)
        {
            var result = new StringBuilder();

            var hundredthDigit = Convert.ToInt32(number[0].ToString());
            var tenthPart = number.Substring(number.Length - 2);

            result.Append(UNDER_TWENTY[hundredthDigit]).Append(" Hundred");

            if (StringDoesNotContainOnlyZeros(tenthPart))
                result.Append(" And ");

            result.Append(ConvertNumberUnderHundred(tenthPart));

            return result.ToString();
        }

        private static Boolean StringDoesNotContainOnlyZeros(String tenthPart)
        {
            return !String.IsNullOrWhiteSpace(tenthPart.Trim('0'));
        }

        private String ConvertNumberOverThousand(String number)
        {
            var input = Convert.ToDouble(number);

            

            for (var index = 0; index < DENOM.Length; index++)
            {
                var result = new StringBuilder();
                var incrementOfThousands = Convert.ToDouble(Math.Pow(1000, index));

                if (incrementOfThousands > input)
                {
                    var divisor = Convert.ToDouble(Math.Pow(1000, index - 1));
                    var quotient = (Int32)(input / divisor);
                    var remainder = input - quotient * divisor;

                   

                    result.Append(ConvertIntegerPart(quotient.ToString()) + " " + DENOM[index - 1]);
                    if (remainder > 0)
                    {
                        result.Append(" And " + ConvertIntegerPart(remainder.ToString()));
                    }
                    return result.ToString();
                }
            }
            return String.Empty;
        }

        private Boolean NumberContainsDecimal(String number)
        {
            if (!number.Contains('.'))
                return false;

            var decimalPart = Convert.ToInt32(number.Substring(number.LastIndexOf('.') + 1));

            if (decimalPart == 0)
                return false;
            return true;
        }

        private String ConvertDecimalPart(String number)
        {
            var decimalPart = number.Substring(number.LastIndexOf('.') + 1);

            return ConvertIntegerPart(decimalPart) + " Cents";
        }
    }
}