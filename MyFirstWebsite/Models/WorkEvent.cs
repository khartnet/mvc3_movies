using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebsite.Models
{
    public class WorkEvent
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int JobID { get; set; }
    }

    public class WorkEventDBContext : DbContext
    {
        public DbSet<WorkEvent> WorkEvents { get; set; }
    }
}