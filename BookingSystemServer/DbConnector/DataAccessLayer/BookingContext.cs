using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityModels.Models;

namespace DbConnector.DataAccessLayer
{
    public class BookingContext : DbContext
    {
        public BookingContext()
            : base("name = DbConnector.Properties.Settings.SqlConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<AbsenceType> AbsenceTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OpeningHours> OpeningHours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOptional(o => o.OrderTypes)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Order>()
            //    .HasOptional(o => o.Customer)
            //    .WithRequired()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Order>()
            //    .HasOptional(o => o.Employee)
            //    .WithRequired()
            //    .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
