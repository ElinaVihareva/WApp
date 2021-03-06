﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Model
    {
        public class WorkflowInstance
        {

            public int Id { get; set; }
            public int pId { get; set; }
            public Guid uid { get; set; }
            public long process { get; set; }
            public long header { get; set; }
            public string name { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? endDate { get; set; }
            public long status { get; set; }
            public Guid elementUid { get; set; }
            public long elmaId { get; set; }

        }
        public class WorkflowBookmark
        {

            public int Id { get; set; }
            public int pId { get; set; }
            public Guid uid { get; set; }
            public Guid elementUid { get; set; }
            public long instance { get; set; }
            public long elmaId { get; set; }
        }

        public class TaskBase
        {

            public int Id { get; set; }
            public int pId { get; set; }
            public long executor { get; set; }
            public string subject { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? endWorkDate { get; set; }
            public long? workflowBookmark { get; set; }
            public long elmaId { get; set; }
        }

        public class WorkflowTrackingItem
        {

            public int Id { get; set; }
            public int pId { get; set; }
            public Guid elementUid { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? endDate { get; set; }
            public long elmaId { get; set; }
        }

        public class WorkflowProcess
        {

            public int Id { get; set; }
            public int pId { get; set; }
            public string name { get; set; }
            public long header { get; set; }
            public long versionNumber { get; set; }
            public long elmaId { get; set; }
        }

        public class ELMAConnetion
        {
            public string address { get; set; }
            public int pId { get; set; }
            public string ogin { get; set; }
            public string password { get; set; }
            public int Id { get; set; }
        }

        public class ProcessHeader
        {
            public int Id { get; set; }
            public int pId { get; set; }
            public string Name { get; set; }
            public Guid Uid { get; set; }
        }

        public class SwimlineInstance
        {
            public int Id { get; set; }
            public int swimlineId { get; set; }
            public int processId { get; set; }
            public int instanceId { get; set; }

        }
        public class Swimline
        {
            public int Id { get; set; }
            public int pId { get; set; }
            public string Name { get; set; }
            
        }

    }
}
