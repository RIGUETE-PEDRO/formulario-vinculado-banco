using System;
using System.Collections.Generic;
using System.Linq;

namespace ifesFood
{
    internal class ProdutoDAO
    {
        internal static List<Produto> ListarProdutos()
        {
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var lista = ctx.Produtos.ToList();

            return lista;
        }
    }
}