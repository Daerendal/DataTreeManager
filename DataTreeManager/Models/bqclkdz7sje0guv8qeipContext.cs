using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataTreeManager.Models
{
    public partial class bqclkdz7sje0guv8qeipContext : DbContext
    {
        public bqclkdz7sje0guv8qeipContext()
        {
        }

        public bqclkdz7sje0guv8qeipContext(DbContextOptions<bqclkdz7sje0guv8qeipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TreeOrder> TreeOrder { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=bqclkdz7sje0guv8qeip-mysql.services.clever-cloud.com;uid=u7ei0ogjrzrf4iot;pwd=pUeW2NfleB7hbCMIZRZ9;database=bqclkdz7sje0guv8qeip", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<TreeOrder>(entity =>
            {
                entity.HasKey(e => e.IdTreeOrder)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdTreeOrder).HasColumnName("idTreeOrder");

                entity.Property(e => e.IdParent).HasColumnName("idParent");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Lineage)
                    .HasMaxLength(45)
                    .HasColumnName("lineage");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
