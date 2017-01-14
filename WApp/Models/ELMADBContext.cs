using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WApp.Models
{
    public class ELMADBContext : DbContext
    {
        public DbSet<ELMADBModels.TaskBase> TaskBase { get; set; }
        public DbSet<ELMADBModels.WorkflowBookmark> WorkflowBookmark { get; set; }
        public DbSet<ELMADBModels.WorkflowInstance> WorkflowInstance { get; set; }
        public DbSet<ELMADBModels.WorkflowProcess> WorkflowProcess { get; set; }
        public DbSet<ELMADBModels.WorkflowTrackingItem> WorkflowTrackingItem { get; set; }
        public DbSet<ELMADBModels.ELMAConnetion> ELMAConnetion { get; set; }
    }
}