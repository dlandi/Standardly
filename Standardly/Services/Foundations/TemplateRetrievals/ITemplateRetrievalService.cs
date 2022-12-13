﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Models.Foundations.TemplateGenerations.Templates;

namespace Standardly.Services.Foundations
{
    public interface ITemplateRetrievalService
    {
        List<Template> FindAllTemplates();
    }
}
