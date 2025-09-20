

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mapping.Data.Configrations;

public class ConfigrationWithIndividual : IEntityTypeConfiguration<Individual>
{
      public void Configure(EntityTypeBuilder<Individual> builder)
      {


            builder.ToTable("Individual");

      }


}

