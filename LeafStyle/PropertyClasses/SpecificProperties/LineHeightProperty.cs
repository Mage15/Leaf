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
    public class LineHeightProperty : BasicStyleProperty<LineHeightState>
    {
        public short Number { get; set; }
        public int Absolute { get; set; }
        public float Percent { get; set; }

        public LineHeightProperty()
            : base(
                defaultState: default(LineHeightState),
                inherited: true,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, LineHeightState>()
                {
                    {"normal", LineHeightState.Normal},
                    {"number", LineHeightState.Number},
                    {"absolute", LineHeightState.LengthAbsolute},
                    {"percent", LineHeightState.LengthPercent},
                    {"initial", LineHeightState.Initial},
                    {"inherit", LineHeightState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null)
            {
                if (value.Contains("px"))
                {
                    int absolute;
                    if (int.TryParse(value.Remove(value.IndexOf("px")), out absolute))
                    {
                        this.Absolute = absolute;
                        this.CurrentState = LineHeightState.LengthAbsolute;

                        return true;
                    }
                }
                else if (value.Contains("%"))
                {
                    float percent;
                    if (float.TryParse(value.Remove(value.IndexOf("%")), out percent))
                    {
                        this.Percent = percent;
                        this.CurrentState = LineHeightState.LengthPercent;

                        return true;
                    }
                }
                else
                {
                    short number;
                    if (short.TryParse(value, out number))
                    {
                        this.Number = number;
                        this.CurrentState = LineHeightState.Number;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }
    }
}