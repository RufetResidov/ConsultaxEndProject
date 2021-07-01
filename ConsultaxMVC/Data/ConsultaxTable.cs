using ConsultaxMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Data
{
    public class ConsultaxTable : DbContext
    {
        public ConsultaxTable(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AllProject> AllProjects { get; set; }
        public DbSet<AllService> AllServices { get; set; }
        public DbSet<AltSection> AltSections { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SectionOne> SectionOnes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WhoWeAre> WhoWeAres { get; set; }
        //Cases Section
        public DbSet<FeaturedProject> FeaturedProjects { get; set; }
        public DbSet<CustomerSayProject> CustomerSayProjects { get; set; }
        public DbSet<ProsesWork> ProsesWorks { get; set; }
        public DbSet<DetailsProject> DetailsProjects { get; set; }
        public DbSet<PictureProject> PictureProjects { get; set; }
        //AboutSection
        public DbSet<PagesContactUs> PagesContactUs { get; set; }
        public DbSet<AboutSlider> AboutSliders { get; set; }
        public DbSet<AboutLogo> AboutLogos { get; set; }
        public DbSet<AboutStatisticCount> AboutStatisticCounts { get; set; }
        public DbSet<AboutWhatWeDo> AboutWhatWeDos { get; set; }
        //Our Team
        public DbSet<TeamLeaderShip> TeamLeaderShips { get; set; }
        public DbSet<TeamExpert> TeamExperts { get; set; }
        //How It Work
        public DbSet<WorkBackground> WorkBackgrounds { get; set; }
        public DbSet<WorkClient> WorkClients { get; set; }
        public DbSet<WorkFeatured> WorkFeatureds { get; set; }
        //Service Box
        public DbSet<ServiceAboutPicture> ServiceAboutPictures { get; set; }
        //Career
        public DbSet<CareerHiring> CareerHirings { get; set; }


    }
}
