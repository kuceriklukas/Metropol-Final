namespace WebAPIApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attendee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttendeeID { get; set; }

        public int StudentID { get; set; }

        public int BookingID { get; set; }

        public int Going { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Student Student { get; set; }
    }
}
