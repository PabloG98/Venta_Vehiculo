using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Venta_Vehiculos_2014067.Models;
using System.Data.Entity.Infrastructure;

namespace Venta_Vehiculos_2014067.Controllers
{
    public class VehiculoController : Controller
    {
        private DB_VEHICULO db = new DB_VEHICULO();

        // GET: Vehiculo
        public ActionResult Index(String ordenFiltro, String busqueda)
        {
            ViewBag.ordenarNombre = String.IsNullOrEmpty(ordenFiltro) ? "nom_desc" : "";
            var usuario = db.vehiculo.Include(c => c.idVehiculo);
            if (!String.IsNullOrEmpty(busqueda))
            {
                usuario = usuario.Where(l => l.Modelo.Contains(busqueda) || l.Color.Contains(busqueda) || l.tipoCombustible.Contains(busqueda) || l.precio.Contains(busqueda));
            }
            usuario = usuario.OrderBy(l => l.idMarca);
            switch (ordenFiltro)
            {
                case "nom_desc":
                    usuario = usuario.OrderByDescending(l => l.idMarca);
                    break;
            }
            return View(db.vehiculo.ToList());
        }

        public ActionResult IndexUsuario()
        {

            var usuario = db.vehiculo.Include(c => c.idVehiculo);
            return View(db.vehiculo.ToList());
        }
        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create(Marca marca)
        {
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "nombre");
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVehiculo,Modelo,Color,tipoCombustible,precio,idMarca")] Vehiculo vehiculo, HttpPostedFileBase archivo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        var imagen = new Archivo
                        {
                            nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipoDeArchvio = FileType.Imagen,
                            contentType = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        };
                        vehiculo.foto = new List<Archivo> { imagen };
                    }
                    db.vehiculo.Add(vehiculo);
                db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException ex)
            {
                ModelState.AddModelError("", "Imposible guardar información. Intente de nuevo, si el problema sigue contacte a su administrador.");
            }
            ViewBag.idRol = new SelectList(db.vehiculo, "idVehiculo", "nombre", vehiculo.idMarca);
            return View();
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVehiculo,Modelo,Color,tipoCombustible,precio")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.vehiculo.Find(id);
            db.vehiculo.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
