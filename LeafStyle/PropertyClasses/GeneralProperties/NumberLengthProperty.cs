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
    public class NumberLengthProperty : BasicStyleProperty<NumberLengthState>
    {
        public short Number { get; set; }
        public int Length { get; set; }

        public NumberLengthProperty()
            : base(
                defaultState: default(NumberLengthState),
                inherited: false,
                animatable: true
                )
        {
            this.Length = 0;

            this.StateValues = new Dictionary<string, NumberLengthState>()
                {
                    {"length", NumberLengthState.Length},
                    {"number", NumberLengthState.Number},
                    {"inherit", NumberLengthState.Inherit},
                    {"initial", NumberLengthState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null && value.Contains("px"))  // If not key for StateValues try and parse as Length value
            {
                int length;
                if (int.TryParse(value.Remove(value.IndexOf("px")), out length))
                {
                    this.Length = length;
                    this.CurrentState = NumberLengthState.Length;

                    return true;
                }
            }
            else if (value != null)  // If not key for StateValues or Length value try and parse as Number value
            {
                short number;
                if (short.TryParse(value, out number))
                {
                    this.Number = number;
                    this.CurrentState = NumberLengthState.Number;

                    return true;
                }
            }

            // Can not be parsed
            return false;
        }
    }
}