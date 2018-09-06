using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class EfLunchAndLearnDbFirstContext : DbContext
    {
        public EfLunchAndLearnDbFirstContext()
        {
        }

        public EfLunchAndLearnDbFirstContext(DbContextOptions<EfLunchAndLearnDbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Drawers> Drawers { get; set; }
        public virtual DbSet<Folders> Folders { get; set; }
        public virtual DbSet<ImportName> ImportName { get; set; }
        public virtual DbSet<ImportNameType> ImportNamesTypes { get; set; }
        public virtual DbSet<ImportStatus> ImportStatus { get; set; }
        public virtual DbSet<ImportType> ImportType { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<PagesMetadata> PagesMetadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfLunchAndLearnDbFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.HasIndex(e => e.FolderId);

                entity.Property(e => e.FileLocation).HasMaxLength(100);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Drawers>(entity =>
            {
                entity.HasKey(e => e.DrawerId);

                entity.Property(e => e.DrawerDescription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DrawerName)
                    .IsRequired()
                    .HasMaxLength(10);

          
            });

            modelBuilder.Entity<Folders>(entity =>
            {
                entity.HasKey(e => e.FolderId);

                entity.HasIndex(e => e.DrawerId);

                entity.HasIndex(e => e.ImportNameTypeId);

                entity.Property(e => e.FolderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsName).HasMaxLength(500);

                entity.Property(e => e.Lob)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Drawer)
                    .WithMany(p => p.Folders)
                    .HasForeignKey(d => d.DrawerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ImportNameType)
                    .WithMany(p => p.Folders)
                    .HasForeignKey(d => d.ImportNameTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ImportName>(entity =>
            {
                entity.ToTable("ImportName");
                entity.Property(e => e.ImportName1)
                    .IsRequired()
                    .HasColumnName("ImportName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImportNameType>(entity =>
            {
                entity.HasKey(e => e.ImportNameTypeId);

                entity.HasOne(d => d.ImportName)
                    .WithMany(p => p.ImportNamesTypes)
                    .HasForeignKey(d => d.ImportNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ImportStatus)
                    .WithMany(p => p.ImportNamesTypes)
                    .HasForeignKey(d => d.ImportStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ImportType)
                    .WithMany(p => p.ImportNamesTypes)
                    .HasForeignKey(d => d.ImportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ImportStatus>(entity =>
            {
                entity.Property(e => e.ImportStatus1)
                    .IsRequired()
                    .HasColumnName("ImportStatus")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImportType>(entity =>
            {
                entity.Property(e => e.ImportTypeDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.HasKey(e => e.PageId);

                entity.HasIndex(e => e.DocumentId);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FullFilePath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PageDescription).HasMaxLength(200);

                entity.Property(e => e.WinFileType)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PagesMetadata>(entity =>
            {
                entity.HasKey(e => e.PageMetaDataId);

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.DataKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DataValue)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PagesMetadata)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pages_PagesMetaData_PageId");
            });
        }
    }
}
