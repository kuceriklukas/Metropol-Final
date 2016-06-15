using System;
using Windows.UI.Popups;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;
using System.Collections.ObjectModel;
using MetropolFinal2.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Data.Json;

namespace MetropolFinal2.DAL
{
    public static class Persistance//Everything asociated with saving and retrieveng data from repositories (db or fakeDB)
    {

        #region FAKEDATABASE
        public static List<Room> Rooms;
        public static List<Booking> Bookings;
        public static List<Login> Logins;
        public static List<Student> Students;
        public static List<Attendee> Attendees;
        public static List<Message> Messages;
        public static List<Student> AttendeesOnBooking;
        public static List<Student> AttendeesOnBookingGoing;
        public static List<Booking> Invitations;

        #endregion

        public static async Task<Login> GetLoginData(string LoginName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");
           
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Logins").Result;
            
            Login finalLog = new Login();

            if (response.IsSuccessStatusCode)
            {
                var logins = response.Content.ReadAsAsync<IEnumerable<Login>>().Result;

                foreach (Login login in logins)
                {
                    if (login.LoginName == LoginName)
                    {
                        finalLog = login;
                    }
                }
                return finalLog;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static async Task<IEnumerable<Room>> GetRooms()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Rooms").Result;

            if (response.IsSuccessStatusCode)
            {
                var rooms = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;


                return rooms.ToList();


            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        

        public static async void AddNewBooking(int studentID, string startTime, int length, int roomID, string bookingTitle, string description)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Booking booking = new Booking();

            booking.BookingID = GetRightBookingID();
            booking.StudentID = studentID; 
            booking.StartTime = startTime;
            booking.Length = length;
            booking.RoomID = roomID;
            booking.BookingTitle = bookingTitle;
            booking.Description = description;


            var response = client.PostAsJsonAsync("api/Bookings", booking).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageDialog md = new MessageDialog("Booking was successfully created!");
                md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("There was some error during the process\nError Code: " + response.StatusCode + ", Message: " + response.ReasonPhrase);
                md.ShowAsync();
            }
        }

        private static int GetRightBookingID()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Bookings").Result;

            if (response.IsSuccessStatusCode)
            {
                var bookings = response.Content.ReadAsAsync<IEnumerable<Model.Booking>>().Result;
                int autoIncID = 0;

                foreach (Booking booking in bookings)
                {
                    autoIncID = booking.BookingID;
                }
                return autoIncID + 1;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return 0;
            }

        }

        public static IEnumerable<Model.Attendee> GetAttendees(int BookingID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<Attendee> FilteredAttendees = new List<Attendee>();

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if (att.BookingID == BookingID)
                    {
                        FilteredAttendees.Add(att);
                    }
                }
                return FilteredAttendees;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static void AddAttendees(ObservableCollection<Model.Attendee> ListAttendees)
        {
            int autoIncAttendeeID = GetRightAttendeeID();
            try
            {
                foreach (var attendee in ListAttendees)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:15320");

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    attendee.AttendeeID = autoIncAttendeeID;
                    autoIncAttendeeID = autoIncAttendeeID + 1;
                    var response = client.PostAsJsonAsync("api/Attendees", attendee).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        continue;
                    }
                    else
                    {
                        Exception ex = new Exception();
                        throw ex;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog("There was some error during the process.");
                msg.ShowAsync();
            }
            
        }

