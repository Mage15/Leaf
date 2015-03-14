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
    internal class BackgroundPositionProperty : BasicStyleProperty<BackgroundPositionState>
    {
        private Parser.PointParser pointParser = new Parser.PointParser();
        private Parser.VectorParser vectorParser = new Parser.VectorParser();

        public Point PositionAbsolute;
        public Vector2 PositionPercent;

        public BackgroundPositionProperty()
            : base(
                    defaultState: default(BackgroundPositionState),
                    inherited: false,
                    animatable: true
            )
        {
            this.PositionAbsolute = new Point(0, 0);
            this.PositionPercent = new Vector2(0.0f, 0.0f);

            this.StateValues = new Dictionary<string, BackgroundPositionState>()
				{
					{"percent", BackgroundPositionState.XY_Percent },
					{"absolute", BackgroundPositionState.XY_Absolute },
					{"left top", BackgroundPositionState.LeftTop },
					{"left center", BackgroundPositionState.LeftCenter },
					{"left bottom", BackgroundPositionState.LeftBottom },
					{"right top", BackgroundPositionState.RightTop },
					{"right center", BackgroundPositionState.RightCenter },
					{"right bottom", BackgroundPositionState.RightBottom },
					{"center top", BackgroundPositionState.CenterTop },
					{"center center", BackgroundPositionState.CenterCenter },
					{"center bottom", BackgroundPositionState.CenterBottom },
					{"initial", BackgroundPositionState.Initial },
					{"inherit", BackgroundPositionState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value)) // Check if and set if StateValues key
            {
                return true;
            }
            else if (value != null && value.Contains("px")) // If not StatesValue key try and parse as X and Y Absolute values
            {
                Point absolute;
                if (this.pointParser.TryPoint(value, out absolute))
                {
                    this.PositionAbsolute = absolute;
                    this.CurrentState = BackgroundPositionState.XY_Absolute;

                    return true;
                }
            }
            else if (value != null && value.Contains("%")) // If not StatesValue key try and parse as X and Y Percent values
            {
                Vector2 percent;
                if (this.vectorParser.TryVector2(value, out percent))
                {
                    this.PositionPercent = percent;
                    this.CurrentState = BackgroundPositionState.XY_Percent;

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
                    this.PositionAbsolute = (Point)value;
                    this.CurrentState = BackgroundPositionState.XY_Absolute;

                    return true;
                }
                else if (value.GetType() == typeof(Vector2))
                {
                    this.PositionPercent = (Vector2)value;
                    this.CurrentState = BackgroundPositionState.XY_Percent;

                    return true;
                }
            }

            return false;
        }
    }
}