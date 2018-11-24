// <author>Eli Armstrong</author>
// <remarks>I pledge my word of honor that I have abided
// by the CSN Academic Integrity Policy while completing
// this assignment.</remarks>
// <file>Program.cs</file>
// <date>2018-10-16</date>
// <summary>The start of the program.</summary> 
// <remarks>Time taken to develop, write, test and debug
// solution. About 4 hours. </remarks>

using System;
using System.IO;

namespace DuplicatePhoneNumberFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var readLines = File.ReadAllLines("../../test_input.txt");
            PhoneNumberList phoneList = new PhoneNumberList();
            PhoneData phone;


            int numberOFDataSets = int.Parse(readLines[count++]);
            count++;
            for (int i = 0; i < numberOFDataSets; i++)
            {
                Console.WriteLine($"----- Dataset {i+1} ----- \n");
                int numberOfPhoneNumbers = int.Parse(readLines[count++]);
                for (int j = 0; j < numberOfPhoneNumbers; j++)
                {
                    phone = new PhoneData(PhoneLettersToNumbers.FormatToPhoneNumber(readLines[count++]));
                    phoneList.InsertByNumber(phone);
                }
                count++;
                phoneList.PhoneDisplayDupsWithExtra();
                phoneList = new PhoneNumberList();
                Console.WriteLine();
            }
        }
    }
}
