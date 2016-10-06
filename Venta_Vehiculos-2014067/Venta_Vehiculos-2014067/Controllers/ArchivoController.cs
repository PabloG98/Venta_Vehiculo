using System.Web.Mvc;
using Venta_Vehiculos_2014067.Models;

namespace Venta_Vehiculos_2014067.Controllers
{
    public class ArchivoController : Controller
    {
        private DB_VEHICULO db = new DB_VEHICULO();
        // GET: Archivo
        public ActionResult Index(int id)
        {
            var ar = db.archivo.Find(id);
            return File(ar.contenido, ar.contentType);
        }
    }
}