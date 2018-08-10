using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class CategoriaDAO
    {
        //Puxando o SingletonContext para instanciar a classe ctx
        public static Context ctx = SingletonContext.GetInstance();

        #region Listar Categorias
        public static List<Categoria> RetornarCategorias()
        {
            return ctx.Categorias.ToList();
        }
        #endregion

        #region Cadastar Categoria
        public static bool CadastrarCategoria(Categoria categoria)
        {
            if(BuscarByNome(categoria) == null)
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Buscar pelo Nome
        public static Categoria BuscarByNome(Categoria categoria)
        {
            return ctx.Categorias.FirstOrDefault(x => x.NomeCateg.Equals
            (categoria.NomeCateg));
        }
        #endregion

        #region Buscar Pelo Id
        public static Categoria BuscarCategoriaById(int? value)
        {
            return ctx.Categorias.FirstOrDefault(x => x.CategoriaId == value);
        }
        #endregion

        #region Alterar Categoria
        public static bool AlterarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaById(categoria.CategoriaId) == null)
            {
                ctx.Entry(categoria).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Remover Categoria
        public static void RemoverCategoria(int id)
        {
            Categoria categoria = new Categoria();
            categoria = BuscarCategoriaById(id);
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }
        #endregion
    }
}