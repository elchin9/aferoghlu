using Aferoglu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.DAL
{
    public class AferogluDbContext : IdentityDbContext<AppUser>
    {
        public AferogluDbContext(DbContextOptions<AferogluDbContext> options) : base(options)
        {
        }

        public DbSet<About> About { get; set; }
        public DbSet<Lang> Langs { get; set; }
        public DbSet<AboutLang> AboutLang { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryLang> CategoryLangs { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLang> ProductLangs { get; set; }

        public DbSet<MailBox> MailBoxes { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderLang> SliderLangs { get; set; }

        public DbSet<StaticData> StaticData { get; set; }
        public DbSet<StaticDataLang> StaticDataLangs { get; set; }

        public DbSet<OurTeam> OurTeam { get; set; }
        public DbSet<OurTeamLang> OurTeamLangs { get; set; }

        public DbSet<AferogluHistory> AferogluHistory { get; set; }
        public DbSet<AferogluHistoryLang> AferogluHistoryLangs { get; set; }

        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<TestimonialsLang> TestimonialsLangs { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
