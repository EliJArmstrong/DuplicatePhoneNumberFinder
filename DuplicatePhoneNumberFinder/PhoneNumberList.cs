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
using System.Collections.Generic;
using LinkedListLibrary;

namespace DuplicatePhoneNumberFinder
{
    class PhoneNumberList: List
    {
        public PhoneNumberList() : base() {}
        public PhoneNumberList(string name) : base(name){}

        public void InsertByNumber(PhoneData phone)
        {
            ListNode current;
            ListNode previous = firstNode;
            ListNode newNode = new ListNode(phone);
            PhoneData currentData;
            var found = false;

            if (IsEmpty())
            {
                InsertAtFront(phone);
            }
            else
            {
                current = firstNode;
                while(current != null && !found)
                {
                    currentData = (PhoneData)current.Data;
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

                currentData = (current != null)? (PhoneData)current.Data : null;

                if (current != null && currentData.ToString().CompareTo(phone.ToString()) == 0)
                {
                    currentData.IncrementCount();
                }
                else
                {
                    if (current == firstNode)
                    {
                        InsertAtFront(phone);
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
        }


        public void PhoneDisplayDupsWithExtra()
        {
            List<string> phoneList = new List<String>();
            ListNode current = firstNode;

            // output current node data while not at end of list
            while (current != null)
            {
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
