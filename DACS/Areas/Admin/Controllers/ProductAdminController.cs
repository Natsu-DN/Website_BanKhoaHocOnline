using DACS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DACS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var listProduct = db.Courses.Include(x=>x.Category).ToList();
            return View(listProduct);
        }
    }
}