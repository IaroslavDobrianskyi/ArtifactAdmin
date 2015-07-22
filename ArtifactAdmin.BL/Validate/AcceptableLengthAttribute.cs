// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceptableLengthAttribute.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the AcceptableLengthAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Validate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Interfaces;
    using ModelsDTO;

    public class AcceptableLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int newPosition = 0;
            int newLength = 0;
            int nextPosition = 0;
            var nameDto = validationContext.ObjectType.Name;
            switch (nameDto)
            {
                case "CharacteristicDto":
                    ICharacteristicService characteristicService = DependencyResolver.Current.GetService<ICharacteristicService>();
                    CharacteristicDto characteristicDto = validationContext.ObjectInstance as CharacteristicDto;
                    newPosition = characteristicDto.Position;
                    newLength = characteristicDto.Length;
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
                    newLength = predispositionDto.Length;
                    PredispositionDto nextPredispositionDto = predispositionService.GetMinByPosition(newPosition);
                    if (nextPredispositionDto != null)
                    {
                        nextPosition = nextPredispositionDto.Position;
                    }
                    break;
                // case"PropertyDto":
                //    dtoService = DependencyResolver.Current.GetService<IPropertyService>();
                //    dto = validationContext.ObjectInstance as PropertyDto;
                //    break;
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