using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxyDriver
{
    class RomanNumeral
    {
        private static Dictionary<char, int> _valuesOfEachRomanNumeral = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int ConvertToInteger(string romanNumber)
        {
            int result = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                // Getting value of symbol s[i]  
                int currentCharacterInInteger = _valuesOfEachRomanNumeral[romanNumber[i]];

                // If next symbol exists
                if (i + 1 < romanNumber.Length)
                {
                    int nextCharacterInInteger = _valuesOfEachRomanNumeral[romanNumber[i + 1]];

                    // Comparing both values  
                    if (currentCharacterInInteger >= nextCharacterInInteger)
                    {
                        // Value of current symbol is greater  
                        // or equalto the next symbol  
                        result += currentCharacterInInteger;
                    }
                    else
                    {
                        result += nextCharacterInInteger - currentCharacterInInteger;
                        i++; // Value of current symbol is 
                             // less than the next symbol  
                    }
                }
                else
                {
                    result += currentCharacterInInteger;
                    i++;
                }
            }

            return result;
        }
    }
}
