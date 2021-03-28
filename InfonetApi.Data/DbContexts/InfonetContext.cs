using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InfonetApi.Data.Entities;

#nullable disable

namespace InfonetApi.Data.DbContexts
{
    public partial class InfonetContext : DbContext
    {
        public InfonetContext()
        {
        }

        public InfonetContext(DbContextOptions<InfonetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Infonet> Infonets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Infonets;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Infonet>(entity =>
            {
                entity.HasKey(e => e.InformationId)
                    .HasName("PK_Infonet");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.LanguageSkills).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
