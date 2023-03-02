using System;

namespace Mustafarbackend.Modules.Users.Dtos
{
    // public struct UserDto
    // {
    //     // public UserDto(Guid id, string name, string email, string cel, string permission)
    //     // {
    //     //     Id = id;
    //     //     Email = email;
    //     //     Cel = cel;
    //     //     Permission = permission;
    //     // }
    //     public Guid Id { get; set; }
    //     public string ?Name { get; set; }
    //     public string ?Email { get; set; }
    //     public string ?Cel { get; set; }
    //     public string ?Permission { get; set; }
    //     public DateTime CreateAt { get; set; }
    // }

    public record UserDto(
        Guid Id,
        string Name,
        string Email,
        string Cel, 
        string Permission,
        DateTime CreateAt
    );
}