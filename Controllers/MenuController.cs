using Microsoft.AspNetCore.Mvc;
using Sakura_Sushi.Models;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Sakura_Sushi.Dto;

namespace Sakura_Sushi.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IConfiguration _configuration;

        public MenuController(ILogger<MenuController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Menu()
        {
            return View();
        }

    }
}