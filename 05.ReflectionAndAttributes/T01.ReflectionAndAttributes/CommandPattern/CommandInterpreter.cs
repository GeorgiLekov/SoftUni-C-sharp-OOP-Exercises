using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split().ToArray();
            string command = input[0];
            string[] value = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == command + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("MissingCommand");
            }
            else if (type.GetInterface("ICommand") == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            var commandInstance = Activator.CreateInstance(type) as ICommand;

            string result = commandInstance.Execute(value);

            return result;
        }
    }
}
