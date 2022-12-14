using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;

namespace TCC_2._0.Controllers
{

    [Authorize]


    public class ITENSENTRADAController : Controller
    {
        private readonly ApplicationDbContext bd;

        public ITENSENTRADAController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {



            ViewBag.entra = bd.ENTRADA.ToList();
            ViewBag.tipo = bd.PROTIPO.ToList();
            ViewBag.prod = bd.PRODUTO.ToList();
            ViewBag.tip = bd.TIPO.ToList();
            return View(bd.ITENSENTRADA.ToList());
        }

        public ActionResult Criar()
        {
            ViewBag.listaentra = bd.ENTRADA.ToList();
            ViewBag.listapt = bd.PROTIPO.ToList();
            ViewBag.listaprod = bd.PRODUTO.ToList();
            ViewBag.listatip = bd.TIPO.ToList();
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(int protipo,int entrada, int qtd, decimal preco)
        {
            ITENSENTRADA novoitensentrada = new ITENSENTRADA();

            novoitensentrada.PTID = protipo;
            novoitensentrada.ENTID = entrada;
            novoitensentrada.ITEQUANTIDADE = qtd;
            novoitensentrada.ITEPRECO = preco;
          

            

            bd.ITENSENTRADA.Add(novoitensentrada);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ITENSENTRADA Entlocalizar = bd.ITENSENTRADA.ToList().Where(x => x.ITEID == id).First();
            return View(Entlocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, int protipo, int entrada, int qtd, decimal preco)
        {
            ITENSENTRADA Entlocalizar = bd.ITENSENTRADA.ToList().Where(x => x.ITEID == id).First();
            Entlocalizar.PTID = protipo;
            Entlocalizar.ENTID = entrada;
            Entlocalizar.ITEQUANTIDADE = qtd;
            Entlocalizar.ITEPRECO = preco;
           


            bd.Entry(Entlocalizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            ITENSENTRADA itnDeletar = bd.ITENSENTRADA.ToList().Where(x => x.ITEID == id).First();
            return View(itnDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            ITENSENTRADA itndeletar = bd.ITENSENTRADA.ToList().Where(x => x.ITEID == id).First();
            bd.ITENSENTRADA.Remove(itndeletar);
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
