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
    internal class ColorTransparentProperty : BasicStyleProperty<ColorTransparentState>
    {
        private Parser.ColorParser colorParser = new Parser.ColorParser();

        public Microsoft.Xna.Framework.Color Color { get; set; }

        public ColorTransparentProperty()
            : base(
                defaultState: default(ColorTransparentState),
                inherited: false,
                animatable: true
                )
        {
            this.StateValues = new Dictionary<string, ColorTransparentState>()
                {
                    {"color", ColorTransparentState.Color},
                    {"transparent", ColorTransparentState.Transparent},
                    {"inherit", ColorTransparentState.Inherit},
                    {"initial", ColorTransparentState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null) // If not key for StateValues try and parse as Color value
            {
                Microsoft.Xna.Framework.Color color;
                if (this.colorParser.TryColor(value, out color))
                {
                    this.Color = color;
                    this.CurrentState = ColorTransparentState.Color;

                    return true;
                }
            }

            // Could not be prased
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Microsoft.Xna.Framework.Color))
                {
                    this.Color = (Microsoft.Xna.Framework.Color)value;
                    this.CurrentState = ColorTransparentState.Color;

                    return true;
                }
            }

            return false;
        }
    }
}