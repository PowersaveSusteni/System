using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class Student
    {
        public Student(int StudentID, string StudentFirstName,
           string StudentLastName, string StudentClass,
           int RollNumber)
        {
            this.StudentID = StudentID;
            this.StudentFirstName = StudentFirstName;
            this.StudentLastName = StudentLastName;
            this.StudentClass = StudentClass;
            this.RollNumber = RollNumber;

        }

        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentClass { get; set; }
        public int RollNumber { get; set; }

    }

}
