﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceptablePositionAttribute.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the AcceptablePositionAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Validate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Remoting.Channels;
    using System.Web.Mvc;
    using Interfaces;
    using ModelsDTO;

    public class AcceptablePositionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int newPosition = Convert.ToInt32(value);
            int newLength = 0;
            int nextPosition = 0;
            int prevPosition = 0;
            int prevLength = 0;
            var nameDto = validationContext.ObjectType.Name;
            switch (nameDto)
            {
                case "CharacteristicDto":
                    ICharacteristicService characteristicService = DependencyResolver.Current.GetService<ICharacteristicService>();
                    CharacteristicDto characteristicDto = validationContext.ObjectInstance as CharacteristicDto;
                    newLength = characteristicDto.Length;
                    CharacteristicDto nextCharacteristicDto = characteristicService.GetMinByPosition(newPosition);
                    if (nextCharacteristicDto != null)
                    {
                        nextPosition = nextCharacteristicDto.Position;
                    }

                    CharacteristicDto prevCharacteristicDto = characteristicService.GetMaxByPosition(newPosition);
                    if (prevCharacteristicDto != null)
                    {
                        prevPosition = prevCharacteristicDto.Position;
                        prevLength = prevCharacteristicDto.Length;
                    }
                    break;
                case "PredispositionDto":
                    IPredispositionService predispositionService = DependencyResolver.Current.GetService<IPredispositionService>();
                    PredispositionDto predispositionDto=validationContext.ObjectInstance as PredispositionDto;
                    newLength = predispositionDto.Length;
                    PredispositionDto nextPredispositionDto = predispositionService.GetMinByPosition(newPosition);
                    if(nextPredispositionDto != null)
                    {
                        nextPosition = nextPredispositionDto.Position;
                    }

                    PredispositionDto prevPredispositionDto = predispositionService.GetMaxByPosition(newPosition);
                    if (prevPredispositionDto != null)
                    {
                        prevPosition = prevPredispositionDto.Position;
                        prevLength = prevPredispositionDto.Length;
                    }
                    break;
             // case"PropertyDto":
                //    dtoService = DependencyResolver.Current.GetService<IPropertyService>();
                //    dto = validationContext.ObjectInstance as PropertyDto;
                //    break;

            }
            string errorMessage = string.Empty;
            if (newPosition != null)
            {
                var mistake = false;
                if (prevLength != 0 && (prevPosition + prevLength) > newPosition)
                {
                    mistake = true;
                    errorMessage = "Позиція повина бути не менше від "
                                   + (prevPosition + prevLength) + " ! ";
                }

                if (newLength != 0)
                {
                    if (nextPosition != 0 && (nextPosition - newLength) < (prevPosition+prevLength))
                    {
                        mistake = true;
                        errorMessage = errorMessage + "Позиція не може бути "
                                   + newPosition + ", якщо довжина= " + newLength + " !";
                    }
                    else
                    if (nextPosition != 0 && (newPosition + newLength) > nextPosition)
                    {
                        mistake = true;
                        errorMessage = errorMessage + "Позиція повина бути не більше від "
                                   + (nextPosition - newLength) + ", якщо довжина= " + newLength + " !";
                    }
                }

                if (mistake)
                {
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}