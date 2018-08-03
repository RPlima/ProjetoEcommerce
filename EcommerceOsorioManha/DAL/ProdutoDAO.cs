using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = new Context();

        public static List<Produto> ReturnProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public static void CadastrarProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();

        }


        public static void RemoverProduto(int id)
        {
            Produto produto = new Produto();
            produto = BuscarProduto(id);
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
        }

        public static Produto BuscarProduto(int id)
        {
            return ctx.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
        }

        public static void AlterarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        

    }
}