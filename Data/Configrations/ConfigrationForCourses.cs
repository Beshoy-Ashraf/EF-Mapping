using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mapping.Data.Entities;

namespace Mapping.Data.Configrations
{

      public class ConfigrationForCourses : IEntityTypeConfiguration<Course>
      {
            public void Configure(EntityTypeBuilder<Course> builder)
            {
                  builder.ToTable("Course");

                  builder.HasKey(x => x.Id);
                  builder.Property(x => x.Id)
                  .ValueGeneratedNever();

                  builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(250);

                  builder.Property(x => x.Price)
                  .HasPrecision(15, 2);

                  builder.HasData(IntitialData());


            }

            private static List<Course> IntitialData()
            {
                  return new List<Course>
            {
                  new Course {Id = 1 , Name = "Math",   Price=30},
                  new Course {Id = 2 , Name = "English",Price=70},
                  new Course {Id = 3 , Name = "Arabic", Price=40},
                  new Course {Id = 4 , Name = "Science",Price=50},
                  new Course {Id = 5 , Name = "History",Price=20}
            };
            }
      }
}