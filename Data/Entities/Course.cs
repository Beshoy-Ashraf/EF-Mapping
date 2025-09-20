namespace Mapping.Data.Entities;

public class Course
{
      public int Id { get; set; }
      public required string Name { get; set; }
      public decimal Price { get; set; }

      public ICollection<Section> Sections { get; set; } = new List<Section>();


}
