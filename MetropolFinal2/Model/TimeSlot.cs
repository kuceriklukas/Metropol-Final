using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Model
{
    public class TimeSlot
    {
        private DateTimePeriod startDate;

        public DateTimePeriod StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

    }
}
