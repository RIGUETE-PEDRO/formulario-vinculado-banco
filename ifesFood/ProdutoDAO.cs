using System;
using System.Collections.Generic;
using System.Linq;

namespace ifesFood
{
    public class ProdutoDAO
    {
        public static string CadastrarProduto(Produto produto)
        {
            string mensagem = "";

            try
            {
                var ctx = new ifesFoodDBEntities();
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();

                mensagem = "O produto " + produto.Nome +
                    " foi cadastrado com sucesso!";

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }


            return mensagem;
        }

        public static List<Produto> ListarProdutos()
        {
            List<Produto> lista = null;

            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            lista = ctx.Produtos.ToList();

            return lista;
        }

        public static string ExcluirProduto(int id)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    Produto produto =
                        ctx.Produtos.FirstOrDefault(p => p.Id == id);
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

        public static Produto VisualizarProduto(int id)
        {
            Produto produto = null;

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
            }

            return produto;
        }

        internal static Produto ListarProdutos(int id)
        {
            Produto produto = null;
            using (var ctx = new ifesFoodDBEntities())
            {
                produto = ctx.Produtos.FirstOrDefault(
                    p => p.Id == id
                );
            }
            return produto;
        }

        internal static string AlterarProduto(Produto produto)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    var produtoBD = ctx.Produtos.FirstOrDefault(
                        p => p.Id == produto.Id
                    );

                    produtoBD.Nome = produto.Nome;
                    produtoBD.Descricao = produto.Descricao;
                    produtoBD.Imagem = produto.Imagem;
                    produtoBD.Preco = produto.Preco;
                    ctx.SaveChanges();
                    mensagem = "Produto alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }
            return mensagem;
        }
    }
}