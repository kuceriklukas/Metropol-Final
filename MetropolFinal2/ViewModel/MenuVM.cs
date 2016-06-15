using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.View;
using MetropolFinal2.Model;
using MetropolFinal2.Common;
using MetropolFinal2.Singleton;

namespace MetropolFinal2.ViewModel
{
    public class MenuVM
    {
        public RelayCommand NavigateToBookingCommand { get; set; }
        public RelayCommand NavigateToCurrentBookingsCommand { get; set; }
        public RelayCommand NavigateToMessagesCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }
        

        public MenuVM()
        {
            NavigateToBookingCommand = new RelayCommand(NavigateToBooking);
            NavigateToCurrentBookingsCommand = new RelayCommand(NavigateToCurrentBookings);
            NavigateToMessagesCommand = new RelayCommand(NavigateToMessages);
            LogOutCommand = new RelayCommand(LogOut);

            
        }

        public void NavigateToBooking()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof (CalendarPage));

        }

        public void NavigateToCurrentBookings()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(CurrentBookingsPage)); 
        }

        public void NavigateToMessages()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MessagesPage));

        }

        public void LogOut()
        {
            LoggedInSingleton logsingeton = LoggedInSingleton.Instance;
            logsingeton.LoggedStudentID = 0;
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(LoginPage));
        }

        

        

        
    }
}
