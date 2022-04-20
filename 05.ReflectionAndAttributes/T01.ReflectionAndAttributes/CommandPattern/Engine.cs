using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            commandInterpreter = interpreter;
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                Console.WriteLine(commandInterpreter.Read(input));
                input = Console.ReadLine();
            }
        }
    }
}
