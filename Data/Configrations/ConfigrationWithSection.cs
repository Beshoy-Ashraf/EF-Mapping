

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping.Data.Configrations;

public class ConfigrationWithSection : IEntityTypeConfiguration<Section>
{
      public void Configure(EntityTypeBuilder<Section> builder)
      {
            builder.ToTable("Section");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .ValueGeneratedNever();

            builder.Property(x => x.SectionName).HasColumnType("VARCHAR").HasMaxLength(250);

            builder.HasOne(x => x.Course)
            .WithMany(x => x.Sections)
            .HasForeignKey(X => X.CourseId)
            .IsRequired();

            builder.HasOne(x => x.Instructor)
            .WithMany(x => x.sections)
            .HasForeignKey(x => x.InstructorId)
            .IsRequired(false);



            builder.HasMany(x => x.Participants)
            .WithMany(x => x.sections)
            .UsingEntity<Enrollment>();

            builder.HasOne(x => x.Schedule)
            .WithMany(x => x.sections)
            .HasForeignKey(x => x.ScheduleId)
            .IsRequired();

            builder.OwnsOne(
                  x => x.TimeSlot,
                  ts =>
                  {
                        ts.Property(p => p.StartTime).HasColumnType("time").HasColumnName("StartTime");
                        ts.Property(p => p.EndTime).HasColumnType("time").HasColumnName("EndTime");
                  }
          );




      }


}
