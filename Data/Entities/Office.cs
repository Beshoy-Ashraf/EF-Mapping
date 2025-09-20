namespace Mapping.Data.Entities;

public class Office
{
      public int Id { get; set; }
      public required string OfficeName { get; set; }
      public required string OfficeLocation { get; set; }


      public Instructor? instructor { get; set; }
}
