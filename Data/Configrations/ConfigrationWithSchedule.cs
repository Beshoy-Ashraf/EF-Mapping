

using Mapping.Data.Entities;
using Mapping.Data.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping.Data.Configrations;

public partial class ConfigrationWithSchedule : IEntityTypeConfiguration<Schedule>
{
      public void Configure(EntityTypeBuilder<Schedule> builder)
      {
            builder.ToTable("Schedule");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .ValueGeneratedNever();

            builder.Property(
                  x => x.Title
            ).HasConversion(
                  x => x.ToString(),
                  x => (SchudelTitelEnum)Enum.Parse(typeof(SchudelTitelEnum), x)
            );

            builder.Property(
                  x => x.MeetingDay
            ).HasConversion(
                  x => x.ToString(),
                  x => (WeekDay)Enum.Parse(typeof(WeekDay), x)
            );




            builder.HasData(IntitialData());



      }

      private List<Schedule> IntitialData()
      {
            return new List<Schedule>
            {
                new Schedule { Id = 1, Title = SchudelTitelEnum.Daily      , MeetingDay = WeekDay.Sunday|WeekDay.Thursday},
                new Schedule { Id = 2, Title = SchudelTitelEnum.TwiceAWeek , MeetingDay = WeekDay.Saturday|WeekDay.Monday},
                new Schedule { Id = 3, Title = SchudelTitelEnum.Weekend    , MeetingDay = WeekDay.Friday|WeekDay.Wednesday },
                new Schedule { Id = 4, Title =SchudelTitelEnum.DayAfterDay , MeetingDay = WeekDay.Tuesday|WeekDay.Friday},
            };
      }
}
