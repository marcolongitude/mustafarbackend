using System;

namespace Mustafarbackend.Modules.Users.Dtos
{
    public record UserDtoUpdateResult
    (
        Guid Id,
        string Name,
        string Email,
        string Cel,
        string Permission,
        DateTime UpdateAt
    );
}

