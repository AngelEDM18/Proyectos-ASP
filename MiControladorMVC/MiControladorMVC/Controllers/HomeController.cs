using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiControladorMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public String Index()
        {
            return "Hola Pepe";
        }

        [ActionName("hora")]
       // [Authorize(Roles ="Admin")]
        // [OutputCache(Duration =10)]
        public string horaActual()
        {
            return CadenaHora();
        }
        [NonAction]
        public string CadenaHora()
        {
            return DateTime.Now.ToString("T");
        }

    }
}