namespace Mapping.Data.Entities;

public class Enrollment
{
      public int SectionId { get; set; }
      public int ParticipantId { get; set; }

      public Section Section { get; set; } = null!;
      public Participant Participants { get; set; } = null!;
}
