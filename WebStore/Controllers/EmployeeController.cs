using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    //employee
    [Route("users")]
    //users
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        //employee/index
        [Route("all")]
        //users/all
        public IActionResult Index()
        {
            //return Content("Hello from controller!");
            return View(_employeesService.GetAll());
        }

        //employee/details/id
        [Route("{id}")]
        //users/id
        public IActionResult Details(int id)
        {
            var employee = _employeesService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}
