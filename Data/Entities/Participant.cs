namespace Mapping.Data.Entities;

public class Participant
{
      public int Id { get; set; }
      public required string FName { get; set; }
      public required string LName { get; set; }

      public ICollection<Section> sections { get; set; } = new List<Section>();
}

public class Individual : Participant
{
      public string University { get; set; }
      public int YearOfGraduation { get; set; }
      public bool IsIntern { get; set; }

      public override string ToString()
      {
            return $"Participant Name IS : {FName + " " + LName} | University IS : {University} |  Year Of Graduation IS : {YearOfGraduation} ";
      }
}

public class Corprate : Participant
{
      public string Company { get; set; }
      public string JobTitle { get; set; }
      public override string ToString()
      {
            return $"Participant Name IS : {FName + " " + LName} | Company IS : {Company} |  Job Title IS : {JobTitle} ";
      }
}
