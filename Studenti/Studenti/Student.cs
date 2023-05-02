using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenti
{
    class Student
    {
        private string lastname;
        private string firstname;
        private string group;
        private double exam;
        private double coursework;

        public Student(string ln, string fn, string gr, double ex, double cw)
        {
            lastname = ln;
            firstname = fn;
            group = gr;
            exam = ex;
            coursework = cw;
        }
        public string Info()
        {
            string s = lastname + " " + firstname + " " + group + " " + exam + " " + coursework;
            return s;
        }
    }
}

