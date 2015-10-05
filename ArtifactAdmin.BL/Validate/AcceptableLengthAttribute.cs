// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceptableLengthAttribute.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the AcceptableLengthAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Validate
{
    public class AcceptableLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int newPosition = 0;
            int newLength = Convert.ToInt32(value);
            int nextPosition = 0;
            var nameDto = validationContext.ObjectType.Name;
            switch (nameDto)
            {
                case "CharacteristicDto":
                    ICharacteristicService characteristicService = DependencyResolver.Current.GetService<ICharacteristicService>();
                    CharacteristicDto characteristicDto = validationContext.ObjectInstance as CharacteristicDto;
                    newPosition = characteristicDto.Position;
                    CharacteristicDto nextCharacteristicDto = characteristicService.GetMinByPosition(newPosition);
                    if (nextCharacteristicDto != null)
                    {
                        nextPosition = nextCharacteristicDto.Position;
                    }

                    break;
                case "PredispositionDto":
                    IPredispositionService predispositionService = DependencyResolver.Current.GetService<IPredispositionService>();
                    PredispositionDto predispositionDto = validationContext.ObjectInstance as PredispositionDto;
                    newPosition = predispositionDto.Position;
                    PredispositionDto nextPredispositionDto = predispositionService.GetMinByPosition(newPosition);
                    if (nextPredispositionDto != null)
                    {
                        nextPosition = nextPredispositionDto.Position;
                    }

                    break;
                case "PropertyDto":
                    IPropertyService propertyService = DependencyResolver.Current.GetService<IPropertyService>();
                    PropertyDto propertyDto = validationContext.ObjectInstance as PropertyDto;
                    newPosition = propertyDto.Position;
                    PropertyDto nextPropertyDto = propertyService.GetMinByPosition(newPosition);
                    if (nextPropertyDto != null)
                    {
                        nextPosition = nextPropertyDto.Position;
                    }

                    break;
            }

            if (newPosition != null && newLength != null)
            { 
                if (nextPosition != 0)
                { 
                    if (newPosition + newLength > nextPosition)
                    {
                        return
                            new ValidationResult("Довжина повинна бути не більше "
                                                 + (nextPosition - newPosition) + ", якщо позиція=" + newPosition + " !");
                    }
                }
                else
                {
                    if (newPosition + newLength > 50)
                    {
                        return
                            new ValidationResult("Довжина повинна бути не більше "
                                                 + (50 - newPosition) + ", якщо позиція=" + newPosition + " !");
                    } 
                }
            }

            return ValidationResult.Success;
        }
    }
}