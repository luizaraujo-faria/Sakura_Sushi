using Microsoft.AspNetCore.Mvc;
using Sakura_Sushi.Models;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Sakura_Sushi.Dto;

namespace Sakura_Sushi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CreateClienteDTO request)
        {

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "insert into tbCliente (Nome, Email, Senha, CPF, Telefone) values(@Nome, @Email, @Senha, @CPF, @Telefone);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", request.Nome);
            command.Parameters.AddWithValue("@Email", request.Email);
            command.Parameters.AddWithValue("@Senha", request.Senha);
            command.Parameters.AddWithValue("@CPF", request.CPF);
            command.Parameters.AddWithValue("@Telefone", request.Telefone);
            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
