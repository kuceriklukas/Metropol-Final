using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetropolFinal2.Model;

namespace MetropolFinal2.Singleton
{
    public class InvitationCancelSingleton
    {
        private static InvitationCancelSingleton instance;
        private Booking currentBooking;

        public Booking CurrentBooking
        {
            get { return currentBooking; }
            set { currentBooking = value; }
        }
        public static InvitationCancelSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InvitationCancelSingleton();
                }
                return instance;
            }
        }

        private InvitationCancelSingleton()
        {

        }
    }
}
