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
    internal class BorderImageSliceProperty : BasicStyleProperty<BorderImageSliceState>
    {
        private Parser.VectorParser vectorParser = new Parser.VectorParser();
        private Parser.PointParser pointParser = new Parser.PointParser();

        public Point Number;
        public Vector2 Percent;

        private BorderImageSliceProperty()
            : base(
                    defaultState: default(BorderImageSliceState),
                    inherited: false,
                    animatable: false
            )
        {
            this.Number = new Point();
            this.Percent = new Vector2(1.0f, 1.0f);

            this.StateValues = new Dictionary<string, BorderImageSliceState>()
				{
					{"number", BorderImageSliceState.Number },
					{"percent", BorderImageSliceState.Percent },
					{"fill", BorderImageSliceState.Fill },
					{"initial", BorderImageSliceState.Initial },
					{"inherit", BorderImageSliceState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null && value.Contains("%"))
            {
                Vector2 percent;
                if (this.vectorParser.TryVector2(value, out percent))
                {
                    this.Percent = percent;
                    this.CurrentState = BorderImageSliceState.Percent;

                    return true;
                }
            }
            else if (value != null)
            {
                Point number;
                if (this.pointParser.TryPoint(value, out number))
                {
                    this.Number = number;
                    this.CurrentState = BorderImageSliceState.Number;

                    return true;
                }
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
                    this.Number = (Point)value;
                    this.CurrentState = BorderImageSliceState.Number;

                    return true;
                }
                else if (value.GetType() == typeof(Vector2))
                {
                    this.Percent = (Vector2)value;
                    this.CurrentState = BorderImageSliceState.Percent;

                    return true;
                }
            }

            return false;
        }
    }
}