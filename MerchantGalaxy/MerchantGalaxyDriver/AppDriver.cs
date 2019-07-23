using System;
using System.Collections.Generic;

namespace MerchantGalaxyDriver
{
    public class AppDriver
    {
        public Dictionary<string, string> _romanTranslations = new Dictionary<string, string>();
        public Dictionary<string, float> _itemValues = new Dictionary<string, float>();
        private string _allowedRomanNumeralCharacters = "IVXLCDM";
        public static string NoIdeaWhatYouAreTalkingAbout { get; } 
            = "I have no idea what you are talking about";

        public string LineFeed(string s)
        {
            string[] split = s.Split(' ');

            if (split.Length == 3 && split[1] == "is" && _allowedRomanNumeralCharacters.Contains(split[2]))
            {
                _romanTranslations[split[0]] = split[2];
            }
            else if (split.Length >= 5 && 
                    split[split.Length-1] == "Credits" && 
                    int.TryParse(split[split.Length-2], out int credits) &&
                    split[split.Length-3] == "is")
            {
                string RomanNumber = string.Empty;
                string item = split[split.Length - 4];

                Array.Resize<string>(ref split, split.Length - 4);

                foreach (var numeral in split)
                {
                    if (_romanTranslations.ContainsKey(numeral))
                    {
                        RomanNumber += _romanTranslations[numeral];
                    }
                    else
                    {
                        return NoIdeaWhatYouAreTalkingAbout;
                    }
                }

                int value = RomanNumeral.ConvertToInteger(RomanNumber);

                _itemValues[item] = (float) credits / value;
                return item + " is " + RomanNumeral.ConvertToInteger(RomanNumber) + " Credits.";
            }
            else if (split.Length >= 4 &&
                    split[0] == "how" &&
                    split[1] == "much" &&
                    split[2] == "is")
            {
                string RomanNumber = string.Empty;
                string result = string.Empty;

                // upto length - 1 to avoid scanning '?'
                for (int i = 3; i < split.Length - 1; i++)
                {
                    if (_romanTranslations.ContainsKey(split[i]))
                    {
                        RomanNumber += _romanTranslations[split[i]];
                        result += split[i] + " ";
                    }
                    else
                    {
                        return NoIdeaWhatYouAreTalkingAbout;
                    }
                }

                return result + $"is {RomanNumeral.ConvertToInteger(RomanNumber)}";
            }
            else if (split.Length >= 6 &&
                    split[0] == "how" &&
                    split[1] == "many" &&
                    split[2] == "Credits" &&
                    split[3] == "is")
            {
                string RomanNumber = String.Empty;
                string result = string.Empty;

                for (int i = 4; i < split.Length - 2; i++)
                {
                    if (!_romanTranslations.ContainsKey(split[i]))
                    {
                        return NoIdeaWhatYouAreTalkingAbout;
                    }
                    RomanNumber += _romanTranslations[split[i]];
                    result += split[i] + " ";
                }
                string item = split[split.Length - 2];
                int integer = (int) (RomanNumeral.ConvertToInteger(RomanNumber) * _itemValues[item]);
                result += split[split.Length - 2] + " is " + integer.ToString() + " Credits";
                return result;
            }

            return NoIdeaWhatYouAreTalkingAbout;
        }
    }
}
