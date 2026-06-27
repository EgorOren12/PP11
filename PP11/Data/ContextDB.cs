using Microsoft.EntityFrameworkCore;
using PP11.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PP11.Data
{
    internal class ContextDB : DbContext
    {

        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MembersOfBrigade> MembersOfBrigades { get; set; }
        public DbSet<Models.Object> Objects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<TypesOfSituation> TypesOfSituation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KOMPUKTER\SQLEXPRESS;Database=PPV3;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foreignKeys = modelBuilder.Model.GetEntityTypes()
             .SelectMany(e => e.GetForeignKeys())
             .ToList();

            foreach (var fk in foreignKeys)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }

    }
}
