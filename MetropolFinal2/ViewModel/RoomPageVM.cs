using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.View;
using MetropolFinal2.Model;
using MetropolFinal2.Singleton;
using MetropolFinal2.Common;
using MetropolFinal2.DAL;
using Windows.UI.Popups;

namespace MetropolFinal2.ViewModel
{
    class RoomPageVM: INotifyPropertyChanged
    {
        public RelayCommand NavigateToTimeCommand { get; set; }
        public RelayCommand NavigateBackCommand { get; set; }
        
        
        public IEnumerable<Room> Rooms { get; set; }

        private Room selectedRoom;
        private int roomID;
        private string otherFacilities;
        private string projector;
        private string whiteBoard;
        private int numberOfSeats;

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set 
            { 
                numberOfSeats = value;
                OnPropertyChanged("NumberOfSeats");
            }
        }

        public string WhiteBoard
        {
            get { return whiteBoard; }
            set 
            {
                whiteBoard = value;
                OnPropertyChanged("WhiteBoard");
            }
        }

        public string Projector
        {
            get { return projector; }
            set
            {
                projector = value;
                OnPropertyChanged("Projector");
            }
        }

        public string OtherFacilities
        {
            get { return otherFacilities; }
            set 
            { 
                otherFacilities = value;
                OnPropertyChanged("OtherFacilities");
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


        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set 
            { 
                selectedRoom = value;
                OnPropertyChanged("SelectedRoom");
                RoomID = SelectedRoom.RommID;
                NumberOfSeats = SelectedRoom.NumOfSeats;
                OtherFacilities = SelectedRoom.OtherFacilities;
                WhiteBoard = FillWhiteBoard();
                Projector = FillProjector();
                PushToSingleton();
            }
        }

        public RoomPageVM ()//constructor
        {
            NavigateToTimeCommand = new RelayCommand(NavigateToTime);
            NavigateBackCommand = new RelayCommand(NavigateBack);
            Rooms = new List<Room>();
            GetRooms();
        }

        private string FillWhiteBoard()
        {
            if (SelectedRoom.WhiteBoard == 1)
            {
                return "Whiteboard";
            }
            return "X";
        }

        private string FillProjector()
        {
            if (SelectedRoom.Projector == 1)
            {
                return "Projector";
            }
            return "X";
        }

        private void PushToSingleton()
        {
            BookingSingleton singleton = BookingSingleton.Instance;
            singleton.SelectedRoom = SelectedRoom;
        }

        private void GetRooms() //get the list of rooms from Persistance class in RoomPage
        {
            Rooms = Persistance.GetRooms().Result;
        }

        public void NavigateToTime()
        {
            if (SelectedRoom == null)
            {
                MessageDialog msg = new MessageDialog("You need to select a room.");
                msg.ShowAsync();
            }
            else
            {
                NavigationService ns = new NavigationService();
                ns.Navigate(typeof(TimePage));
            }       
        }

        public void NavigateBack()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(CalendarPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
