using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Twitter.BLL;
using Twitter.BLL.JsonTypes;


namespace TN.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IOAuthTwitterWrapper _oAuthTwitterWrapper;

        public TestController(IOAuthTwitterWrapper oAuthTwitterWrapper)
        {
            _oAuthTwitterWrapper = oAuthTwitterWrapper;
        }

        
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        public JsonResult GetTwitterFeed()
        {
            

            return Json(_oAuthTwitterWrapper.GetMyTimeline(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Deserialized()
        {
            var json = _oAuthTwitterWrapper.GetMyTimeline();
            var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);
            return View(result);
        }

        public ActionResult DeserializedSearch()
        {
            var json = _oAuthTwitterWrapper.GetSearch();
            var result = JsonConvert.DeserializeObject<Search>(json);
            return View(result);
        }
    }
}
