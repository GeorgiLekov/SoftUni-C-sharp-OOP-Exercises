using System;

namespace T01.ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                Box box = new Box();

                box.Length = double.Parse(Console.ReadLine());
                box.Width = double.Parse(Console.ReadLine());
                box.Height = double.Parse(Console.ReadLine());

                Console.WriteLine(box);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
