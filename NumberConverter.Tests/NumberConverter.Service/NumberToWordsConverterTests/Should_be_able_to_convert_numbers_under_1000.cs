using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_convert_numbers_under_1000
    {
        private INumberToWordsConverter _sut;
        private String result;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "output")
                {
                    {"100", "One Hundred Dollars"},
                    {"200", "Two Hundred Dollars"},
                    {"800", "Eight Hundred Dollars"},
                    {"620", "Six Hundred And Twenty Dollars"},
                    {"730", "Seven Hundred And Thirty Dollars"},
                    {"240", "Two Hundred And Forty Dollars"},
                    {"950", "Nine Hundred And Fifty Dollars"},
                    {"460", "Four Hundred And Sixty Dollars"},
                    {"170", "One Hundred And Seventy Dollars"},
                    {"380", "Three Hundred And Eighty Dollars"},
                    {"890", "Eight Hundred And Ninety Dollars"},
                    {"599", "Five Hundred And Ninety-Nine Dollars"},
                    {"787", "Seven Hundred And Eighty-Seven Dollars"}
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