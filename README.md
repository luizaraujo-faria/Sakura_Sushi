# Projeto Sakura Sushi - 2DS

- Luiz Henrique Araujo
- Thiago Ferreira

# Views

- Shared/
    
    ├── Layout.cshtml - View com componentes layout como Header e Footer e que renderiza as demais Views na main.

- Home/
    
    ├── Index.cshtml - Página inicial, com sessões de introdução, horários e carrosel.
    ├── Signin.cshtml - Página de cadastro e login com formulário que alterna para ambas as ações.

- Cliente/

   ├── Perfil.cshtml - Página de perfil de usuário com os dados do usuário possibilitando a checagem e atualização.

- Menu/
    
    ├── Menu.cshtml - Página de cardápio com cards dos pratos e opções por dia da semana (Incompleto).

# Models

- Classes representativas das entidades do meu sistema como Cliente, Profissional, Endereco, Pedido etc.
- Utilizado o pacote <System.ComponentModel.DataAnnotations> para aplicar anotações de validações de dados.

# Controllers

- Controladores de requisições e endpoints da aplicação.
- Utilizado a classe nativa <TempData> para retornar mensagens de erro e sucesso às Views.
- HomeController retorna as Views Index e Signin com método <IActionResult>.
- ClienteController realiza a lógica dos endpoints do cliente, como Cadastro, Login, Busca e Atualização de dados.

- ClientController/

    ├── Método <Cadastrar> que espera um objeto do tipo <ClienteDTO> [POST]

        ├── Abre conexão com o banco de dados através da <_configuration.GetConnectionString("DefaultConnection")>.
        ├── Busca usuário pelo email recebido para verificar se o email já esta cadastrado e se encontrar retorna erro.
        ├── Insere os dados enviados pelo usuário no banco de dados e retorna sucesso.

    ├── Método <Login> que espera um <LoginClienteDTO> [POST]

        ├── Abre conexão com o banco de dados através da <_configuration.GetConnectionString("DefaultConnection")>.
        ├── Verifica se os dados informados estão corretos, caso contrario retorna erro.
        ├── Armazena o ID do usuário retornado na memória local de sessão do ASP.NET Core através do 
        <HttpContext.Session.SetInt32("UserId", reader.GetInt32("Id_Cliente"))> e redireciona para a View Perfil.

    ├── Método <GetClienteById> que espera um inteiro <id>
    
        ├── Abre conexão com o banco de dados usando a connection string do _configuration.
        ├── Executa um SELECT buscando Nome, Email, Senha, CPF e Telefone do cliente filtrando pelo Id_Cliente.
        ├── Se nenhum usuário for encontrado, define mensagem de erro no TempData e retorna null.
        ├── Se os dados existirem, monta e retorna um objeto <ClienteDTO> preenchido com as informações do banco.
    
    
    ├── Método <Editar> [GET]
    
       ├── Busca o ID do usuário logado através da sessão do ASP.NET Core através do <HttpContext.Session>.
       ├── Se não existir ID na sessão, redireciona para a Home (usuário não logado).
       ├── Chama o método <GetClienteById> para obter os dados do cliente.
       ├── Se não encontrar o usuário, define mensagem no <TempData> e redireciona para a página de login.
       ├── Retorna a View preenchida com os dados do cliente para edição.
    
    
    ├── Método <Editar> [POST] que recebe um objeto <ClienteDTO>
    
        ├── Busca o ID do usuário logado na sessão do servidor.
        ├── Se não houver ID, redireciona para a página de login.
        ├── Abre conexão com o banco usando a connection string padrão.
        ├── Executa um UPDATE atualizando Nome, Email, Senha, CPF e Telefone do cliente baseado no ID da sessão.
        ├── Se atualizar com sucesso, define mensagem de sucesso no <TempData>.
        ├── Redireciona para o método Perfil, em caso de erro, define mensagem e retorna para Editar.
    
    ├── Método <Perfil>
        
        ├── Obtém o ID do usuário logado via <HttpContext.Session>.
        ├── Se não estiver logado, redireciona para a página de login.
        ├── Busca os dados completos do cliente chamando <GetClienteById>.
        ├── Se não encontrar o cliente, define mensagem e redireciona para o login.
        ├── Retorna a View exibindo os dados do usuário logado.

# Conexão Com MySQL

- Utilizado o pacote <MySql.Data> para prover os recursos de conectividade com o MySQl
- Configurando a String de Conexão no <appsettings.json>

- "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;database=DBName;user=User;password=Senha"
  },

# WWWWROOT

- Arquivos estáticos da Aplicação.

    ├── CSS/
    ├── JS/
    ├── Images/
    ├── favicon.ico 

# ©2025 - 2DS - Nívia