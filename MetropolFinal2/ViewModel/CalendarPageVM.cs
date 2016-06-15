using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Popups;
using System.Threading.Tasks;
using MetropolFinal2.View;
using MetropolFinal2.Model;
using MetropolFinal2.Singleton;
using MetropolFinal2.Common;

namespace MetropolFinal2.ViewModel
{
    public class CalendarPageVM
    {
        public RelayCommand NavigateToRoomCommand { get; set; }

        public RelayCommand NavigateBackCommand { get; set; }

        private DateTimeOffset selectedDate;

        public DateTimeOffset SelectedDate //A property for selected date from view DatePicker
        {
            get { return selectedDate; }
            set 
            { 
                selectedDate = value;
                             
            }
        }

        private DateTimeOffset minYear;

        public DateTimeOffset MinYear
        {
            get { return minYear; }
            set { minYear = value; }
        }

        public CalendarPageVM() //Constructor of CalendarPage
        {
            NavigateToRoomCommand = new RelayCommand(NavigateToRoom);
            NavigateBackCommand = new RelayCommand(NavigateBack);
            minYear = DateTimeOffset.Now;

        }

        private void PushToSingleton()
        {
            BookingSingleton singleton = BookingSingleton.Instance;
            string myDate = SelectedDate.ToString("dd/MM/yyyy");
            DateTimePeriod date = DateTimePeriodConverter.ToDate(myDate);
            singleton.SelectedDate = date;         
        }

        private bool CheckDate()
        {
            if (SelectedDate < DateTimeOffset.Now)
            {
                return false;
            }
            return true;      
        }

        public void NavigateToRoom() //navigate to RoomPage
        {
            if (!CheckDate())
            {
                MessageDialog msg = new MessageDialog("You cannot book a room on a past date.");
                msg.ShowAsync();
            }
            else
            {
                PushToSingleton();
                NavigationService ns = new NavigationService();
                ns.Navigate(typeof(RoomPage));
            }
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MenuPage));
        }

    }
}
