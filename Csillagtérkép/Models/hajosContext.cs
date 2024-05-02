using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Csillagtérkép.Models
{
    public partial class hajosContext : DbContext
    {
        public hajosContext()
        {
        }

        public hajosContext(DbContextOptions<hajosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConstellationLine> ConstellationLines { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<StarDatum> StarData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=bit.uni-corvinus.hu;Initial Catalog=hajos;Persist Security Info=True;User ID=hallgato;Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConstellationLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ConstellationLine");

                entity.Property(e => e.Star1).HasColumnName("star1");

                entity.Property(e => e.Star2).HasColumnName("star2");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Question_ID");

                entity.Property(e => e.Question1).HasColumnName("Question");
            });

            modelBuilder.Entity<StarDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DecDegrees).HasColumnName("dec_degrees");

                entity.Property(e => e.DecMasPerYear).HasColumnName("dec_mas_per_year");

                entity.Property(e => e.EpochYear).HasColumnName("epoch_year");

                entity.Property(e => e.Hip).HasColumnName("hip");

                entity.Property(e => e.Magnitude).HasColumnName("magnitude");

                entity.Property(e => e.ParallaxMas).HasColumnName("parallax_mas");

                entity.Property(e => e.RaDegrees).HasColumnName("ra_degrees");

                entity.Property(e => e.RaHours).HasColumnName("ra_hours");

                entity.Property(e => e.RaMasPerYear).HasColumnName("ra_mas_per_year");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
