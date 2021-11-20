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

        /// <summary>
        /// Открыть страницу для редактирования сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employeesService.GetById(id.Value);
            if (model == null)
                return NotFound(); //возвращаем результат 404 not found

            return View(model);
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Age < 18 || model.Age > 100)
            {
                ModelState.AddModelError("Age", "Ошибка возраста");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id > 0)           //если есть id, то редактируем модель
            {
                var dbItem = _employeesService.GetById(model.Id);

                if (dbItem is null)
                    return NotFound();  // возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = model.Position;
            }
            else                        //иначе добавляем модель в список
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit(); //станет актуальным когда добавим БД

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
