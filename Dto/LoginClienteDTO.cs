using System.ComponentModel.DataAnnotations;

namespace Sakura_Sushi.Dto
{
    public class LoginClienteDTO
    {
        [Display(Name = "Seu email")]
        [StringLength(150)]
        [Required(ErrorMessage = "Email é obrigatório!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string? Email { get; set; }

        [Display(Name = "Sua senha")]
        [StringLength(150, MinimumLength = 8, ErrorMessage = "Deve conter no mínimo 8 caractéres")]
        [Required(ErrorMessage = "Senha é obrigatória!", AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}