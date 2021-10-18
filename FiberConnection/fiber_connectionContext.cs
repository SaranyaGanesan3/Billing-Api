using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BillingAPI.FiberConnection
{
    public partial class fiber_connectionContext : DbContext
    {
        public fiber_connectionContext()
        {
        }

        public fiber_connectionContext(DbContextOptions<fiber_connectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FiberPlan> FiberPlans { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = tcp:fiberplan.database.windows.net, 1433; Initial Catalog = fiberconnection; Persist Security Info = False; User ID = team3; Password = Bdgs@007; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.HasKey(e => e.BillingNumber)
                    .HasName("PK__Billing__0974CD0E3209787F");

                entity.ToTable("Billing");

                entity.Property(e => e.BookedDate).HasColumnType("date");

                entity.Property(e => e.CustomerAadharNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerMailId).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.PaymentMethod).IsUnicode(false);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.PlanName).IsUnicode(false);

                entity.Property(e => e.PlanPrice).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Billing__Custome__245D67DE");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Billing__PlanID__25518C17");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerAadharNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.CustomerMailId).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.CustomerPassword)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.EmployeeMail)
                    .IsUnicode(false)
                    .HasColumnName("Employee_mail");

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("Employee_password");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkLocation).IsUnicode(false);
            });

            modelBuilder.Entity<FiberPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__FiberPla__755C22D7B7FB4E8C");

                entity.ToTable("FiberPlan");

                entity.Property(e => e.PlanId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlanID");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.PlanName).IsUnicode(false);

                entity.Property(e => e.PlanPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanSpeed)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Validity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.FiberPlans)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__FiberPlan__Offer__7E37BEF6");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Hotstar)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Hungamaplay)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Lionplay)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Netflix)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Others).IsUnicode(false);

                entity.Property(e => e.Ultra)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Voot)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.CustomerPhonenumber).IsUnicode(false);

                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).IsUnicode(false);

                entity.Property(e => e.EmployeePhonenumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.PlanName).IsUnicode(false);

                entity.Property(e => e.Status1)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.HasOne(d => d.BillingNumberNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.BillingNumber)
                    .HasConstraintName("FK__Status__BillingN__339FAB6E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Status__Customer__31B762FC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Status__Employee__30C33EC3");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Status__PlanID__32AB8735");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
