namespace WebAPIApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public Student()
        {
            Attendees = new HashSet<Attendee>();
            Bookings = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string EMail { get; set; }

        public int TelNum { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Login Login { get; set; }
    }
}
