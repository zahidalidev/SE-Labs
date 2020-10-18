using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Lab2.Program;

namespace Lab2
{
    class test
    {
        static void Main(string[] args)
        {
            Student st = new Student(); //object of student with paratmeterless constructor
            Student stPar = new Student("Zahid Ali", "2018-CS-136"); //object of student with paratmeterize constructor

            st.display(st);
            stPar.display(stPar);

            st.input();
            st.toString(st);

        }
    }
}
