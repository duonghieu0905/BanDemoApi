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
    public class ChiTietHoaDonsController : ApiController
    {
        private NoiThatDBEntities db = new NoiThatDBEntities();

        // GET: api/ChiTietHoaDons
        public IQueryable<ChiTietHoaDon> GetChiTietHoaDons()
        {
            return db.ChiTietHoaDons;
        }

        // GET: api/ChiTietHoaDons/5
        [ResponseType(typeof(ChiTietHoaDon))]
        public IHttpActionResult GetChiTietHoaDon(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return Ok(chiTietHoaDon);
        }

        // PUT: api/ChiTietHoaDons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietHoaDon(int id, ChiTietHoaDon chiTietHoaDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHoaDon.HoaDonID)
            {
                return BadRequest();
            }

            db.Entry(chiTietHoaDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonExists(id))
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

        // POST: api/ChiTietHoaDons
        [ResponseType(typeof(ChiTietHoaDon))]
        public IHttpActionResult PostChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHoaDons.Add(chiTietHoaDon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChiTietHoaDonExists(chiTietHoaDon.HoaDonID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chiTietHoaDon.HoaDonID }, chiTietHoaDon);
        }

        // DELETE: api/ChiTietHoaDons/5
        [ResponseType(typeof(ChiTietHoaDon))]
        public IHttpActionResult DeleteChiTietHoaDon(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            db.ChiTietHoaDons.Remove(chiTietHoaDon);
            db.SaveChanges();

            return Ok(chiTietHoaDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHoaDonExists(int id)
        {
            return db.ChiTietHoaDons.Count(e => e.HoaDonID == id) > 0;
        }
    }
}