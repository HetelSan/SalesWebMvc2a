using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departmemt> list = new List<Departmemt>();
            list.Add(new Departmemt { Id = 1, Name = "Electronics" });
            list.Add(new Departmemt { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
