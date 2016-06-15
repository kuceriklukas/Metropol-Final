using System;
using Windows.UI.Popups;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.View;
using MetropolFinal2.Singleton;
using MetropolFinal2.Model;
using MetropolFinal2.Common;
using MetropolFinal2.DAL;
using System.Collections.ObjectModel;

namespace MetropolFinal2.ViewModel
{
    public class InvitePeopleVM: INotifyPropertyChanged
    {
        public RelayCommand NavigateBackCommand { get; set; }
        public RelayCommand InvitePeopleCommand { get; set; }
        public RelayCommand FilterStudentsCommand { get; set; }
        public RelayCommand ResetListsCommand { get; set; }

        private IEnumerable<Student> studentList;
        private IEnumerable<Attendee> attendeeList;
        private ObservableCollection<Attendee> listOfAttendees;
        private ObservableCollection<Student> listOfStudents;
        private ObservableCollection<Student> aleadyInvitedStudents;
        private ObservableCollection<Student> filteredStudents;
        private ObservableCollection<Student> helperList;

     
        private Student selectedStudent;
        private Student selectedAttendee;
        private string filterText;


        public ObservableCollection<Student> HelperList
        {
            get { return helperList; }
            set 
            { 
                helperList = value;
                OnPropertyChanged("HelperList");
            }
        }

        public ObservableCollection<Student> FilteredStudents
        {
            get { return filteredStudents; }
            set 
            { 
                filteredStudents = value;
                OnPropertyChanged("FilteredStudents");
            }
        }
        public ObservableCollection<Student> AleadyInvitedStudents
        {
            get { return aleadyInvitedStudents; }
            set 
            { 
                aleadyInvitedStudents = value;
                OnPropertyChanged("AlreadyInvitedStudents");
            }
        }

        public ObservableCollection<Student> ListOfStudents
        {
            get { return listOfStudents; }
            set 
            { 
                listOfStudents = value;
                OnPropertyChanged("ListOfStudents");
            }
        }

        public ObservableCollection<Attendee> ListOfAttendees
        {
            get { return listOfAttendees; }
            set { listOfAttendees = value; }
        }

        public string FilterText
        {
            get { return filterText; }
            set 
            { 
                filterText = value;
                OnPropertyChanged("FilterText");
            }
        }

        public Student SelectedAttendee
        {
            get { return selectedAttendee; }
            set 
            { 
                selectedAttendee = value;
                ListOfStudents.Remove(SelectedAttendee);
                OnPropertyChanged("SelectedAttendee");
            }
        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set 
            { 
                selectedStudent = value;
                AddAttendee();
                
                OnPropertyChanged("ListOfStudents");
            }
        }


        public IEnumerable<Attendee> AttendeeList
        {
            get { return attendeeList; }
            set 
            { 
                attendeeList = value;
                OnPropertyChanged("AttendeeList");
            }
        }

        public IEnumerable<Student> StudentList
        {
            get { return studentList; }
            set 
            { 
                studentList = value;
                OnPropertyChanged("StudentList");
            }
        }


        public InvitePeopleVM()
        {
            StudentList = new List<Student>();
            AttendeeList = new List<Attendee>();
            ListOfAttendees = new ObservableCollection<Attendee>();
            ListOfStudents = new ObservableCollection<Student>();
            AleadyInvitedStudents = new ObservableCollection<Student>();
            HelperList = new ObservableCollection<Student>();
        
            GetStudents();
            GetAttendees();

            RetrieveStudentObservable();
            
            NavigateBackCommand = new RelayCommand(NavigateBack);
            InvitePeopleCommand = new RelayCommand(InvitePeople);
            FilterStudentsCommand = new RelayCommand(FilterStudents);
            ResetListsCommand = new RelayCommand(ResetLists);
            foreach (Student s in StudentList)
            {
                HelperList.Add(s);
            }
        }

        private void FilterStudents()
        {
            SelectedStudent = null;
            StudentList = HelperList;
            FilteredStudents = new ObservableCollection<Student>();
            HelperList = new ObservableCollection<Student>();
            foreach (Student student in StudentList)
            {
                if (student.FirstName.Contains(FilterText) || (student.LastName.Contains(FilterText)) || (student.EMail.Contains(FilterText))) 
                {
                    FilteredStudents.Add(student);
                }
            }

            foreach (Student s in StudentList)
            {
                HelperList.Add(s);
            }

            StudentList = new List<Student>();
            StudentList = FilteredStudents;
        }

        private void ResetLists()
        {
            FilteredStudents = new ObservableCollection<Student>();
            StudentList = HelperList;
            HelperList = new ObservableCollection<Student>();
            foreach (Student s in StudentList)
            {
                HelperList.Add(s);
            }

        }

        private void AddAttendee()
        {
            bool IsInList = false;

            if (SelectedStudent != null)
            {
                if ((ListOfStudents.Count == 0) && (AleadyInvitedStudents.Count == 0))
                {
                    ListOfStudents.Add(SelectedStudent);
                }
                else
                {
                    foreach (var s in ListOfStudents)
                    {
                        if (s == SelectedStudent)
                        {
                            IsInList = true;
                        }
                        else if (s != SelectedStudent)
                        {
                            continue;
                        }
                    }
                    foreach (var t in AleadyInvitedStudents)
                    {
                        if (t == SelectedStudent)
                        {
                            IsInList = true;
                        }
                        else if (t != SelectedStudent)
                        {
                            continue;
                        }
                    }

                    if (IsInList == true)
                    {
                        MessageDialog msg = new MessageDialog("This student is already added as attendee.");
                        msg.ShowAsync();
                    }
                    else
                    {
                        ListOfStudents.Add(SelectedStudent);
                    }
                }
            }
                   
        }

        private void GetStudents() 
        {
            StudentList = Persistance.GetStudents();
        }

        private void RetrieveStudentObservable()
        {
            foreach (var a in AttendeeList)
            {
                foreach (var s in StudentList)
                {
                    if (a.StudentID == s.StudentID)
                        AleadyInvitedStudents.Add(s);
                }
            }
        }


        private void GetAttendees()
        {
            AttendeesCancelSingleton singleton = AttendeesCancelSingleton.Instance;
            int bookingID = singleton.SelectedBooking.BookingID;

            AttendeeList = Persistance.GetAttendees(bookingID);
        }

        //private void MakeAttendees()
        //{
        //    AttendeesCancelSingleton singleton = AttendeesCancelSingleton.Instance;
        //    int ifgoing = 2;
        //    Attendee attendee = new Attendee() { BookingID = singleton.SelectedBooking.BookingID, StudentID = SelectedStudent.StudentID, Going = ifgoing};

        //    ListOfAttendees.Add(attendee);
        //    //GetAttendees();
        //}

        private void MakeAttendees()
        {
            AttendeesCancelSingleton sing = AttendeesCancelSingleton.Instance;
            foreach (var stud in ListOfStudents)
            {
                ListOfAttendees.Add(new Attendee(){StudentID = stud.StudentID, BookingID = sing.SelectedBooking.BookingID, Going = 2});
            }
        }

        public void InvitePeople()
        {
            MakeAttendees();
            Persistance.AddAttendees(ListOfAttendees);
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(CurrentBookingsPage));
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
