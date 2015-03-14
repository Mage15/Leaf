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
    public class BasicColorProperty : BasicStyleProperty<BasicColorState>
    {
        private Parser.ColorParser colorParser = new Parser.ColorParser();

        public Microsoft.Xna.Framework.Color Color { get; private set; }

        public BasicColorProperty()
            : base(
                defaultState: default(BasicColorState),
                inherited: false,
                animatable: false
                )
        {
            Color = Microsoft.Xna.Framework.Color.Black;

            this.StateValues = new Dictionary<string, BasicColorState>()
                {
                    {"color",   BasicColorState.Color},
                    {"initial", BasicColorState.Initial},
                    {"inherit", BasicColorState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null)  // If not a key for StateValues try and parse as Color
            {
                Microsoft.Xna.Framework.Color color;

                if (this.colorParser.TryColor(value, out color))
                {
                    this.Color = color;
                    this.CurrentState = BasicColorState.Color;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }
    }
}