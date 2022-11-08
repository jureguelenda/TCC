using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;


namespace TCC_2._0.Controllers
{
    public class TipoController : Controller
    {

        private readonly ApplicationDbContext bd;

        public TipoController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
