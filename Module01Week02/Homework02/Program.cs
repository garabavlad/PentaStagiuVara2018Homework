using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("This program does some operations with strings.");
            string output = "My name is ";
            string name = "Vlad";

            // Concatenating 2 strings.
            System.Console.WriteLine("// Concatenating 2 strings.");
            System.Console.Write("Result: ");
            output = string.Concat(output, name);
            System.Console.WriteLine(output);


            // Other way to concat strings.
            System.Console.WriteLine("// Other way to concat strings.");
            System.Console.Write("Result: ");
            output += name;
            System.Console.WriteLine(output);

            // Empty string if string has elements.
            System.Console.WriteLine("// Empty string if string has elements.");
            System.Console.Write("Result: ");
            if (output.Length != 0)
                output = string.Empty;
            System.Console.WriteLine(output);

            // Reinit string.
            System.Console.WriteLine("// Reinit string.");
            System.Console.Write("Result: ");
            output = "A";
            System.Console.WriteLine(output);

            // Replacing substring "A" with name substring.
            System.Console.WriteLine("// Replacing substring \"A\" with name substring.");
            System.Console.Write("Result: ");
            output = output.Replace("A", name);
            System.Console.WriteLine(output);

            //Comparing strings.
            //Teoretically they should be the same.
            System.Console.WriteLine(
@"//Comparing strings.
//Teoretically they should be the same.");
            System.Console.Write("Result: ");
            int stringIntComparator = output.CompareTo(name);
            System.Console.WriteLine(stringIntComparator);

            // Getting index of 'V' from the string.
            System.Console.WriteLine("// Getting index of 'V' from the string.");
            System.Console.Write("Result: ");
            int stringIndex = output.LastIndexOf('V');
            System.Console.WriteLine(stringIndex);

            // Getting next character. Here should be an if, just too lazy.
            System.Console.WriteLine("// Getting next character. Here should be an if, just too lazy.");
            System.Console.Write("Result: ");
            char charFromString = output[++stringIndex];
            System.Console.WriteLine(charFromString);

            // Getting a char array of string values.
            System.Console.WriteLine("// Getting a char array of string values.");
            System.Console.Write("Result: ");
            char[] outputStringToCharArray = output.ToCharArray();
            System.Console.WriteLine(outputStringToCharArray);

        }
    }
}
