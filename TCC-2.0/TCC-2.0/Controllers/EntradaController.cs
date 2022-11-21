using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;

namespace TCC_2._0.Controllers
{
    [Authorize]
    public class EntradaController : Controller
    {


        private readonly ApplicationDbContext bd;

        public EntradaController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            return View(bd.ENTRADA.ToList());
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
        public ActionResult Criar(string origem, string observacao, DateTime data)
        {
            ENTRADA novaentrada = new ENTRADA();

            novaentrada.ENTORIGEM = origem;
            novaentrada.ENTOBSERVACAO = observacao;
            novaentrada.ENTDATA = data;

            bd.ENTRADA.Add(novaentrada);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ENTRADA Entlocalizar = bd.ENTRADA.ToList().Where(x => x.ENTID == id).First();
            return View(Entlocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string origem, string observacao, DateTime data)
        {
            ENTRADA Entatualizar = bd.ENTRADA.ToList().Where(x => x.ENTID == id).First();
            Entatualizar.ENTORIGEM = origem;
            Entatualizar.ENTOBSERVACAO = observacao;
            Entatualizar.ENTDATA = data;


            bd.Entry(Entatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            ENTRADA entDeletar = bd.ENTRADA.ToList().Where(x => x.ENTID == id).First();
            return View(entDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            ENTRADA entDeletar = bd.ENTRADA.ToList().Where(x => x.ENTID == id).First();
            bd.ENTRADA.Remove(entDeletar);
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
