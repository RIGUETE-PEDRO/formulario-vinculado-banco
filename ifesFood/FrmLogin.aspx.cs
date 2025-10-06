using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ifesFood.admin;

namespace ifesFood
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                string login = txtUsuario.Value;
                string senha = txtPassword.Value;

                if (String.IsNullOrEmpty(login) ||
                    String.IsNullOrEmpty(senha))
                {
                    lblMensagem.InnerText = "Você precisa preencher todos os campos!";
                    return;
                }

                Usuario usuario = UsuarioDAO.ListarUsuario(login);
                if (usuario == null)
                {
                    lblMensagem.InnerText = "Não foi possível realizar o login, tente novamente mais tarde!";
                }

                var senhaHash = Sha1Hasher.ComputeSha1Hash(senha);

                if (senhaHash.Equals(usuario.Senha))
                {
                    Response.Redirect("~/view/home");
                }
                else
                {
                    lblMensagem.InnerText = "Usuário ou senha inválidos";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }
    }
}