namespace Mapping.Data.Entities
{
      public class Instructor
      {
            public int Id { get; set; }
            public required string FName { get; set; }
            public required string LName { get; set; }

            public int? OfficeId { get; set; }

            public Office? office { get; set; } = null;

            public ICollection<Section> sections { get; set; } = new List<Section>();

      }
}
