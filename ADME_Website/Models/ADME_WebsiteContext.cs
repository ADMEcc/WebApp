using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADME_Website.Models
{
    public partial class ADME_WebsiteContext : DbContext
    {
        public ADME_WebsiteContext()
        {
        }

        public ADME_WebsiteContext(DbContextOptions<ADME_WebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donations> Donations { get; set; }
        public virtual DbSet<EmailwalletTable> EmailwalletTable { get; set; }

        public virtual DbSet<Subscribers> Subscribers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:admedb.database.windows.net,1433;Initial Catalog=ADME_Website;Persist Security Info=False;User ID=\"admeadmin\";Password=\"AzureDb69admin\";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donations>(entity =>
            {
                entity.ToTable("DONATIONS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.DonateTime)
                    .HasColumnName("DONATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Usertype).HasColumnName("USERTYPE");

                entity.Property(e => e.Wallet)
                    .IsRequired()
                    .HasColumnName("WALLET");
            });

            modelBuilder.Entity<EmailwalletTable>(entity =>
            {
                entity.ToTable("EMAILWALLET_TABLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Wallet)
                    .IsRequired()
                    .HasColumnName("WALLET");
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.ToTable("SUBSCRIBERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL");
            });
        }
    }
}
