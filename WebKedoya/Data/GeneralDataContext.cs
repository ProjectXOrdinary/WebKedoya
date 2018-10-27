using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebKedoya.Models;

namespace WebKedoya.Data
{
    public class GeneralDataContext : DbContext
    {

        public GeneralDataContext(DbContextOptions<GeneralDataContext> options) : base(options)
        {
        }

        public virtual DbSet<General> Generals { get; set; }

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
        }
    }
}
