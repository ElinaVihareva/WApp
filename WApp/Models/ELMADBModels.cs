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
            long id;
            Guid uid;
            long process;
            string name;
            DateTime startDate;
            DateTime endDate;
            long status;
            Guid elementUid;
            long elmaId;
        }

        public class WorkflowBookmark
        {
            long id;
            Guid uid;
            Guid elementUid;
            long instance;
            long elmaId;
        }

        public class TaskBase
        {
            long id;
            long executor;
            string subject;
            DateTime startDate;
            DateTime endWorkDate;
            long workflowBookmark;
            long elmaId;
        }

        public class WorkflowTrackingItem 
        {
            long id;
            Guid elementUid;
            DateTime startDate;
            DateTime endDate;
            long elmaId;
        }

        public class WorkflowProcess 
        {
            long id;
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
            long id;
        }
    }
}