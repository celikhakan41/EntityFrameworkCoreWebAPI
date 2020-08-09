using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework3.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte Gender { get; set; }
        public DateTime? WorkStart { get; set; }
        public DateTime? WorkEnd { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public int DepartmentId { get; set; }
        public int TitleId { get; set; }
        public int ManagerUserId { get; set; }
        public string Language { get; set; }
        public int TimeZone { get; set; }
        public string Culture { get; set; }
        public string Picture { get; set; }

        public Department Name { get; set; }
        public Title TitleCode { get; set; }
        public Position PositionCode { get; set; }
    }
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne<Department>(navigationExpression: s => s.Name)
                .WithOne(sa => sa.User)
                .HasForeignKey<Department>(sa => sa.DepartmentId);

            builder.HasOne<Title>(navigationExpression: s => s.TitleCode)
               .WithOne(sa => sa.User)
               .HasForeignKey<Title>(sa => sa.TitleId);

            builder.HasOne<Position>(navigationExpression: s => s.PositionCode)
               .WithOne(sa => sa.User)
               .HasForeignKey<Position>(sa => sa.PositionId);


        }
    }
}
