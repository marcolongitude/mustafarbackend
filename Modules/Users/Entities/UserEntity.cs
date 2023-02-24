using mustafarbackend.Entity;

namespace mustafarbackend.Modules.Users.Entities
{
    public enum Roles
    {
        admin,
        common
    }

    public class UserEntity: BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cel { get; set; }
        public Roles Permission { get; set; }
    }

}
