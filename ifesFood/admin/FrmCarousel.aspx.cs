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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                AtualizarDdlProdutos(ProdutoDAO.ListarProdutos());
            }
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
            carousel.ProdutoID = Convert.ToInt32(DdlProdutos.SelectedValue);

            txtTitulo.Value = "";
            txtDescricao.Value = "";
            DdlProdutos.SelectedIndex = 0;

            lblMensagem.InnerText = CarouselDAO.CadastrarCarousel(carousel);
        }
    }
}