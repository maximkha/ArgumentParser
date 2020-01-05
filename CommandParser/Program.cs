using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example
            ArgumentParser argumentParser = new ArgumentParser(ArgumentParser.ArgumentFormat.KVP, true);
            argumentParser.Help = 
                () => {
                    Console.WriteLine("You've reached the help LINE!"); //funny joke
                };

            argumentParser.AddArgument("string", ArgumentParser.ArgumentType.String, false, false);
            argumentParser.AddArgument("int", ArgumentParser.ArgumentType.Int, false, false);
            argumentParser.AddArgument("double", ArgumentParser.ArgumentType.Double, false, false);

            ArgumentParser.ParsedArguments parsed = new ArgumentParser.ParsedArguments();

            try
            {
                parsed = argumentParser.Parse(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }

            string a1 = parsed.StringArguments["string"][0];
            int a2 = parsed.IntArguments["int"][0];
            double a3 = parsed.DoubleArguments["double"][0];
            Console.WriteLine("string: {0}, int: {1}, double: {2}", a1, a2, a3);
            Console.ReadLine();
        }
    }
}
