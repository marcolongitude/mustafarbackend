using System;
using System.ComponentModel.DataAnnotations;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo celular é obrigatório")]
        [StringLength(15, ErrorMessage = "O celular deve ter no máximo {1} caracteres")]
        public string Cel { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(6, ErrorMessage = "O senha deve ter no máximo {1} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Permission { get; set; }
    }
}