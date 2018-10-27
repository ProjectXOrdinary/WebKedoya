using Microsoft.EntityFrameworkCore;
using WebKedoya.Models;

namespace WebKedoya.Data
{
    public class SettingDataContext : DbContext
    {

        public SettingDataContext(DbContextOptions<SettingDataContext> options) : base(options)
        {
        }

        public virtual DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>().ToTable("mssetting");


            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.SettingID).HasColumnName("setting_id");
                entity.Property(e => e.SettingName).HasColumnName("setting_name");
                entity.Property(e => e.SettingDescription).HasColumnName("setting_description");
                entity.Property(e => e.SettingType).HasColumnName("setting_type");

                modelBuilder.Entity<Setting>().HasKey(e => new { e.SettingID });
            });
        }
    }
}
