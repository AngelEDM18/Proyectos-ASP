using MiModeloMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiModeloMVC.Controllers
{
    public class ClientesController : Controller
    {
        public static List<Clientes> empList = new List<Clientes> {
            new Clientes {
                    ID=1,
                    nombre="Angel",
                    FechaAlta=DateTime.Today.ToString(),
                    edad=20
                },

                new Clientes {
                    ID=2,
                    nombre="Patricia",
                    FechaAlta=DateTime.Today.ToString(),
                    edad=25
                },
        };
        // GET: Clientes
        private EmpDBContext db = new EmpDBContext();

        [OutputCache (CacheProfile = "Cache5Minutos")]

        public ActionResult Index()
        {
            var Clientes= from e in db.Clientes
                          orderby e.ID
                          select e;
            return View(Clientes);
        }

        [OutputCache (Duration =int.MaxValue, VaryByParam ="id")]
        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var Clientes = db.Clientes.SingleOrDefault(e => e.ID == id);
            return View(Clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Clientes emp = new Models.Clientes();
                emp.nombre = collection["Nombre"];
                DateTime jDate;
                DateTime.TryParse(collection["DOB"], out jDate);
                emp.FechaAlta = jDate.ToString();
                string edad = collection["edad"];
                emp.edad = Int32.Parse(edad);
                db.Clientes.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var Clientes = db.Clientes.Single(m => m.ID == id);
            return View(Clientes);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var Clientes = db.Clientes.Single(m => m.ID == id);
                if (TryUpdateModel(Clientes)) {
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(Clientes);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [NonAction]
        public List<Clientes> TodosLosClientes()
        {
            return new List<Clientes>
            {
                new Clientes {
                    ID=1,
                    nombre="Angel",
                    FechaAlta=DateTime.Today.ToString(),
                    edad=20
                },

                new Clientes {
                    ID=2,
                    nombre="Patricia",
                    FechaAlta=DateTime.Today.ToString(),
                    edad=25
                },
            };
        }
    }
}
