using DAL;
using Entities;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoQueueSystem.Controllers
{
    public class DriverAppController : Controller
    {
        //private readonly IAutoBookInterface _autoBookDal;
        //public DriverAppController(IAutoBookInterface autoBookDal)
        //{
        //    _autoBookDal = autoBookDal;
        //}
        // GET: driverapp
        public ActionResult Index(int driverId)
        {
            AutoBookDAL autoBookDal = new AutoBookDAL();
            List<BookingStatus> driverRidesDetails = autoBookDal.GetDriverBookingStatus(driverId);

            return View("~/Views/BookingPages/DriverRidesPage.cshtml", driverRidesDetails);
        }
    }
}