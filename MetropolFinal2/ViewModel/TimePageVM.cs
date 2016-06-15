using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using System.Threading.Tasks;
using MetropolFinal2.DAL;
using MetropolFinal2.Common;
using MetropolFinal2.View;
using MetropolFinal2.Model;
using MetropolFinal2.Singleton;

namespace MetropolFinal2.ViewModel
{
    public class TimePageVM: INotifyPropertyChanged
    {
        public RelayCommand NavigateToCurrentBookingsCommand { get; set; }
        public RelayCommand NavigateBackCommand { get; set; }

        private bool checkBox1;
        private bool checkBox2;
        private bool checkBox3;
        private bool checkBox4;
        private bool checkBox5;
        private bool checkBox6;
        private bool checkBox7;
        private bool checkBox8;
        private bool checkBox9;
        private bool checkBox10;
        private bool checkBox11;
        private bool checkBox12;

        private bool textBox1;
        private bool textBox2;
        private bool textBox3;
        private bool textBox4;
        private bool textBox5;
        private bool textBox6;
        private bool textBox7;
        private bool textBox8;
        private bool textBox9;
        private bool textBox10;
        private bool textBox11;
        private bool textBox12;

        private List<bool> listofTextBoxes;

        public List<bool> ListofTextBoxes
        {
            get { return listofTextBoxes; }
            set { listofTextBoxes = value; }
        }


        private IEnumerable<Booking> timePeriods;

        private int minute;
        private int hour;
        private int startTime;
        public List<int> Integers { get; set; }
        public IEnumerable<Booking> TimePeriods
        {
            get { return timePeriods; }
            set 
            { 
                timePeriods = value;
                OnPropertyChanged("TimePeriods");
            }
        }
        public int StartTime
        {
            get { return startTime; }
            set 
            { 
                startTime = value;
              
            }
        }

        private int endTime;
        public int EndTime
        {
            get { return endTime; }
            set 
            { 
                endTime = value;
             
            }
        }

        private int meetingLenght;
        public int MeetingLenght
        {
            get { return meetingLenght; }
            set 
            { 
                meetingLenght = value;
               
            }
        }

        bool[] CheckBoxes;
        bool[] TextBoxesArray;

