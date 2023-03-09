using System.ComponentModel.DataAnnotations;

namespace mustafarbackend.Modules.Auth.Dtos;

public record AuthenticateDto
(
    [Required(ErrorMessage = "Email é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        string Email,

    [Required(ErrorMessage = "Password é um campo obrigatório!")]
        string Password
);
