using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        public class Student
        {
            public string studentName { get; set; }
            public string registerationNumber { get; set; }
            public DateTime dateOfBirth { get; set; }
            public Double CGPA { get; set; }
            public string CNIC { get; set; }
            public string[] hobbies { get; set; }

            //Constructor with no parameter
            public Student()
            {

            }

            //Constructor with parameters
            public Student(string studentName, string registerationNumber)
            {
                this.studentName = studentName;
                this.registerationNumber = registerationNumber;
            }

            //Input function
            public void input()
            {
                Console.WriteLine("\n\n***************************** Enter details for the student *****************************\n");

                // validating student name in this validation i have used regular expressions
                Console.WriteLine("Enter Student Name (only alphabets and space is allowed): ");
                this.studentName = Console.ReadLine();

                while (!Regex.IsMatch(this.studentName, @"^[a-zA-Z || ]+$") || this.studentName == "" || this.studentName == " ")
                {
                    Console.WriteLine("Enter Student Name (only alphabets and space is allowed): ");
                    this.studentName = Console.ReadLine();
                }

                //validating student registration number in this validation i have used regular expressions
                Console.WriteLine("\nEnter Register Number eg. 2018-CS-123: ");
                this.registerationNumber = Console.ReadLine();

                string[] wrods = this.registerationNumber.Split('-'); //words to check numbers before and after -CS-

                while ((!(Regex.IsMatch(wrods[0], @"^[0-9]+$") && Regex.IsMatch(wrods[2], @"^[0-9]+$"))) || ((this.registerationNumber.IndexOf("-CS-") <= 0) || (this.registerationNumber.IndexOf("-CS-") == this.registerationNumber.Length - 4)) || this.registerationNumber == "" || this.registerationNumber == " ")
                {
                    Console.WriteLine("Enter Register Number eg. 2018-CS-123: ");
                    this.registerationNumber = Console.ReadLine();

                    wrods = this.registerationNumber.Split('-');
                }


                

                Console.WriteLine("\nEnter Date of Birth eg. dd/mm/yyyy: ");
                this.dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("\nEnter CGPA");
                this.CGPA = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nEnter CNIC number: ");
                this.CNIC = Console.ReadLine();

                //reading hobbies in array by using loop
                Console.WriteLine("\nEnter Number of Hobbies");
                int values = Int32.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter hobies");
                this.hobbies = new string[values];  //dyamic array of hoobies
                for (int i = 0; i < values; i++)
                {
                    Console.Write("Hoby #" + (i + 1) + ": ");
                    this.hobbies[i] = Console.ReadLine();
                }
            }

            // get age function
            public string getAge()
            {
                DateTime dateOfBirth = this.dateOfBirth;  //date of birth

                if (dateOfBirth != new DateTime())
                {
                    DateTime currentDateTime = DateTime.Now;
                    TimeSpan span = currentDateTime.Subtract(dateOfBirth);  //subtracting dates to get age

                    //getting age from TimeSpan
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    int years = (zeroTime + span).Year - 1;
                    int month = (zeroTime + span).Month - 1;
                    int days = (zeroTime + span).Day - 1;

                    //formating date according to requirements
                    string strMonth = dateOfBirth.ToString("MMMM");
                    int intDays = dateOfBirth.Day;
                    int intYear = dateOfBirth.Year;
                    string DOBAge = strMonth + " " + intDays + ", " + intYear + " " +
                        "(Age is " + years + " years " + month + " months and " + days + " days)";

                    return DOBAge;  //returning date
                }
                else
                {
                    return "Please Enter DOB to Know Age";
                }

            }

            //get status of student
            public string getStatus()
            {
                Double CGPA = this.CGPA;

                if (CGPA < 2.0)
                {
                    return CGPA + " Suspended";
                } else if (CGPA >= 2.0 && CGPA <= 2.5)
                {
                    return CGPA + " Below Average";
                } else if (CGPA >= 2.5 && CGPA <= 3.3)
                {
                    return CGPA + " Average";
                }
                else if (CGPA >= 3.3 && CGPA <= 3.5)
                {
                    return CGPA + " Below Good";
                }
                else
                {
                    return CGPA + " Excellent";
                }
            }

            public string numberOfWordsInName()
            {
                string studentName = this.studentName;

                int index = 0;
                int words = 1;

                //While loop to iterate over student name
                while (index <= studentName.Length - 1)
                {
                    //conditions to check next word.
                    if (studentName[index] == ' ' || studentName[index] == '\n' || studentName[index] == '\t')
                    {
                        words++;
                    }

                    index++;
                }

                return studentName + " (Contain " + words + " words)";
            }
            //get gender funtion
            public string getGender()
            {
                string CNIC = this.CNIC;

                if (CNIC != null)
                {
                    int lastNumber = CNIC[CNIC.Length - 1];  //last number of CNIC

                    if ((lastNumber & 1) == 1)  //if number is odd
                        return "Male";
                    else
                        return "FeMale";
                }
                else
                {
                    return "Enter CNIC";
                }

            }

            public void toString(Student st)
            {
                Console.WriteLine("\n\n***************************** Output of ToString Method *****************************\n");

                Console.WriteLine("\nName " + st.numberOfWordsInName());
                Console.WriteLine("Registration Number: " + st.registerationNumber);
                Console.WriteLine("CGPA: " + st.getStatus());
                Console.WriteLine("Date of Birth: " + st.getAge());
                Console.WriteLine("CNIC: " + st.CNIC);
                Console.WriteLine("Gender: " + st.getGender());
                Console.Write("Hobbies: ");

                if (st.hobbies != null)
                {
                    for (int i = 0; i < st.hobbies.Length; i++)
                    {
                        if (i < st.hobbies.Length - 1)
                        {
                            Console.Write(st.hobbies[i] + ", ");
                        }
                        else
                        {
                            Console.Write(st.hobbies[i]);
                        }

                    }
                }
            }

            public void printMembers(Student st)
            {
                Console.WriteLine("\n\n***************************** Current data members *****************************\n");

                Console.WriteLine("Student Name: " + st.studentName);
                Console.WriteLine("Registratiorn Number: " + st.registerationNumber);

                DateTime dateOfBirth = st.dateOfBirth;  //date of birth
                if (dateOfBirth != new DateTime())
                {
                    Console.WriteLine("DOB: " + st.dateOfBirth);
                }
                else
                {
                    Console.WriteLine("DOB: ");
                }

                Console.WriteLine("CGPA: " + st.CGPA);
                Console.WriteLine("CNIC: " + st.CNIC);

                if (st.hobbies != null)
                {
                    Console.Write("Hobbies: ");
                    for (int i = 0; i < st.hobbies.Length; i++)
                    {
                        if (i < st.hobbies.Length - 1)
                        {
                            Console.Write(st.hobbies[i] + ", ");
                        }
                        else
                        {
                            Console.Write(st.hobbies[i]);
                        }
                    }
                }

            }

            //distructure
            ~Student()
            {
                Console.WriteLine("\n\ndestructor called");
            }
        }

        static void Main(string[] args)
        {
            //Student st = new Student(); //object of student with paratmeterless constructor
            //Student stPar = new Student("Hafiz", "2018-CS-000"); //object of student with paratmeterize constructor

            //st.input();
            //st.printMembers(st);
            //st.toString(st);

            //Console.WriteLine("--------------------------------------------------------------------------------------------");
            //stPar.printMembers(stPar);
            //stPar.toString(stPar);

            //Console.WriteLine("Enter Register Number eg. 2018-CS-123: ");
            //string registerationNumber = Console.ReadLine();

            
        }
    }
}
