using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class DateTimePeriod
    {
        private int _day;
        private int _month;
        private int _year;
        private int _hour;
        private int _minute;

        public int Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }

        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Day
        {
            get { return _day; }
            set 
            { 
                _day = value; 
            }
        }

        public override string ToString()
        {
            if (Minute < 10)
            {
                return Day + "/" + Month + "/" + Year + " " + Hour + ":0" + Minute;
            }
            else if (Hour < 10)
            {
                return Day + "/" + Month + "/" + Year + " 0" + Hour + ":" + Minute;
            }
            else if ((Minute < 10) && (Hour < 10))
            {
                return Day + "/" + Month + "/" + Year + " 0" + Hour + ":0" + Minute;
            }
            return Day + "/" + Month + "/" + Year + " " + Hour + ":" + Minute;
        }
    }
}
