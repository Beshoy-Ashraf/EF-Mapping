

using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mapping.Data.Configrations;


public class ConfigrationWithParticipant : IEntityTypeConfiguration<Participant>
{
      public void Configure(EntityTypeBuilder<Participant> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50).IsRequired();

            // builder.HasDiscriminator<String>("PatricipantType")
            // .HasValue<Individual>("IND")
            // .HasValue<Corprate>("Cor");

            // builder.Property("PatricipantType")
            // .HasColumnType("VARCHAR")
            // .HasMaxLength(3);


            builder.ToTable("Participant");

      }



}
