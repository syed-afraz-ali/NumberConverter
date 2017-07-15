using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_convert_numbers_under_100
    {
        private INumberToWordsConverter _sut;
        private String result;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "output")
                {
                    {"20", "Twenty Dollars"},
                    {"30", "Thirty Dollars"},
                    {"40", "Forty Dollars"},
                    {"50", "Fifty Dollars"},
                    {"60", "Sixty Dollars"},
                    {"70", "Seventy Dollars"},
                    {"80", "Eighty Dollars"},
                    {"90", "Ninety Dollars"},
                    {"99", "Ninety-Nine Dollars"},
                    {"32", "Thirty-Two Dollars"},
                    {"73", "Seventy-Three Dollars"}
                })
                .BDDfy();
        }


        private void WhenUserEnters__input__(String input)
        {
            _sut = new NumberToWordsConverter();
            result = _sut.ConvertToWords(input);
        }


        private void ThenResultShouldBe__output__(String output)
        {
            result.ShouldBe(output);
        }
    }
}