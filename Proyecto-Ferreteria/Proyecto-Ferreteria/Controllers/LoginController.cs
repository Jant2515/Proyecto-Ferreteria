using System;
using Proyecto_Ferreteria.Models;
using Proyecto_Ferreteria.Logica;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto_Ferreteria.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string NCorreo, string NContrasena)
        {

            Usuario oUsuario = new Usuario();

            oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NContrasena);

            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }

            FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
            Session["Usuario"] = oUsuario;

            if (oUsuario.EsAdministrador == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Tienda");
            }


        }

        // GET: Login
        public ActionResult Registrarse()
        {
            return View(new Usuario() { Nombres = "", Apellidos = "", Correo = "", Contrasena = ""});
        }

        [HttpPost]
        public ActionResult Registrarse(string NNombres, string NApellidos, string NCorreo, string NContrasena, string NConfirmarContrasena)
        {
            Usuario oUsuario = new Usuario()
            {
                Nombres = NNombres,
                Apellidos = NApellidos,
                Correo = NCorreo,
                Contrasena = NContrasena,
                EsAdministrador = false
            };
                int idusuario_respuesta = UsuarioLogica.Instancia.Registrar(oUsuario);

                if (idusuario_respuesta == 0)
                {
                    ViewBag.Error = "Error al registrar";
                    return View();

                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
        }

    }
}