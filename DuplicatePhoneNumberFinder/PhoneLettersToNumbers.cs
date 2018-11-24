using System.Collections.Generic;


namespace DuplicatePhoneNumberFinder
{
    static class PhoneLettersToNumbers
    {
        // Holds a Dictionary with a char as the key and a char as a value.
        // I made it read only
        private readonly static Dictionary<char, char> letterToNumber =
            new Dictionary<char, char>()
              {
                    {'1', '1'},
                    {'2', '2'}, {'A', '2'}, {'B', '2'}, {'C', '2'},
                    {'3', '3'}, {'D', '3'}, {'E', '3'}, {'F', '3'},
                    {'4', '4'}, {'G', '4'}, {'H', '4'}, {'I', '4'},
                    {'5', '5'}, {'J', '5'}, {'K', '5'}, {'L', '5'},
                    {'6', '6'}, {'M', '6'}, {'N', '6'}, {'O', '6'},
                    {'7', '7'}, {'P', '7'}, {'R', '7'}, {'S', '7'},
                    {'8', '8'}, {'T', '8'}, {'U', '8'}, {'V', '8'},
                    {'9', '9'}, {'W', '9'}, {'X', '9'}, {'Y', '9'},
                    {'0', '0'}
              };

        public static char Convert(char letter)
        {
            char returnChar = ' ';
            if (letterToNumber.ContainsKey(letter))
            {
                returnChar = letterToNumber[letter];
            }
            return returnChar;
        }

        public static string FormatToPhoneNumber(string line)
        {
            string returnString = "";
            for (int i = 0; i < line.Length; i++)
            {
                    if (letterToNumber.ContainsKey(line[i]))
                    {
                        returnString += letterToNumber[line[i]];
                    }
            }
            returnString = returnString.Insert(3, "-");
            return returnString;
        }

    }
}
