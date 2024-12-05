 using System;
 using System.Data.Entity;
 using System.Linq;
 using System.Net;
using System.Web.Mvc;
 using CarInsurance.Models;


namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // Instance of the database context.
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Admin
        // Displays the list of all insurees.
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Admin/Details/5
        // Displays details of a specific insuree.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find/*r*/(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }


        // GET: Admin/Create
        // Displays the form to create a new insuree.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // Creates a new insuree.
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Calculate the quote for the insuree.
                insuree.Quote = QuoteCalculator.CalculateQuote(insuree);
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Admin/Edit/5
        // Displays the form to edit an existing insuree.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Admin/Edit/5
        // Edits an existing insuree.
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Calculate the quote for the insuree.
                insuree.Quote = QuoteCalculator.CalculateQuote(insuree);
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Admin/Delete/5
        // Displays the form to delete an existing insuree.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Admin/Delete/5
        // Deletes an existing insuree.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
