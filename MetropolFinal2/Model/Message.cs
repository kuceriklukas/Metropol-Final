using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class Message
    {
        //private string firstName;

        //public string FirstName
        //{
        //    get { return firstName; }
        //    set { firstName = value; }
        //}

        //private string lastName;

        //public string LastName
        //{
        //    get { return lastName; }
        //    set { lastName = value; }
        //}

        private DateTimePeriod meetingDate;

        public DateTimePeriod MeetingDate
        {
            get { return meetingDate; }
            set { meetingDate = value; }
        }

        private string bookingTitle;

        public string BookingTitle
        {
            get { return bookingTitle; }
            set { bookingTitle = value; }
        }

        private string meetingDescription;

        public string MeetingDescription
        {
            get { return meetingDescription; }
            set { meetingDescription = value; }
        }

        private int meetingLength;

        public int MeetingLength
        {
            get { return meetingLength; }
            set { meetingLength = value; }
        }

        private int bookingID;

        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        private int roomID;

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        //private string messageText;

        //public string MessageText
        //{
        //    get { return messageText; }
        //    set { messageText = value; }
        //}

        public override string ToString()
        {
            return "You have been invited on meeting: " + BookingTitle + " - " + MeetingDescription;
        }


    }
}
