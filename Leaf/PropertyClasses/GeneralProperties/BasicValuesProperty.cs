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
    internal class BasicValuesProperty : BasicStyleProperty<BasicValuesState>
    {
        public BasicValuesProperty()
            : base(
                defaultState: default(BasicValuesState),
                inherited: false,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, BasicValuesState>()
                {
                    {"use-values", BasicValuesState.UseValues},
                    {"inherit", BasicValuesState.Inherit},
                    {"initial", BasicValuesState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null)  // If not key for StateValues just assume user wants to use values
            {
                this.CurrentState = BasicValuesState.UseValues;
                return true;
            }

            // value was null
            return false;
        }
    }
}