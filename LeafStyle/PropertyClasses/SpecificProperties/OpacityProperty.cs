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
    internal class OpacityProperty : BasicStyleProperty<BasicNumberState>
    {
        public float Number { get; set; }

        public OpacityProperty()
            : base(
                defaultState: default(BasicNumberState),
                inherited: false,
                animatable: false
                )
        {
            this.Number = 0;

            this.StateValues = new Dictionary<string, BasicNumberState>()
                {
                    {"number", BasicNumberState.Number},
                    {"initial", BasicNumberState.Initial},
                    {"inherit", BasicNumberState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null)  // If not key for StateValues try and parse as Number value
            {
                float number;
                if (float.TryParse(value, out number))
                {
                    this.Number = number;
                    this.CurrentState = BasicNumberState.Number;

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
                if (value.GetType() == typeof(float))
                {
                    this.Number = (int)value;
                    this.CurrentState = BasicNumberState.Number;

                    return true;
                }
            }

            return false;
        }
    }
}