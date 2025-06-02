using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities.Common;
using SchoolManagement.Domain.Entities.PeopleEntity;
using SchoolManagement.Domain.Entities.School;
using SchoolManagement.Domain.Entities.Users;
using SchoolManagement.Infrastructure.Repository;

namespace SchoolManagement.Infrastructure
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolManagementDbContext).Assembly);
            QueryHelper.GlobalQueryFilter(modelBuilder);
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolAddress> SchoolAddress { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BloodGroup> BloodGroup { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Religion> Religion { get; set; }
    }
}