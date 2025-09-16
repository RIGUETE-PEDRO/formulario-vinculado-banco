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

                string cod = Request.QueryString["cod"];
                if (cod != null)
                {
                    int id = int.Parse(cod);
                    Produto produto = ProdutoDAO.VisualizarProduto(id);
                    MostrarDadosProduto(produto,true);
                }
            }

        }

        private void MostrarDadosProduto(Produto produto, bool visualizar)
        {
           
            txtDescricao.Value = produto.Descricao;
            txtNome.Value = produto.Nome;
            txtImagem.Value = produto.Imagem;
            txtPreco.Value = produto.Preco.ToString();
            txtId.Value = produto.Id.ToString();



            if (visualizar) { DesabilitarCampos(); }
        

       
        }

            private void DesabilitarCampos()
        {
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
            var lista = produtos.OrderBy(p => p.Nome);
            lvProdutos.DataSource = lista;
            lvProdutos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            bool alterar = btnCadastrar.Text.ToUpper() == "ALTERAR";

            Produto produto = null;
            if (!alterar)
            {
                produto = new Produto(); 
            }
            else
            {
                int id = Convert.ToInt32(txtId.Value);
                produto = ProdutoDAO.ListarProdutos(id);
            }
           
            produto.Nome = txtNome.Value;
            produto.Descricao = txtDescricao.Value;
            produto.Imagem = txtImagem.Value;
            produto.Preco = Convert.ToDecimal(txtPreco.Value);
            produto.DataCadastro = DateTime.Now;


            if (!alterar)
            {
                lblMensagem.InnerText = ProdutoDAO.CadastrarProduto(produto);
            }
            else {
                lblMensagem.InnerText = ProdutoDAO.AlterarProduto(produto);

            }
           

            LimparCampos(mensagem);

            AtualizarLvProdutos(ProdutoDAO.ListarProdutos());

            txtDescricao.Value = "";
            txtImagem.Value = "";
            txtNome.Value = "";
            txtPreco.Value = "";

            btnAddProduto.Visible = false;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.CssClass = "";
            btnLimpar.CssClass = "btn-secondary";

        }

        private void LimparCampos(string mensagem)
        {
            lblMensagem.InnerText = mensagem;
            txtDescricao.Value = "";
            txtImagem.Value = "";
            txtNome.Value = "";
            txtPreco.Value = "";
        }

        protected void lvProdutos_ItemCommand(
            object sender, ListViewCommandEventArgs e)
        {
            string comando = e.CommandName;

            if (e.CommandArgument != null)
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Produto produto = null;

                switch (comando)
                {
                    case "Deletar":
                        //Iremos excluir o Produto
                        string mensagem = ProdutoDAO.ExcluirProduto(id);
                        AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
                        lblMensagem.InnerText = mensagem;
                        break;

                    case "Visualizar":
                        produto = ProdutoDAO.ListarProdutos(id);
                        MostrarDadosProduto(produto, true);
                        break;
                    case "Editar":
                        produto = ProdutoDAO.ListarProdutos(id);
                        MostrarDadosProduto(produto, false);
                        btnCadastrar.Text = "Alterar";
                        btnCadastrar.CssClass = "btn btn-warning";
                        btnLimpar.CssClass = "btn btn-secondary";
                        btnAddProduto.Visible = true;

                        break;

                    default:
                        break;

                }
            }
           
        }
    }
}