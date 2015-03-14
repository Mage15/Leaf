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
    internal class VerticalAlignProperty : BasicStyleProperty<VerticalAlignState>
    {
        public int LengthAbsolute { get; set; }
        public float LengthPercent { get; set; }

        public VerticalAlignProperty()
            : base(
                defaultState: default(VerticalAlignState),
                inherited: false,
                animatable: true
                )
        {
            this.StateValues = new Dictionary<string, VerticalAlignState>()
                {
                    {"baseline", VerticalAlignState.Baseline},
		            {"length-absolute", VerticalAlignState.LengthAbsolute},
		            {"legnth-percent", VerticalAlignState.LengthPercent},
		            {"sub", VerticalAlignState.Sub},
		            {"super", VerticalAlignState.Super},
		            {"top", VerticalAlignState.Top},
		            {"text-top", VerticalAlignState.TextTop},
		            {"middle", VerticalAlignState.Middle},
		            {"bottom", VerticalAlignState.Bottom},
		            {"text-bottom", VerticalAlignState.TextBottom},
		            {"initial", VerticalAlignState.Initial},
		            {"inherit", VerticalAlignState.Inherit}
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
                        this.LengthAbsolute = absolute;
                        this.CurrentState = VerticalAlignState.LengthAbsolute;

                        return true;
                    }
                }
                else if (value.Contains("%"))
                {
                    float percent;
                    if (float.TryParse(value.Remove(value.IndexOf("%")), out percent))
                    {
                        // Convert to decimal form
                        this.LengthPercent = percent / 100;
                        this.CurrentState = VerticalAlignState.LengthPercent;

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
                    this.LengthAbsolute = (int)value;
                    this.CurrentState = VerticalAlignState.LengthAbsolute;

                    return true;
                }
                else if (value.GetType() == typeof(float))
                {
                    this.LengthPercent = (float)value;
                    this.CurrentState = VerticalAlignState.LengthPercent;

                    return true;
                }
            }

            return false;
        }
    }
}