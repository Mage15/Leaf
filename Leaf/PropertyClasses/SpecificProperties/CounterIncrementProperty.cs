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
    internal class CounterIncrementProperty : BasicStyleProperty<CounterIncrementState>
    {
        public string Id { get; set; }

        public CounterIncrementProperty()
            : base(
                    defaultState: default(CounterIncrementState),
                    inherited: false,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, CounterIncrementState>()
                {
                    {"none", CounterIncrementState.None},
                    {"id", CounterIncrementState.Id},
                    {"initial", CounterIncrementState.Initial},
                    {"inherit", CounterIncrementState.Inherit}
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
                if (value != null)  // Assume Id value was provided
                {
                    this.Id = value;
                    this.CurrentState = CounterIncrementState.Id;

                    return true;
                }
            }

            // value was null
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(string))
                {
                    this.Id = (string)value;
                }
            }

            return false;
        }
    }
}