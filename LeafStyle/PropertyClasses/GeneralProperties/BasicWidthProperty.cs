﻿/*
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
    public class BasicWidthProperty : BasicStyleProperty<BasicWidthState>
    {
        public int Length { get; set; }

        public BasicWidthProperty()
            : base(
                defaultState: default(BasicWidthState),
                inherited: false,
                animatable: true
                )
        {
            this.StateValues = new Dictionary<string, BasicWidthState>()
                {
                    {"length", BasicWidthState.Length},
                    {"medium", BasicWidthState.Medium},
                    {"thick", BasicWidthState.Thick},
                    {"thin", BasicWidthState.Thin},
                    {"inherit", BasicWidthState.Inherit},
                    {"initial", BasicWidthState.Initial}
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
                    this.CurrentState = BasicWidthState.Length;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }
    }
}