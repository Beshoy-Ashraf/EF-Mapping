

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mapping.Data.Configrations;

public class ConfigrationWithQuiz : IEntityTypeConfiguration<Quiz>
{
      public void Configure(EntityTypeBuilder<Quiz> builder)
      {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedNever();

            builder.UseTptMappingStrategy();



      }


}


