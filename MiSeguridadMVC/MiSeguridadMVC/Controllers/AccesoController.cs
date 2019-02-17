using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiSeguridadMVC.Controllers
{
    [Authorize (Users ="tucorreo@tuotrocorre.com")]
    public class AccesoController : Controller
    {
        
        // GET: Acceso
        public ActionResult Privado()
        {
            return Content("Esta parte de la web es PRIVADA");
        }
        [AllowAnonymous]
        public ContentResult Publico()
        {
            return Content("Esta parte de la web es PUBLICA");
        }
    }
}