using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ifesFood.admin
{
    public partial class FrmCarousel : System.Web.UI.Page
    {
        private List<Produto> lista; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarDdlProdutos(ProdutoDAO.ListarProdutos());
                string cod = Request.QueryString["cod"];
                lista = ProdutoDAO.ListarProdutos(); 
                AtualizarLvCarouselComProdutos(CarouselDAO.ListarProdutos(lista));


                if (cod != null)
                {
                    int id = int.Parse(cod);
                    Carousel carousel = CarouselDAO.ListarProdutos(lista).FirstOrDefault(c => c.Id == id);
                    MostrarDadosCarousel(carousel);


                }
            }
        }

        private void MostrarDadosCarousel(Carousel carousel)
        {

            txtTitulo.Value = carousel.Titulo;
            txtDescricao.Value = carousel.Descricao;
            DdlProdutos.SelectedValue = carousel.ProdutoID.ToString();
            cbDestaque.Disabled = true;
            if ((bool)carousel.Destaque) cbDestaque.Checked = true;
            txtTitulo.Disabled = true;
            txtDescricao.Disabled = true;
            DdlProdutos.Enabled = false;
           
            btnCadastrar.Visible = false;
            
        }

        private void AtualizarDdlProdutos(List<Produto> produtos)
        {
            DdlProdutos.DataSource = produtos.OrderBy(p => p.Nome);
            DdlProdutos.DataTextField = "Nome";
            DdlProdutos.DataValueField = "Id";

            DdlProdutos.DataBind();
            DdlProdutos.Items.Insert(0, "Selecione um produto");


        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Carousel carousel = new Carousel();
            carousel.Titulo = txtTitulo.Value;
            carousel.Descricao = txtDescricao.Value;
            


            var destaque = cbDestaque.Checked;
            if (destaque) carousel.Destaque = true;

            txtTitulo.Value = "";
            txtDescricao.Value = "";
            DdlProdutos.SelectedIndex = 0;

            lblMensagem.InnerText = CarouselDAO.CadastrarCarousel(carousel);
        }

        protected void lvCarousel_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string command = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (command == "Deletar")
            {
                string mensagem = CarouselDAO.ExcluirProduto(id);
                AtualizarLvCarouselComProdutos(CarouselDAO.ListarProdutos(lista));
                lblMensagem.InnerText = mensagem;
            }
            else if (command == "Visualizar")
            {
                Response.Redirect("~/admin/FrmCarousel.aspx?cod=" + id);
            }
            else if (command == "Editar")
            {
            }
        }

        private void AtualizarLvCarouselComProdutos(object value)
        {
            var lista = (List<Carousel>)value;
            lvCarousel.DataSource = lista;
            lvCarousel.DataBind();
        }
    }
}