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
        public IActionResult Cadastrar(CreateClienteDTO request)
        {
            string? conn = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new MySqlConnection(conn);
                connection.Open();

                // Verifica se o email já existe
                string checkQuery = "SELECT Id FROM tbCliente WHERE Email = @Email LIMIT 1;";
                using var checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Email", request.Email);

                var exists = checkCmd.ExecuteScalar();
                if (exists != null)
                {
                    TempData["Error"] = "Este e-mail já está cadastrado!";
                    return RedirectToAction("Login", "Home");
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
                cmd.ExecuteNonQuery();

                TempData["Success"] = "Conta criada com sucesso!";
                return RedirectToAction("Login", "Home");
            }
            catch (Exception)
            {
                TempData["Error"] = "Erro ao criar conta. Tente novamente.";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(LoginClienteDTO request)
        {
            string? conn = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new MySqlConnection(conn);
                connection.Open();

                string query = @"SELECT Id, Nome FROM tbCliente 
                                 WHERE Email = @Email AND Senha = @Senha LIMIT 1;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters.AddWithValue("@Senha", request.Senha);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    TempData["Error"] = "Credenciais inválidas!";
                    return RedirectToAction("Login", "Home");
                }

                // Aqui você pode guardar userId em Session futuramente
                TempData["Success"] = "Login realizado com sucesso!";
                return RedirectToAction("Perfil");
            }
            catch (Exception)
            {
                TempData["Error"] = "Erro ao tentar fazer login.";
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}