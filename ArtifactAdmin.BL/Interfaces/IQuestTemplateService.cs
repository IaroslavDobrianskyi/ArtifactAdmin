// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IQuestTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
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
