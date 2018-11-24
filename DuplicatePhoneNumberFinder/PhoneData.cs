

namespace DuplicatePhoneNumberFinder
{
    class PhoneData
    {
        private string phoneNumber;
        private int count = 1;

        public PhoneData(string number)
        {
            phoneNumber = number;
        }

        public int Count { get => count; }

        public void IncrementCount()
        {
            count++;
        }

        public override string ToString()
        {
            return phoneNumber;
        }

    }
}
