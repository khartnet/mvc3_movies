using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyFirstWebsite.Models
{
    public class WorkEventInitializer : DropCreateDatabaseIfModelChanges<WorkEventDBContext>
    {
        protected override void Seed(WorkEventDBContext context)
        {
            var workevents = new List<WorkEvent> {  
  
                 new WorkEvent { UserName = "Tim", 
                     Comment = "Tim", 
                     StartTime=DateTime.Parse("1989-1-11"), 
                     EndTime=DateTime.Parse("1989-1-11"), 
                     JobID=0},  
             };

            workevents.ForEach(d => context.WorkEvents.Add(d));
        }
    }
}