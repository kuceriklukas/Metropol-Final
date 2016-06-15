using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class Attendee
    {
        private int bookingID;

        private int studentID;

        private int attendeeID;

        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }


        private int going;

        public int Going
        {
            get { return going; }
            set { going = value; }
        }

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

    }
}
