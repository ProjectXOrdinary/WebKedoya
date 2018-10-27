using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using WebKedoya.Models;

namespace WebKedoya.Data
{

    /// <summary>
    /// Configuring Model using Fluent API
    /// </summary>
    public class KedoyaDataContext : DbContext
    {

        public virtual DbSet<General> Generals { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Kehadiran> Kehadirans { get; set; }
        public virtual DbSet<JenisIbadah> JenisIbadahs{ get; set; }
        public virtual DbSet<JenisJemaat> JenisJemaats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=root;password=''; database=gkikedoya;SslMode=none;");

            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            //    .SetBasePath(hostingEnvironment.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //IConfigurationRoot configurationRoot = configurationBuilder.Build();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<General>().ToTable("msgeneral");
            modelBuilder.Entity<General>(entity =>
            {
                entity.Property(e => e.GeneralID).HasColumnName("general_id");
                entity.Property(e => e.GeneralName).HasColumnName("general_name");
                entity.Property(e => e.GeneralDescription).HasColumnName("general_description");

                modelBuilder.Entity<General>().HasKey(e => new { e.GeneralID });
            });

            modelBuilder.Entity<Setting>().ToTable("mssetting");
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.SettingID).HasColumnName("setting_id");
                entity.Property(e => e.SettingName).HasColumnName("setting_name");
                entity.Property(e => e.SettingDescription).HasColumnName("setting_description");
                entity.Property(e => e.SettingType).HasColumnName("setting_type");

                modelBuilder.Entity<Setting>().HasKey(e => new { e.SettingID });
            });

            modelBuilder.Entity<User>().ToTable("msuser");
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserID).HasColumnName("user_id");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.FullName).HasColumnName("fullname");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.RoleID).HasColumnName("role_id");

                modelBuilder.Entity<User>().HasKey(e => new { e.UserID });
            });

            modelBuilder.Entity<Role>().ToTable("msrole");
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleID).HasColumnName("role_id");
                entity.Property(e => e.RoleName).HasColumnName("role_name");

                modelBuilder.Entity<Role>().HasKey(e => new { e.RoleID });
            });


            modelBuilder.Entity<Kehadiran>().ToTable("kehadiran");
            modelBuilder.Entity<Kehadiran>(entity =>
            {
                entity.Property(e => e.IDKehadiran).HasColumnName("id_kehadiran");
                entity.Property(e => e.Tanggal).HasColumnName("tanggal");
                entity.Property(e => e.KodeJenisIbadah).HasColumnName("kode_jenis_ibadah");
                entity.Property(e => e.KodeJenisJemaat).HasColumnName("kode_jenis_jemaat");
                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                modelBuilder.Entity<Kehadiran>().HasKey(e => new { e.IDKehadiran });
            });

            modelBuilder.Entity<JenisJemaat>().ToTable("jenisjemaat");
            modelBuilder.Entity<JenisJemaat>(entity =>
            {
                entity.Property(e => e.IDJenisJemaat).HasColumnName("id_jenis_jemaat");
                entity.Property(e => e.KodeJenisJemaat).HasColumnName("kode_jenis_jemaat");
                entity.Property(e => e.NamaJenisJemaat).HasColumnName("nama_jenis_jemaat");
                entity.Property(e => e.KeteranganJenisJemaat).HasColumnName("keterangan");

                modelBuilder.Entity<JenisJemaat>().HasKey(e => new { e.IDJenisJemaat });
            });

            modelBuilder.Entity<JenisIbadah>().ToTable("jenisibadah");
            modelBuilder.Entity<JenisIbadah>(entity =>
            {
                entity.Property(e => e.IDJenisIbadah).HasColumnName("id_jenis_ibadah");
                entity.Property(e => e.KodeJenisIbadah).HasColumnName("kode_jenis_ibadah");
                entity.Property(e => e.NamaJenisIbadah).HasColumnName("nama_jenis_ibadah");
                entity.Property(e => e.KeteranganJenisIbadah).HasColumnName("keterangan");

                modelBuilder.Entity<JenisIbadah>().HasKey(e => new { e.IDJenisIbadah});
            });


        }
    }
}
