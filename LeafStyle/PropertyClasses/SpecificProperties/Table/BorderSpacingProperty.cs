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
    internal class BorderSpacingProperty : BasicStyleProperty<BasicLengthState>
    {
        private Parser.PointParser pointParser = new Parser.PointParser();

        public Point Spacing { get; set; }

        public BorderSpacingProperty()
            : base(
                    defaultState: default(BasicLengthState),
                    inherited: false,
                    animatable: true
            )
        {
            this.Spacing = new Point(0, 0);

            this.StateValues = new Dictionary<string, BasicLengthState>
				{
					{"length", BasicLengthState.Length },
					{"inherit", BasicLengthState.Inherit },
					{"initial", BasicLengthState.Initial }
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
                Point spacing;
                if (this.pointParser.TryPoint(value, out spacing))
                {
                    this.Spacing = spacing;
                    this.CurrentState = BasicLengthState.Length;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Point))
                {
                    this.Spacing = (Point)value;
                    this.CurrentState = BasicLengthState.Length;

                    return true;
                }
            }

            return false;
        }
    }
}