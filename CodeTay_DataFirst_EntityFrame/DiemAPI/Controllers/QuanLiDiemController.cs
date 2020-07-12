using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using DataAccess;

namespace DiemAPI.Controllers
{
    public class QuanLiDiemController : ApiController
    {
        QuanLiDiemEntities db = new QuanLiDiemEntities();
        [Route("api/QuanLiDiem/GetSinhVien")]
        public IHttpActionResult GetSinhVien()
        {
            return Json(db.SinhViens.ToList());
        }
        [Route("api/QuanLiDiem/GetBangDiem")]
        public IHttpActionResult GetBangDiem(int id)
        {
            return Json(db.BangDiems.Where(x => x.SinhVienID == id).ToList());
            
        }
        [Route("api/QuanLiDiem/PostBangDiem")]
        public IHttpActionResult PostUpdate(BangDiem bangdiem)
        {
            var result = db.BangDiems.Where(x => x.MonHocID == bangdiem.MonHocID && x.SinhVienID == bangdiem.SinhVienID).FirstOrDefault();
            if (result == null)
                return NotFound();
            else
            {
                result.TK = bangdiem.TK;
                result.GK = bangdiem.GK;
                result.CK = bangdiem.CK;
                return Json(db.SaveChanges());
            }
        }

    }
}
