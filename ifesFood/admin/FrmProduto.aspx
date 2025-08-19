<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmProduto.aspx.cs" Inherits="ifesFood.admin.FrmProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>

    <nav class="navbar navbar-expand-lg bg-body-tertiary">
        <div class="container-fluid">
            <a class="navbar-brand" href="/">IfesFood</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link " aria-current="page" href="Default.aspx">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="FrmProduto.aspx">Produtos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " href="FrmCarousel.aspx">Carousel</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <main class="p-3">
        <h1>Gerenciamento de produtos</h1>

        <form id="form1" runat="server" class="frm-cadastro">
            <div>
                <p>
                    <label>Nome do produto:</label>
                    <input type="text" id="txtNome" runat="server" required />
                    <span class="required">*</span>
                </p>

                <p>
                    <label>Descrição:</label>
                    <input type="text" id="txtDescricao" runat="server" required />
                    <span class="required">*</span>
                </p>
                <p>
                    <label>imagem:</label>
                    <input type="text" id="txtImagem" runat="server" required />
                    <span class="required">*</span>
                </p>
                <p>
                    <label>Preço:</label>
                    <input type="text" id="txtPreco" runat="server" />
                </p>

                <p>
                    <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" class="btn-primary" OnClick="btnCadastrar_Click" />
                    <input type="reset" value="Limpar" class="btn-secondary" />
                </p>
                <p>
                    <label id="lblMensagem" runat="server"></label>
                </p>
            </div>
        </form>

        <section>

            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col">COD</th>
                        <th scope="col">PRODUTO</th>
                        <th scope="col">PREÇO</th>
                        <th scope="col">DATA CADASTRO</th>
                        <th scope="col">AÇÃOES</th>
                    </tr>
                </thead>
                <tbody>

                    <%--repetir--%>
                    <asp:ListView runat="server" ID="lvProdutos">
                        <ItemTemplate>
                            <tr>
                                
                                <td><%# Eval("Id") %></td>
                                <td><%# Eval("Nome") %></td>
                                <td><%# Eval("Preco") %></td>
                                <td><%# Eval("DataCadastro") %></td>
                                <td>
                                    <img src="../img/view.svg" />
                                    <img src="../img/edit.svg" />
                                    <img src="../img/delete.svg" />
                                </td>
                            </tr>

                        </ItemTemplate>
                    </asp:ListView>

                </tbody>
            </table>

        </section>

    </main>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"></script>

</body>
</html>
