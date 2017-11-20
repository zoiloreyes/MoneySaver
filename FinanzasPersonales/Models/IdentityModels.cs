﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinanzasPersonales.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Email", this.Email.ToString()));
            userIdentity.AddClaim(new Claim("PhoneNumber", this.PhoneNumber.ToString()));


            return userIdentity;
        }
        public virtual User User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure Student & StudentAddress entity
            modelBuilder.Entity<ApplicationUser>()
                        .HasRequired(s => s.User) // Mark Address property optional in Student entity
                        .WithOptional(m => m.ApplicationUser); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.CuentaBanco> CuentaBancoes { get; set; }

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.Banco> Bancoes { get; set; }

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.EstadoCuentaBanco> EstadoCuentaBancoes { get; set; }

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.Moneda> Monedas { get; set; }
    }
}