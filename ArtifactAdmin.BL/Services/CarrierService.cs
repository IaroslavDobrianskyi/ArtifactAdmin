// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarrierService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the CarrierService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Linq;
    using DAL.Models;
    using Interfaces;

    public class CarrierService : ICarrierService
    {
        // TODO extract into separate class 
        public const int StartingExpPoints = 10;

        private readonly IRaceService raceService;
        private readonly IRepository<Property> propertyRepository;
        private readonly IRepository<Characteristic> characteristicsRepository;

        public CarrierService(IRaceService raceService, IRepository<Property> propertyRepository, IRepository<Characteristic> characteristicsRepository)
        {
            this.raceService = raceService;
            this.propertyRepository = propertyRepository;
            this.characteristicsRepository = characteristicsRepository;
        }

        // TODO extract into utils method
        public static int GetFibonacciNumber(int n)
        {
            var a = 0;
            var b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (var i = 0; i < n; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }

        public int CalculateExperiencePointsForLevel(int experienceLevel)
        {
            return GetFibonacciNumber(experienceLevel) * StartingExpPoints;
        }

        public Carrier GenerateCarrier(int raceId, int experienceLevel)
        {
            var race = this.raceService.GetById(raceId);
            Carrier generatedCarrier = new Carrier();
            generatedCarrier.Race = race.Id;
            generatedCarrier.ExperienceLevel = experienceLevel;
            generatedCarrier.ExperiencePoints = this.CalculateExperiencePointsForLevel(experienceLevel);
            generatedCarrier.Predisposition = race.Predisposition;
            generatedCarrier.DefaultPredisposition = race.Predisposition;
            generatedCarrier.Properties = CalculateProperties(race.Properties);
            generatedCarrier.Characteristics = CalculateCharacteristics(race.Characreristics, race.CharacteristicsLevelModifier, experienceLevel);
            GenerateCarrierDesires(generatedCarrier);

            return generatedCarrier;
        }

        private void GenerateCarrierDesires(Carrier generatedCarrier)
        {
            // for given carrier generate entries for CarrierDesires table for further use
            throw new NotImplementedException();
        }

        private string CalculateProperties(string raceProperties)
        {
            // foreach property - calculate value for given level taking deviation into account
            var allProperties = this.propertyRepository.GetAll()
                                    .OrderBy(s => s.Position);
            var lengthRaceProperties = raceProperties.Length;
            foreach (var property in allProperties)
            {
                var position = property.Position;
                var length = property.Length;
                if (position < lengthRaceProperties)
                {
                    var rnd = new Random();
                    var koef = (rnd.NextDouble() * 2 * property.Deviation) + 1 - property.Deviation;
                    var value = position + length > lengthRaceProperties
                                ? int.Parse(raceProperties.Substring(position))
                                : int.Parse(raceProperties.Substring(position, length));
                    var newValue = Convert.ToInt32(value * koef).ToString().Trim();
                    var newValueLength = newValue.Length;
                    var addSpaces = string.Empty;
                    for (addSpaces = string.Empty; addSpaces.Length < length - newValueLength; addSpaces += " ")
                    {
                    }

                    newValue = newValue + addSpaces;
                    raceProperties = raceProperties.Substring(0, position) + newValue
                                     + raceProperties.Substring(position + length); 
                }
                else
                {
                    break;
                }
            }

            return raceProperties;
        }

        private string CalculateCharacteristics(string baseCharacteristics, string characteristicsLevelModifier, int experienceLevel)
        {
            // foreach characteristic - calculate value for given level 
            var allCharacteristics = this.characteristicsRepository.GetAll()
                                         .OrderBy(s => s.Position);
            var lengthCharacteristics = baseCharacteristics.Length;
            var lengthModifier = characteristicsLevelModifier.Length;
            foreach (var characteristic in allCharacteristics)
            {
                var position = characteristic.Position;
                var length = characteristic.Length;
                if (position < lengthCharacteristics)
                {
                    var value = position + length > lengthCharacteristics
                                    ? int.Parse(baseCharacteristics.Substring(position))
                                    : int.Parse(baseCharacteristics.Substring(position, length));
                    var modifier = position + length > lengthModifier
                                       ? int.Parse(characteristicsLevelModifier.Substring(position))
                                       : int.Parse(characteristicsLevelModifier.Substring(position, length));
                    var newValue = (value + (modifier * experienceLevel)).ToString()
                                                                       .Trim();
                    var newValueLength = newValue.Length;
                    var addSpaces = string.Empty;
                    for (addSpaces = string.Empty; addSpaces.Length < length - newValueLength; addSpaces += " ")
                    {
                    }

                    newValue = newValue + addSpaces;
                    baseCharacteristics = baseCharacteristics.Substring(0, position) + newValue
                                          + baseCharacteristics.Substring(position + length);
                }
                else
                {
                    break;
                }
            }

            return baseCharacteristics;
        }

        public int GetCarrierPredictionRadius(int carrierId)
        {
            return 0;
        }
    }
}