using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static CodeFirst.Model;
using static CodeFirst.Model.WorkflowInstance;

namespace CodeFirst
{
    public class SampleContext : DbContext
    {
        public SampleContext()
            :base("Data Source=n0039;Initial Catalog=HW2;User ID=sa;Password=123qwe;")
        {
            
        }

        public DbSet<TaskBase> TaskBase { get; set; }
            public DbSet<WorkflowBookmark> WorkflowBookmark { get; set; }
            public DbSet<WorkflowInstance> WorkflowInstance { get; set; }
            public DbSet<WorkflowProcess> WorkflowProcess { get; set; }
            public DbSet<WorkflowTrackingItem> WorkflowTrackingItem { get; set; }
            public DbSet<ELMAConnetion> ELMAConnetion { get; set; }
            public DbSet<ProcessHeader> ProcessHeader { get; set; }
       

    }
}
