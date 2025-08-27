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

        public static string ExcluirProduto(int id)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    Produto produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);
                    ctx.Produtos.Remove(produto);
                    ctx.SaveChanges();
                    mensagem = "Produto excluído com sucesso!";
                }
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

        internal static Produto VisualizarProduto(int id)
        {
            Produto produto = null;

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex) { }

            return produto;
        }
    }
}