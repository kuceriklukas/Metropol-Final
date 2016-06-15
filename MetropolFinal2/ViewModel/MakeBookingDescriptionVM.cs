using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MetropolFinal2.Model;
using MetropolFinal2.Common;
using MetropolFinal2.Singleton;
using MetropolFinal2.View;
using MetropolFinal2.DAL;

namespace MetropolFinal2.ViewModel
{
    public class MakeBookingDescriptionVM
    {
        public RelayCommand NavigateToCurrentBookingsCommand { get; set; }
        public RelayCommand NavigateBackCommand { get; set; }

        private string meetingName;

        private string meetingDescription;

        public string MeetingDescription
        {
            get { return meetingDescription; }
            set { meetingDescription = value; }
        }

        public string MeetingName
        {
            get { return meetingName; }
            set { meetingName = value; }
        }

        public MakeBookingDescriptionVM()
        {
            NavigateToCurrentBookingsCommand = new RelayCommand(NavigateToCurrentBookings);
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        private bool CheckIfNull(string meetingString)
        {
            if (String.IsNullOrEmpty(meetingString))
            {
                return true;
            }
            return false;
        }

        public void NavigateToCurrentBookings()
        {
            if (CheckIfNull(MeetingName))
            {
                MessageDialog msg = new MessageDialog("You need to enter a name of your meeting!");
                msg.ShowAsync();
            }
            else
            {
                SendData();
                NavigationService ns = new NavigationService();
                ns.Navigate(typeof(CurrentBookingsPage));
            }      
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(TimePage));
        }

        private void SendData()
        {
            BookingSingleton singleton = BookingSingleton.Instance;
            LoggedInSingleton singletonLoggedIn = LoggedInSingleton.Instance;
            DateTimePeriod date = singleton.SelectedDate;
            int starttimeH = singleton.StartTimeHour;
            int starttimeM = singleton.StartTimeMinute;
            date = DateTimePeriodConverter.AppendToDate(date, starttimeH, starttimeM);
            string mydate = DateTimePeriodConverter.ToString(date);
            Room room = singleton.SelectedRoom;
            int length = singleton.Length;
            
            int loggedstudentID = singletonLoggedIn.LoggedStudentID;

            Persistance.AddNewBooking(loggedstudentID, mydate, length, room.RommID, MeetingName, MeetingDescription);
        }
    }
}
