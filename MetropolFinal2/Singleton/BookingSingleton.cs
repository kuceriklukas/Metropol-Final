using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;

namespace MetropolFinal2.Singleton
{
    public class BookingSingleton
    {
        private static BookingSingleton instance; //backing field for the instance property

        private DateTimePeriod selectedDate;

        private Room selectedRoom;

        private int startTimeHour;

        private int startTimeMinute;

        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int StartTimeHour
        {
            get { return startTimeHour; }
            set { startTimeHour = value; }
        }

        public int StartTimeMinute
        {
            get { return startTimeMinute; }
            set { startTimeMinute = value; }
        }

        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set { selectedRoom = value; }
        }

        public DateTimePeriod SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; }
        }

        private BookingSingleton()
        {

        }

        public static BookingSingleton Instance //Instance property with all the magic
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingSingleton();
                }
                return instance;
            }
        }
    }
}
