using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options) : base(options)
        {
        }

        public DbSet<MusicInfo> MusicInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicInfo>().Property(x => x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Artist).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Language).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Description).HasMaxLength(100);
            modelBuilder.Entity<MusicInfo>().Property(x => x.TransName).HasMaxLength(50);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Album).HasMaxLength(100);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Gain).IsRequired();
            modelBuilder.Entity<MusicInfo>().Property(x => x.Peak).IsRequired();
            modelBuilder.Entity<MusicInfo>().Property(x => x.Lra).IsRequired();
            modelBuilder.Entity<MusicInfo>().Property(x => x.Bpm).IsRequired();
            modelBuilder.Entity<MusicInfo>().Property(x => x.Interval).IsRequired();
            modelBuilder.Entity<MusicInfo>().Property(x => x.Company).HasMaxLength(100);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Genre).HasMaxLength(50);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Mid).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<MusicInfo>().Property(x => x.Id).IsRequired();
        }
    }
}