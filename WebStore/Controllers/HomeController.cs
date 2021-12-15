using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        [SimpleActionFilter]
        public IActionResult Index()
        {
            //throw new ApplicationException("Ooooops...");
            //return Content("Hello!");
            //return new EmptyResult();
            //return new FileContentResult();
            //return new NotFoundResult();
            //return new JsonResult("");
            //return PartialView("_Partial/Cart");
            //return RedirectToAction("Blog");
            //return new RedirectResult("http://google.com");
            //return StatusCode(500);
            return View();
        }
        
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
