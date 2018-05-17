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
            string output = "My name is ";
            string name = "Vlad";

            // Concatenating 2 strings.
            output = string.Concat(output, name);

            // Other way to concat strings.
            output += name;

            // Empty string if string has elements.
            if (output.Length != 0)
                output = string.Empty;

            // Reinit string.
            output = "A";

            // Replacing substring "A" with name substring.
            output = output.Replace("A", name);

            //Comparing strings.
            //Teoretically they should be the same.
            int stringIntComparator = output.CompareTo(name);

            // Getting index of 'V' from the string.
            int stringIndex = output.LastIndexOf('V');
            stringIndex++;

            // Getting next character. Here should be an if, just too lazy.
            char charFromString = output[stringIndex];

            // Getting a char array of string values.
            char[] outputStringToCharArray = output.ToCharArray();

        }
    }
}
