using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FARMAPLUS.Models;
using FARMAPLUS.VM;


namespace FARMAPLUS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Empleados(String empleado = "", Boolean office = false)
        {
            var viewModel = new CEVM
            {
                Empleados = new List<Empleado>
                {

                }
            };

            if (HttpContext.Application["CitasEmpleado"] != null)
            {
                viewModel = (CEVM)HttpContext.Application["CitasEmpleado"];
            }

            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Empleados(string name)
        {
            var viewModel = (CEVM)HttpContext.Application["CitasEmpleado"];
            viewModel.Empleados.Add(new Empleado
            {
                Nombre = name,
                Hours = 0,
                Estadia = false,
                Citas = new List<Cita>(0)
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Citas( String z)
        {
            var viewModel = new CEVM
            {
                Empleados = new List<Empleado>
                {

                }
            };

            if (HttpContext.Application["CitasEmpleado"] != null)
            {
                viewModel = (CEVM)HttpContext.Application["CitasEmpleado"];
            }

            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Citas()
        {
            var viewModel = (CEVM)HttpContext.Application["CitasEmpleado"];
            Random rnd = new Random();
            foreach (var empleado in viewModel.Empleados)
            {
                var nCitas = rnd.Next(1, 3);
                for (int o = 0; o < nCitas; o++)
                {
                    TimeSpan tSpan = new TimeSpan(2 * o, 0, 0);
                    empleado.Citas.Add(new Cita { Client = "Cliente " + o, DateTime = DateTime.Now + tSpan });
                }
            }
            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }









    }
}