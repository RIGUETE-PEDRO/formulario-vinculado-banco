using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace ifesFood.admin
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var senha = txtSenha.Value;
            var RepSenha = txtRepetirSenha.Value;


            if (senha.Equals(RepSenha))
            {
                Usuario usuario = new Usuario();   
                usuario.NomeUsuario = txtNomeUsuario.Value;
                usuario.Login = txtLogin.Value;
                usuario.Email = txtEmail.Value;
                usuario.DataCadastro = DateTime.Now;

                //Criptografa senha
                usuario.Senha = Sha1Hasher.ComputeSha1Hash(senha);
                
                string mensagem = UsuarioDAO.CadastrarUsuario(usuario);
                LimparDados();


                lblMensagem.InnerText = mensagem;
            }
            else
            {
                //Exibir mensagens sobre as senhas 
                lblMensagem.InnerText = "As senhas não conferem!";
                return;
            }
        }

        private void LimparDados()
        {
            txtNomeUsuario.Value = "";
            txtLogin.Value = "";
            txtEmail.Value = "";
            txtSenha.Value = "";
            txtRepetirSenha.Value = "";

        }
    }
}

