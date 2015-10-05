 // --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceDesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceDesireService interface.
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

    public class RaceDesireService : IRaceDesireService
    {
        private readonly IRepository<Race> raceRepository;
        private readonly IRepository<Desire> desireRepository;
        private readonly IRepository<RaceDesire> raceDesireRepository;

        public RaceDesireService(IRepository<Race> raceRepository, IRepository<Desire> desireRepository, IRepository<RaceDesire> raceDesireRepository)
        {
            this.raceRepository = raceRepository;
            this.desireRepository = desireRepository;
            this.raceDesireRepository = raceDesireRepository;
        }

        public IEnumerable<ViewRaceDesireDto> GetAll()
        {
            return Mapper.Map<List<ViewRaceDesireDto>>(this.raceRepository.GetAll()
                                                           .Include(s => s.RaceDesires));
        }

        public ViewRaceDesireDto GetViewById(int? id)
        {
            var viewRaceDesireDto = Mapper.Map<ViewRaceDesireDto>(this.raceRepository.GetAll()
                                                                      .Include(s => s.RaceDesires)
                                                                      .FirstOrDefault(s => s.Id == id));
            var countRaceDesires = viewRaceDesireDto.RaceDesires.Count;
            viewRaceDesireDto.AllDesires = Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
            viewRaceDesireDto.SelectedDesires = new List<DesireDto>();
            viewRaceDesireDto.Probabilities = new List<double>();
            viewRaceDesireDto.DefaultValues = new List<int>();
            viewRaceDesireDto.Deviations = new List<double>();
        if (countRaceDesires != 0)
            {
                foreach (var desire in viewRaceDesireDto.RaceDesires)
                {
                    viewRaceDesireDto.Probabilities.Add(desire.Probability);
                    viewRaceDesireDto.DefaultValues.Add(desire.DefaultValue);
                    viewRaceDesireDto.Deviations.Add(Convert.ToDouble(desire.Deviation));
                    var oneDesire =
                        viewRaceDesireDto.AllDesires.FirstOrDefault(allDesire => allDesire.Id == desire.DesireId);
                    viewRaceDesireDto.AllDesires.Remove(oneDesire);
                    viewRaceDesireDto.SelectedDesires.Add(oneDesire);
                }
            }

        viewRaceDesireDto.OneProbability = "0.25";
            viewRaceDesireDto.DefaultValue = 0;
            viewRaceDesireDto.Deviation = "0.0";
            return viewRaceDesireDto;
        }

        public void Update(int id, int[] selectedDesires, string[] probabilities, int[] defaultValues, string[] deviations)
        {
            var oldRaceDesire = this.raceDesireRepository.GetAll()
                                                                         .Where(s => s.RaceId == id);
            foreach (var oldDesire in oldRaceDesire)
            {
                var desireDeleted = selectedDesires.FirstOrDefault(item => item == oldDesire.DesireId);
                if (desireDeleted != null)
                { 
                    this.raceDesireRepository.DeleteWithOutSave(oldDesire);
                }
            }

            int selectedDesiresLength = selectedDesires.Length;
            for (int i = 0; i < selectedDesiresLength; i++)
            {
                var desireId = selectedDesires[i];
                probabilities[i] = ViewHelper.ConvertToCurrentSeparator(probabilities[i]);
                deviations[i] = ViewHelper.ConvertToCurrentSeparator(deviations[i]);
                var desireUpdate = oldRaceDesire.FirstOrDefault(item => item.DesireId == desireId);
                if (desireUpdate != null)
                {
                    desireUpdate.Probability = Convert.ToDouble(probabilities[i]);
                    desireUpdate.DefaultValue = defaultValues[i];
                    if (Convert.ToDouble(deviations[i]) == 0)
                    {
                        desireUpdate.Deviation = null;
                    }
                    else
                    {
                        desireUpdate.Deviation = Convert.ToDouble(deviations[i]);
                    }

                    this.raceDesireRepository.UpdateWithoutSave(desireUpdate);
                }
                else
                {
                    this.raceDesireRepository.InsertWithoutSave(new RaceDesire
                                                                {
                                                                    RaceId = id,
                                                                    DesireId = selectedDesires[i],
                                                                    Deviation = Convert.ToDouble(deviations[i]) == 0
                                                                                                ? (double?)null
                                                                                                : Convert.ToDouble(deviations[i]),
                                                                               Probability =
                                                                                   Convert.ToDouble(probabilities[i]),
                                                                               DefaultValue = defaultValues[i],
                                                                              });
                }
            }

            this.raceDesireRepository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var desireForDelete = this.raceDesireRepository.GetAll()
                                      .Where(s => s.RaceId == id)
                                      .Where(d => d.RaceId == id);
            foreach (var desire in desireForDelete)
            {
                this.raceDesireRepository.DeleteWithOutSave(desire);
            }

            this.raceDesireRepository.SaveChanges();
        }
    }
}