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
    public class BackgroundSizeProperty : BasicStyleProperty<BackgroundSizeState>
    {
        private Parser.PointParser pointParser = new Parser.PointParser();
        private Parser.VectorParser vectorParser = new Parser.VectorParser();

        public Point SizeAbsolute;
        public Vector2 SizePercent;

        public BackgroundSizeProperty()
            : base(
                    defaultState: default(BackgroundSizeState),
                    inherited: false,
                    animatable: true
            )
        {
            this.SizeAbsolute = new Point();
            this.SizePercent = new Vector2(1.0f, 1.0f);

            this.StateValues = new Dictionary<string, BackgroundSizeState>()
				{
					{"auto", BackgroundSizeState.Auto },
					{"length", BackgroundSizeState.Length },
					{"percent", BackgroundSizeState.Percent },
					{"cover", BackgroundSizeState.Cover },
					{"contain", BackgroundSizeState.Contain },
					{"initial", BackgroundSizeState.Initial },
					{"inherit", BackgroundSizeState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null && value.Contains("px")) // If not StatesValues key try and parse as X and Y Absolute values
            {
                Point absolute;
                if (this.pointParser.TryPoint(value, out absolute))
                {
                    this.SizeAbsolute = absolute;
                    this.CurrentState = BackgroundSizeState.Length;

                    return true;
                }
            }
            else if (value != null && value.Contains("%")) // If not StatesValues key try and parse as X and Y Percent values
            {
                Vector2 percent;
                if (this.vectorParser.TryVector2(value, out percent))
                {
                    this.SizePercent = percent;
                    this.CurrentState = BackgroundSizeState.Percent;

                    return true;
                }
            }

            // Could not parse
            return false;
        }
    }
}