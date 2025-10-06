<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadTest.aspx.cs" Inherits="ifesFood.UploadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>Testando Upload de arquivos</h1>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:FileUpload ID="fileArquivo" runat="server" AllowMultiple="false" />
                <asp:Button ID="btnUpload" runat="server" Text="Enviar"
                    OnClick="btnUpload_Click"
                    />
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
            <p>
                <img src="#" alt="Imagem enviada" id="imgUpload" runat="server" />
            </p>
        </div>
    </form>
</body>
</html>
