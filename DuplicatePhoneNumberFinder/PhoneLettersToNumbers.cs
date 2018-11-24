// <author>Eli Armstrong</author>
// <remarks>I pledge my word of honor that I have abided
// by the CSN Academic Integrity Policy while completing
// this assignment.</remarks>
// <file>PhoneLettersToNumbers.cs</file>
// <date>2018-11-23</date>
// <summary> This class is used to change to letter on the 
// phone dial to it digit counterpart.</summary> 
// <remarks>Time taken to develop, write, test and debug
// solution. About 3 hours. </remarks>

using System.Collections.Generic;

// ----------------------------------------------------------------------------
// The Name Space for DuplicatePhoneNumberFinder.
// ----------------------------------------------------------------------------
namespace DuplicatePhoneNumberFinder
{
    /// -----------------------------------------------------------------------
    /// <summary>The static PhoneLettersToNumbers class.</summary>
    /// -----------------------------------------------------------------------
    static class PhoneLettersToNumbers
    {
        // Holds a Dictionary with a char as the key and a char as a value.
        // I made it read only. : )
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

        /// -------------------------------------------------------------------
        /// <summary>
        /// Converts a letter to it number counterpart.
        /// </summary>
        /// <param name="letter"> the char to be converted.</param>
        /// <returns>A char that is a number found on a phone.</returns>
        /// <remarks>If the letter is not a char on a phone then the method 
        /// returns a blank space. Because one can not return an empty char.
        /// </remarks>
        /// -------------------------------------------------------------------
        public static char Convert(char letter)
        {
            char returnChar = ' ';
            if (letterToNumber.ContainsKey(letter))
            {
                returnChar = letterToNumber[letter];
            }
            return returnChar;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method taken in a string and converts it into a phone number 
        /// format.
        /// </summary>
        /// <param name="line">The string to be converted</param>
        /// <returns> A formated string in the format of a phone number.
        /// </returns>
        /// <remarks>This will added the '-' in the phone number.</remarks>
        /// -------------------------------------------------------------------
        public static string FormatToPhoneNumber(string line)
        {
            // The string to be returned.
            string returnString = "";
            foreach (var ch in line)
            {
                    if (letterToNumber.ContainsKey(ch))
                    {
                        returnString += letterToNumber[ch];
                    }
            }
            returnString = returnString.Insert(3, "-");
            return returnString;
        }

    }
}
