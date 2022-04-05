using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFood.Controllers
{
    public class QuanLiPhieuNhapController : Controller
    {
        // GET: QuanLiPhieuNhap
        MyDataDataContext db = new MyDataDataContext();
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.MaNCC = db.NCCs;
            ViewBag.ListSanPham = db.SanPhams;
            return View();
        }
        [HttpPost]
        public ActionResult NhapHang(PhieuNhap model, IEnumerable<CTPN> lstModel)
        {
          
            SanPham sp;
            foreach (var item in lstModel)
            {
                sp = db.SanPhams.Single(n => n.MaSP == item.MaSP);
                sp.Soluongton += item.Soluong;
                item.Maphieu = model.Maphieu;
            }
            db.CTPNs.InsertOnSubmit((CTPN)lstModel);
            db.SubmitChanges();
            return View();
        }
        [HttpGet]
        public ActionResult DSSPHetHang()
        {
            var lstSP = db.SanPhams.Where(n => n.Soluongton <= 0);
            return View(lstSP);

        }
        [HttpGet]
        public ActionResult NhapHangDon(int? id)
        {
            ViewBag.MaNCC = new SelectList(db.NCCs.OrderBy(n => n.TenNCC ), "MaNCC", "TenNCC");
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);

        }
        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap model, CTPN ctpn)
        {
            ViewBag.MaNCC = new SelectList(db.NCCs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            model.Ngaynhap= DateTime.Now;
            
            db.PhieuNhaps.InsertOnSubmit(model);
            db.SubmitChanges();
            ctpn.Maphieu = model.Maphieu;
            SanPham sp = db.SanPhams.Single(n => n.MaSP == ctpn.MaSP);
            sp.Soluongton += ctpn.Soluong;
            db.CTPNs.InsertOnSubmit(ctpn);
            db.SubmitChanges();
            return View(sp);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}