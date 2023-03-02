using System;
using System.ComponentModel.DataAnnotations;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public record UserDtoUpdate
    (
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        Guid Id,

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        string Name,

        [Required(ErrorMessage = "Email é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        string Email,

        [Required(ErrorMessage = "O campo celular é obrigatório")]
        [StringLength(15, ErrorMessage = "O celular deve ter no máximo {1} caracteres")]
        string Cel,

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(6, ErrorMessage = "O senha deve ter no máximo {1} caracteres")]
        string Password,

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        string Permission
    );
}