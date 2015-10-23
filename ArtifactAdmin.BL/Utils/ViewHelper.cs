 // --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewHelper.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Utils
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using ModelsDTO;

    public class ViewHelper
    {
        public static ViewValueCharacteristic GetValueByString(string specificValue, List<ViewCharacteristic> allCharacteristic)
        {
            var viewValueCharacteristic = new ViewValueCharacteristic();
            viewValueCharacteristic.SelectedCharacteristics = new List<ViewCharacteristic>();
            viewValueCharacteristic.SelectedValues = new List<ViewCharacteristic>();
            if (specificValue == null)
            {
                viewValueCharacteristic.Characteristics = allCharacteristic;
            }
            else
            {
                viewValueCharacteristic.Characteristics = new List<ViewCharacteristic>();
                int lengthSpecificValue = specificValue.Length;
                if (lengthSpecificValue < 50)
                {
                    specificValue += new string(' ', 50 - lengthSpecificValue);
                }

                int value;
                int position;
                int length;
                foreach (var characteristic in allCharacteristic)
                {
                    position = int.Parse(characteristic.PositionLength.Substring(0, characteristic.PositionLength.IndexOf(".")));
                    length = int.Parse(characteristic.PositionLength.Substring(characteristic.PositionLength.IndexOf(".") + 1));
                    bool selValue = false;
                    if (int.TryParse(specificValue.Substring(position, length), out value))
                    {
                        if (value > 0)
                        {
                            viewValueCharacteristic.SelectedCharacteristics.Add(new ViewCharacteristic { Name = characteristic.Name, PositionLength = characteristic.PositionLength, Value = value });
                            viewValueCharacteristic.SelectedValues.Add(new ViewCharacteristic { Name = characteristic.Name, PositionLength = characteristic.PositionLength, Value = value });
                            selValue = true;
                        }
                    }

                    if (!selValue)
                    {
                        viewValueCharacteristic.Characteristics.Add(characteristic);
                    }
                }
            }

            return viewValueCharacteristic;
        }

        public static string ConvertToCurrentSeparator(string stringIn)
        {
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string outString = stringIn.Replace('.', separator);
            return outString;
        }

        public static string ConvertSeparatorToDot(string stringIn)
        {
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string outString = stringIn.Replace(separator, '.');
            return outString;
        }

        public static string ModelStateExeption(ModelStateDictionary modelState)
        {
            var messageException = string.Empty;
            var errors = modelState.Where(ms => ms.Value.Errors.Any())
                                       .Select(x => new { x.Key, x.Value.Errors });
            foreach (var oneError in errors)
            {
                var fieldKey = oneError.Key;
                var fieldErrors = oneError.Errors;
                messageException += fieldKey + ": " + fieldErrors[0].Exception.Message.ToString() + ". ";
            }

            return messageException;
        }
    }
}