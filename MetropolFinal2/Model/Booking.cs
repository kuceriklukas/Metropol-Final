using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class Booking
    {
        private int bookingID;

        public int BookingID 
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        private int studentID;

        public int StudentID
        { 
            get { return studentID; }
            set { studentID = value; }
        }

        private int roomID;

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        private string bookingTitle;

        public string BookingTitle
        {
            get { return bookingTitle; }
            set { bookingTitle = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public override string ToString()
        {
            return BookingID + " " + BookingTitle + "\n" + StartTime + "\nRoom " + RoomID;
        }


    }
}