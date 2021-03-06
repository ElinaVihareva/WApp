﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CodeFirst.Model;
using static CodeFirst.Model.WorkflowInstance;

namespace WApp.Models
{
    public class DiagramsModels
    {
        public List<ProcessHeader> process { get; set; }
        public List<string> namPprocess { get; set; }

        public ProcessHeader processHeader { get; set; }
        public List<WorkflowProcess> workflowProcess { get; set; }
        public List<WorkflowBookmark> workflowBookmark { get; set; }
        public List<WorkflowInstance> workflowInstance { get; set; }
        public List<WorkflowTrackingItem> workflowTrackingItem { get; set; }
        

        /*private List<SelectListItem> _process = new List<SelectListItem>();

        [Required(ErrorMessage = "Пожалуйста выберете процесс")]
        public string SelectedProcess { get; set; }

        public List<SelectListItem> Process
        {
            get { return _process; }
        }*/


    }
}