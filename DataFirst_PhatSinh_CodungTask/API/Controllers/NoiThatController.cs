using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class NoiThatController : ApiController
    {
        NoiThatDBEntities db = new NoiThatDBEntities();
        [Route("api/NoiThat/GetSanPham")]
        public IHttpActionResult GetSanPham()
        {
            return Json(db.SanPhams.ToList());
        }
        [Route("api/NoiThat/GetChiTietHoaDon")]
        public IHttpActionResult GetChiTietHoaDon()
        {
            return Json(db.ChiTietHoaDons.ToList());
        }
        [Route("api/NoiThat/GetHoaDon")]
        public IHttpActionResult GetHoaDon()
        {
            return Json(db.HoaDons.ToList());
        }
    }
}
