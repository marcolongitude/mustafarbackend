using System;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public record UserDto(
        Guid Id,
        string Name,
        string Email,
        string Cel, 
        string Permission,
        DateTime CreateAt
    );
}