using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Services.Description;

namespace ifesFood.admin
{
    public class CarouselDAO
    {
        private static string mensagem;

        public static string CadastrarCarousel(Carousel carousel)
        {
            string mensagem = "";

            try
            {
                ifesFoodDBEntities ctx = new ifesFoodDBEntities();
                ctx.Carousels.Add(carousel);
                ctx.SaveChanges();
                mensagem = "O caroucel foi cadastrado" ;

                
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string ExcluirProduto(int id)
        {
            string mensagem = "";
            try
            {
                using (var cx = new ifesFoodDBEntities())
                {
                    Carousel carousel = cx.Carousels.FirstOrDefault(p => p.Id == id);
                    if (carousel != null)
                    {
                        cx.Carousels.Remove(carousel);
                        cx.SaveChanges();
                        mensagem = "Produto excluído com sucesso!";
                    }
                    else
                    {
                        mensagem = "Produto não encontrado!";
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem; 
        }

        internal static List<Carousel> ListarProdutos(List<Produto> lista)
        {
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var ProdutosCarousel = ctx.Carousels.ToList();

            return ProdutosCarousel;
        }

       
    }
}