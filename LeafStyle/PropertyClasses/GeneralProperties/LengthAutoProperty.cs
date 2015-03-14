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
    public class LengthAutoProperty : BasicStyleProperty<LengthAutoState>
    {
        public int Length { get; set; }

        public LengthAutoProperty()
            : base(
                defaultState: default(LengthAutoState),
                inherited: false,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, LengthAutoState>()
                {
                    {"auto", LengthAutoState.Auto},
                    {"length", LengthAutoState.Length},
                    {"inherit", LengthAutoState.Inherit},
                    {"initial", LengthAutoState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null && value.Contains("px"))
            {
                int length;
                if (int.TryParse(value.Remove(value.IndexOf("px")), out length))
                {
                    this.Length = length;
                    this.CurrentState = LengthAutoState.Length;

                    return true;
                }
            }

            // Could not parse
            return false;
        }
    }
}