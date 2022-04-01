using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFood.Controllers
{
    public class NguoidungController : Controller
    {
        // GET: Nguoidung
        Mydata mydata = new Mydata();
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, TaiKhoan tk)
        {
            var tentk= collection["Tên Tài tkoản"];
            
            var matkhau = collection["matkhau"];
            var MatkhauXacNhan = collection["MatkhauXacNhan"];
            var email = collection["email"];
          
            if (String.IsNullOrEmpty(MatkhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật tkẩu xác nhận!";
            }
            else
            {
                if (matkhau!=MatkhauXacNhan)
                {
                    ViewData["MattkauGiongNhau"] = "Mật tkẩu và mật tkẩu xác nhận phải giống nhau";
                }
                else
                {
                    tk.TenTK = tentk;
                  
                    tk.MatKhau = matkhau;
                    tk.Email = email;
                   
                    mydata.TaiKhoans.Add(tk);
                    mydata.SaveChanges();
                    return RedirectToAction("DangNhap","Nguoidung");
                }
            }
            return this.DangKy();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tentk = collection["tentk"];
            var mattkhau = collection["mattkhau"];

            TaiKhoan tk = mydata.TaiKhoans.SingleOrDefault(n=> n.TenTK==tentk || n.MatKhau== mattkhau );
            if (tk != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                Session["Taikhoan"] = tk;
            }
            else
            {
                ViewBag.ThongBao = "Ten đăng nhập hoặc mật tkẩu tkông đúng";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}