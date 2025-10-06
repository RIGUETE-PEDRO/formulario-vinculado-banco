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
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var lista = ctx.Produtos.ToList();

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
                    ctx.SaveChanges() ;
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

        internal static string AlterarProduto(Produto produto)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    Produto produtoAlterado = ctx.Produtos.
                        FirstOrDefault(p => p.Id == produto.Id);
                    produtoAlterado.Descricao = produto.Descricao;  
                    produtoAlterado.Nome = produto.Nome;
                    produtoAlterado.Imagem = produto.Imagem;
                    produtoAlterado.Preco = produto.Preco;

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