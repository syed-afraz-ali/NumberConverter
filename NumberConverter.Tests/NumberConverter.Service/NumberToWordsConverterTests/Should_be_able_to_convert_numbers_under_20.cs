using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_convert_numbers_under_20
    {
        private INumberToWordsConverter _sut;
        private String result;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "output")
                {
                    {"1", "One Dollars"},
                    {"2", "Two Dollars"},
                    {"3", "Three Dollars"},
                    {"4", "Four Dollars"},
                    {"5", "Five Dollars"},
                    {"6", "Six Dollars"},
                    {"7", "Seven Dollars"},
                    {"8", "Eight Dollars"},
                    {"9", "Nine Dollars"},
                    {"10", "Ten Dollars"},
                    {"11", "Eleven Dollars"},
                    {"12", "Twelve Dollars"},
                    {"13", "Thirteen Dollars"},
                    {"14", "Fourteen Dollars"},
                    {"15", "Fifteen Dollars"},
                    {"16", "Sixteen Dollars"},
                    {"17", "Seventeen Dollars"},
                    {"18", "Eighteen Dollars"},
                    {"19", "Nineteen Dollars"},
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