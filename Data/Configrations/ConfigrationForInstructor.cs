
using Mapping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping.Data.Configrations;

public class ConfigrationForInstructor : IEntityTypeConfiguration<Instructor>
{
      public void Configure(EntityTypeBuilder<Instructor> builder)
      {
            builder.ToTable("Instructor");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .ValueGeneratedNever();

            builder.Property(x => x.FName).HasColumnType("VARCHAR").HasMaxLength(250);
            builder.Property(x => x.LName).HasColumnType("VARCHAR").HasMaxLength(250);

            builder.HasOne(x => x.office)
            .WithOne(e => e.instructor)
            .HasForeignKey<Instructor>(x => x.OfficeId)
            .IsRequired(false);





            builder.HasData(IntitialData());


      }

      private static List<Instructor> IntitialData()
      {
            return new List<Instructor>
            {
                  new Instructor {Id = 1 , FName = "Ahmed", LName  = " Ali" ,   OfficeId =1},
                  new Instructor {Id = 2 , FName = "Momen", LName  = " Ahmed",  OfficeId =2},
                  new Instructor {Id = 3 , FName = "Beshoy",LName  = " Ashraf", OfficeId =3},
                  new Instructor {Id = 4 , FName = "Mena ", LName  = "Maged"  , OfficeId =4},
                  new Instructor {Id = 5 , FName = "Boles ",LName  = "Gorge"  , OfficeId =5}
            };
      }
}