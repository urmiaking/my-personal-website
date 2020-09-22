using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.Models;
using PersonalWebsite.Models;
using PersonalWebsite.Models.Weblog;

namespace PersonalWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        #region AboutMe

        public virtual DbSet<AboutMe> AboutMe { get; set; }

        public virtual DbSet<Technology> Technologies { get; set; }

        #endregion

        #region ContactMe

        public virtual DbSet<ContactMe> ContactMe { get; set; }

        public virtual DbSet<ContactForm> ContactForms { get; set; }

        #endregion

        #region Education

        public virtual DbSet<Education> Educations { get; set; }

        #endregion

        #region Experience

        public virtual DbSet<Experience> Experiences { get; set; }

        public virtual DbSet<Tool> Tools { get; set; }

        #endregion

        #region Skills

        public virtual DbSet<TechnicalSkill> TechnicalSkills { get; set; }

        public virtual DbSet<PersonalSkill> PersonalSkills { get; set; }

        #endregion

        #region WorkSamples

        public virtual DbSet<WorkSample> WorkSamples { get; set; }

        public virtual DbSet<WorkSampleCategory> WorkSampleCategories { get; set; }

        public virtual DbSet<Detail> Details { get; set; }

        #endregion

        #region Site Admin

        public virtual DbSet<SiteAdmin> SiteAdmins { get; set; }

        #endregion

        #region MailServer

        public DbSet<MailServer> MailServers { get; set; }

        #endregion

        #region ClientVisit

        public virtual DbSet<ClientVisit> ClientVisits { get; set; }

        #endregion

        #region Blog

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkSample>()
                .HasOne(ws => ws.Detail)
                .WithOne(d => d.WorkSample);

            modelBuilder.Entity<ExperienceTool>()
                .HasKey(et => new { et.ExperienceId, et.ToolId });
            modelBuilder.Entity<ExperienceTool>()
                .HasOne(et => et.Experience)
                .WithMany(e => e.ExperienceTools);
            modelBuilder.Entity<ExperienceTool>()
                .HasOne(et => et.Tool)
                .WithMany(t => t.ExperienceTools);

            modelBuilder.Entity<WorkSampleCategory>()
                .HasKey(et => new { et.WorkSampleId, et.CategoryId });
            modelBuilder.Entity<WorkSampleCategory>()
                .HasOne(et => et.WorkSample)
                .WithMany(e => e.WorkSampleCategories);
            modelBuilder.Entity<WorkSampleCategory>()
                .HasOne(et => et.Category)
                .WithMany(t => t.WorkSampleCategories);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs);

            modelBuilder.Seed();
        }
    }
}
