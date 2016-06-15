using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.View;
using Windows.UI.Xaml;
using MetropolFinal2.Singleton;
using MetropolFinal2.Common;
using MetropolFinal2.Model;
using MetropolFinal2.DAL;
using System.Collections.ObjectModel;

namespace MetropolFinal2.ViewModel
{
    public class MessagesVM: INotifyPropertyChanged
    {
        public RelayCommand NavigateBackCommand { get; set; }
        public RelayCommand GoingCommand { get; set; }
        public RelayCommand NotGoingCommand { get; set; }


        private IEnumerable<Message> messagesList;
        private ObservableCollection<Message> listOfMessages;
        private Message selectedMessage;
        private string titleText;
        private string descriptionText;
        private int meetingLength;
        private DateTimePeriod meetingDate;
        private int roomID;
        private string goingOrNot;
        private int ifgoing;

        public object ShowDetails
        {
            get
            {
                if (SelectedMessage == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public ObservableCollection<Message> ListOfMessages
        {
            get { return listOfMessages; }
            set 
            { 
                listOfMessages = value;
                OnPropertyChanged("ListOfMessages");
            }
        }

        public int RoomID
        {
            get { return roomID; }
            set 
            { 
                roomID = value;
                OnPropertyChanged("RoomID");
            }
        }

        public DateTimePeriod MeetingDate
        {
            get { return meetingDate; }
            set 
            { 
                meetingDate = value;
                OnPropertyChanged("MeetingDate");
            }
        }

        public int MeetingLength
        {
            get { return meetingLength; }
            set 
            { 
                meetingLength = value;
                OnPropertyChanged("MeetingLength");
                
            }
        }

        public string DescriptionText
        {
            get { return descriptionText; }
            set
            {
                descriptionText = value;
                OnPropertyChanged("DescriptionText");
            }

        }

        public string TitleText
        {
            get { return titleText; }
            set 
            { 
                titleText = value;
                OnPropertyChanged("TitleText");
            }
        }

        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set 
            { 
                selectedMessage = value;
                OnPropertyChanged("SelectedMessage");
                FillTextBlocks();
                OnPropertyChanged("ShowButtons");
                OnPropertyChanged("ShowDetails");
            }
        }
        public string GoingOrNot
        {
            get { return goingOrNot; }
            set
            {
                goingOrNot = value;
                OnPropertyChanged("GoingOrNot");
            }
        }


        public IEnumerable<Message> MessagesList
        {
            get { return messagesList; }
            set 
            { 
                messagesList = value; 
            }
        }

        public MessagesVM()
        {
            NavigateBackCommand = new RelayCommand(NavigateBack);
            MessagesList = new List<Message>();
            ListOfMessages = new ObservableCollection<Message>();
            GoingCommand = new RelayCommand(AttendeeGoing);
            NotGoingCommand = new RelayCommand(AttendeeNotGoing);
            GetMessages();
            ConvertToObservable();

        }

        private void FillTextBlocks()
        {
            MeetingDate = SelectedMessage.MeetingDate;
            MeetingLength = SelectedMessage.MeetingLength;
            TitleText = SelectedMessage.BookingTitle;
            DescriptionText = SelectedMessage.MeetingDescription;
            RoomID = SelectedMessage.RoomID;
            

            GetAttendeeStatus();
            MakeStatus();
            OnPropertyChanged("GoingOrNot");
            OnPropertyChanged("Visibility");
        }

        private void MakeStatus()
        {
            switch (ifgoing)
            {
                case 0:
                    GoingOrNot = "You are not attendeing this meeting.";
                    break;

                case 1:
                    goingOrNot = "You are attending this meeting.";
                    break;

                case 2:
                    goingOrNot = "You haven't stated if you will go to this meeting or not.";
                    break;
            }
            
        }

        private void ConvertToObservable()
        {
            foreach (var m in MessagesList)
            {
                ListOfMessages.Add(m);
            }
        }

        private void AttendeeGoing()
        {
            LoggedInSingleton singlg = LoggedInSingleton.Instance;
            int logID = singlg.LoggedStudentID;
            Persistance.AttendeeGoing(logID, SelectedMessage.BookingID);
            FillTextBlocks();
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MessagesPage));
        }

        private void AttendeeNotGoing()
        {
            LoggedInSingleton singlg = LoggedInSingleton.Instance;
            int logID = singlg.LoggedStudentID;
            Persistance.AttendeeNotGoing(logID, SelectedMessage.BookingID);
            FillTextBlocks();
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MessagesPage));
        }

        private void GetMessages()
        {
            LoggedInSingleton logsingleton = LoggedInSingleton.Instance;
            MessagesList = Persistance.GetMessages(logsingleton.LoggedStudentID);
        }

        private void GetAttendeeStatus()
        {
            LoggedInSingleton logsingleton = LoggedInSingleton.Instance;
            ifgoing = Persistance.GetOneAttendee(logsingleton.LoggedStudentID, SelectedMessage.BookingID);
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MenuPage));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
