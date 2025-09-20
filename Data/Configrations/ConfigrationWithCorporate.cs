

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mapping.Data.Configrations;


public class ConfigrationWithCorporate : IEntityTypeConfiguration<Corporate>
{
      public void Configure(EntityTypeBuilder<Corporate> builder)
      {


            builder.ToTable("Corporate");

      }


}


