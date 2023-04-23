using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Ferreteria.Controllers
{
    public class NosotrosController : Controller
    {
        // GET: Nosotros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

    }
}