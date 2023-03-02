using System.ComponentModel.DataAnnotations;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public struct UserDtoCreate
    {
        public UserDtoCreate()
        {
        }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string ?Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "Cel é um campo obrigatório!")]
        public string ?Cel { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigatório!")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Permissão é um campo obrigatório")]
        public string ?Permission { get; set; }
    }
}

