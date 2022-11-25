using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;


namespace TCC_2._0.Controllers
{
    [Authorize]
    public class ProTipoController : Controller
    {

        private readonly ApplicationDbContext bd;

        public ProTipoController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            ViewBag.tip = bd.TIPO.ToList();
            ViewBag.desp = bd.PRODUTO.ToList();
            return View(bd.PROTIPO.ToList());
        }

        [HttpGet]
        public ActionResult Criar()
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> CriarAsync(int produto, int tipo, string maximo, string minimo, string estoque, IFormFile imagem)
        {
            PROTIPO novoproduto = new PROTIPO();

            novoproduto.PROID = produto;
            novoproduto.TIPID = tipo;
            novoproduto.PTMAXIMO = Convert.ToInt32(maximo);
            novoproduto.PTMINIMO = Convert.ToInt32(minimo);
            novoproduto.PTESTOQUE = Convert.ToInt32(estoque);
            
            if (imagem != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                     await imagem.CopyToAsync(memoryStream);
                     novoproduto.PTIMAGEM = memoryStream.ToArray();
                }
            }

            bd.PROTIPO.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }
        


        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            PROTIPO prolocalizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, int produto, int tipo, string maximo, string minimo, string estoque)
        {
            PROTIPO proatualizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            proatualizar.PROID = produto;
            proatualizar.TIPID = tipo;
            proatualizar.PTMAXIMO = Convert.ToInt32(maximo);
            proatualizar.PTMINIMO = Convert.ToInt32(minimo);
            proatualizar.PTESTOQUE = Convert.ToInt32(estoque);


            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            bd.PROTIPO.Remove(proDeletar);
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
