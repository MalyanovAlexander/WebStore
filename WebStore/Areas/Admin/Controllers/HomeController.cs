using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService _productdata;

        public HomeController(IProductService productData)
        {
            _productdata = productData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            return View(_productdata.GetProducts(new ProductFilter()));
        }
    }
}
