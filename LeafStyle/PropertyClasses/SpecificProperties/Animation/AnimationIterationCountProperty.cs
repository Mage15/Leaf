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
    internal class AnimationIterationCountProperty : BasicStyleProperty<AnimationIterationCountState>
    {
        public int Number { get; set; }

        public AnimationIterationCountProperty()
            : base(
                    defaultState: default(AnimationIterationCountState),
                    inherited: false,
                    animatable: false
            )
        {
            this.Number = 1;

            this.StateValues = new Dictionary<string, AnimationIterationCountState>()
				{
					{"number", AnimationIterationCountState.Number },
					{"infinite", AnimationIterationCountState.Infinite },
					{"initial", AnimationIterationCountState.Initial },
					{"inherit", AnimationIterationCountState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value)) // Check if and set if StateValues key
            {
                return true;
            }
            else if (value != null) // If not a StateValues key check try to parse as Number value
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    this.Number = number;
                    this.CurrentState = AnimationIterationCountState.Number;

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
                if (value.GetType() == typeof(int))
                {
                    this.Number = (int)value;
                    this.CurrentState = AnimationIterationCountState.Number;

                    return true;
                }
            }

            return false;
        }
    }
}