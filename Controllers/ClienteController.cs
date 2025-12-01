using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Sakura_Sushi.Dto;

namespace Sakura_Sushi.Controllers
{
    public class ClienteController : Controller
    {   
        private readonly ILogger<ClienteController> _logger;
        private readonly IConfiguration _configuration;

        public ClienteController(ILogger<ClienteController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteDTO request)
        {   
            // Pega a string de conexão para utilizar no método
            string? conn = _configuration.GetConnectionString("DefaultConnection");

            // try e catch para tratar exceções mais facilmente
            try
            {
                using var connection = new MySqlConnection(conn);
                connection.Open();

                // Verifica se o email já existe
                string existingUser = "select Id_Cliente from tbCliente where Email = @Email limit 1;";
                using var checkCmd = new MySqlCommand(existingUser, connection);
                checkCmd.Parameters.AddWithValue("@Email", request.Email);

                // Se o Email já existir no banco retorna erro
                var exists = checkCmd.ExecuteScalar();
                if (exists != null)
                {
                    TempData["Error"] = "Este e-mail já está cadastrado!"; // Classe que captura e exibe os exceções no HTML
                    return RedirectToAction("Signin", "Home");
                }

                // Cadastra usuário
                string insert = @"INSERT INTO tbCliente (Nome, Email, Senha, CPF, Telefone)
                                  VALUES (@Nome, @Email, @Senha, @CPF, @Telefone);";

                using var cmd = new MySqlCommand(insert, connection);
                cmd.Parameters.AddWithValue("@Nome", request.Nome);
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters.AddWithValue("@Senha", request.Senha);
                cmd.Parameters.AddWithValue("@CPF", request.CPF);
                cmd.Parameters.AddWithValue("@Telefone", request.Telefone);
                cmd.ExecuteNonQuery(); // Executa insert

                TempData["Success"] = "Conta criada com sucesso!";
                return RedirectToAction("Signin", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao criar conta. Tente novamente. {ex.Message}";
                return RedirectToAction("Signin", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(LoginClienteDTO request)
        {
            // Pega a string de conexão para utilizar no método
            string? conn = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new MySqlConnection(conn);
                connection.Open();

                string existingUser = @"select Id_Cliente, Nome from tbCliente 
                                 where Email = @Email and Senha = @Senha LIMIT 1;";

                using var cmd = new MySqlCommand(existingUser, connection);
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters.AddWithValue("@Senha", request.Senha);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    TempData["Error"] = "Credenciais inválidas!";
                    return RedirectToAction("Signin", "Home");
                }

                // Armazena o id do usuário na sessão local do servidor para simular Autenticação
                HttpContext.Session.SetInt32("UserId", reader.GetInt32("Id_Cliente"));

                // Aqui você pode guardar userId em Session futuramente
                TempData["Success"] = "Login realizado com sucesso!";
                return RedirectToAction("Perfil");
            }
            catch (Exception)
            {
                TempData["Error"] = "Erro ao tentar fazer login.";
                return RedirectToAction("Signin", "Home");
            }
        }

        private ClienteDTO? GetClienteById(int id)
        {
            string? conn = _configuration.GetConnectionString("DefaultConnection");

            try
            {    
                using var connection = new MySqlConnection(conn);
                connection.Open();

                string existingUser = @"select Nome, Email, Senha, CPF, Telefone 
                                from tbCliente where Id_Cliente = @Id limit 1;";

                using var cmd = new MySqlCommand(existingUser, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    TempData["Error"] = "Nenhum usuário encontrado!";
                    return null;
                }

                return new ClienteDTO
                {
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email"),
                    Senha = reader.GetString("Senha"),
                    CPF = reader.GetString("CPF"),
                    Telefone = reader.GetString("Telefone")
                };
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao buscar dados do usuário! {ex.Message}";
                return null;
            }
        }

        [HttpGet]
        public IActionResult Editar()
        {
            // Pega o id do usuário logado da sessão do servidor
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Index", "Home");

            var model = GetClienteById(userId.Value);

            if (model == null)
            {
                TempData["Error"] = "Usuário não encontrado!";
                return RedirectToAction("Signin", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(ClienteDTO request)
        {
            // Pega o id do usuário logado da sessão do servidor
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Signin", "Home");

            string? conn = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new MySqlConnection(conn);
                connection.Open();

                string update = @"update tbCliente set Nome = @Nome, Email = @Email, Senha = @Senha, 
                                    CPF = @CPF, Telefone = @Telefone where Id_Cliente = @Id;";

                using var cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@Id", userId.Value);
                cmd.Parameters.AddWithValue("@Nome", request.Nome);
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters.AddWithValue("@Senha", request.Senha);
                cmd.Parameters.AddWithValue("@CPF", request.CPF);
                cmd.Parameters.AddWithValue("@Telefone", request.Telefone);

                cmd.ExecuteNonQuery();

                TempData["Success"] = "Perfil atualizado com sucesso!";
                return RedirectToAction("Perfil");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao atualizar perfil. {ex.Message}";
                return RedirectToAction("Editar");
            }
        }

        public IActionResult Perfil()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Signin", "Home");
            }

            var model = GetClienteById(userId.Value);

            if (model == null)
            {
                TempData["Error"] = "Usuário não encontrado!";
                return RedirectToAction("Signin", "Home");
            }

            return View(model);
        }
    }
}