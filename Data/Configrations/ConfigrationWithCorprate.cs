

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mapping.Data.Configrations;


public class ConfigrationWithCorprate : IEntityTypeConfiguration<Corprate>
{
      public void Configure(EntityTypeBuilder<Corprate> builder)
      {


            builder.ToTable("Corprate");

      }


}