        private static int GetRightAttendeeID()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            int attID = 0;
            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    attID = att.AttendeeID;
                }
                return attID + 1;

            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return 0;
            }
        }

        public static void CancelBooking(Booking booking)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");


            var url = "api/Bookings/" + booking.BookingID;
            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageDialog md = new MessageDialog("Booking successfully deleted!");
                md.ShowAsync();
            }
            else
            {
                MessageDialog md= new MessageDialog("There was some error during the process\nError Code: " + response.StatusCode + ", Message: " + response.ReasonPhrase);
                md.ShowAsync();
            }
        }
        

        public static IEnumerable<Booking> GetBookingsOnRoom(int roomID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Bookings").Result;

            if (response.IsSuccessStatusCode)
            {
                var bookings = response.Content.ReadAsAsync<IEnumerable<Booking>>().Result;
                List<Booking> FilteredBookings = new List<Booking>();

                foreach (Booking booking in bookings)
                {
                    if (booking.RoomID == roomID)
                    {
                        FilteredBookings.Add(booking);
                    }
                }
                return FilteredBookings;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static int GetOneAttendee(int StudentID, int BookingID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if ((att.StudentID == StudentID) && (att.BookingID == BookingID))
                    {
                        return att.Going;
                    }
                }
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return 0;
            }
            return 0;
        }

        public static IEnumerable<Message> GetMessages(int StudentID)
        {
            Messages = new List<Message>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if (att.StudentID == StudentID)
                    {
                        HttpResponseMessage response2 = client.GetAsync("api/Bookings").Result;

                        if (response2.IsSuccessStatusCode)
                        {
                            var bookings = response2.Content.ReadAsAsync<IEnumerable<Booking>>().Result;

                            foreach (var b in bookings)
                            {
                                if (b.BookingID == att.BookingID)
                                {
                                    Messages.Add(new Message()
                                    {
                                        BookingTitle = b.BookingTitle,
                                        MeetingDescription = b.Description,
                                        MeetingDate = DateTimePeriodConverter.ToDate(b.StartTime),
                                        BookingID = b.BookingID,
                                        MeetingLength = b.Length,
                                        RoomID = b.RoomID
                                    });
                                }
                            }
                        }
                        else
                        {
                            MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                            message.ShowAsync();

                            return null;
                        }
                    }
                }

                return Messages;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }

        }

        public static IEnumerable<Model.Student> GetAttendeesOnBooking(int BookingID)
        {
            AttendeesOnBooking = new List<Student>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if (att.BookingID == BookingID)
                    {
                        HttpResponseMessage response2 = client.GetAsync("api/Students").Result;

                        if (response2.IsSuccessStatusCode)
                        {
                            var students = response2.Content.ReadAsAsync<IEnumerable<Student>>().Result;

                            foreach (var student in students)
                            {
                                if (att.StudentID == student.StudentID)
                                {
                                    AttendeesOnBooking.Add(student);
                                }
                            }
                        }
                        else
                        {
                            MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                            message.ShowAsync();

                            return null;
                        }
                    }
                }
                
                return AttendeesOnBooking;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static IEnumerable<Model.Student> GetAttendeesOnBookingGoing(int BookingID)
        {
            AttendeesOnBookingGoing = new List<Student>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if ((att.BookingID == BookingID) && (att.Going == 1))
                    {
                        HttpResponseMessage response2 = client.GetAsync("api/Students").Result;

                        if (response2.IsSuccessStatusCode)
                        {
                            var students = response2.Content.ReadAsAsync<IEnumerable<Student>>().Result;

                            foreach (var student in students)
                            {
                                if (att.StudentID == student.StudentID)
                                {
                                    AttendeesOnBookingGoing.Add(student);
                                }
                            }
                        }
                        else
                        {
                            MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                            message.ShowAsync();

                            return null;
                        }
                    }
                }

                return AttendeesOnBookingGoing;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static void AttendeeGoing(int studentID, int bookingID)
        {
            int attID = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if ((att.StudentID == studentID) && (att.BookingID == bookingID))
                    {
                        attID = att.AttendeeID;
                        Attendee attendee = new Attendee() { AttendeeID = attID, BookingID = bookingID, StudentID = studentID, Going = 1 };
                        try
                        {
                            client.PutAsJsonAsync<Attendee>("api/Attendees/" + attID, attendee);
                        }
                        catch (Exception ex)
                        {
                            MessageDialog msg = new MessageDialog(ex.Message);
                            msg.ShowAsync();
                        }
                        
                        break;
                    }
                }

            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();
            }
       
            //HttpClientHandler httpClientHandler = new HttpClientHandler();
            //using (var client = new HttpClient(httpClientHandler))
            //{
            //    client.BaseAddress = new Uri("http://localhost:15320");
            //    client.DefaultRequestHeaders.Clear();
            //    try
            //    {
            //        await client.PutAsJsonAsync<Attendee>("api/Attendees/" + userToEdit.UserID, userToEdit);

            //    }
            //    catch (Exception ex)
            //    {
            //        new MessageDialog(ex.Message).ShowAsync();
            //    }
            //}
        }

        public static void AttendeeNotGoing(int studentID, int bookingID)
        {
            int attID = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Attendees").Result;

            if (response.IsSuccessStatusCode)
            {
                var attendees = response.Content.ReadAsAsync<IEnumerable<Attendee>>().Result;

                foreach (var att in attendees)
                {
                    if ((att.StudentID == studentID) && (att.BookingID == bookingID))
                    {
                        attID = att.AttendeeID;
                        Attendee attendee = new Attendee() { AttendeeID = attID, BookingID = bookingID, StudentID = studentID, Going = 0 };
                        try
                        {
                            client.PutAsJsonAsync<Attendee>("api/Attendees/" + attID, attendee);
                        }
                        catch (Exception ex)
                        {
                            MessageDialog msg = new MessageDialog(ex.Message);
                            msg.ShowAsync();
                        }

                        break;
                    }
                }

            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();
            }
        }
        public static IEnumerable<Model.Booking> GetBookings(int StudentID) //returns the list of bookings 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Bookings").Result;

            if (response.IsSuccessStatusCode)
            {
                var bookings = response.Content.ReadAsAsync<IEnumerable<Model.Booking>>().Result;
                List<Booking> FilteredBookings = new List<Booking>();

                foreach (Booking booking in bookings)
                {
                    if (booking.StudentID == StudentID)
                    {
                        FilteredBookings.Add(booking);
                    }
                }
                return FilteredBookings;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        public static IEnumerable<Model.Student> GetStudents()
        {
            Students = new List<Student>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:15320");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Students").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;

                foreach (var s in students)
                {
                    Students.Add(s);
                }
                return Students;
            }
            else
            {
                MessageDialog message = new MessageDialog("There were some errors during the proccess. Try again.");
                message.ShowAsync();

                return null;
            }
        }

        static Persistance()
        {
            Rooms = new List<Room>() //Filling the list of rooms, which is returned in GetRooms method above
            {
                new Room{RommID = 1, NumOfSeats = 20, OtherFacilities = "", Projector = 1, WhiteBoard = 0},
                new Room{RommID = 2, NumOfSeats = 22, OtherFacilities = "", Projector = 0, WhiteBoard = 0},
                new Room{RommID = 3, NumOfSeats = 25, OtherFacilities = "", Projector = 1, WhiteBoard = 1},
                new Room{RommID = 4, NumOfSeats = 23, OtherFacilities = "", Projector = 1, WhiteBoard = 1}
            };

            //DateTime date1 = new DateTime(2, 5, 2015);
            //DateTime date2 = new DateTime(18, 6, 2015);

            Bookings = new List<Booking>();
            Bookings.Add(new Booking { BookingID = 1, StartTime = "30/08/2015 12:15", BookingTitle = "Meeting Eating", Description = "Bla blah", Length = 2, RoomID = 2, StudentID = 1});
            Bookings.Add(new Booking { BookingID = 2, StartTime = "20/05/2015 12:15", BookingTitle = "Singing in the rain", Description = "We like to wing in the rain.", Length = 3, RoomID = 2, StudentID = 1 });
            Bookings.Add(new Booking { BookingID = 3, StartTime = "29/07/2015 12:15", BookingTitle = "Feeding", Description = "Feeding zombies with our brains", Length = 2, RoomID = 4, StudentID = 2 });
            Bookings.Add(new Booking { BookingID = 4, StartTime = "30/07/2015 12:15", BookingTitle = "Negative people trying to older everything", Description = "Making new things old again", Length = 4, RoomID = 1, StudentID = 2 });
            Bookings.Add(new Booking { BookingID = 5, StartTime = "29/08/2015 12:15", BookingTitle = "Speaking", Description = "We will be speaking about how this app is awesome! Be sure to come!", Length = 1, RoomID = 1, StudentID = 2 });
            Bookings.Add(new Booking { BookingID = 6, StartTime = "1/12/2015 12:15", BookingTitle = "Making strange sounds", Description = "Woof woof! Oink oink! Waflaere waflaere!", Length = 3, RoomID = 3, StudentID = 4 });

            Logins = new List<Login>()
            {
                new Login{StudentID = 1, LoginName = "Mufloon", Password = "Mufloon1"},
                new Login{StudentID = 2, LoginName = "Allan", Password = "Allan123"},
                new Login{StudentID = 3, LoginName = "Char", Password = "Lliiee"},
                new Login{StudentID = 4, LoginName = "Chris", Password = "Chris321"},
                new Login{StudentID = 5, LoginName = "GeraltBoss", Password = "Rivia"},
                new Login{StudentID = 6, LoginName = "Triss", Password = "Ranuncul"}
            };

            Students = new List<Student>() 
            {
                new Student{ StudentID = 1, FirstName = "Muflon", LastName = "Hlinka", EMail = "muflonhlinka@gmail.com", TelNum = 21547854},
                new Student{ StudentID = 2, FirstName = "Allan", LastName = "Sheen", EMail = "sheen123@gmail.com", TelNum = 142536},
                new Student{ StudentID = 3, FirstName = "Charlie", LastName = "Ofhhg", EMail = "offgh@gmail.com", TelNum = 1254563},
                new Student{ StudentID = 4, FirstName = "Chris", LastName = "Marigold", EMail = "marigildch@gmail.com", TelNum = 11447454},
                new Student{ StudentID = 5, FirstName = "Geralt", LastName = "OfRivia", EMail = "geraltrivia@gmail.com", TelNum = 25647896},
                new Student{ StudentID = 6, FirstName = "Triss", LastName = "Ranuncul", EMail = "beautifultriss@gmail.com", TelNum = 47586912}
            };

            Attendees = new List<Attendee>();
            Attendees.Add(new Attendee { StudentID = 1, BookingID = 2, Going = 0 });
            Attendees.Add(new Attendee { StudentID = 2, BookingID = 2, Going = 1 });
            Attendees.Add(new Attendee { StudentID = 2, BookingID = 6, Going = 1 });
            Attendees.Add(new Attendee { StudentID = 2, BookingID = 5, Going = 1 });
            Attendees.Add(new Attendee { StudentID = 4, BookingID = 2 });
            Attendees.Add(new Attendee { StudentID = 1, BookingID = 4, Going = 1 });

            Messages = new List<Message>();
            AttendeesOnBooking = new List<Student>();
            Invitations = new List<Booking>();
            AttendeesOnBookingGoing = new List<Student>();
        }
    }
}

