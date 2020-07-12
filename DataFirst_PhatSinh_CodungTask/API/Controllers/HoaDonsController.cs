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
using DataAccess;

namespace API.Controllers
{
    public class HoaDonsController : ApiController
    {
        private NoiThatDBEntities db = new NoiThatDBEntities();

        // GET: api/HoaDons
        public IQueryable<HoaDon> GetHoaDons()
        {
            return db.HoaDons;
        }

        // GET: api/HoaDons/5
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult GetHoaDon(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return Ok(hoaDon);
        }

        // PUT: api/HoaDons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDon(int id, HoaDon hoaDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoaDon.HoaDonID)
            {
                return BadRequest();
            }

            db.Entry(hoaDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(id))
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

        // POST: api/HoaDons
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult PostHoaDon(HoaDon hoaDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDons.Add(hoaDon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HoaDonExists(hoaDon.HoaDonID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hoaDon.HoaDonID }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult DeleteHoaDon(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();

            return Ok(hoaDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonExists(int id)
        {
            return db.HoaDons.Count(e => e.HoaDonID == id) > 0;
        }
    }
}