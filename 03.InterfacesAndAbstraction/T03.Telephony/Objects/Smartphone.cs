using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T03.Telephony
{
    public class Smartphone : ICallNumbers, IBrowse
    {
        public void BrowseWebsites(string url)
        {
            if (url.Any(letter => char.IsDigit(letter)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        public void CallNumber(string number)
        {
            if(number.Any(number => char.IsLetter(number)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
