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
    public class BorderImageWidthProperty : BasicStyleProperty<BorderImageWidthState>
    {
        private Parser.QuadValuesParser quadParser = new Parser.QuadValuesParser();

        public QuadValues<int> Absolute { get; set; }
        public QuadValues<float> Percent { get; set; }
        public QuadValues<short> Number { get; set; }

        public BorderImageWidthProperty()
            : base(
                    defaultState: default(BorderImageWidthState),
                    inherited: false,
                    animatable: false
            )
        {
            this.Number = new QuadValues<short>(1);

            this.StateValues = new Dictionary<string, BorderImageWidthState>()
				{
					{"number", BorderImageWidthState.Number },
					{"length", BorderImageWidthState.Length },
					{"percent", BorderImageWidthState.Percent },
					{"auto", BorderImageWidthState.Auto },
					{"initial", BorderImageWidthState.Initial },
					{"inherit", BorderImageWidthState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value)) // Check if and set if StateValues key
            {
                return true;
            }
            else if (value != null && value.Contains("px"))
            {
                QuadValues<int> quadValues;
                if (this.quadParser.TryQuadValues<int>(value, out quadValues))
                {
                    this.Absolute = quadValues;
                    this.CurrentState = BorderImageWidthState.Length;

                    return true;
                }
            }
            else if (value != null && value.Contains("%"))
            {
                QuadValues<float> quadValues;
                if (this.quadParser.TryQuadValues<float>(value, out quadValues))
                {
                    this.Percent = quadValues;
                    this.CurrentState = BorderImageWidthState.Percent;

                    return true;
                }
            }
            else if (value != null)
            {
                QuadValues<short> quadValues;
                if (this.quadParser.TryQuadValues<short>(value, out quadValues))
                {
                    this.Number = quadValues;
                    this.CurrentState = BorderImageWidthState.Number;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }
    }
}