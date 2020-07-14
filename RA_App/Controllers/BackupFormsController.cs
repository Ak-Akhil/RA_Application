//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
//using RA_App.Models;

//namespace RA_Application.Controllers
//{
//    public class FormsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Forms

//        [Authorize(Roles = "Admin")]
//        public ActionResult Index()
//        {
//            return View(db.Forms.ToList());
//        }

//        // GET: Forms/Details/5
//        [Authorize(Roles = "Admin")]
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Form form = db.Forms.Find(id);
//            if (form == null)
//            {
//                return HttpNotFound();
//            }
//            return View(form);
//        }

//        // GET: Forms/Create
//        [Authorize(Roles = "Admin, RA")]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Forms/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ID,TOR,StudName,StudSurname,StudNo,YOS,ContactNo,NatureOf_II,Dateof_II,DateReported_II,Details_II,ActionsTaken,Recommendations,ResidenceAdvisor")] Form form)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Forms.Add(form);
                
//                string currentUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//                if (string.IsNullOrWhiteSpace(currentUserName))
//                {
//                    currentUserName = User.Identity.Name;
//                }

//                var currentUser = (from u in db.Users
//                                   where u.UserName.Equals(currentUserName)
//                                   select u).FirstOrDefault();
//                form.UserName = currentUser.UserName;
//                form.Emp_Name = currentUser.Emp_Name;

//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }




//            return View(form);
//        }

//        // GET: Forms/Edit/5
//        [Authorize(Roles = "Admin")]
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Form form = db.Forms.Find(id);
//            if (form == null)
//            {
//                return HttpNotFound();
//            }
//            return View(form);
//        }

//        // POST: Forms/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [Authorize(Roles = "Admin")]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,TOR,StudName,StudSurname,StudNo,YOS,ContactNo,NatureOf_II,Dateof_II,DateReported_II,Details_II,ActionsTaken,Recommendations,ResidenceAdvisor")] Form form)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(form).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(form);
//        }

//        // GET: Forms/Delete/5
//        [Authorize(Roles = "Admin")]
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Form form = db.Forms.Find(id);
//            if (form == null)
//            {
//                return HttpNotFound();
//            }
//            return View(form);
//        }

//        // POST: Forms/Delete/5



//        [Authorize(Roles = "Admin")]
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Form form = db.Forms.Find(id);
//            db.Forms.Remove(form);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
