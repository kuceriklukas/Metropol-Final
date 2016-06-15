using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class Student
    {
        private int studentID;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        private string eMail;

        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }


        private int telNum;

        public int TelNum
        {
            get { return telNum; }
            set { telNum = value; }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "\t" + EMail;
        }






    }
}