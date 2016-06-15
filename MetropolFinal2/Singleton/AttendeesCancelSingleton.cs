using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;

namespace MetropolFinal2.Singleton
{
    public class AttendeesCancelSingleton
    {
        private static AttendeesCancelSingleton instance;

        private Booking selectedBooking;

        private List<Student> studentsOnBooking;

        private List<Student> studentsOnBookingGoing;

        public List<Student> StudentsOnBookingGoing
        {
            get { return studentsOnBookingGoing; }
            set { studentsOnBookingGoing = value; }
        }

        public List<Student> StudentsOnBooking
        {
            get { return studentsOnBooking; }
            set { studentsOnBooking = value; }
        }

        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set { selectedBooking = value; }
        }

        private AttendeesCancelSingleton()
        {

        }

        public static AttendeesCancelSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AttendeesCancelSingleton();
                }
                return instance;
            }
        }
    }
}
