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
    public class TransitionPropertyProperty : BasicStyleProperty<TransitionPropertyState>
    {
        private Parser.StringParser stringParser = new Parser.StringParser();

        public List<string> PropertyNames { get; set; }

        public TransitionPropertyProperty()
            : base(
                defaultState: default(TransitionPropertyState),
                inherited: false,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, TransitionPropertyState>()
                {
                    {"all", TransitionPropertyState.All},
                    {"none", TransitionPropertyState.None},
                    {"property", TransitionPropertyState.Property},
                    {"initial", TransitionPropertyState.Initial},
                    {"inherit", TransitionPropertyState.Inherit}
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
                List<string> propertyNames;
                if (this.stringParser.TryStringList(value, out propertyNames))
                {
                    this.PropertyNames = propertyNames;
                    this.CurrentState = TransitionPropertyState.Property;

                    return true;
                }
            }

            // Couldn't parse
            return false;
        }
    }
}
