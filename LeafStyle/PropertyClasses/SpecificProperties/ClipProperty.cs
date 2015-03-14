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
using System.Text.RegularExpressions;

namespace LeafStyle
{
    public class ClipProperty : BasicStyleProperty<ClipState>
    {
        private Parser.RectangleParser rectParser = new Parser.RectangleParser();

        public Microsoft.Xna.Framework.Rectangle ClipRectangle { get; private set; }
        
        public ClipProperty()
            : base(
                    defaultState: default(ClipState),
                    inherited: false,
                    animatable: true
            )
        {
            this.StateValues = new Dictionary<string, ClipState>()
				{
					{"auto", ClipState.Auto },
					{"shape", ClipState.Shape },
					{"initial", ClipState.Initial },
					{"inherit", ClipState.Inherit }
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
                if (value.Contains("rect"))
                {
                    Microsoft.Xna.Framework.Rectangle clipRect;
                    if(rectParser.TryRectangle(value, out clipRect))
                    {
                        this.CurrentState = ClipState.Shape;
                        this.ClipRectangle = clipRect;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }
    }
}