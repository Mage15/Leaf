/*
Copyright (C) 2015 Matthew Gefaller
This file is part of LeafStyle.

LeafStyle is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

LeafStyle is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LeafStyle. If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;

namespace LeafStyle
{
    public class LengthPercentNoneProperty : BasicStyleProperty<LengthPercentNoneState>
    {
        public int LengthAbsolute { get; set; }
        public float LengthPercent { get; set; }

        public LengthPercentNoneProperty()
            : base(
                defaultState: default(LengthPercentNoneState),
                inherited: false,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, LengthPercentNoneState>()
                {
                    {"none", LengthPercentNoneState.None},
                    {"absolute", LengthPercentNoneState.LengthAbsolute},
                    {"percent", LengthPercentNoneState.LengthPercent},
                    {"inherit", LengthPercentNoneState.Inherit},
                    {"initial", LengthPercentNoneState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null && value.Contains("px"))  // If not key for StateValues try and parse as
            {                                                // LengthAbsolute value
                int absolute;
                if (int.TryParse(value.Remove(value.IndexOf("px")), out absolute))
                {
                    this.LengthAbsolute = absolute;
                    this.CurrentState = LengthPercentNoneState.LengthAbsolute;

                    return true;
                }
            }
            else if (value != null && value.Contains("%"))  // If not key for StateValues and not LengthAbsolute
            {                                               // try and parse as LengthPercent value
                float percent;
                if (float.TryParse(value.Remove(value.IndexOf("%")), out percent))
                {
                    // Covert to decimal form
                    this.LengthPercent = percent / 100;
                    this.CurrentState = LengthPercentNoneState.LengthPercent;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }
    }
}