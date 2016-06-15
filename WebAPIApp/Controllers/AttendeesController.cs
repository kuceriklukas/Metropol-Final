using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIApp;

namespace WebAPIApp.Controllers
{
    public class AttendeesController : ApiController
    {
        private BookingContext db = new BookingContext();

        // GET: api/Attendees
        public IQueryable<Attendee> GetAttendees()
        {
            return db.Attendees;
        }

        // GET: api/Attendees/5
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult GetAttendee(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return NotFound();
            }

            return Ok(attendee);
        }

        // PUT: api/Attendees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendee(int id, Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendee.AttendeeID)
            {
                return BadRequest();
            }

            db.Entry(attendee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Attendees
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult PostAttendee(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attendees.Add(attendee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AttendeeExists(attendee.AttendeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = attendee.AttendeeID }, attendee);
        }

        // DELETE: api/Attendees/5
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult DeleteAttendee(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return NotFound();
            }

            db.Attendees.Remove(attendee);
            db.SaveChanges();

            return Ok(attendee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendeeExists(int id)
        {
            return db.Attendees.Count(e => e.AttendeeID == id) > 0;
        }
    }
}