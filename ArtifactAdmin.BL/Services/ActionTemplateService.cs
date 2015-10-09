// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using Utils;

    public class ActionTemplateService : IActionTemplateService
    {
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<ActionTemplateResult> actionTemplateResultRepository;
        private readonly IRepository<DesireActionTemplateResult> desireActionTemplateResultRepository;
        private readonly IRepository<Desire> desireRepository;
        private readonly IRepository<Characteristic> characteristicRepository;
        private readonly IRepository<Predisposition> predispositionRepository;
        private readonly IRepository<Property> propertyRepository;
        private readonly IRepository<ActionTemplateCharacteristic> actionCharacteristicRepository;
        private readonly IRepository<ActionTemplatePredisposition> actionPredispositionRepository;
        private readonly IRepository<ActionTemplateProperty> actionPropertyRepository;
        private readonly IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository;
        private readonly IRepository<ActionDescription> actionDescriptionRepository; 

        public ActionTemplateService(IRepository<ActionTemplate> actionTemplateRepository,
            IRepository<ActionTemplateResult> actionTemplateResultRepository,
            IRepository<DesireActionTemplateResult> desireActionTemplateResultRepository,
            IRepository<Desire> desireRepository,
            IRepository<Characteristic> characteristicRepository,
            IRepository<Predisposition> predispositionRepository,
            IRepository<Property> propertyRepository,
            IRepository<ActionTemplateCharacteristic> actionCharacteristicRepository,
            IRepository<ActionTemplatePredisposition> actionPredispositionRepository,
            IRepository<ActionTemplateProperty> actionPropertyRepository,
            IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository,
            IRepository<ActionDescription> actionDescriptionRepository) 
        {
            this.actionTemplateRepository = actionTemplateRepository;
            this.actionTemplateResultRepository = actionTemplateResultRepository;
            this.desireActionTemplateResultRepository = desireActionTemplateResultRepository;
            this.desireRepository = desireRepository;
            this.characteristicRepository = characteristicRepository;
            this.predispositionRepository = predispositionRepository;
            this.propertyRepository = propertyRepository;
            this.actionCharacteristicRepository = actionCharacteristicRepository;
            this.actionPredispositionRepository = actionPredispositionRepository;
            this.actionPropertyRepository = actionPropertyRepository;
            this.stepTemplateActionTemplateRepository = stepTemplateActionTemplateRepository;
            this.actionDescriptionRepository = actionDescriptionRepository;
        }

        public IEnumerable<ActionTemplateDto> GetAll()
        {
            return Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll().Include(s => s.ActionTemplateResult1));
        }

        public ViewActionTemplateDto GetViewById(int? id) 
        {
            var viewActionTemplateDto = new ViewActionTemplateDto();
            viewActionTemplateDto.OneProbability = "0.25";
            viewActionTemplateDto.Predisposition = "0.0";
            viewActionTemplateDto.Experience = "0.0";
            viewActionTemplateDto.Posibility = "0.0";
            viewActionTemplateDto.Gold = "0.0";
            viewActionTemplateDto.ActionTemplateResults = Mapper.Map<List<ActionTemplateResultDto>>(this.actionTemplateResultRepository.GetAll());
            viewActionTemplateDto.Characteristics = Mapper.Map<List<CharacteristicDto>>(this.characteristicRepository.GetAll());
            viewActionTemplateDto.Predispositions = Mapper.Map<List<PredispositionDto>>(this.predispositionRepository.GetAll());
            viewActionTemplateDto.Properties = Mapper.Map<List<PropertyDto>>(this.propertyRepository.GetAll());
            viewActionTemplateDto.SelectedCharacteristics = new List<ActionTemplateCharacteristicDto>();
            viewActionTemplateDto.SelectedPredispositions = new List<ActionTemplatePredispositionDto>();
            viewActionTemplateDto.SelectedProperties = new List<ActionTemplatePropertyDto>();
            viewActionTemplateDto.Lows = new List<int>();
            viewActionTemplateDto.Highs = new List<int>();
            viewActionTemplateDto.Appearances = new List<bool>();
            viewActionTemplateDto.OneLow = 0;
            viewActionTemplateDto.OneHigh = 1;
            viewActionTemplateDto.OneAppearance = true;
            if (id != null) 
            {
                viewActionTemplateDto.ActionTemplateDto = Mapper.Map<ActionTemplateDto>(this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id));
                if (viewActionTemplateDto.ActionTemplateDto != null)
                {
                    viewActionTemplateDto.OneProbability = ViewHelper.ConvertSeparatorToDot(viewActionTemplateDto.ActionTemplateDto.BlockProbability.ToString());
                }

                viewActionTemplateDto.SelectedCharacteristics =
                    Mapper.Map<List<ActionTemplateCharacteristicDto>>(this.actionCharacteristicRepository.GetAll()
                                                                          .Where(s => s.ActionTemplate == id));
                if (viewActionTemplateDto.SelectedCharacteristics.Count > 0)
                {
                    foreach (var selectedCharacteristic in viewActionTemplateDto.SelectedCharacteristics)
                    {
                        foreach (var characteristic in viewActionTemplateDto.Characteristics)
                        {
                            if (characteristic.Id == selectedCharacteristic.Characteristics)
                            {
                                viewActionTemplateDto.Characteristics.Remove(characteristic);
                                break;
                            }
                        }
                    }
                }

                viewActionTemplateDto.SelectedProperties =
                    Mapper.Map<List<ActionTemplatePropertyDto>>(this.actionPropertyRepository.GetAll()
                                                                    .Where(s => s.ActionTemplate == id));
                if (viewActionTemplateDto.SelectedProperties.Count > 0)
                {
                    foreach (var selectedProperties in viewActionTemplateDto.SelectedProperties)
                    {
                        viewActionTemplateDto.Appearances.Add(selectedProperties.Appearance);
                        foreach (var property in viewActionTemplateDto.Properties)
                        {
                            if (property.Id == selectedProperties.Properties)
                            {
                                viewActionTemplateDto.Properties.Remove(property);
                                break;
                            }
                        }
                    }
                }

                viewActionTemplateDto.SelectedPredispositions =
                    Mapper.Map<List<ActionTemplatePredispositionDto>>(this.actionPredispositionRepository.GetAll()
                                                                          .Where(s => s.ActionTemplate == id));
                if (viewActionTemplateDto.SelectedPredispositions.Count > 0)
                {
                    foreach (var selectedPredisposition in viewActionTemplateDto.SelectedPredispositions)
                    {
                        viewActionTemplateDto.Lows.Add(selectedPredisposition.RequirementLow);
                        viewActionTemplateDto.Highs.Add(selectedPredisposition.RequirementHigh);
                        foreach (var predisposition in viewActionTemplateDto.Predispositions)
                        {
                            if (predisposition.Id == selectedPredisposition.Predisposition)
                            {
                                viewActionTemplateDto.Predispositions.Remove(predisposition);
                                break;
                            }
                        }
                    }
                }
            }

            return viewActionTemplateDto;
        }

        public ActionTemplateDto GetById(int? id)
        {
            return Mapper.Map<ActionTemplateDto>(this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public ActionTemplateDto Create(ActionTemplateDto actionTemplateDto, int[] characteristics, int[] predispositions, int[] lows, int[] highs, int[] properties, bool[] appearences)
        {
            var actionTemplate = Mapper.Map<ActionTemplate>(actionTemplateDto);
            this.actionTemplateRepository.InsertWithoutSave(actionTemplate);
            if (characteristics != null)
            {
                var objLength = characteristics.Length;
                for (var i = 0; i < objLength; i++)
                {
                    var characteristicId = characteristics[i];
                    this.actionCharacteristicRepository.InsertWithoutSave(new ActionTemplateCharacteristic { Characteristics = characteristicId, ActionTemplate1 = actionTemplate }); 
                }
            }

            if (predispositions != null)
            {
                var objLength = predispositions.Length;
                for (var i = 0; i < objLength; i++)
                {
                    var predispositionId = predispositions[i];
                    var requirementLow = lows[i];
                    var requirementHigh = highs[i];
                    this.actionPredispositionRepository.InsertWithoutSave(new ActionTemplatePredisposition { Predisposition = predispositionId, RequirementLow = requirementLow, RequirementHigh = requirementHigh, ActionTemplate1 = actionTemplate });
                }
            }

            if (properties != null)
            {
                var objLength = properties.Length;
                for (var i = 0; i < objLength; i++)
                {
                    var propertyId = properties[i];
                    var appearenceValue = appearences[i];
                    this.actionPropertyRepository.InsertWithoutSave(new ActionTemplateProperty { Properties = propertyId, Appearance = appearenceValue, ActionTemplate1 = actionTemplate });
                }
            }

            this.actionTemplateRepository.SaveChanges();
            return Mapper.Map<ActionTemplateDto>(actionTemplate);
        }

        public ActionTemplateDto Update(ActionTemplateDto actionTemplateDto, int[] characteristics, int[] predispositions, int[] lows, int[] highs, int[] properties, bool[] appearences)
        {
            var actionTemplate = Mapper.Map<ActionTemplate>(actionTemplateDto);
            this.actionTemplateRepository.UpdateWithoutSave(actionTemplate);
            if (characteristics != null)
            {
                var allCharacteristic = this.actionCharacteristicRepository.GetAll()
                                            .Where(s => s.ActionTemplate == actionTemplate.Id)
                                            .ToList();
                foreach (var characterictic in allCharacteristic)
                {
                    var forDelete = true;
                    foreach (var newCharacteristic in characteristics)
                    {
                        if (characterictic.Characteristics == newCharacteristic)
                        {
                            forDelete = false;
                            break;
                        }
                    }

                    if (forDelete)
                    {
                       this.actionCharacteristicRepository.DeleteWithOutSave(characterictic); 
                    }
                }

                foreach (var newCharacteristic in characteristics)
                {
                    var forInsert = true;
                    foreach (var characterictic in allCharacteristic)
                    {
                        if (characterictic.Characteristics == newCharacteristic)
                        {
                            forInsert = false;
                            break;
                        }
                    }

                    if (forInsert)
                    {
                        this.actionCharacteristicRepository.InsertWithoutSave(new ActionTemplateCharacteristic { ActionTemplate = actionTemplate.Id, Characteristics = newCharacteristic });
                    }
                }
            }

            if (predispositions != null)
            {
                var allPredispositions = this.actionPredispositionRepository.GetAll()
                                             .Where(s => s.ActionTemplate == actionTemplate.Id)
                                             .ToList();
                foreach (var predisposition in allPredispositions)
                {
                    var forDelete = true;
                    for (var i = 0; i < predispositions.Length; i++)
                    {
                        if (predisposition.Predisposition == predispositions[i])
                        {
                            forDelete = false;
                            predisposition.RequirementLow = lows[i];
                            predisposition.RequirementHigh = highs[i];
                            this.actionPredispositionRepository.UpdateWithoutSave(predisposition);
                            break;
                        }
                    }

                    if (forDelete)
                    {
                        this.actionPredispositionRepository.DeleteWithOutSave(predisposition);
                    }
                }

                for (var i = 0; i < predispositions.Length; i++)
                {
                    var forInsert = true;
                    foreach (var predisposition in allPredispositions)
                    {
                        if (predisposition.Predisposition == predispositions[i])
                        {
                            forInsert = false;
                            break;
                        }
                    }

                    if (forInsert)
                    {
                        var newPredisposition = predispositions[i];
                        var newLow = lows[i];
                        var newHigh = highs[i];
                        this.actionPredispositionRepository.InsertWithoutSave(new ActionTemplatePredisposition { ActionTemplate = actionTemplate.Id, Predisposition = newPredisposition, RequirementLow = newLow, RequirementHigh = newHigh });
                    }
                }
            }

            if (properties != null)
            {
                var allProperties = this.actionPropertyRepository.GetAll()
                                        .Where(s => s.ActionTemplate == actionTemplate.Id)
                                        .ToList();
                foreach (var property in allProperties)
                {
                    var forDelete = true;
                    for (var i = 0; i < properties.Length; i++)
                    {
                        if (property.Properties == properties[i])
                        {
                            forDelete = false;
                            property.Appearance = appearences[i];
                            this.actionPropertyRepository.UpdateWithoutSave(property);
                            break;
                        }
                    }

                    if (forDelete)
                    {
                        this.actionPropertyRepository.DeleteWithOutSave(property);
                    }
                }

                for (var i = 0; i < properties.Length; i++)
                {
                    var forInsert = true;
                    foreach (var property in allProperties)
                    {
                        if (property.Properties == properties[i])
                        {
                            forInsert = false;
                            break;
                        }
                    }

                    if (forInsert)
                    {
                        var newProperty = properties[i];
                        var newAppearance = appearences[i];
                        this.actionPropertyRepository.InsertWithoutSave(new ActionTemplateProperty { ActionTemplate = actionTemplate.Id, Properties = newProperty, Appearance = newAppearance });
                    }
                }
            }

            this.actionTemplateRepository.SaveChanges();
            return Mapper.Map<ActionTemplateDto>(actionTemplate);
        }

        public void Delete(int? id)
        {
            var actionTemplate = this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id);
            
            var stepTemplates = this.stepTemplateActionTemplateRepository.GetAll()
                                   .Where(s => s.ActionTemplate == actionTemplate.Id);
            foreach (var stepTemplate in stepTemplates)
            {
                this.stepTemplateActionTemplateRepository.DeleteWithOutSave(stepTemplate);
            }

            var characteristics = this.actionCharacteristicRepository.GetAll()
                                      .Where(s => s.ActionTemplate == actionTemplate.Id);
            foreach (var characteristic in characteristics)
            {
                this.actionCharacteristicRepository.DeleteWithOutSave(characteristic);
            }

            var predispositions = this.actionPredispositionRepository.GetAll()
                                      .Where(s => s.ActionTemplate == actionTemplate.Id);
            foreach (var predisposition in predispositions)
            {
                this.actionPredispositionRepository.DeleteWithOutSave(predisposition);
            }

            var propperties = this.actionPropertyRepository.GetAll()
                                  .Where(s => s.ActionTemplate == actionTemplate.Id);
            foreach (var property in propperties)
            {
                this.actionPropertyRepository.DeleteWithOutSave(property);
            }

            var descriptions = this.actionDescriptionRepository.GetAll()
                                   .Where(s => s.ActionTemplate == actionTemplate.Id);
            foreach (var description in descriptions)
            {
                this.actionDescriptionRepository.DeleteWithOutSave(description);
            }

            this.actionTemplateRepository.DeleteWithOutSave(actionTemplate);
            this.actionTemplateRepository.SaveChanges();
        }

        public ViewDesireActionResultDto GetViewDesireResult(int? id, string name)
        {
            var viewDesireActionResultDto = new ViewDesireActionResultDto();
            viewDesireActionResultDto.OneModifier = "0.5";
            viewDesireActionResultDto.ActionName = name;
            viewDesireActionResultDto.ActionResultId = Convert.ToInt32(id);
            viewDesireActionResultDto.DesiresDto = Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
            viewDesireActionResultDto.DesireResultsDto = new List<DesireActionTemplateResultDto>();
            var listSelectedDesires =
                Mapper.Map<List<DesireActionTemplateResultDto>>(this.desireActionTemplateResultRepository.GetAll()
                                                                    .Where(s => s.ActionTemplateResult == id));
            viewDesireActionResultDto.Modifiers = new List<double>();
            foreach (var desire in listSelectedDesires)
            {
                viewDesireActionResultDto.Modifiers.Add(desire.Modifier);
                viewDesireActionResultDto.DesireResultsDto.Add(desire);
                var desireForRemove = viewDesireActionResultDto.DesiresDto.Find(s => s.Id == desire.Desire);
                viewDesireActionResultDto.DesiresDto.Remove(desireForRemove);
            }

            return viewDesireActionResultDto;
        }

        public void UpdateDesireActionResult(int id, int[] desires, string[] modifiers)
        {
            var listForUpdate = this.desireActionTemplateResultRepository.GetAll()
                                    .Where(s => s.ActionTemplateResult == id)
                                    .ToList();
            if (desires != null)
            {
                foreach (var oldDesire in listForUpdate)
                {
                    var find = false;
                    for (var i = 0; i < desires.Length; i++)
                    {
                        if (oldDesire.Desire == desires[i])
                        {
                            modifiers[i] = ViewHelper.ConvertToCurrentSeparator(modifiers[i]);
                            oldDesire.Modifier = Convert.ToDouble(modifiers[i]);
                            this.desireActionTemplateResultRepository.UpdateWithoutSave(oldDesire);
                            find = true;
                            break;
                        }
                    }

                    if (!find)
                    {
                        this.desireActionTemplateResultRepository.DeleteWithOutSave(oldDesire);
                    }
                }

                for (var i = 0; i < desires.Length; i++)
                {
                    var find = false;
                    foreach (var oldDesires in listForUpdate)
                    {
                        if (oldDesires.Desire == desires[i])
                        {
                            find = true;
                            break;
                        }
                    }

                    if (!find)
                    {
                        modifiers[i] = ViewHelper.ConvertToCurrentSeparator(modifiers[i]);
                        this.desireActionTemplateResultRepository.InsertWithoutSave(new DesireActionTemplateResult()
                                                                                    {
                                                                                        Desire = desires[i],
                                                                                        ActionTemplateResult = id,
                                                                                        Modifier = Convert.ToDouble(modifiers[i])
                                                                                    });
                    }
                }
            }
            else
            {
                if (listForUpdate.Count > 0)
                {
                    foreach (var oldDesire in listForUpdate)
                    {
                        this.desireActionTemplateResultRepository.DeleteWithOutSave(oldDesire);
                    }
                }
            }

            this.desireActionTemplateResultRepository.SaveChanges();
        }

        public ViewDesireActionResultDto GetViewDesireResultByList(int id,
            string name,
            int[] desires,
            string[] modifiers)
        {
            var viewDesireActionResultDto = new ViewDesireActionResultDto();
            viewDesireActionResultDto.OneModifier = "0.5";
            viewDesireActionResultDto.ActionName = name;
            viewDesireActionResultDto.ActionResultId = Convert.ToInt32(id);
            viewDesireActionResultDto.DesireResultsDto = new List<DesireActionTemplateResultDto>();
            viewDesireActionResultDto.DesiresDto = Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
            viewDesireActionResultDto.Modifiers = new List<double>();
            if (desires != null)
            { 
            for (var i = 0; i < desires.Length; i++)
            {
                modifiers[i] = ViewHelper.ConvertToCurrentSeparator(modifiers[i]);
                var desireModifier = Convert.ToDouble(modifiers[i]);
                foreach (var desire in viewDesireActionResultDto.DesiresDto)
                {
                    if (desire.Id == desires[i])
                    {
                        viewDesireActionResultDto.DesiresDto.Remove(desire);
                        viewDesireActionResultDto.DesireResultsDto.Add(new DesireActionTemplateResultDto()
                                                                       {
                                                                           Desire = desires[i],
                                                                           ActionTemplateResult = id,
                                                                           Modifier = desireModifier,
                                                                           Desire1 = desire
                                                                       });
                        viewDesireActionResultDto.Modifiers.Add(desireModifier);
                    }
                }
            }
            }

            return viewDesireActionResultDto;
        }
    }
}