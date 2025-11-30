using Microsoft.AspNetCore.Mvc;

namespace Sakura_Sushi.Models
{
    public class Pedido : Controller
    {
        int idPedido { get; set; }
        DateOnly data { get; set;}
        
        // enum StatusPedido
        // {
        //     Pendente = "Pendente",

        // }
    }
}