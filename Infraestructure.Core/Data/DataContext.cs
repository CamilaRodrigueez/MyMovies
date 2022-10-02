using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Movies;
using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        //DbSet Significa: tenga en cuenta estas entidades.
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<RolEntity> RolEntity { get; set; }
        public DbSet<RolUserEntity> RolUserEntity { get; set; }
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<RolPermissionEntity> RolPermissionEntity { get; set; }
        public DbSet<TypePermissionEntity> TypePermissionEntity { get; set; }
        public DbSet<TypeStateEntity> TypeStateEntity { get; set; }
        public DbSet<DirectorEntity> DirectorEntity { get; set; }
        public DbSet<MoviesEntity> MoviesEntity { get; set; }
        public DbSet<GenderEntity> GenderEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(b => b.Email)
                .IsUnique();

            //este código es para hacer una excepción con los ID que les seteamos en el Enums
            modelBuilder.Entity<TypeStateEntity>().Property(t => t.IdTypeState).ValueGeneratedNever();
            modelBuilder.Entity<TypePermissionEntity>().Property(t => t.IdTypePermission).ValueGeneratedNever();
            modelBuilder.Entity<RolEntity>().Property(t => t.IdRol).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.IdPermission).ValueGeneratedNever();


            modelBuilder.Entity<GenderEntity>().Property(t => t.IdGender).ValueGeneratedNever();
            modelBuilder.Entity<DirectorEntity>().Property(t => t.IdDirector).ValueGeneratedNever();
            modelBuilder.Entity<MoviesEntity>().Property(t => t.IdMovie).ValueGeneratedNever();
        }
    }
}
