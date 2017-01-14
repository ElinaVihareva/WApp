using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WApp.Models
{
    public class ELMADBModels
    {
        
        public class WorkflowInstance
        {
            
            public int id { get; set; }
            public Guid uid;
            public long process;
            public string name;
            public DateTime startDate;
            public DateTime endDate;
            public long status;
            public Guid elementUid;
            public long elmaId;
        }

        public class WorkflowBookmark
        {
           
            public int id { get; set; }
            Guid uid;
            Guid elementUid;
            long instance;
            long elmaId;
        }

        public class TaskBase
        {
  
            public int id { get; set; }
            long executor;
            string subject;
            DateTime startDate;
            DateTime endWorkDate;
            long workflowBookmark;
            long elmaId;
        }

        public class WorkflowTrackingItem 
        {
           
            public int Id { get; set; }
            Guid elementUid;
            DateTime startDate;
            DateTime endDate;
            long elmaId;
        }

        public class WorkflowProcess 
        {
          
            public int Id { get; set; }
            string name;
            long header;
            long versionNumber;
            long elmaId;
        }

        public class ELMAConnetion
        {
            string address;
            string login;
            string password;
           
            public int Id { get; set; }
        }
    }
}