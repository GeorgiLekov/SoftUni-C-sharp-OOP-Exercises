using System;
using System.Text;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The RaceName race has:");
            result.AppendLine($"Participants: Pilots.Count");
            result.AppendLine($"Participants: Pilots.Count");
            result.AppendLine($"Number of laps: NumberOfLaps");
            result.AppendLine($"Number of laps: NumberOfLaps");

            string temp = "Yes";

            result.AppendLine($"Took place: {temp}");

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
