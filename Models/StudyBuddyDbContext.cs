using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BootCampStudyBuddy_BackEnd.Models;

public partial class StudyBuddyDbContext : DbContext
{
    public StudyBuddyDbContext()
    {
    }

    public StudyBuddyDbContext(DbContextOptions<StudyBuddyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=StudyBuddyDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC27EC4DECD6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__QuizI__4D94879B");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC2703460204");

            entity.ToTable("Quiz");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Answer).HasMaxLength(1000);
            entity.Property(e => e.Question).HasMaxLength(1000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