        public string TextBox1
        {
            get 
            {
                if (textBox1 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox1");
            }
        }

        public string TextBox2
        {
            get
            {
                if (textBox2 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox2");
            }
        }

        public string TextBox3
        {
            get
            {
                if (textBox3 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox3");
            }
        }

        public string TextBox4
        {
            get
            {
                if (textBox4 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox4");
            }
        }

        public string TextBox5
        {
            get
            {
                if (textBox5 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox5");
            }
        }

        public string TextBox6
        {
            get
            {
                if (textBox6 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox6");
            }
        }

        public string TextBox7
        {
            get
            {
                if (textBox7 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox7");
            }
        }

        public string TextBox8
        {
            get
            {
                if (textBox8 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox8");
            }
        }

        public string TextBox9
        {
            get
            {
                if (textBox9 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox9");
            }
        }

        public string TextBox10
        {
            get
            {
                if (textBox10 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox10");
            }
        }

        public string TextBox11
        {
            get
            {
                if (textBox11 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox11");
            }
        }

        public string TextBox12
        {
            get
            {
                if (textBox12 == true)
                {
                    return "Already booked";
                }
                return "Free";
            }
            set
            {
                OnPropertyChanged("TextBox12");
            }
        }

        public bool CheckBox1
        {
            get { return checkBox1; }
            set 
            { 
                checkBox1 = value;
                OnPropertyChanged("CheckBox1");
            }
        }
        public bool CheckBox2
        {
            get { return checkBox2; }
            set
            {
                checkBox2 = value;
                OnPropertyChanged("CheckBox2");
            }
        }
        public bool CheckBox3
        {
            get { return checkBox3; }
            set
            {
                checkBox3 = value;
                OnPropertyChanged("CheckBox3");
            }
        }
        public bool CheckBox4
        {
            get { return checkBox4; }
            set
            {
                checkBox4 = value;
                OnPropertyChanged("CheckBox4");
            }
        }
        public bool CheckBox5
        {
            get { return checkBox5; }
            set
            {
                checkBox5 = value;
                OnPropertyChanged("CheckBox5");
            }
        }
        public bool CheckBox6
        {
            get { return checkBox6; }
            set
            {
                checkBox6 = value;
                OnPropertyChanged("CheckBox6");
            }
        }
        public bool CheckBox7
        {
            get { return checkBox7; }
            set
            {
                checkBox7 = value;
                OnPropertyChanged("CheckBox7");
            }
        }
        public bool CheckBox8
        {
            get { return checkBox8; }
            set
            {
                checkBox8 = value;
                OnPropertyChanged("CheckBox8");
            }
        }
        public bool CheckBox9
        {
            get { return checkBox9; }
            set
            {
                checkBox9 = value;
                OnPropertyChanged("CheckBox9");
            }
        }
        public bool CheckBox10
        {
            get { return checkBox10; }
            set
            {
                checkBox10 = value;
                OnPropertyChanged("CheckBox10");
            }
        }
        public bool CheckBox11
        {
            get { return checkBox11; }
            set
            {
                checkBox11 = value;
                OnPropertyChanged("CheckBox11");
            }
        }
        public bool CheckBox12
        {
            get { return checkBox12; }
            set
            {
                checkBox12 = value;
                OnPropertyChanged("CheckBox12");
            }
        }
                

        public TimePageVM() //constructor
        {
            NavigateToCurrentBookingsCommand = new RelayCommand(NavigateToCurrentBookings);
            NavigateBackCommand = new RelayCommand(NavigateBack);
            Integers = new List<int>() { StartTime, EndTime, MeetingLenght };
            TimePeriods = new List<Booking>();
            GetTimePeriods();
        }

        private bool CheckIfDoubleBooking()
        {
            for (int i = 0; i < CheckBoxes.Length; i++)
            {
                for (int j = 0; j < ListofTextBoxes.Capacity; j++)
                {
                    if (i == j)
                    {
                        if ((CheckBoxes[i] == true) && (ListofTextBoxes[j] == true))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void GetTimePeriods() //Go to persistance and get the time periods for this room on this date - if it's already booked or not
        {
            BookingSingleton sing = BookingSingleton.Instance;
            int roomID = sing.SelectedRoom.RommID;
            DateTimePeriod date = sing.SelectedDate;
            TimePeriods = Persistance.GetBookingsOnRoom(roomID);
            int usedLabel = 0;

            foreach (Booking timePeriod in TimePeriods)
            {
                if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Day == date.Day) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Month == date.Month) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Year == date.Year))
                {
                    
                        if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 8) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 20))
                        {
                            usedLabel = 0;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 9) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 10))
                        {
                            usedLabel = 1;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 10) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 5))
                        {
                            usedLabel = 2;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 10) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 55))
                        {
                            usedLabel = 3;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 12) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 15))
                        {
                            usedLabel = 4;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 13) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 5))
                        {
                            usedLabel = 5;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 14) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 0))
                        {
                            usedLabel = 6;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 14) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 50))
                        {
                            usedLabel = 7;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 15) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 50))
                        {
                            usedLabel = 8;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 16) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 50))
                        {
                            usedLabel = 9;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 17) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 50))
                        {
                            usedLabel = 10;
                        }
                        else if ((DateTimePeriodConverter.ToDate(timePeriod.StartTime).Hour == 18) && (DateTimePeriodConverter.ToDate(timePeriod.StartTime).Minute == 50))
                        {
                            usedLabel = 11;
                        }
                        else
                        {
                            MessageDialog msg = new MessageDialog("There was some error. Go back and select another room.");
                            msg.ShowAsync();
                        }

                        FillList();

                        int length = timePeriod.Length;

                        for (int i = usedLabel; i <= (usedLabel + length) - 1; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    textBox1 = true;
                                    break;
                                case 1:
                                    textBox2 = true;
                                    break;
                                case 2:
                                    textBox3 = true;
                                    break;
                                case 3:
                                    textBox4 = true;
                                    break;
                                case 4:
                                    textBox5 = true;
                                    break;
                                case 5:
                                    textBox6 = true;
                                    break;
                                case 6:
                                    textBox7 = true;
                                    break;
                                case 7:
                                    textBox8 = true;
                                    break;
                                case 8:
                                    textBox9 = true;
                                    break;
                                case 9:
                                    textBox10 = true;
                                    break;
                                case 10:
                                    textBox11 = true;
                                    break;
                                case 11:
                                    textBox12 = true;
                                    break;
                            }
                        }
                    
                }
            }
            


            
        }

        private void FillList()
        {
            ListofTextBoxes = new List<bool>();
            ListofTextBoxes.Add(textBox1);
            ListofTextBoxes.Add(textBox2);
            ListofTextBoxes.Add(textBox3);
            ListofTextBoxes.Add(textBox4);
            ListofTextBoxes.Add(textBox5);
            ListofTextBoxes.Add(textBox6);
            ListofTextBoxes.Add(textBox7);
            ListofTextBoxes.Add(textBox8);
            ListofTextBoxes.Add(textBox9);
            ListofTextBoxes.Add(textBox10);
            ListofTextBoxes.Add(textBox11);
            ListofTextBoxes.Add(textBox12);
        }

        private void Calculator() //assigns values to variables according to checked checkboxes
        {
            CheckBoxes = new bool[12] { CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5, CheckBox6, CheckBox7,
                                        CheckBox8, CheckBox9, CheckBox10, CheckBox11, CheckBox12};
            for (int i = 0; i < CheckBoxes.Length; i++)   
            {
                if (CheckBoxes[i] == true)
                {
                    StartTime = i + 8; // because 8 am is the first time slot
                    break;
                }
            }

            for (int i = 0; i < CheckBoxes.Length; i++)
            {
                if (CheckBoxes[i] == true)
                {
                    EndTime = i + 9; // because duration of meeting is one hour
                }
            }

            MeetingLenght = EndTime - StartTime;
            hour = AssignHourValues(StartTime);
            minute = AssignMinuteValues(StartTime);
        }

        public int AssignHourValues(int startTime)
        {
            switch (startTime) // gives real time slot values 
            {
                case 8:
                    return 8;
                    //minute = 20;
                case 9:
                    return 9;
                    //minute = 10;
                case 10:
                    return 10;
                    //minute = 5;
                case 11:
                    return 10;
                    //minute = 55;
                case 12:
                    return 12;
                    //minute = 15;
                case 13:
                    return 13;
                    //minute = 5;
                case 14:
                    return 14;
                    //minute = 0;
                case 15:
                    return 14;
                    //minute = 50;
                case 16:
                    return 15;
                    //minute = 50;
                case 17:
                    return 16;
                    //minute = 50;
                case 18:
                    return 17;
                    //minute = 50;
                case 19:
                    return 18;
                    //minute = 50;
            }
            return 0;
        }

        public int AssignMinuteValues(int startTime)
        {
            switch (startTime) // gives real time slot values 
            {
                case 8:
                    return 20;
                case 9:
                    return 10;
                case 10:
                    return 5;
                case 11:
                    return 55;
                case 12:
                    return 15;
                case 13:
                    return 5;
                case 14:
                    return 0;
                case 15:
                    return 50;
                case 16:
                    return 50;
                case 17:
                    return 50;
                case 18:
                    return 50;
                case 19:
                    return 50;
            }
            return 0;
        }

        private bool CheckIfEmpty()
        {
            if ((hour == 0) && (minute == 0))
            {
                return true;
            }
            return false;
        }
  
        public void NavigateToCurrentBookings() //Navigate to current bookings page with a new ViewModel
        {
            Calculator();
            if (CheckIfEmpty())
            {
                MessageDialog msg = new MessageDialog("You must select some time periods for your meeting.");
                msg.ShowAsync();
            }
            else
            {
                FillList();
                if (CheckIfDoubleBooking())
                {
                    MessageDialog msg = new MessageDialog("You cannot book a room on an already booked period.");
                    msg.ShowAsync();
                }
                else
                {
                    SendData();
                    NavigationService ns = new NavigationService();
                    ns.Navigate(typeof(MakeBookingDescriptionPage));
                }      
            }        
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(RoomPage));
        }

        private void SendData()
        {
            BookingSingleton singleton = BookingSingleton.Instance;
            singleton.StartTimeHour = hour;
            singleton.StartTimeMinute = minute;
            singleton.Length = MeetingLenght;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}