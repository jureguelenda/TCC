using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;


namespace TCC_2._0.Controllers
{
    [Authorize]
    public class SaidaController : Controller
    {

        private readonly ApplicationDbContext bd;

        public SaidaController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            return View(bd.SAIDA.ToList());
        }

        public ActionResult Criar()
        {
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar( DateTime data)
        {
            SAIDA novasaida = new SAIDA();

            novasaida.SAIDATA = data;

            bd.SAIDA.Add(novasaida);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            SAIDA Sailocalizar = bd.SAIDA.ToList().Where(x => x.SAIID == id).First();
            return View(Sailocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id,DateTime data)
        {
            SAIDA Saiatualizar = bd.SAIDA.ToList().Where(x => x.SAIID == id).First();
            
            Saiatualizar.SAIDATA = data;


            bd.Entry(Saiatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            SAIDA saiDeletar = bd.SAIDA.ToList().Where(x => x.SAIID == id).First();
            return View(saiDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            SAIDA saiDeletar = bd.SAIDA.ToList().Where(x => x.SAIID == id).First();
            bd.SAIDA.Remove(saiDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("/Home/Erro");
            }



            return RedirectToAction("Index");
        }
    }
}
