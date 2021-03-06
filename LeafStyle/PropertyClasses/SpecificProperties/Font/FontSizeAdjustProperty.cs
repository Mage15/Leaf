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
    public class FontSizeAdjustProperty : BasicStyleProperty<FontSizeAdjustState>
    {
        public float Number { get; set; }

        public FontSizeAdjustProperty()
            : base(
                defaultState: default(FontSizeAdjustState),
                inherited: true,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, FontSizeAdjustState>()
                {
                    {"number", FontSizeAdjustState.Number},
                    {"none", FontSizeAdjustState.None},
                    {"initial", FontSizeAdjustState.Initial},
                    {"inherit", FontSizeAdjustState.Inherit}
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
                float number;
                if (float.TryParse(value, out number))
                {
                    this.Number = number;
                    this.CurrentState = FontSizeAdjustState.Number;

                    return true;
                }
            }

            // Couldn't parse
            return false;
        }
    }
}