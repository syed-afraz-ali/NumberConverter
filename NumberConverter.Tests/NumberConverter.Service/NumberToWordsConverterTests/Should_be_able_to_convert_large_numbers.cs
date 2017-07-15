using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_convert_large_numbers
    {
        private INumberToWordsConverter _sut;
        private String result;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "output")
                {
                    {"1000", "One Thousand Dollars"},
                    {"2000000", "Two Million Dollars"},
                    {"8000000000", "Eight Billion Dollars"},
                    {"6000000000000", "Six Trillion Dollars"},
                    {"52345745645645645", "Fifty-Two Quadrillion And Three Hundred And Forty-Five Trillion And Seven Hundred And Forty-Five Billion And Six Hundred And Forty-Five Million And Six Hundred And Forty-Five Thousand And Six Hundred And Forty-Eight Dollars"},
                    {"752345745645645645123123.45", "Seven Hundred And Fifty-Two Sextillion And Three Hundred And Forty-Five Quintillion And Seven Hundred And Forty-Five Quadrillion And Six Hundred And Forty-Five Trillion And Six Hundred And Forty-Five Billion And Five Hundred And Ninety-Nine Million And Fifteen Thousand And Forty Dollars And Forty-Five Cents"},
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