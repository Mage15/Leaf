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
    internal class TextShadowProperty : BasicStyleProperty<TextShadowState>
    {
        private Parser.ColorParser colorParser = new Parser.ColorParser();
        private Parser.PointParser pointParser = new Parser.PointParser();

        public Point Location { get; set; }
        public int Blur { get; set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }

        public TextShadowProperty()
            : base(
                defaultState: default(TextShadowState),
                inherited: true,
                animatable: true
                )
        {
            this.StateValues = new Dictionary<string, TextShadowState>()
                {
                    {"use-values", TextShadowState.UseValues},
                    {"none", TextShadowState.None},
                    {"initial", TextShadowState.Initial},
                    {"inherit", TextShadowState.Inherit}
                };
        }

        // Look at using Regex to parse
        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null)
            {
                string[] valuesArray = value.Split(new char[] { ' ' });
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

                Microsoft.Xna.Framework.Color color;
                if (index < valuesArray.Length &&
                this.colorParser.TryColor(valuesArray[index], out color))
                {
                    index++; // Prepare for next use
                    this.Color = color;
                }

                this.CurrentState = TextShadowState.UseValues;
                return true;
            }

            // Could not parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Point))
                {
                    this.Location = (Point)value;
                    this.CurrentState = TextShadowState.UseValues;

                    return true;
                }
                else if (value.GetType() == typeof(Microsoft.Xna.Framework.Color))
                {
                    this.Color = (Microsoft.Xna.Framework.Color)value;
                    return true;
                }
            }

            return false;
        }

        public override bool TrySetValues(object[] values)
        {
            bool allValuesSet = true;

            foreach (object obj in values)
            {
                if (!this.TrySetValue(obj))
                {
                    allValuesSet = false;
                }
            }

            return allValuesSet;
        }
    }
}