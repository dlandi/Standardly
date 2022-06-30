﻿using System.Collections.Generic;

namespace Standardly.Core.Models.Templates
{
    public class Template
    {
        public string RawTemplate { get; set; }
        public string ModelSingularName { get; set; }
        public string ModelPluralName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateType { get; set; }
        public int SortOrder { get; set; }
        public string RequiredProjects { get; set; }
        public List<Models.Tasks.Task> Tasks { get; set; } = new List<Models.Tasks.Task>();
        public List<string> CleanupTasks { get; set; } = new List<string>();
    }
}
