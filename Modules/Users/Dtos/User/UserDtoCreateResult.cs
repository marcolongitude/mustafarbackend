using System;

namespace Mustafarbackend.Modules.Users.Dtos
{
    // public struct UserDtoCreateResult
    // {
    //     public Guid ?Id { get; set; }
    //     public string ?Name { get; set; }
    //     public string ?Email { get; set; }
    //     public string ?Cel { get; set; }
    //     public string ?Permission { get; set; }
    //     public DateTime CreateAt { get; set; }

    // }

    public record UserDtoCreateResult(
        Guid Id,
        string Name,
        string Email,
        string Cel,
        string Permission, 
        DateTime CreateAt
    );
}

