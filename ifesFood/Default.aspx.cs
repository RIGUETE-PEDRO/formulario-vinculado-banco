using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ifesFood
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var lista = ProdutoDAO.ListarProdutos();
                AtualizarLvProdutos(lista);
            }
        }

        private void AtualizarLvProdutos(List<Produto> lista)
        {
            lvProdutos.DataSource = lista;
            lvProdutos.DataBind();
        }
    }
}