using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Common;
using MetropolFinal2.DAL;
using MetropolFinal2.View;
using MetropolFinal2.Model;
using MetropolFinal2.Singleton;
using MetropolFinal2.ViewModel;


namespace MetropolFinal2.ViewModel
{
    public class BookingDescriptionToCancelVM: INotifyPropertyChanged
    {
        public RelayCommand NavigateToMenuPageCommand { get; set; }
        public RelayCommand NavigateBackCommand { get; set; }
        public RelayCommand CancelRoomCommand { get; set; }

        private string meetingName;

        private DateTimePeriod date;

        private string description;

        private List<Student> goingStudents;

        private List<Student> statetThatGoing;

        private int roomNumber;

        private int length;

        public int Length
        {
            get { return length; }
            set 
            { 
                length = value;
                OnPropertyChanged("Length");
            }
        }

        public int RoomNumber
        {
            get { return roomNumber; }
            set 
            { 
                roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }

        public List<Student> GoingStudents
        {
            get { return goingStudents; }
            set 
            { 
                goingStudents = value;
                OnPropertyChanged("GoingStudents");
            }
        }

        public List<Student> StatetThatGoing
        {
            get { return statetThatGoing; }
            set { statetThatGoing = value; }
        }


        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public DateTimePeriod Date
        {
            get { return date; }
            set 
            { 
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public string MeetingName
        {
            get { return meetingName; }
            set 
            { 
                meetingName = value;
                OnPropertyChanged("MeetingName");
            }
        }
        

        public BookingDescriptionToCancelVM()
        {
            NavigateToMenuPageCommand = new RelayCommand(NavigateToMenuPage);
            NavigateBackCommand = new RelayCommand(NavigateBack);
            CancelRoomCommand = new RelayCommand(CancelRoom);

            AttendeesCancelSingleton singleton = AttendeesCancelSingleton.Instance; //Initialize the properties with the data from singleton (previous page)
            MeetingName = singleton.SelectedBooking.BookingTitle;
            Date = DateTimePeriodConverter.ToDate(singleton.SelectedBooking.StartTime);
            Length = singleton.SelectedBooking.Length;
            RoomNumber = singleton.SelectedBooking.RoomID;
            Description = singleton.SelectedBooking.Description;
            GoingStudents = singleton.StudentsOnBooking;
            StatetThatGoing = singleton.StudentsOnBookingGoing;
            
        }

        public void NavigateToMenuPage()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MenuPage));
        }

        private void CancelRoom()
        {
            AttendeesCancelSingleton singleton = AttendeesCancelSingleton.Instance;
            Persistance.CancelBooking(singleton.SelectedBooking);
            NavigateBack();
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(CurrentBookingsPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
