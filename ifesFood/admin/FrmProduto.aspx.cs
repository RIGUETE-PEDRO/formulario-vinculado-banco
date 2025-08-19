using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ifesFood.admin
{
    public partial class FrmProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
            }
        }

        private void AtualizarLvProdutos(List<Produto> produtos)
        {
            var lista = produtos.OrderByDescending(p => p.Nome);
            lvProdutos.DataSource = lista;
            lvProdutos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.Nome = txtNome.Value;
            produto.Descricao = txtDescricao.Value;
            produto.Imagem = txtImagem.Value;
            produto.Preco = Convert.ToDecimal(txtPreco.Value);
            produto.DataCadastro = DateTime.Now;

            String mensagem = ProdutoDAO.CadastrarProduto(produto);

            lblMensagem.InnerText = mensagem;

            AtualizarLvProdutos(ProdutoDAO.ListarProdutos());

        }
    }
}