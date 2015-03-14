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
    internal class TextOverflowProperty : BasicStyleProperty<TextOverflowState>
    {
        public string String { get; set; }

        public TextOverflowProperty()
            : base(
                defaultState: default(TextOverflowState),
                inherited: false,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, TextOverflowState>()
                {
                    {"clip", TextOverflowState.Clip},
                    {"ellipsis", TextOverflowState.Ellipsis},
                    {"string", TextOverflowState.String},
                    {"initial", TextOverflowState.Initial},
                    {"inherit", TextOverflowState.Inherit}
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
                this.String = value;
                this.CurrentState = TextOverflowState.String;

                return true;
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
                    this.String = (string)value;
                    this.CurrentState = TextOverflowState.String;

                    return true;
                }
            }

            return false;
        }
    }
}