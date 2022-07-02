﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        [Fact]
        public void ShouldGenerateCodeFromTemplate()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;
            string randomTransformedStringTemplate = GetRandomString();
            string transformedStringTemplate = randomTransformedStringTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Template randomTransformedTemplate = CreateRandomTemplate();
            Template transformedTemplate = randomTemplate;

            string sourceTemplateString = GetRandomString();
            string targetTemplateString = GetRandomString();
            string powerShellScriptMessage = GetRandomString();

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Returns(transformedStringTemplate);

            this.templateServiceMock.Setup(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate))
                    .Returns(transformedTemplate);


            if (transformedTemplate.Tasks.Any())
            {
                foreach (Models.Tasks.Task task in transformedTemplate.Tasks)
                {
                    if (task.Actions.Any())
                    {
                        foreach (Models.Actions.Action action in task.Actions)
                        {
                            if (action.FileItems.Any())
                            {
                                foreach (FileItem fileItem in action.FileItems)
                                {
                                    this.fileServiceMock.Setup(fileService =>
                                        fileService.ReadFromFile(fileItem.Template))
                                            .Returns(sourceTemplateString);

                                    this.templateServiceMock.Setup(templateService =>
                                        templateService
                                            .TransformString(sourceTemplateString, randomReplacementDictionary))
                                                .Returns(targetTemplateString);
                                }
                            }

                            if (action.Scripts.Any())
                            {
                                this.powerShellServiceMock.Setup(powerShellService =>
                                    powerShellService.RunScript(action.Scripts, action.ExecutionFolder))
                                        .Returns(powerShellScriptMessage);
                            }
                        }
                    }
                }
            }

            // when
            bool actualGenerateCodeFromTemplateResult = this.templateOrchestrationService
                .GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            // then
            actualGenerateCodeFromTemplateResult.Should().BeTrue();

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate),
                    Times.Once);


            if (transformedTemplate.Tasks.Any())
            {
                foreach (Models.Tasks.Task task in transformedTemplate.Tasks)
                {
                    if (task.Actions.Any())
                    {
                        foreach (Models.Actions.Action action in task.Actions)
                        {
                            if (action.FileItems.Any())
                            {
                                foreach (FileItem fileItem in action.FileItems)
                                {
                                    this.fileServiceMock.Verify(fileService =>
                                        fileService.ReadFromFile(fileItem.Template),
                                            Times.Once);

                                    this.templateServiceMock.Verify(templateService =>
                                        templateService
                                            .TransformString(sourceTemplateString, randomReplacementDictionary),
                                                Times.Once);
                                }
                            }

                            if (action.Scripts.Any())
                            {
                                this.powerShellServiceMock.Verify(powerShellService =>
                                    powerShellService.RunScript(action.Scripts, action.ExecutionFolder),
                                        Times.Once);
                            }
                        }
                    }
                }
            }

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
        }

    }
}
