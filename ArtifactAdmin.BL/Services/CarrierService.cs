namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Security.AccessControl;
    using DAL.Models;
    using Interfaces;

    public class CarrierService : ICarrierService
    {
        // TODO extract into separate class 
        public const int StartingExpPoints = 10;

        private readonly IRaceService raceService;

        public CarrierService(IRaceService raceService)
        {
            this.raceService = raceService;
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
            //for given carrier generate entries for CarrierDesires table for further use
            throw new NotImplementedException();
        }

        private string CalculateProperties(string raceProperties)
        {
            // foreach property - calculate value for given level taking deviation into account
            throw new NotImplementedException();
        }

        private string CalculateCharacteristics(string baseCharacteristics, string characteristicsLevelModifier, int experienceLevel)
        {
            // foreach characteristic - calculate value for given level 
            throw new NotImplementedException();
        }

        public int CalculateExperiencePointsForLevel(int experienceLevel)
        {
            return GetFibonacciNumber(experienceLevel) * StartingExpPoints;
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
    }
}