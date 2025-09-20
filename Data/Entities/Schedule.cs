using System.Globalization;
using Mapping.Data.Entities.Enum;

namespace Mapping.Data.Entities;

public class Schedule
{


      public int Id { get; set; }
      public WeekDay MeetingDay { get; set; }
      public SchudelTitelEnum Title { get; set; }

      public ICollection<Section> sections { get; set; } = new List<Section>();
}
