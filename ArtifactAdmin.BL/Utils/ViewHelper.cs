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
    using System;
    using System.Collections.Generic;
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
                    specificValue += new String(' ', 50 - lengthSpecificValue);
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
                            characteristic.Value = value;
                            viewValueCharacteristic.SelectedCharacteristics.Add(characteristic);
                            viewValueCharacteristic.SelectedValues.Add(characteristic);
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
    }
}