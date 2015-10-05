// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UniquePositionAttribute.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the UniquePositionAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Validate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Interfaces;
    using ModelsDTO;

    public class UniquePositionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var newPosition = Convert.ToInt32(value);
            int positionFoundId = -1;
            int newId = 0;
            var nameDto = validationContext.ObjectType.Name;
            switch (nameDto)
            {
                case "CharacteristicDto":
                    ICharacteristicService characteristicService = DependencyResolver.Current.GetService<ICharacteristicService>();
                    CharacteristicDto characteristicDto = validationContext.ObjectInstance as CharacteristicDto;
                    newId = characteristicDto.Id;
                    CharacteristicDto characteristicFound = characteristicService.GetByPosition(newPosition);
                    if (characteristicFound != null) 
                    {
                        positionFoundId = characteristicFound.Id;
                    }

                    break;
                case "PredispositionDto":
                    IPredispositionService predispositionService = DependencyResolver.Current.GetService<IPredispositionService>();
                    PredispositionDto predispositionDto = validationContext.ObjectInstance as PredispositionDto;
                    newId = predispositionDto.Id;
                    PredispositionDto predispositionFound = predispositionService.GetByPosition(newPosition);
                    if (predispositionFound != null)
                    {
                        positionFoundId = predispositionFound.Id;
                    }

                    break;
                case "PropertyDto":
                    IPropertyService propertyService = DependencyResolver.Current.GetService<IPropertyService>();
                    PropertyDto propertyDto = validationContext.ObjectInstance as PropertyDto;
                    newId = propertyDto.Id;
                    PropertyDto propertyFound = propertyService.GetByPosition(newPosition);
                    if (propertyFound != null)
                    {
                        positionFoundId = propertyFound.Id;
                    }

                    break;
            }

            if (positionFoundId != -1 && positionFoundId != newId)
            {
                    return new ValidationResult("Позиція " + newPosition + " вже використана!");
            }
            
            return ValidationResult.Success;
        }
    }
}