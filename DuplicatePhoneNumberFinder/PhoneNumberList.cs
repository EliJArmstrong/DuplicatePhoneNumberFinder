// <author>Eli Armstrong</author>
// <remarks>I pledge my word of honor that I have abided
// by the CSN Academic Integrity Policy while completing
// this assignment.</remarks>
// <file>PhoneNumberList.cs</file>
// <date>2018-11-23</date>
// <summary>This program inherents the linklist given. 
// This list is modified to handle PhoneData data types.
// </summary> 
// <remarks>Time taken to develop, write, test and debug
// solution. About 3 hours. </remarks>

using System;
using System.Collections.Generic;
using LinkedListLibrary;

// ----------------------------------------------------------------------------
// The Name Space for DuplicatePhoneNumberFinder.
// ----------------------------------------------------------------------------
namespace DuplicatePhoneNumberFinder
{
    /// -----------------------------------------------------------------------
    /// <summary>The PhoneNumberList class this inherents the list from the
    /// LinkedListLibrary.</summary>
    /// -----------------------------------------------------------------------
    class PhoneNumberList : List
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// The default constructor. This just calls the base constructor.
        /// </summary>
        /// -------------------------------------------------------------------
        public PhoneNumberList() : base() {}

        /// -------------------------------------------------------------------
        /// <summary>
        /// An overloaded constructor that calls the base overloaded 
        /// constructor.
        /// </summary>
        /// <param name="name">The name to call the list.</param>
        /// -------------------------------------------------------------------
        public PhoneNumberList(string name) : base(name){}

        /// -------------------------------------------------------------------
        /// <summary>
        /// This inserts a PhoneData object into the link list. 
        /// </summary>
        /// <remarks>
        /// When this method is only used to insert a PhoneData objects. This 
        /// link list is become an ordered link list by phone number in ascending
        /// lexicographical order. If a phone number is already in the list then
        /// the number is not stored in the list instead the count in the 
        /// associated phone number is incremented.
        /// </remarks>
        /// <param name="phone">The PhoneData object to be inserted.</param>
        /// -------------------------------------------------------------------
        public void InsertByNumber(PhoneData phone)
        {
            // An iterator to track the current position in the link list.
            // Needed to give the iterator a value to stop a compiler error.
            ListNode current = new ListNode("");

            // An iterator to track the position before the current iterator in
            // the link list. Needed to give the iterator a value to stop a
            // compiler error.
            ListNode previous = new ListNode("");

            // The new node to insert into the list.
            ListNode newNode = new ListNode(phone);

            if (IsEmpty())
            {
                InsertAtFront(phone);
            }
            else
            {
                FindInsertPosition(ref current, ref previous, ref phone);
                InsertData(ref current, ref previous, ref newNode);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method is used by the InsertByNumber method to find the 
        /// position to insert a PhoneData object.
        /// </summary>
        /// <param name="current"> The current node to be evaluated.</param>
        /// <param name="previous">The node before the current node.</param>
        /// <param name="phone"> PhoneData object to be compared to the current
        /// node.</param>
        /// -------------------------------------------------------------------
        private void FindInsertPosition(ref ListNode current, 
                                    ref ListNode previous, ref PhoneData phone)
        {
            // A flag if the location to insert the node is found before 
            // getting to the end of the link list.
            var found = false;

            current = firstNode;
            while (current != null && !found)
            {
                // Holds information from the Data variable in a ListNode when 
                // converted to a PhoneData from comparisons.
                var currentData = current.Data as PhoneData;
                if (currentData.ToString().CompareTo(phone.ToString()) >= 0)
                {
                    found = true;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method inserts a list node in to the link list. This method is
        /// called by InsertByNumber method and assisted by the 
        /// FindInsertPosition to insert a node into the list at the correct 
        /// location.
        /// </summary>
        /// <param name="current">The current node to be evaluated.</param>
        /// <param name="previous">The node before the current node.</param>
        /// <param name="newNode">The node to be inserted</param>
        /// -------------------------------------------------------------------
        private void InsertData(ref ListNode current,
                                    ref ListNode previous, ref ListNode newNode)
        {
            // Holds information from the Data variable in a ListNode when 
            // converted to a PhoneData from comparisons. This is check 
            // also check to see if null.
            var currentData = (current != null) ? (PhoneData)current.Data : null;
            
            // Holds information from the Data variable in a ListNode when 
            // converted to a PhoneData from comparisons.
            var newNodeData = (PhoneData)newNode.Data;

            if (current != null && currentData.ToString().CompareTo(newNodeData.ToString()) == 0)
            {
                currentData.IncrementCount();
            }
            else
            {
                if (current == firstNode)
                {
                    InsertAtFront(newNodeData);
                }
                else
                {
                    previous.Next = newNode;
                    newNode.Next = current;
                    if (current == null)
                    {
                        lastNode = newNode;
                    }
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Displays the duplicate phone numbers and the number of times 
        /// duplicated number is in the list.
        /// </summary>
        /// -------------------------------------------------------------------
        public void DisplayPhoneDups()
        {
            // A list to check hold strings. If this empty at the end of the 
            // while loop then there where no duplicates where in the link list.
            List<string> phoneList = new List<String>();

            // An iterator to move through the link list.
            ListNode current = firstNode;

            // output current node data while not at end of list
            while (current != null)
            {
                // Holds information from the Data variable in a ListNode when 
                // converted to a PhoneData from comparisons.
                var phone = (PhoneData)current.Data;
                if (phone.Count > 1)
                {
                    phoneList.Add($"{phone.ToString()} {phone.Count}");
                }
                current = current.Next;
            }

            if (phoneList.Count == 0)
            {
                Console.WriteLine($"No duplicates.");
            }
            else
            {
                foreach (var item in phoneList)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
