using System.ComponentModel.DataAnnotations;

namespace Sakura_Sushi.Models
{
    public class Endereco
    {
        public int ID_Endereco { get; }
        [Display(Name = "Seu CEP")]
        [Required(ErrorMessage = "CEP é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(11)]
        public string? CEP { get; set; }
        [Display(Name = "Número da casa")]
        [Required(ErrorMessage = "Número da casa é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(5)]
        public string? Numero { get; set; }
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Bairro é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100)]
        public string? Bairro { get; set; }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade é obrigatória!", AllowEmptyStrings = false)]
        [StringLength(100)]
        public string? Cidade { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(2, MinimumLength = 2)]
        public string? Estado { get; set; }
        [Display(Name = "Nome da rua")]
        [Required(ErrorMessage = "Nome da rua é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100)]
        public string? Rua { get; set; }
    }
}