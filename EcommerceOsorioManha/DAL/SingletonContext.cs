using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class SingletonContext
    {
        private static Context ctx;

        private SingletonContext() { }

        //Método de gerar uma Instancia de acesso ao banco
        #region GetInstance
        public static Context GetInstance()
        {
            if (ctx == null)
            {
                ctx = new Context();

            }
            return ctx;
        }
        #endregion

    }
}