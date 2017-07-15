using System;
using NumberConverter.Service;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace NumberConverter.Tests.NumberConverter.Service.NumberToWordsConverterTests
{
    [TestFixture]
    public class Should_be_able_to_handle_valid_exception_scenarios
    {
        private INumberToWordsConverter _sut;
        private String result;
        private Exception _exception;

        [Test]
        public void Test()
        {
            this.WithExamples(new ExampleTable("input", "error")
                {
                    {"-1", "Amount cannot be negative"},
                    {"12.123", "You can only enter number upto two decimal places"},
                    {"12s", "The number that you entered is invalid"},
                    {(Double.MaxValue + 1).ToString("0." + new string('#', 339)), "Unfortunately this number is too big for me!"},
                })
                .BDDfy();
        }
        
        private void WhenUserEntersInvalid__input__(String input)
        {
            _sut = new NumberToWordsConverter();
            _exception = Should.Throw<Exception>(() => _sut.ConvertToWords(input));
        }
        
        private void ThenErrorMessageShouldBe__error__(String error)
        {
            _exception.Message.ShouldBe(error);
        }
    }
}