using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Task:
 *  Read from the console 3 integers representing the year, month and day of a person and a letter (M/F)
 * representing the gender of the person
 *  Convert the 3 integers and create a DateTime for the birthdate
 *  Compute the age of the person, based on the birthdate
 *  Create an enum for the genders (Female, Male)
 *  Using the input for gender, set the value of a nullable variable to one of the enum values or to null
 * (if the user wrote an invalid character, other than M or F)
 *  If there’s a valid Gender, then display a message if the person is retired or at what age he/she will
 * retire (Female at 63, Male at 65).
 */
namespace Homework01
{
    public enum genders
    {
        Error = -1,
        M=0,
        F=1
    }

    class Program
    {
        static void Main(string[] args)
        {
            int bornDay, bornMonth, bornYear;
            genders personGender;
            
            Console.WriteLine("Upload data of the person:");
            Console.WriteLine("Enter the year he/she was born:");
            bornYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the month he/she was born:");
            bornMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the day he/she was born:");
            bornDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter his/her gender:");
            string checkInput = Console.ReadLine();

            // Checking input for gender.
            if(checkInput.Length==1)
            {
                if(checkInput.Equals("M"))
                {
                    personGender = genders.M;
                }
                else if(checkInput.Equals("F"))
                {
                    personGender = genders.F;
                }
                else
                {
                    personGender = genders.Error;
                }
            }
            else
            {
                personGender = genders.Error;
            }

            DateTime personBirthdate = new DateTime(bornYear, bornMonth, bornDay);
            TimeSpan personActualAge = DateTime.Now - personBirthdate;
            DateTime personActualAge1 = DateTime.Now + personActualAge;
            Console.WriteLine(personActualAge1);
            //DateTime.

            Console.Read();

        }
    }
}
