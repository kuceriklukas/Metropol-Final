using System;
using Windows.UI.Popups;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;
using MetropolFinal2.View;
using MetropolFinal2.DAL;
using MetropolFinal2.Common;
using MetropolFinal2.Singleton;

namespace MetropolFinal2.ViewModel
{
    public class LoginVM
    {
        public RelayCommand LoginCommand { get; set; }

        private string enteredName;

        private string enteredPassword;

        public string EnteredPassword
        {
            get { return enteredPassword; }
            set { enteredPassword = value; }
        }

        public string EnteredName
        {
            get { return enteredName; }
            set { enteredName = value; }
        }

        public LoginVM()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            Login login = Persistance.GetLoginData(EnteredName).Result;
            if (login == null)
            {
                MessageDialog msg = new MessageDialog("This name doesn't exist!");
                msg.ShowAsync();
                //NavigationService ns = new NavigationService();
                //ns.Navigate(typeof(LoginPage));
            }
            else
            {
                if (login.Password == EnteredPassword)
                {
                    LoggedInSingleton singletonlog = LoggedInSingleton.Instance;
                    singletonlog.LoggedStudentID = login.StudentID;
                    NavigateToMenu();
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Entered password is incorrect!");
                    msg.ShowAsync();
                    //NavigationService ns = new NavigationService();
                    //ns.Navigate(typeof(LoginPage));
                }
            }
        }

        public void NavigateToMenu()
        {
            NavigationService ns = new NavigationService();
            ns.Navigate(typeof(MenuPage));
        }
    }
}
