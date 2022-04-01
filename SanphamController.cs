using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace FastFood.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        Mydata mydata = new Mydata();

        public ActionResult ListSanpham(int? MaLoaiSP, int? page)
        {
            var lstsanpham = mydata.SanPhams.ToList();
            int PageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.MaLoaiSP = MaLoaiSP;
          
            return View(lstsanpham.OrderBy(n => n.MaSP).ToPagedList(pageNumber, PageSize));
        }
       
    }
}