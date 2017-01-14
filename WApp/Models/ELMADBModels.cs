﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        }

        public class WorkflowBookmark
        {
            long id;
            Guid uid;
            Guid elementUid;
            long instance;
        }

        public class TaskBase
        {
            long id;
            long executor;
            string subject;
            DateTime startDate;
            DateTime endWorkDate;
            long workflowBookmark;
        }

        public class WorkflowTrackingItem
        {
            long id;
            Guid elementUid;
            DateTime startDate;
            DateTime endDate;
        }

        public class WorkflowProcess
        {
            long id;
            string name;
            long header;
            long versionNumber;
        }     
    }
}