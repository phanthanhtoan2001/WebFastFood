using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFood.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
       
        MyDataDataContext db = new MyDataDataContext();
        public ActionResult Listsanpham()
        {
            var all_food = from tt in db.SanPhams  orderby tt.Dongia ascending select tt;
            return View(all_food);
        }
        public ActionResult Detail(int id)
        {
            var D_theloai = db.SanPhams.Where(m => m.MaSP == id).First();
            return View(D_theloai);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham tl)
        {
            var masp = collection["MaSP"];
            var tensp = collection["Tensp"];
            var dongia = collection["Dongia"];
            var size = collection["Size"];
            var hinhanh = collection["Hinhanh"];
            var soluongton = collection["Soluongton"];
            var Mansx = collection["MaNSX"];
            var Mancc = collection["MaNCC"];
            var MaLoaisp = collection["MaLoaiSP"];
            if (string.IsNullOrEmpty(tensp))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.MaSP = int.Parse(masp);
                tl.Tensp = tensp;
                tl.Dongia = int.Parse(dongia);
                tl.Size = size;
                tl.Hinhanh = hinhanh;
                tl.Soluongton = int.Parse(soluongton);
                tl.MaNCC = Mancc;
                tl.MaLoaiSP = int.Parse(MaLoaisp);
                db.SanPhams.InsertOnSubmit(tl);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = db.SanPhams.First(m => m.MaSP == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var tl = db.SanPhams.First(m => m.MaSP == id);
            var masp = collection["MaSP"];
            var tensp = collection["Tensp"];
            var dongia = collection["Dongia"];
            var size = collection["Size"];
            var hinhanh = collection["Hinhanh"];
            var soluongton = collection["Soluongton"];
            var Mansx = collection["MaNSX"];
            var Mancc = collection["MaNCC"];
            var MaLoaisp = collection["MaLoaiSP"];
            if (string.IsNullOrEmpty(masp) || string.IsNullOrEmpty(tensp) || string.IsNullOrEmpty(dongia) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(hinhanh) || string.IsNullOrEmpty(soluongton) || string.IsNullOrEmpty(Mansx) || string.IsNullOrEmpty(Mancc) || string.IsNullOrEmpty(MaLoaisp))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.MaSP = int.Parse(masp);
                tl.Tensp = tensp;
                tl.Dongia = int.Parse(dongia);
                tl.Size = size;
                tl.Hinhanh = hinhanh;
                tl.Soluongton = int.Parse(soluongton);
                tl.MaNCC = Mancc;
                tl.MaLoaiSP = int.Parse(MaLoaisp);
                UpdateModel(tl);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = db.SanPhams.First(m => m.MaSP == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = db.SanPhams.Where(m => m.MaSP == id).First();
            db.SanPhams.DeleteOnSubmit(D_theloai);
            db.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }
    }
}