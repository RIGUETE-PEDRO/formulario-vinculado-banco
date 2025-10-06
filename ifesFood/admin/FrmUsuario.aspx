<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUsuario.aspx.cs" Inherits="ifesFood.admin.FrmUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Usuários</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous" />

    <link href="../css/style.css" rel="stylesheet" />

</head>
<body>
    <header>
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <a class="navbar-brand" href="home">iFesFood</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="home">Início</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="produtos">Produtos</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="carousels">Carousel</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link active" href="users">Usuários</a>
                        </li>

                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <main class="p-3">

        <h1>Gerenciamento de Usuários</h1>
        <form id="formUser" runat="server" class="frm-cadastro">
            <p>
                <label>Nome Usuário:</label>
                <input type="text" id="txtNomeUsuario" runat="server" />
                <span class="required">*</span>
            </p>

            <p>
                <label>Login:</label>
                <input type="text" id="txtLogin" runat="server" />
                <span class="required">*</span>
            </p>

            <p>
                <label>Senha:</label>
                <input type="password" id="txtSenha" runat="server" />
                <span class="required">*</span>
            </p>

            <p>
                <label>Repetir Senha:</label>
                <input type="password" id="txtRepetirSenha" runat="server" />
                <span class="required">*</span>
            </p>

            <p>
                <label>E-mail:</label>
                <input type="email" id="txtEmail" runat="server" />
                <span class="required">*</span>
            </p>

            <p>
                <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" class="btn-primary"
                    OnClick="btnCadastrar_Click" />

                <input type="reset"
                    value="Limpar"
                    class="btn-secondary"
                    id="btnLimpar"
                    runat="server" />
            </p>

            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </form>

    </main>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"></script>
</body>
</html>
