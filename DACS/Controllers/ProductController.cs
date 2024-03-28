using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS.Models;

namespace DACS.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category);
            return View(courses.ToList());
        }
        public ActionResult LearnFree()
        {
            var courses = db.Courses.Where(p => p.CateID > 4);
            return View(courses.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Course course = db.Courses.FirstOrDefault(x => x.ID == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View("Details", course);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CateID = new SelectList(db.Categories, "Id", "Title");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Des,Price,Image,CateID")] Course course, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {   //Luu hinh vao Web Server
                if (Image != null)
                {
                    string path = Path.Combine(Server.MapPath("/Content/img-freeCourses/"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path);
                }
                //Luu hinh vao DB
                course.Image = "/Content/img-freeCourses/" + Path.GetFileName(Image.FileName);
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateID = new SelectList(db.Categories, "Id", "Title", course.CateID);
            return View(course);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateID = new SelectList(db.Categories, "Id", "Title", course.CateID);
            return View(course);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Des,Price,Image,CateID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateID = new SelectList(db.Categories, "Id", "Title", course.CateID);
            return View(course);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
