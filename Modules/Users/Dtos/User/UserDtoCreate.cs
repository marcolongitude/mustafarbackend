using System.ComponentModel.DataAnnotations;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public record UserDtoCreate
    (
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        string Name,

        [Required(ErrorMessage = "Email é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        string Email,

        [Required(ErrorMessage = "Cel é um campo obrigatório!")]
        string Cel,

        [Required(ErrorMessage = "Password é um campo obrigatório!")]
         string Password,

        [Required(ErrorMessage = "Permissão é um campo obrigatório")]
        string ?Permission
    );
}

