using CascadeDemo.Data;
using CascadeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CascadeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppDb _context;
        public HomeController(ILogger<HomeController> logger,MyAppDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employee
                .Include(x=>x.Country)
                .Include(x => x.State)
                .Include(x=>x.City)
                .ToList(); 
            return View(employees);
        }


        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            
                _context.Employee.Add(emp);
                _context.SaveChanges();
                TempData["Msg"] = "Data Insert Successfully!";
                return RedirectToAction("Index");
            
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            //ViewBag.countrylist = _context.Country.ToList();
            //ViewBag.countrylist = new SelectList(_context.Country, "CountryId", "CountryName");
            //ViewBag.Statelist = new SelectList(_context.State, "StateId", "StateName");
            //ViewBag.citylist = new SelectList(_context.City, "CityId", "CityName");

            return View(data);
        }
        public IActionResult Edit(Employee emp ,int id)
        {
            
            var data = _context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            if (data != null) {
                data.FirstName = emp.FirstName;
                data.LastName = emp.LastName;
                data.Age = emp.Age;
                data.Gender = emp.Gender;
                data.Email = emp.Email;
                data.Phone = emp.Phone;
                data.CountryId = emp.CountryId;
                data.StateId = emp.StateId;
                data.CityId = emp.CityId;

                _context.Employee.Update(data);
                _context.SaveChanges();
                TempData["Msg"] = "Update Successfully!";
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            if(data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
                TempData["Msg"] = "Delete Successfuly!";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult GetCountry()
        {
            var data = _context.Country.OrderBy(x => x.CountryName).ToList();

            return Json(data);
        }

        public IActionResult GetState(int id)
        {
            var data = _context.State.Where(x => x.Country.CountryId == id).ToList(); 
            return Json(data);
        }

        public IActionResult GetCity(int id)
        {
            var data = _context.City.Where(x => x.State.StateId == id).ToList();
            return Json(data);
        }


        
    }
}
