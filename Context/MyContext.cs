using Microsoft.EntityFrameworkCore;
using mustafarbackend.Modules.Users.Entities;
using mustafarbackend.Modules.Users.Mapping;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace mustafarbackend.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);



            //modelBuilder.Entity<UserEntity>().HasData(
            //    new UserEntity
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Administrador",
            //        Email = "adm@gmail.com",
            //        Password = "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==",
            //        Cel = "64992959483",
            //        Permission = Roles.admin,
            //        CreateAt = DateTime.Now,
            //        UpdateAt = DateTime.Now,
            //    }
            //);
        }
    }
}
