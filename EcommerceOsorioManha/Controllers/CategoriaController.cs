using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class CategoriaController : Controller
    {

        // GET: Categoria

        #region View CadastrarCategoria
        public ActionResult IndexCategoria()
        {
            return View(CategoriaDAO.RetornarCategorias());
        }
        #endregion

        #region Pag Cadastrar Categoria
        public ActionResult CadastrarCategoria()
        {
            return View();
        }
        #endregion

        #region Cadastrando Categoria
        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("IndexCategoria", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Categoria já existente no Banco!");
                    return View(categoria);
                }
            }
            else
            {
                return View(categoria);
            }
        }
        #endregion

        #region Pag Alterar Categoria
        public ActionResult AlterarCategoria(int id)
        {
            return View(CategoriaDAO.BuscarCategoriaById(id));
        }
        #endregion

        #region Alterar Categoria
        [HttpPost]
        public ActionResult AlterarProduto(Categoria categoriaAlterada)
        {
            Categoria categoriaOriginal = CategoriaDAO.BuscarCategoriaById(categoriaAlterada.CategoriaId);
            categoriaOriginal.NomeCateg = categoriaAlterada.NomeCateg;
            categoriaOriginal.DescCategoria = categoriaAlterada.DescCategoria;



            if (ModelState.IsValid)
            {
                if (CategoriaDAO.AlterarCategoria(categoriaOriginal))
                {
                    return RedirectToAction("IndexCategoria", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Categoria com o mesmo nome já existente no Banco!");
                    return View(categoriaOriginal);
                }
            }
            else
            {
                return View(categoriaOriginal);
            }
            // ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
        }
        #endregion

        #region Remover Categoria
        public ActionResult RemoverCategoria(int id)
        {

            CategoriaDAO.RemoverCategoria(id);
            return RedirectToAction("IndexCategoria", "Categoria");
            //não esquecer de utilizar o RedirectToAction("Nome da página", "Controller") pois ao não utiliza-lo gerará uma excessão de arquivo não encontrado -> 404 not found
        }
        #endregion

    }
}