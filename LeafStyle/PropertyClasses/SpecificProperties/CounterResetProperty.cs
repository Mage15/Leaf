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
    internal class CounterResetProperty : BasicStyleProperty<CounterResetState>
    {
        public string Id { get; set; }
        public int Number { get; set; }

        public CounterResetProperty()
            : base(
                    defaultState: default(CounterResetState),
                    inherited: false,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, CounterResetState>()
                {
                    {"none", CounterResetState.None},
                    {"name-number", CounterResetState.Name_Number},
                    {"initial", CounterResetState.Initial},
                    {"inherit", CounterResetState.Inherit}
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
                string[] strValues = value.Split(new char[] { ' ' });

                if (strValues.Length == 2)
                {
                    int number;
                    if (int.TryParse(strValues[1], out number))
                    {
                        this.Id = strValues[0];
                        this.Number = number;
                        this.CurrentState = CounterResetState.Name_Number;

                        return true;
                    }
                }
                else if (strValues.Length == 1)
                {
                    this.Id = strValues[0];
                    this.Number = 0; // Default value
                    this.CurrentState = CounterResetState.Name_Number;
                }
            }

            // Could not be parsed
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
                else if (value.GetType() == typeof(int))
                {
                    this.Number = (int)value;
                }
            }

            return false;
        }

        public override bool TrySetValues(object[] values)
        {
            bool allValuesSet = true;

            foreach (object obj in values)
            {
                if (!TrySetValue(obj))
                {
                    allValuesSet = false;
                }
            }

            return allValuesSet;
        }
    }
}