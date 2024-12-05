using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CarInsurance.Models;



namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        // Creates an instance of the database context.
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Home
        // Retrieves and displays a list of all insurees.
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

    }
}