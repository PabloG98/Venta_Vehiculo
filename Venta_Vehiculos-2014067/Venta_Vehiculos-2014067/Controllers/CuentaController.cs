using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta_Vehiculos_2014067.Models;

namespace Venta_Vehiculos_2014067.Controllers
{
    public class CuentaController : Controller
    {
        public DB_VEHICULO db = new DB_VEHICULO();
        // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.correo == usuario.correo && u.contrasena == usuario.contrasena);
            if (usr != null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Verifique sus credenciales: Usuario o contraseña incorrecta");
            }
            return View();
        }

        // GET: Cuenta
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Rol rol = db.rol.FirstOrDefault(r=> r.idRol==2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " fue registrado correctamento";
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"].Equals(1))
            {
                return RedirectToAction("../Home/Index");
            }

            else if (Session["idUsuario"].Equals(3))
            {
                return RedirectToAction("../Usuario/IndexUsuario");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }
            
   }
}
