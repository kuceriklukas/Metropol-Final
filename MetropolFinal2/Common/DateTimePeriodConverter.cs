using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;

namespace MetropolFinal2.Common
{
    public static class DateTimePeriodConverter
    {
        public static DateTimePeriod ToDate(string date) //converts string to DateTimePeriod
        {
            char[] delimiterChars = { '/', ' ', ':' };
            string[] split = date.Split(delimiterChars);

            DateTimePeriod myDate = new DateTimePeriod();

            if (split.Length == 3)
            {
                myDate.Day = Convert.ToInt16(split[0]);
                myDate.Month = MakeMonth(split[1]);
                myDate.Year = Convert.ToInt16(split[2]);
                return myDate;
            }
            myDate.Day = Convert.ToInt16(split[0]);
            myDate.Month = MakeMonth(split[1]);
            myDate.Year = Convert.ToInt16(split[2]);
            myDate.Hour = Convert.ToInt16(split[3]);
            myDate.Minute = Convert.ToInt16(split[4]);
            return myDate;
        }

        public static string ToString(DateTimePeriod date)
        {
            return date.Day + "/" + date.Month + "/" + date.Year + " " + date.Hour + ":" + date.Minute;
        }

        public static DateTimePeriod AppendToDate(DateTimePeriod date, int startHour, int startMinute)
        {
            date.Hour = startHour;
            date.Minute = startMinute;
            return date;
        }

        public static int MakeMonth(string month)
        {
            if ((month.Contains("01")) || (month.Contains("02")) || (month.Contains("03")) || (month.Contains("04")) ||
                (month.Contains("05")) || (month.Contains("06")) || (month.Contains("07")) || (month.Contains("08")) ||
                (month.Contains("09")))
            {
                switch (month)
                {
                    case "01":
                        return 1;
                    case "02":
                        return 2;
                    case "03":
                        return 3;
                    case "04":
                        return 4;
                    case "05":
                        return 5;
                    case "06":
                        return 6;
                    case "07":
                        return 7;
                    case "08":
                        return 8;
                    case "09":
                        return 9;
                }
            }
            else
            {
                return Convert.ToInt32(month);
            }

            return 0;
        }
    }
}
