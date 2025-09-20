using Mapping.Data;
using Mapping.Data.Entities;

namespace Mapping
{
      class Program
      {
            public static void Main(string[] args)
            {
                  using (var context = new AppDbContext())
                  {
                        var ind = new Individual
                        {
                              Id = 1,
                              FName = "Besho",
                              LName = "Ashraf",
                              IsIntern = false,
                              University = "Kafr el Sheikh",
                              YearOfGraduation = 2024,

                        };
                        var corp = new Corprate
                        {

                              Id = 2,
                              FName = "Besho",
                              LName = "Ashraf",
                              JobTitle = "Develpober",
                              Company = "vodafone"
                        };
                        context.Participants.Add(ind);
                        context.Participants.Add(corp);
                        context.SaveChanges();

                  }
                  using (var context = new AppDbContext())
                  {

                        foreach (var p in context.Set<Participant>().OfType<Individual>())
                        {
                              Console.WriteLine(p);
                        }
                  }

            }
      }
}