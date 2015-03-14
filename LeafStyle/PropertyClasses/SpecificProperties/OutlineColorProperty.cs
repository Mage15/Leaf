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
    internal class OutlineColorProperty : BasicStyleProperty<OutlineColorState>
    {
        private Parser.ColorParser colorParser = new Parser.ColorParser();

        public Microsoft.Xna.Framework.Color Color { get; set; }

        public OutlineColorProperty()
            : base(
                defaultState: default(OutlineColorState),
                inherited: false,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, OutlineColorState>()
                {
                    {"invert", OutlineColorState.Invert},
                    {"color", OutlineColorState.Color},
                    {"initial", OutlineColorState.Initial},
                    {"inherit", OutlineColorState.Inherit}
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
                Microsoft.Xna.Framework.Color color;
                if (this.colorParser.TryColor(value, out color))
                {
                    this.Color = color;
                    this.CurrentState = OutlineColorState.Color;

                    return true;
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Microsoft.Xna.Framework.Color))
                {
                    this.Color = (Microsoft.Xna.Framework.Color)value;
                    this.CurrentState = OutlineColorState.Color;

                    return true;
                }
            }

            return false;
        }
    }
}