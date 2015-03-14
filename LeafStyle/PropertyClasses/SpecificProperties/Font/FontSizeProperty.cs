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
    internal class FontSizeProperty : BasicStyleProperty<FontSizeState>
    {
        public int Absolute { get; set; }
        public float Percent { get; set; }

        public FontSizeProperty()
            : base(
                defaultState: default(FontSizeState),
                inherited: true,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, FontSizeState>()
                {
                    {"medium", FontSizeState.Medium},
                    {"xx-small", FontSizeState.XXSmall},
                    {"x-small", FontSizeState.XSmall},
                    {"small", FontSizeState.Small},
                    {"large", FontSizeState.Large},
                    {"x-large", FontSizeState.XLarge},
                    {"xx-large", FontSizeState.XXLarge},
                    {"smaller", FontSizeState.Smaller},
                    {"larger", FontSizeState.Larger},
                    {"length", FontSizeState.LengthAbsolute},
                    {"percent", FontSizeState.LengthPercent},
                    {"initial", FontSizeState.Initial},
                    {"inherit", FontSizeState.Inherit}
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
                        this.CurrentState = FontSizeState.LengthAbsolute;

                        return true;
                    }
                }
                else if (value.Contains("%"))
                {
                    float percent;
                    if (float.TryParse(value.Remove(value.IndexOf("%")), out percent))
                    {
                        // Convert to decimal form
                        this.Percent = percent / 100;
                        this.CurrentState = FontSizeState.LengthPercent;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(int))
                {
                    this.Absolute = (int)value;
                    this.CurrentState = FontSizeState.LengthAbsolute;

                    return true;
                }
                else if (value.GetType() == typeof(float))
                {
                    this.Percent = (float)value;
                    this.CurrentState = FontSizeState.LengthPercent;

                    return true;
                }

            }

            return false;
        }
    }
}