using System;
using System.Collections.Generic;
using System.Linq;

namespace ifesFood
{
    internal class ProdutoDAO
    {
        internal static string CadastrarProduto(Produto produto)
        {
            String mensagem = "";
            try
            {
                var ctx = new ifesFoodDBEntities();
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
                mensagem = "o Produto " + produto.Nome + "foi cadastrado com sucesso";
            }
            catch (Exception ex)
            {

                mensagem = ex.Message;
            }
            return mensagem;
        }

        internal static List<Produto> ListarProdutos()
        {
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var lista = ctx.Produtos.ToList();

            return lista;
        }
    }
}