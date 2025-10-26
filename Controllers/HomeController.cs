using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Sakura_Sushi.Dto;
using Sakura_Sushi.Models;
using System.Diagnostics;

namespace Sakura_Sushi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signin(CreateClienteDTO request)
        {
            return View();

            // string? connectionString = settings.GetConnectionString("DefaultConnection");
            // using var connection = new MySqlConnection(connectionString);
            // connection.Open();

            // string sql = "insert into tbCliente (Nome, Email, Senha, CPF, Telefone) values(@Nome, @Email, @Senha, @CPF, @Telefone);";

            // MySqlCommand command = new MySqlCommand(sql, connection);
            // command.Parameters.AddWithValue("@Nome", request.Nome);
            // command.Parameters.AddWithValue("@Nome", request.Email);
            // command.Parameters.AddWithValue("@Nome", request.Senha);
            // command.Parameters.AddWithValue("@Nome", request.CPF);
            // command.Parameters.AddWithValue("@Nome", request.Telefone);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
