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
                    MostrarDadosProduto(produto, true);
                }
            }

        }

        /// <summary>
        /// Método utilizado para exibir dados no furmulário
        /// </summary>
        /// <param name="produto">Objeto preenchido</param>
        /// <param name="visualizar">Booleano informando ação atual</param>
        private void MostrarDadosProduto(Produto produto, bool visualizar)
        {
            txtDescricao.Value = produto.Descricao;
            txtNome.Value = produto.Nome;
            txtImagem.Value = produto.Imagem;
            txtPreco.Value = produto.Preco.ToString();

            btnAddProduto.Visible = true;
            if (visualizar)
            {
                Visualizar();
            }
            else
            {
                Alterar();
            }

        }

        private void Alterar()
        {
            btnCadastrar.Text = "Alterar";
            
        }

        private void Visualizar()
        {
            txtDescricao.Disabled = true;
            txtNome.Disabled = true;
            txtImagem.Disabled = true;
            txtPreco.Disabled = true;

            btnCadastrar.Visible = false;
            btnLimpar.Visible = false;
        }

        private void AtualizarLvProdutos(List<Produto> produtos)
        {
            var lista = produtos.OrderBy(p => p.Nome);
            lvProdutos.DataSource = lista;
            lvProdutos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool alterando = btnCadastrar.Text == "Alterar";

            Produto produto = null;

            if (!alterando)
            {
                produto = new Produto();
                produto.DataCadastro = DateTime.Now;
            }
            else
            {
                int id = Int32.Parse(txtId.Value);
                produto = ProdutoDAO.VisualizarProduto(id);
            }

            produto.Nome = txtNome.Value;
            produto.Descricao = txtDescricao.Value;
            produto.Imagem = txtImagem.Value;
            produto.Preco = Convert.ToDecimal(txtPreco.Value);

            string mensagem = "";
            if (!alterando)
            {
                mensagem = ProdutoDAO.CadastrarProduto(produto);
            }
            else
            {
                mensagem = ProdutoDAO.AlterarProduto(produto);
                Response.Redirect("~/FrmProduto.aspx");
            }

            LimparCampos(mensagem);

            AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
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
            int id = Convert.ToInt32(e.CommandArgument);

            if (comando == "Deletar")
            {
                //Iremos excluir o Produto
                string mensagem = ProdutoDAO.ExcluirProduto(id);
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
                lblMensagem.InnerText = mensagem;
            }
            else if(comando == "Visualizar")
            {
                Response.Redirect("~/admin/FrmProduto.aspx?cod=" + id);
            }
            else if (comando == "Editar")
            {
                Produto produto = ProdutoDAO.VisualizarProduto(id);
                MostrarDadosProduto(produto, false);
                txtId.Value = id.ToString();
            }
        }
    }
}