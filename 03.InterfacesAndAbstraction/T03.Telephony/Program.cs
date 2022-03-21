using System;

namespace T03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            // This code does not take the BrowseWebsites method of the smartphone. Only its ability to call
            ICallNumbers smartphone = new Smartphone();
            ICallNumbers stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    smartphone.CallNumber(number);
                }
                else if(number.Length == 7)
                {
                    stationaryPhone.CallNumber(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            // so here I make a smartphone that can only browse websites
            string[] urls = Console.ReadLine().Split();
            IBrowse browser = new Smartphone();

            foreach (var url in urls)
            {
                browser.BrowseWebsites(url);
            }
        }
    }
}
