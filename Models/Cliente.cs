using System.ComponentModel.DataAnnotations;

namespace Sakura_Sushi.Models
{
    public class Cliente
    {

        public int ID_Cliente { get; }
        [Display(Name = "Seu nome")]
        [StringLength(150, MinimumLength = 2)]
        [Required(ErrorMessage = "Nome é obrigatório!", AllowEmptyStrings = false)]
        public string? Nome { get; set; }
        [Display(Name = "Seu email")]
        [StringLength(150)]
        [Required(ErrorMessage = "Email é obrigatório!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string? Email { get; set; }
        [Display(Name = "Sua senha")]
        [StringLength(150, MinimumLength = 8, ErrorMessage = "Deve conter no mínimo 8 caractéres")]
        [Required(ErrorMessage = "Senha é obrigatória!", AllowEmptyStrings = false)]
        private string? Senha { get; set; }
        [Display(Name = "Seu CPF")]
        [StringLength(13)]
        [Required(ErrorMessage = "CPF é obrigatório!", AllowEmptyStrings = false)]
        public string? CPF { get; set; }
        [Display(Name = "Número de telefone")]
        [StringLength(13, MinimumLength = 10)]
        [Required(ErrorMessage = "Telefone é obrigatório!", AllowEmptyStrings = false)]
        public string? Telefone { get; set; }
    }
}