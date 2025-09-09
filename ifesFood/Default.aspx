<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ifesFood.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ifesFood - Alimentação Inteligente</title>

    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/style.css">
</head>
<%--<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>--%>

<body>
  <!-- NAVBAR -->
   <header class="bg-body-tertiary">
    <nav class="navbar navbar-expand-lg container">
      <a class="navbar-brand" href="/">ifesFood</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav me-auto">
          <li class="nav-item"><a class="nav-link active" href="/">Início</a></li>
          <li class="nav-item"><a class="nav-link" href="produtos.html">Produtos</a></li>
          <li class="nav-item"><a class="nav-link" href="planos.html">Planos</a></li>
          <li class="nav-item"><a class="nav-link" href="sobre.html">Sobre</a></li>
          <li class="nav-item"><a class="nav-link" href="contato.html">Contato</a></li>
        </ul>
      </div>
    </nav>
  </header>



  <!-- CARROSSEL -->
  <main>
    <section>
      <div id="myCarousel" class="carousel slide mb-5" data-bs-ride="carousel">
        <div class="carousel-indicators">
          <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="active"
            aria-label="Slide 1"></button>
          <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
          <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>

        <div class="carousel-inner">
          <div class="carousel-item active">
            <img src="img/carousel03.jpg" class="d-block w-100 carousel-item-img"
            <img src="img/carousel03.jpg" class="d-block w-100 carousel-item-img"
              alt="Prato saudável com legumes e arroz">
            <div class="container">
              <div class="carousel-caption text-start">
                <h1>Alimentação saudável e acessível</h1>
                <p>Conectamos produtores locais e estudantes em uma rede de alimentação sustentável.</p>
                <p><a class="btn btn-lg btn-primary" href="#">Conheça nossos produtos</a></p>
              </div>
            </div>
          </div>

          <div class="carousel-item">
            <img src="img/carousel02.png" class="d-block w-100 carousel-item-img" alt="Prato com proteína e salada">
            <div class="container">
              <div class="carousel-caption">
                <h1>Produção local valorizada</h1>
                <p>Trabalhamos com ingredientes frescos e de produtores da região.</p>
                <p><a class="btn btn-lg btn-primary" href="#">Saiba mais</a></p>
              </div>
            </div>
          </div>

          <div class="carousel-item">
            <img src="img/carousel03.jpg" class="d-block w-100 carousel-item-img" alt="Equipe do projeto ifesFood">
            <div class="container">
              <div class="carousel-caption text-end">
                <h1>ifesFood é inovação e sabor</h1>
                <p>Projetos que alimentam, educam e transformam.</p>
                <p><a class="btn btn-lg btn-primary" href="#">Participe do projeto</a></p>
              </div>
            </div>
          </div>
        </div>

        <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Anterior</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Próximo</span>
        </button>
      </div>
    </section>

    <!-- DESTAQUES -->
    <section>
      <div class="container py-5">
        <div class="row text-center">
          <div class="col-lg-4">
            <img src="img/lunch-01.svg" alt="Prato do dia" width="72">
            <h2 class="fw-bold">Prato do Dia</h2>
            <p>Cardápio variado e nutritivo, pensado para sua saúde e bem-estar.</p>
          </div>
          <div class="col-lg-4">
            <img src="img/lunch-02.svg" alt="Ingredientes naturais" width="72">
            <h2 class="fw-bold">Ingredientes Naturais</h2>
            <p>Utilizamos ingredientes frescos, orgânicos e da agricultura familiar.</p>
          </div>
          <div class="col-lg-4">
            <img src="img/lunch-03.svg" alt="Preparo responsável" width="72">
            <h2 class="fw-bold">Preparo Responsável</h2>
            <p>Alunos e professores do Ifes cuidando de cada detalhe do seu alimento.</p>
          </div>
        </div>
      </div>
    </section>

    <!-- PRATOS -->
    <section class="bg-body-tertiary py-5">
  <div class="container">
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4">


    <!-- Elemento para ser repetido -->

        <asp:ListView runat="server" ID="lvProdutos">
            <ItemTemplate>

      <div class="col">
        <div class="card shadow-sm">
          <img src='<%# Eval("Imagem") %>' class="card-img-prato" alt='<%# Eval("Nome") %>'>
          <div class="card-body">
            <h5 class="card-title"><%# Eval("Nome") %></h5>
            <p class="card-text"><%# Eval("Descricao") %></p>
            <div class="d-flex justify-content-between align-items-center">
              <button class="btn btn-sm btn-outline-primary">Ver detalhes</button>
              <small class="text-muted">Hoje</small>
            </div>
          </div>
        </div>
      </div>

        </ItemTemplate>
    </asp:ListView>
     <!-- Fim Elemento para ser repetido -->


    </div>
  </div>
</section>

  </main>

  <!-- RODAPÉ -->
  <footer class="bg-light text-muted py-5 mt-4">
    <div class="container">
      <div class="row">
        <div class="col-md-3">
          <h5>ifesFood</h5>
          <ul class="list-unstyled">
            <li><a href="#" class="text-muted">Sobre</a></li>
            <li><a href="#" class="text-muted">Contato</a></li>
            <li><a href="#" class="text-muted">Equipe</a></li>
          </ul>
        </div>
        <div class="col-md-3">
          <h5>Produtos</h5>
          <ul class="list-unstyled">
            <li><a href="#" class="text-muted">Cardápio</a></li>
            <li><a href="#" class="text-muted">Planos</a></li>
            <li><a href="#" class="text-muted">Parcerias</a></li>
          </ul>
        </div>
        <div class="col-md-6">
          <form>
            <h5>Receba novidades</h5>
            <p>Cadastre seu e-mail para receber atualizações e promoções.</p>
            <div class="input-group">
              <input type="email" class="form-control" placeholder="Seu e-mail">
              <button class="btn btn-primary" type="submit">Cadastrar</button>
            </div>
          </form>
        </div>
      </div>
      <div class="d-flex justify-content-between pt-4 border-top mt-4">
        <p>&copy; 2025 ifesFood. Todos os direitos reservados.</p>
        <div>
          <a href="#" class="text-muted me-3">Instagram</a>
          <a href="#" class="text-muted">Facebook</a>
        </div>
      </div>
    </div>
  </footer>

  <script src="js/bootstrap.bundle.js"></script>
</body>

</html>
