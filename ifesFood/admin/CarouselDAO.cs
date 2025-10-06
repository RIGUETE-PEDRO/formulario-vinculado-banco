using System;
using System.Collections.Generic;
using System.Linq;

namespace ifesFood.admin
{
    public class CarouselDAO
    {
        public static string CadastrarCarousel(Carousel carousel)
        {
            string mensagem = "";

            try
            {
                ifesFoodDBEntities ctx = new ifesFoodDBEntities();
                ctx.Carousels.Add(carousel);
                ctx.SaveChanges();

                mensagem = "Carousel cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        public static string AlterarCarousel(Carousel carousel)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    var carouselBD = ctx.Carousels.FirstOrDefault(c => c.Id == carousel.Id);
                    carouselBD.Descricao = carousel.Descricao;
                    
                    string titulo = carouselBD.Titulo;
                    carouselBD.Titulo = carousel.Titulo;    
                    carouselBD.Destaque = carousel.Destaque;
                    carouselBD.ProdutoID = carousel.ProdutoID;

                    ctx.SaveChanges();
                    mensagem = "Carousel " + titulo + " alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }


            return mensagem;
        }

        internal static string ExcluirCarousel(int id)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    Carousel carousel = ctx.Carousels.FirstOrDefault(
                            c => c.Id == id
                        );

                    ctx.Carousels.Remove(carousel);
                    ctx.SaveChanges();
                    mensagem = "Carousel excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static List<Carousel> ListarCarousels()
        {
            List<Carousel> lista = null;

            var ctx = new ifesFoodDBEntities();
            lista = ctx.Carousels.ToList();

            return lista;
        }

        internal static Carousel ListarCarousels(int id)
        {
            Carousel carousel = null;

            using (var ctx = new ifesFoodDBEntities())
            {
                carousel = ctx.Carousels.FirstOrDefault(
                    c => c.Id == id
                ); 
            } 
            
            return carousel;
        }
    }
}