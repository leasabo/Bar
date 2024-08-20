using Bar.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Web.Controllers
{
    public class WaiterController : Controller
    {
        private readonly AppDbContext _db;
        public WaiterController(AppDbContext db)
        {
            _db = db;
        }

        //NOTE: una interfaz es una abstracción flexible y útil
        // que permite a los controladores devolver varios tipos de resultados
        public IActionResult Index()
        {
            return View();
        }
        //NOTE: Interfaz en NetCore: tipo de contrato que define
        // un conjunto de miembros (métodos, propiedades, eventos)
    }
}
