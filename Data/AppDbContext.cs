using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mapping.Data
{

      public class AppDbContext : DbContext
      {
            public DbSet<Course> courses { get; set; }
            public DbSet<Instructor> Instructors { get; set; }
            public DbSet<Office> Offices { get; set; }
            public DbSet<Schedule> schedules { get; set; }
            public DbSet<Section> sections { get; set; }
            public DbSet<Participant> Participants { get; set; }
            public DbSet<Individual> Individuals { get; set; }
            public DbSet<Corprate> Corprates { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }
            public DbSet<TimeSlot> TimeSlot { get; set; }
            public DbSet<MultipleChoiceQuiz> MultipleChoiceQuizes { get; set; }
            public DbSet<TrueAndFalseQuiz> TrueAndFalseQuizes { get; set; }




            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  base.OnConfiguring(optionsBuilder);
                  var configuration = new ConfigurationBuilder()
                               .AddJsonFile("applicationsetting.json")
                               .Build();
                  var constr = configuration.GetSection("ConStr").Value;
                  optionsBuilder.UseNpgsql(constr);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            }

      }
}