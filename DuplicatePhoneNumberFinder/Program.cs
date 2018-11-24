using System;
using System.Collections.Generic;


namespace DuplicatePhoneNumberFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var readLines = File.ReadAllLines("../../test_input.txt");
            PhoneNumberList phoneList = new PhoneNumberList();


            int numberOFDataSets = int.Parse(readLines[count++]);
            count++;
            for (int i = 0; i < numberOFDataSets; i++)
            {
                Console.WriteLine($"----- Dataset {i+1} ----- \n");
                int numberOfPhoneNumbers = int.Parse(readLines[count++]);
                for (int j = 0; j < numberOfPhoneNumbers; j++)
                {
                    PhoneData phone = new PhoneData(PhoneLettersToNumbers.FormatToPhoneNumber(readLines[count++]));
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
