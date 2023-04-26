using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient.Server;
using FormApplication.Data.DomainClass;
using PhoneBook.Data.Model.DomainClass;

namespace FormApplication.Data.Contexts
{
    public class FormApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = FormDb; User Id = TestUser; Password = SecuredPassword!123;");

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<FormDetails> FormDetails { get; set; }
    }
}
