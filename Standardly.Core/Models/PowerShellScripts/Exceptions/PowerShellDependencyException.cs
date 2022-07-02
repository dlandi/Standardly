﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class PowerShellDependencyException : Xeption
    {
        public PowerShellDependencyException(Xeption innerException) :
            base(message: "PowerShell dependency error occurred, contact support.", innerException)
        { }
    }
}
