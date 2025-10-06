using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ifesFood
{
    public partial class UploadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensagem.InnerText = "";

                if (!fileArquivo.HasFile)
                {
                    lblMensagem.InnerText = "Selecione uma imagem!";
                    return;
                }

                var file = fileArquivo.PostedFile;

                if (file.ContentType != "image/jpeg")
                {
                    lblMensagem.InnerText = "Tipo de arquivo inválido!";
                    return;
                }

                file.SaveAs(HttpContext.Current.Server.MapPath("~/upload/teste03.jpg"));
                imgUpload.Src = "~/upload/teste03.jpg";

                //fileArquivo.SaveAs("~/uploads");
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }
    }
}