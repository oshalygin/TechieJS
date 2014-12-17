using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using TN.DAL;
using TN.Models;

namespace TN.Web.Controllers
{
    public class CommunityController : Controller
    {
        private TNDbContext db = new TNDbContext();
        //
        // GET: /Community/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(AnonymousSubscription model)
        {
            if (ModelState.IsValid)
            {
                db.AnonymousSubscriptions.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("RedirectingSubscription", "Redirect");
            }


            return View(model);
        }
	}
}