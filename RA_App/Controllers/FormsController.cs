using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RA_App.Models;

namespace RA_App.Controllers
{
    public class FormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forms
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }

        [Authorize(Roles = "Admin, RA")]
        public ActionResult MyIndex()
        {
            string currentUserName = User.Identity.Name;


            var all = (from p in db.Forms
                       where p.UserName == currentUserName
                       select p);

            var MyName = (from p in db.Users
                       where p.UserName == currentUserName
                       select p.Emp_Name).FirstOrDefault();
            if (MyName != null)
            {
               ViewBag.MyName = MyName.ToString();
            }
            return View(all.ToList());


        }

        // GET: Forms/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        [Authorize(Roles = "Admin, RA")]
        public ActionResult MyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // GET: Forms/Create
        [Authorize(Roles = "Admin, RA")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, RA")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TOR,StudName,StudSurname,StudNo,YOS,ContactNo,NatureOf_II,Dateof_II,DateReported_II,Details_II,ActionsTaken,Recommendations,UserName,Emp_Name")] Form form)
        {
            if (ModelState.IsValid)
            {
                string currentUserName = User.Identity.Name;
                

                var currentUser = (from u in db.Users
                                   where u.UserName.Equals(currentUserName)
                                   select u).FirstOrDefault();

                form.UserName = currentUser.UserName;
                form.Emp_Name = currentUser.Emp_Name + " " + currentUser.Emp_Surname;
            
                db.Forms.Add(form);
                db.SaveChanges();
                return RedirectToAction("MyIndex");
            }

            return View(form);
        }

        // GET: Forms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TOR,StudName,StudSurname,StudNo,YOS,ContactNo,NatureOf_II,Dateof_II,DateReported_II,Details_II,ActionsTaken,Recommendations,UserName,Emp_Name")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        // GET: Forms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        public ActionResult Statistics()
        {
            //Shows total number of Reports in Db
            int total = (from p in db.Forms
                         select p).Count();

            ViewBag.total = total.ToString();


            //Shows Total number of RAs 

            var roles = db.Roles.Where(r => r.Name == "RA");
            if (roles.Any())
            {


                var roleId = roles.First().Id;
                int totRA = (from r in db.Users
                             where r.Roles.Any(k => k.RoleId == roleId)
                             select r).Count();

                ViewBag.totRA = totRA.ToString();

                //Gets array of all RAs in the database

                var RAA = roles.First().Id;
                var RAs = (from a in db.Users
                           where a.Roles.Any(k => k.RoleId == RAA)
                           select a).ToList();

                ViewBag.RAs = RAs.Count();


                //Shows number of reports per RA

                List<RA> NumRepRA = new List<RA>();


                foreach (var RA in RAs)
                {
                    RA ra = new RA();

                    ra.UserName = RA.Emp_Name + " " + RA.Emp_Surname;

                    int totReportsPerPA = (from k in db.Forms
                                           where k.UserName == RA.UserName
                                           select k).Count();

                    ra.NumberOfReports = totReportsPerPA;

                    NumRepRA.Add(ra);

                }

                ViewBag.NumRepRA = NumRepRA;


            }



            //Shows Total number of Types of Reports (Incident)
            int totTorInc = (from k in db.Forms
                             where k.TOR == "Incident"
                             select k).Count();

            ViewBag.totTorInc = totTorInc;

            //Shows Total number of Types of Reports (Illness)
            int totTorIll = (from k in db.Forms
                             where k.TOR == "Illness"
                             select k).Count();

            ViewBag.totTorIll = totTorIll;


            //Shows Total number of Reports for first year students
            int totFirstyear = (from n in db.Forms
                                where n.YOS == 1
                                select n).Count();

            ViewBag.totFirstyear = totFirstyear.ToString();

            //Shows Total number of Reports for second year students
            int totSecondyear = (from n in db.Forms
                                 where n.YOS == 2
                                 select n).Count();

            ViewBag.totSecondyear = totSecondyear.ToString();

            //Shows Total number of Reports for third year students
            int totThirdyear = (from n in db.Forms
                                where n.YOS == 3
                                select n).Count();

            ViewBag.totThirdyear = totThirdyear.ToString();


            //Shows Total number of Reports for Fourth year students
            int totFourthyear = (from n in db.Forms
                                 where n.YOS == 4
                                 select n).Count();

            ViewBag.totFourthyear = totFourthyear.ToString();

            //Shows Total number of Reports for Fifth year students
            int totFifthyear = (from n in db.Forms
                                where n.YOS == 5
                                select n).Count();

            ViewBag.totFifthyear = totFifthyear.ToString();










            return View();
        }

        // POST: Forms/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Form form = db.Forms.Find(id);
            db.Forms.Remove(form);
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
