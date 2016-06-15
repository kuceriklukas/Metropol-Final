using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetropolFinal2.Singleton
{
    public class LoggedInSingleton
    {
        private static LoggedInSingleton instance;

        private int loggedStudentID;

        public int LoggedStudentID
        {
            get { return loggedStudentID; }
            set { loggedStudentID = value; }
        } 
       
        private LoggedInSingleton()
        {

        }

        public static LoggedInSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggedInSingleton();
                }
                return instance;
            }
        }
    }
}
