using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDataService employeeDataService;
        private readonly ILocationService locationService;
        public EmployeeController(IEmployeeDataService employeeDataService, ILocationService locationService)
        {
            this.employeeDataService = employeeDataService;
            this.locationService = locationService;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var cities = locationService.GetAllCities().ToDictionary(x => x.Id + "_" + x.StateId, y => y.Name);
            var states = locationService.GetAllStates().ToDictionary(x => x.Id, y => y.Name);
            var employess = employeeDataService.GetAll().Select(x =>
            {
                x.State = states.ContainsKey(x.StateId) ? states[x.StateId] : string.Empty;
                x.City = cities.ContainsKey(x.CityId + "_" + x.StateId) ? cities[x.CityId + "_" + x.StateId] : string.Empty;

                return x;
            }).ToList();
            return View(employess);
        }

        // GET: EmployeeController/Details/5
        public List<Employee.Model.City> Cities(int id)
        {
            return locationService.GetAllCities().Where(x=>x.StateId==id).ToList();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.States = locationService.GetAllStates(null);
            ViewBag.Cities = locationService.GetCitiesByState(null);
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee.Model.Employee employee)
        {
            try
            {

                employeeDataService.Add(employee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.States = locationService.GetAllStates(null);
                ViewBag.Cities = locationService.GetAllStates(null);
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {

            var employee = employeeDataService.GetAll().FirstOrDefault(x => x.Id == id);
            ViewBag.States = locationService.GetAllStates(employee.StateId);
            ViewBag.Cities = locationService.GetCitiesByState(employee.StateId, employee.CityId);
            return PartialView(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Model.Employee employee)
        {
            try
            {
                employee.Id = id;
                employeeDataService.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public bool Delete(int id)
        {
            employeeDataService.Remove(id);
            return true;
        }


    }
}
