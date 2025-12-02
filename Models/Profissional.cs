using System.ComponentModel.DataAnnotations;

namespace Sakura_Sushi.Models
{
    public class Funcionario
    {
        public int ID_Funcionario {get; set;}

        [Display(Name = "Nome")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Nome deve conter entre 2 e 150 caractéres!")]
        [Required(ErrorMessage = "Nome é obrigatório!", AllowEmptyStrings = false)]
        public string? Nome {get; set;}

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Email deve conter no máximo 100 caractéres!")]
        [Required(ErrorMessage = "Email é obrigatório!", AllowEmptyStrings = false)]
        public string? Email {get; set;}

        [Display(Name = "Senha")]
        [StringLength(150, MinimumLength = 8, ErrorMessage = "Senha deve conter no mínimo 8 caractéres!")]
        [Required(ErrorMessage = "Senha é obrigatória!", AllowEmptyStrings = false)]
        public string? Senha {get; set;}

        [Display(Name = "Cargo")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Cargp deve conter entre 2 e 50 caractéres!")]
        [Required(ErrorMessage = "Cargo é obrigatória!", AllowEmptyStrings = false)]
        public string? Cargo {get; set;}
        
        public DateTime Data_Admissao {get; set;}

        [Display(Name = "Telefone")]
        [StringLength(150, MinimumLength = 11, ErrorMessage = "Telefone deve conter no máximo 13 caractéres!")]
        [Required(ErrorMessage = "Telefone é obrigatório!", AllowEmptyStrings = false)]
        public string? Telefone {get; set;}

        [Display(Name = "CPF")]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "CPF deve conter no máximo 13 caractéres!")]
        [Required(ErrorMessage = "CPF é obrigatório!", AllowEmptyStrings = false)]
        public string? CPF {get; set;}

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "Salário é obrigatório!", AllowEmptyStrings = false)]
        public double Salario {get; set;}

        [Display(Name = "RG")]
        [StringLength(15, MinimumLength = 12, ErrorMessage = "RG deve conter no máximo 15 caractéres!")]
        [Required(ErrorMessage = "RG é obrigatório!", AllowEmptyStrings = false)]
        public string? RG {get; set;}
        public int ID_Endereco {get; set;}
    }
}