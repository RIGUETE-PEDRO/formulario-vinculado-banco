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
        private string mensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());

                string cod = Request.QueryString["cod"];
                if (cod != null)
                {
                    int id = int.Parse(cod);
                    Produto produto = ProdutoDAO.VisualizarProduto(id);
                    MostrarDadosProduto(produto);
                }
            }
        }

        private void MostrarDadosProduto(Produto produto)
        {
            txtDescricao.Value = produto.Descricao;
            txtDescricao.Value = produto.Descricao;
            txtNome.Value = produto.Nome;
            txtImagem.Value = produto.Imagem;
            txtPreco.Value = produto.Preco.ToString();


            txtDescricao.Disabled = true;
            txtNome.Disabled = true;
            txtImagem.Disabled = true;
            txtPreco.Disabled = true;

            btnCadastrar.Visible = false;
            btnLimpar.Visible = false;
            btnAddProduto.Visible = true;
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

            LimparCampos(mensagem);



            AtualizarLvProdutos(ProdutoDAO.ListarProdutos());


        }

        private void LimparCampos(string mesagem)
        {
            lblMensagem.InnerText = mensagem;
            txtNome.Value = "";
            txtDescricao.Value = "";
            txtImagem.Value = "";
            txtPreco.Value = "";
        }

        protected void lvProdutos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string command = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (command == "Deletar")
            {
                string mensagem = ProdutoDAO.ExcluirProduto(id);
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
                lblMensagem.InnerText = mensagem;
            }
            else if (command == "Visualizar")
            {
                Response.Redirect("~/admin/FrmProduto.aspx?cod=" + id);
            }
            else if (command == "Editar")
            {
            }
        }
    }
}