namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Models.EntityModels;

    public partial class CarContext : DbContext
    {
        public CarContext()
            : base("name=CarStr")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Car)
                .HasForeignKey(e => e.Car_Id);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Parts)
                .WithMany(e => e.Cars)
                .Map(m => m.ToTable("PartCars"));

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Parts)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Id);
        }
    }
}
