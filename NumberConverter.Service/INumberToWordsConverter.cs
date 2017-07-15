using System;

namespace NumberConverter.Service
{
    public interface INumberToWordsConverter
    {
        String ConvertToWords(String number);
    }
}