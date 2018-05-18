using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Task:
 *  Read from the console 3 integers representing the year, month and day of a person and a letter (M/F)
 * representing the gender of the person
 *  Convert the 3 integers and create a DateTime for the birthdate
 *  
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
        Male=0,
        Female=1
    }

    class Program
    {
        private const double daysPerYear = 365.25;
        private const int retirementAgeMale = 65;
        private const int retirementAgeFemale = 63;



        static void Main(string[] args)

        {

            int bornDay, bornMonth, bornYear;
            genders? personGender;
            

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
            bool validGender = false;
            if(checkInput.Length==1)
            {
                if(checkInput.Equals("M"))
                {
                    personGender = genders.Male;
                    validGender = true;
                }
                else if(checkInput.Equals("F"))
                {
                    personGender = genders.Female;
                    validGender = true;
                }
                else
                {
                    personGender = null;
                }
            }
            else
            {
                personGender = null;
            }


            //Getting life time span.
            DateTime personBirthdate = new DateTime(bornYear, bornMonth, bornDay);
            TimeSpan personLifeTime = DateTime.Now - personBirthdate;


            // Getting person's age.
            int personAge = (int)(personLifeTime.Days / daysPerYear);

            // Displaying time till retirement if gender is valid.
            if(validGender)
            {
                if(personGender == genders.Male)
                {
                    if(personAge>=retirementAgeMale)
                    {
                        Console.WriteLine("This male is retired.");
                    }
                    else
                    {
                        int yearTillRetirement = retirementAgeMale - personAge;
                        Console.WriteLine("{0} more years until retirement.",yearTillRetirement);
                    }
                }
                else
                {
                    if (personAge >= retirementAgeFemale)
                    {
                        Console.WriteLine("This female is retired.");
                    }
                    else
                    {
                        int yearTillRetirement = retirementAgeFemale - personAge;
                        Console.WriteLine("{0} more years until retirement.", yearTillRetirement);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid gender input.");
            }

            Console.Read();

        }
    }
}
