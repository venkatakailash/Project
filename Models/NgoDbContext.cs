﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NgoProjectNew1.Models
{
    public partial class NgoDbContext : DbContext
    {
        public NgoDbContext()
        {
        }

        public NgoDbContext(DbContextOptions<NgoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NgoLogin> NgoLogins { get; set; }
        public virtual DbSet<NgoNews> NgoNews { get; set; }
        public virtual DbSet<NgoRegMember> NgoRegMembers { get; set; }
        public virtual DbSet<NgoUserRole> NgoUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN800021623\\SQLEXPRESS; Database=NGO_DB; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<NgoLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NGO_Login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__NGO_Login__Membe__276EDEB3");
            });

            modelBuilder.Entity<NgoNews>(entity =>
            {
                entity.HasKey(e => e.NewsId)
                    .HasName("PK__NGO_News__954EBDF3693C49AE");

                entity.ToTable("NGO_News");

                entity.Property(e => e.NewsId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.News)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");
            });

            modelBuilder.Entity<NgoRegMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__NGO_RegM__0CF04B184DDBB0FA");

                entity.ToTable("NGO_RegMembers");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AdminComments)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Comments");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Is_Active");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.NgoRegMembers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__NGO_RegMe__RoleI__25869641");
            });

            modelBuilder.Entity<NgoUserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__NGO_User__8AFACE1A65C6E9B1");

                entity.ToTable("NGO_UserRoles");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
