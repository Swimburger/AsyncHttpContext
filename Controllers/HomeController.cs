using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncHttpContext.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IncrementWithStaticSession()
        {
            MyStaticSessionWrapper.Counter++;
            return View("Index");
        }

        public async Task<ActionResult> IncrementWithStaticSessionAsync()
        {
            await Task.Run(() =>
            {
                MyStaticSessionWrapper.Counter++;
            });
            return View("Index");
        }

        public ActionResult Increment()
        {
            var mySession = new MySessionWrapper(Session);
            mySession.Counter++;
            return View("Index");
        }

        public async Task<ActionResult> IncrementAsync()
        {
            await Task.Run(() =>
            {
                var mySession = new MySessionWrapper(Session);
                mySession.Counter++;
            });
            return View("Index");
        }

        public ActionResult IncrementWithExtensionMethods()
        {
            Session.SetCounter(Session.GetCounter() + 1);
            return View("Index");
        }

        public async Task<ActionResult> IncrementWithExtensionMethodsAsync()
        {
            await Task.Run(() =>
            {
                Session.SetCounter(Session.GetCounter() + 1);
            });
            return View("Index");
        }
    }
}