﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;

namespace TCC_2._0.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ApplicationDbContext bd;

        public ProdutoController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            // select * from produto
            return View(bd.PRODUTO.ToList());
        }
        // GET: Criar
        public ActionResult Criar()
        {
            ViewBag.listaCategoria = bd.CATEGORIA.ToList();
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        [HttpPost]
       /* public ActionResult Criar(string descricao, int categoria, HttpPostedFileBase imagem)
        {
            PRODUTO novoproduto = new PRODUTO();

            novoproduto.PRODESCRICAO = descricao;
            novoproduto.CATID = categoria;
            using (var memoryStream = new MemoryStream())
            {
                imagem.InputStream.CopyTo(memoryStream);
                novoproduto.PROIMAGEM = memoryStream.ToArray();
            }

            bd.PRODUTO.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }
        */



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ViewBag.listaCategoria = bd.CATEGORIA.ToList();
            PRODUTO prolocalizar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao, int categoria)
        {
            PRODUTO proatualizar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            proatualizar.PRODESCRICAO = descricao;
            proatualizar.CATID = categoria;


            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            PRODUTO proDeletar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            PRODUTO proDeletar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            bd.PRODUTO.Remove(proDeletar);
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

