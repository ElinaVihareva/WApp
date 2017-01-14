using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static CodeFirst.Model;

namespace CodeFirst
{
    class SampleContext : DbContext
    {
       
            public DbSet<TaskBase> TaskBase { get; set; }
            public DbSet<WorkflowBookmark> WorkflowBookmark { get; set; }
            public DbSet<WorkflowInstance> WorkflowInstance { get; set; }
            public DbSet<WorkflowProcess> WorkflowProcess { get; set; }
            public DbSet<WorkflowTrackingItem> WorkflowTrackingItem { get; set; }
            public DbSet<ELMAConnetion> ELMAConnetion { get; set; }
    }
}
