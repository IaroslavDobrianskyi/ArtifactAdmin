// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IQuestTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;
    
    public interface IQuestTemplateService
    {
        IEnumerable<QuestTemplateDto> GetAll();

        QuestTemplateDto GetViewById(int? id);

        QuestTemplateDto GetById(int? id);

        QuestTemplateDto GetByList(QuestTemplateDto questTemplateDto, string[] steps);

        QuestTemplateDto Create(QuestTemplateDto questTemplateDto, string[] steps);

        QuestTemplateDto Update(QuestTemplateDto questTemplateDto, string[] steps);

        void Delete(int? id);
    }
}
