namespace WebAPIApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RommID { get; set; }

        public int NumOfSeats { get; set; }

        public int Projector { get; set; }

        public int WhiteBoard { get; set; }

        [StringLength(50)]
        public string OtherFacilities { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
