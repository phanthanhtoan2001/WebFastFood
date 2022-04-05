using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace FastFood.Controllers
{
    public class QuanLiDonHangController : Controller
    {
        // GET: QuanLiDonHang
        MyDataDataContext db = new MyDataDataContext();
        public ActionResult DaGiaoHang(string id)
        {
            var lstDSDHCG = db.DonDatHangs.ToList();
           
            return View(lstDSDHCG);
        }
        [HttpGet]
        public ActionResult TimKiem() {
            return View();
        }

        [HttpPost]
        public ActionResult TimKiem(FormCollection collection)
        {
            var lst = new List<DonDatHang>();
            try
            {
                var option = collection["SearchString"];
                lst = db.DonDatHangs.Where(p => (p.MaDDH.ToString().ToLower().Contains(option.ToString().ToLower()))).ToList();

            }
            catch(Exception ex){
                MessageBox.Show(ex.StackTrace);
            }
            return View(lst);
        }
        public ActionResult DuyetDonHang(DonDatHang ddh)
        {
            DonDatHang ddhUpdate = db.DonDatHangs.Single(n => n.MaDDH == ddh.MaDDH);
           
            ddhUpdate.Tinhtrangdonhang = ddh.Tinhtrangdonhang;
            db.SubmitChanges();
            var lstChiTietDH = db.CTDDHs.Where(n => n.MaDDH == ddh.MaDDH);
            ViewBag.ListChiTietDH = lstChiTietDH;
            

            return View(ddhUpdate);
        }
        [HttpGet]
        public ActionResult DDuyetDonHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang model = db.DonDatHangs.SingleOrDefault(n => n.MaDDH == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var lstChiTietDH = db.CTDDHs.Where(n => n.MaDDH == id);
            ViewBag.ListChiTietDH = lstChiTietDH;
            return View(model);
        }
      
       
        
        public ActionResult InHoaDon(int madon)
        {
            var hd = from c in db.CTDDHs where (c.MaDDH == madon) select c;
           return View(hd);
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