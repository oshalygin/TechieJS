using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TN.DAL;
using TN.Models;

namespace TN.Web.Controllers
{
    public class GuestsController : Controller
    {
        //
        // GET: /Guests/
        public ActionResult Index()
        {
            using (IdentityContext db = new IdentityContext())
            {
                ViewBag.Title = "Guest List";
                var guestList = GetGuestList();
                return View(guestList);

            }

        }

        public List<GuestListViewModel> GetGuestList()
        {
            using (IdentityContext db = new IdentityContext())
            {
                var guests = from users in db.Users
                             orderby users.JoinDate
                             select new GuestListViewModel
                             {
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 JoinDate = users.JoinDate,
                                 Logins = users.Logins
                             };

                return guests.ToList<GuestListViewModel>();
            }
        }

    }
}