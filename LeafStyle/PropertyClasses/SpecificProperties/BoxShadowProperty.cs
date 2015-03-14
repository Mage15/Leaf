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

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LeafStyle
{
    public class BoxShadowProperty : BasicStyleProperty<BoxShadowState>
    {
        private Parser.ColorParser colorParser = new Parser.ColorParser();
        private Parser.PointParser pointParser = new Parser.PointParser();

        public Point Location { get; set; }
        public int Blur { get; set; }
        public int Spread { get; set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }

        public BoxShadowProperty()
            : base(
                    defaultState: default(BoxShadowState),
                    inherited: false,
                    animatable: true
            )
        {
            this.Color = Microsoft.Xna.Framework.Color.Black;

            this.StateValues = new Dictionary<string, BoxShadowState>()
				{
					{"none", BoxShadowState.None },
					{"outset", BoxShadowState.Outset },
					{"inset", BoxShadowState.Inset },
					{"initial", BoxShadowState.Initial },
					{"inherit", BoxShadowState.Inherit }
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
                string[] valuesArray = value.Split(' ');
                int index = 0; // Used to move through valuesArray

                Point location;
                if (index + 1 < valuesArray.Length &&
                    this.pointParser.TryPoint((valuesArray[index] + " " + valuesArray[index + 1]), out location))
                {
                    index += 2; // Prepare for next use. Move past the 2 indexes just used
                    this.Location = location;
                }
                else // Must contain location
                {
                    return false;
                }

                int blur;
                if (index < valuesArray.Length &&
                    valuesArray[index].Contains("px") &&
                    int.TryParse(valuesArray[index].Remove(valuesArray[index].IndexOf("px")), out blur))
                {
                    index++; // Prepare for next use
                    this.Blur = blur;
                }

                // Blur is optional so no need to fail if not present

                int spread;
                if (index < valuesArray.Length &&
                    valuesArray[index].Contains("px") &&
                    int.TryParse(valuesArray[index].Remove(valuesArray[index].IndexOf("px")), out spread))
                {
                    index++; // Prepare for next use
                    this.Spread = spread;
                }

                // Spread is optional so no nee to fail if not present

                Microsoft.Xna.Framework.Color color;
                if (index < valuesArray.Length &&
                    this.colorParser.TryColor(valuesArray[index], out color))
                {
                    index++; // Prepare for next use
                    this.Color = color;
                }

                // Check if state was supplied in value. If not set to outset.
                if (index < valuesArray.Length &&
                    this.StateValues.ContainsKey(valuesArray[index]))
                {
                    this.CurrentState = StateValues[valuesArray[index]];
                    return true;
                }
                else
                {
                    this.CurrentState = BoxShadowState.Outset;
                    return true;
                }
            }

            // Could not parse
            return false;
        }
    }
}