// <author>Eli Armstrong</author>
// <remarks>I pledge my word of honor that I have abided
// by the CSN Academic Integrity Policy while completing
// this assignment.</remarks>
// <file>PhoneData.cs</file>
// <date>2018-11-23</date>
// <summary>This class is to be hold phone data for a Data part of 
// the ListNode.</summary> 
// <remarks>Time taken to develop, write, test and debug
// solution. About 3 hours. </remarks>

// ----------------------------------------------------------------------------
// The Name Space for DuplicatePhoneNumberFinder.
// ----------------------------------------------------------------------------
namespace DuplicatePhoneNumberFinder
{
    /// -----------------------------------------------------------------------
    /// <summary>The Program class.</summary>
    /// -----------------------------------------------------------------------
    class PhoneData
    {
        // holds the phone number.
        private string phoneNumber;
        // Holds the number of times a phone number in stored in a list.
        private int count = 1;

        /// -------------------------------------------------------------------
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="number">The phone number to be stored.</param>
        /// -------------------------------------------------------------------
        public PhoneData(string number)
        {
            phoneNumber = number;
        }

        /// ------------------------------------------------------------------- 
        /// <summary>
        /// Gets the number of time the number has been stored.
        /// </summary>
        /// -------------------------------------------------------------------
        public int Count { get => count; }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Adds one to the count.
        /// </summary>
        /// -------------------------------------------------------------------
        public void IncrementCount()
        {
            count++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// A string to that holds the phone Number.
        /// </summary>
        /// <returns> A string that hold the phone number.</returns>
        /// -------------------------------------------------------------------
        public override string ToString()
        {
            return phoneNumber;
        }

    }
}
