using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddContact(Contact contact)
        {
            return await Task.Factory.StartNew<ActionResult>(() => RedirectToAction("Index"));   
        }
    }
}