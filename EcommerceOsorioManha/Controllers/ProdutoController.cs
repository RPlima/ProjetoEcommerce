using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {
        Context ctx = new Context();

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ctx.Produtos.ToList();
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, 
            string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            ctx.Produtos.Add(produto);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult RemoverProduto(int id)
        {
            Produto produto = new Produto();
            produto = ctx.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
            return RedirectToAction("Index", "Produto");
            //não esquecer de utilizar o RedirectToAction("Nome da página", "Model") pois ao não utiliza-lo gerará uma excessão de arquivo não encontrado

        }


        public ActionResult AlterarProduto(int id)
        {
            ViewBag.Produto = ctx.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(int txtid, string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
        
            Produto produto = ctx.Produtos.Where(x => x.ProdutoId == txtid).FirstOrDefault();
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            // ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }

    }
}