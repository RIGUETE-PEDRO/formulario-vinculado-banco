using System;
using System.Linq;

namespace ifesFood.admin
{
    internal class UsuarioDAO
    {
        internal static string CadastrarUsuario(Usuario usuario)
        {
			string mensagem = string.Empty;
			try
			{
				using (var ctx = new ifesFoodDBEntities())
				{
					ctx.Usuarios.Add(usuario);
					ctx.SaveChanges();
				}

				mensagem = "Usuário cadastrado com sucesso!";
			}
			catch (Exception ex)
			{
				mensagem = ex.Message;
			}
			

			return mensagem;
        }

        internal static Usuario ListarUsuario(string login)
        {
			Usuario usuario = null;
			try
			{
				using (var ctx = new ifesFoodDBEntities())
				{
					usuario = ctx.Usuarios.FirstOrDefault(u => u.Login == login);	
				}
			}
			catch (Exception ex)
			{
			}

			return usuario;
        }
    }
}