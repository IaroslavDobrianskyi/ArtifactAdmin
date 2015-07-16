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
    using ModelsDTO;

    public class UniquePositionAttribute : ValidationAttribute
    {
        //private IRepository<Characteristic> characteristicRepository { get; set; }
        
        //public ICharacteristicService CharacteristicService;

        //public ControllerContext 
        public UniquePositionAttribute()
        {
            //CharacteristicService=new CharacteristicService(characteristicRepository);
        }
   
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        //    private readonly IRepository<Characteristic> characteristicRepository;

        //ICharacteristicService CharacteristicService = new CharacteristicService(IRepository<Characteristic> characteristicRepository);
            int newPosition = Convert.ToInt32(value);
            var Dto = validationContext.ObjectInstance as CharacteristicDto;
            //if(newPosition != null)
            //{
            //    var positionFound = CharacteristicService.GetByPosition(newPosition);
            //    if (positionFound != null && positionFound.Id != Dto.Id)
            //    {
            //        return new ValidationResult("Позиція "+ newPosition.ToString()+" вже використина!");
            //    }
            //}
            
            return ValidationResult.Success;
        }
    }
}