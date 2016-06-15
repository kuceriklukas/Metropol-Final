namespace WebAPIApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public Booking()
        {
            Attendees = new HashSet<Attendee>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingID { get; set; }

        public int StudentID { get; set; }

        public int RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string StartTime { get; set; }

        public int Length { get; set; }

        [Required]
        [StringLength(50)]
        public string BookingTitle { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual Room Room { get; set; }

        public virtual Student Student { get; set; }
    }
}
