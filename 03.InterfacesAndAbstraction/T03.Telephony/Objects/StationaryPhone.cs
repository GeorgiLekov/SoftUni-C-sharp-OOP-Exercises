using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T03.Telephony
{
    public class StationaryPhone : ICallNumbers
    {
        public void CallNumber(string number)
        {
            if (number.Any(number => char.IsLetter(number)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
