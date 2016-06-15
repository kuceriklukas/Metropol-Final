using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.View;
using MetropolFinal2.Common;
using MetropolFinal2.DAL;
using MetropolFinal2.Model;
using MetropolFinal2.Singleton;

namespace MetropolFinal2.ViewModel
{
    public class CurrentBookingsVM: INotifyPropertyChanged
    {
        private Booking selectedBooking;

        public RelayCommand BookingDescriptionToCancelCommand { get; set; }
        public RelayCommand InvitePeopleCommand { get; set; }
        public RelayCommand NavigateBackCommand { get; set; }
        
        public IEnumerable<Booking> Bookings { get; set; } //Made it IEnumerable 'cause List<> doesn't support querries (in Persistance)

        private IEnumerable<Student> studentsOnBooking;

        private IEnumerable<Student> studentsOnBookingGoing;

        private List<Student> studentsOnBookingList;

        private List<Student> studentsOnBookingListGoing;

        public List<Student> StudentsOnBookingListGoing
        {
            get { return studentsOnBookingListGoing; }
            set { studentsOnBookingListGoing = value; }
        }

        public IEnumerable<Student> StudentsOnBookingGoing
        {
            get { return studentsOnBookingGoing; }
            set { studentsOnBookingGoing = value; }
        }

        public List<Student> StudentsOnBookingList
        {
            get { return studentsOnBookingList; }
            set { studentsOnBookingList = value; }
        }

        public IEnumerable<Student> StudentsOnBooking
        {
            get { return studentsOnBooking; }
            set { studentsOnBooking = value; }
        }

        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set 
            { 
                selectedBooking = value;
                OnPropertyChanged("SelectedBooking");

                GetStudentsOnBooking();
                GetAttendeesOnBookingGoing();
                TransformToList(); 
                PushToSingleton();
            }
        }

        public CurrentBookingsVM()  //constructor
        {
            //SelectedRoom = null;
            Bookings = new List<Booking>();
            StudentsOnBooking = new List<Student>();
            StudentsOnBookingList = new List<Student>();
            StudentsOnBookingGoing = new List<Student>();
            StudentsOnBookingListGoing = new List<Student>();
            BookingDescriptionToCancelCommand = new RelayCommand(NavigateToDescriptionToCancel);
            InvitePeopleCommand = new RelayCommand(NavigateToInvitePeople);
            NavigateBackCommand = new RelayCommand(NavigateBack);

            GetBookings();
        }

        private void PushToSingleton()
        {
            AttendeesCancelSingleton singleton = AttendeesCancelSingleton.Instance;
            singleton.SelectedBooking = SelectedBooking;
            singleton.StudentsOnBooking = StudentsOnBookingList;
            singleton.StudentsOnBookingGoing = StudentsOnBookingListGoing;
        }

        private void NavigateToDescriptionToCancel()
        {
            if (CheckIfSelected() == false)
            {
                MessageDialog msg = new MessageDialog("You need to select a booking.");
                msg.ShowAsync();
            }
            else
            {
                NavigationService ns = new NavigationService();
                ns.Navigate(typeof(BookingDescriptionToCancel));
            }
        }

        private bool CheckIfSelected()
        {
            if (SelectedBooking == null) return false;
            else return true;
        }

        private void NavigateToInvitePeople()
        {
            if (CheckIfSelected() == false)
            {
                MessageDialog msg = new MessageDialog("You need to select a booking.");
                msg.ShowAsync();
            }
            else
            {
                NavigationService ns = new NavigationService();
                ns.Navigate(typeof(InvitePeoplePage));
            }
            
        }

        private void TransformToList()
        {
            foreach (var s in StudentsOnBooking)
            {
                StudentsOnBookingList.Add(s);
            }

            foreach (var s2 in StudentsOnBookingGoing)
            {
                StudentsOnBookingListGoing.Add(s2);
            }
        }

        private void GetStudentsOnBooking()
        {
            StudentsOnBooking = null;
            StudentsOnBooking = Persistance.GetAttendeesOnBooking(SelectedBooking.BookingID);
        }

        private void GetAttendeesOnBookingGoing()
        {
            StudentsOnBookingGoing = new List<Student>();
            StudentsOnBookingGoing = Persistance.GetAttendeesOnBookingGoing(SelectedBooking.BookingID);
        }

        private void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MenuPage));
        }

        public void GetBookings() // Get the list of bookings from persistance
        {
            LoggedInSingleton loggedinsingleton = LoggedInSingleton.Instance;
            int studentID = loggedinsingleton.LoggedStudentID;
            Bookings = Persistance.GetBookings(studentID); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
