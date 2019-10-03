using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace comp2084_assignment1.Models
{
    public partial class zackalbumsContext : DbContext
    {
        public zackalbumsContext()
        {
        }

        public zackalbumsContext(DbContextOptions<zackalbumsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=zackalbums;User Id=zackalbums;Password=Uj4qdI~_t711;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.AlbumArt).IsUnicode(false);

                entity.Property(e => e.AlbumName).IsUnicode(false);

                entity.Property(e => e.Artist).IsUnicode(false);

                entity.HasOne(d => d.ArtistNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albums_Artist_Id");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.Property(e => e.ArtistName).IsUnicode(false);
            });

            modelBuilder.Entity<Songs>(entity =>
            {
                entity.Property(e => e.AlbumArt).IsUnicode(false);

                entity.Property(e => e.Artist).IsUnicode(false);

                entity.Property(e => e.SongName).IsUnicode(false);

                entity.Property(e => e.SpotifyLink).IsUnicode(false);

                entity.Property(e => e.TrackLength).IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Album_Id");
            });
        }
    }
}
