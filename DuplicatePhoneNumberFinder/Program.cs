// <author>Eli Armstrong</author>
// <remarks>I pledge my word of honor that I have abided
// by the CSN Academic Integrity Policy while completing
// this assignment.</remarks>
// <file>Program.cs</file>
// <date>2018-11-23</date>
// <summary>The start of the program.</summary> 
// <remarks>Time taken to develop, write, test and debug
// solution. About 3 hours. </remarks>

using System;
using System.IO;

// ----------------------------------------------------------------------------
// The Name Space for DuplicatePhoneNumberFinder.
// ----------------------------------------------------------------------------
namespace DuplicatePhoneNumberFinder
{
    /// -----------------------------------------------------------------------
    /// <summary>The Program class.</summary>
    /// -----------------------------------------------------------------------
    class Program
    {
        /// -------------------------------------------------------------------
        /// <summary>The main entry point for the application.</summary>
        /// -------------------------------------------------------------------
        static void Main(string[] args)
        {
            HandleData(FileGetter());
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method asks the user for a file path and if the file exists 
        /// returns a StreamReader to read the file. Else, the user is again 
        /// asked for a file path.
        /// </summary>
        /// <returns> A vaild StreamReader </returns>
        private static StreamReader FileGetter()
        {
            //The path of where the file to be read is located.
            string filePath;

            Console.Write("Please enter a file path: ");
            filePath = Console.ReadLine();
            while (!File.Exists(filePath))
            {
                Console.Clear();
                Console.WriteLine($"Sorry {filePath} does not exists.");
                Console.Write($"Please enter a file path: ");
                filePath = Console.ReadLine();
            }
            Console.Clear();

            return new StreamReader(filePath);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method read the data from a passed StreamReader and writes the
        /// the data by dataset sections.
        /// </summary>
        /// <param name="file">
        /// A StreamReader with dataSets of phone numbers
        /// </param>
        /// -------------------------------------------------------------------
        private static void HandleData(StreamReader file)
        {
            // A link list that stores phone numbers.
            var phoneList = new PhoneNumberList();
            // A phone data type to hold the data from the phoneList.
            PhoneData phone;
            // Stores the number of datasets from the file.
            int numberOFDataSets;
            // Stores the number of phone number in a data set.
            int numberOfPhoneNumbers;


            if (int.TryParse(file.ReadLine(), out numberOFDataSets))
            {
                file.ReadLine();
                for (int i = 0; i < numberOFDataSets; i++)
                {
                    Console.WriteLine($"----- Dataset {i + 1} ----- \n");
                    if (int.TryParse(file.ReadLine(), out numberOfPhoneNumbers))
                    {
                        for (int j = 0; j < numberOfPhoneNumbers; j++)
                        {
                            phone = new PhoneData(PhoneLettersToNumbers.
                                FormatToPhoneNumber(file.ReadLine()));
                            phoneList.InsertByNumber(phone);
                        }
                        file.ReadLine();
                        phoneList.DisplayPhoneDups();
                        phoneList = new PhoneNumberList();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
