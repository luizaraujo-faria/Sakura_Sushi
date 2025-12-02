using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Sakura_Sushi.Models
{
    public class Cardapio : Controller
    {
        int idCardapio { get; set; }
        string dia { get; set; }    
    }
}