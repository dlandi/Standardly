﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.FileItems;

namespace Standardly.Core.Models.Actions
{
    public class Action
    {
        public string Name { get; set; }
        public string ExecutionFolder { get; set; }
        public List<FileItem> FileItems { get; set; } = new List<FileItem>();
        public List<Execution> Executions { get; set; } = new List<Execution>();
    }
}
