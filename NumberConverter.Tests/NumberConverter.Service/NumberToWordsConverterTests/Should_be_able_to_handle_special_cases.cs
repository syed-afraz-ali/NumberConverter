using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_handle_special_cases
    {
        private INumberToWordsConverter _sut;
        private String result;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "output")
                {
                    {"0", "Zero Dollars"},
                    {"0.23", "Zero Dollars And Twenty-Three Cents"},
                    {"00.28", "Zero Dollars And Twenty-Eight Cents"},
                    {"5.00", "Five Dollars"},
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