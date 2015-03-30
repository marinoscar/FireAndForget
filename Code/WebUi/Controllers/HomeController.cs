using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUi.Helpers;
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
            return await Task.Factory.StartNew<ActionResult>(() =>
            {
                AddContactEntity(contact);
                return RedirectToAction("Index");
            });   
        }

        private void AddContactEntity(Contact contact)
        {
            var asyncJob = new WebAsyncJob();
            //Will execute the storage of the contact entity in the backgrod
            //and will return the control and free the thread
            asyncJob.Execute(Task.Factory.StartNew(() =>
            {
                var storageManager = new StorageManager();
                storageManager.Add(contact);
            }));
        }
    }
}