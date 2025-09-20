using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping.Data.Configrations
{


      public class ConfigrationWithEnrollment : IEntityTypeConfiguration<Enrollment>
      {
            public void Configure(EntityTypeBuilder<Enrollment> builder)
            {
                  builder.HasKey(x => new { x.SectionId, x.ParticipantId });

                  builder.ToTable("Enrollments");

            }


      }

}
