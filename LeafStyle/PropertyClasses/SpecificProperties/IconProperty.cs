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
    public class IconProperty : ImageStyleProperty<IconState>
    {
        Parser.StringParser stringParser = new Parser.StringParser();

        public IconProperty()
            : base(
                defaultState: default(IconState),
                inherited: false,
                animatable: false
            )
        {
            this.StateValues = new Dictionary<string, IconState>()
                {
                    {"auto", IconState.Auto},
                    {"url", IconState.Url},
                    {"initial", IconState.Initial},
                    {"inherit", IconState.Inherit}
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
                string url;
                if (this.stringParser.TryUrl(value, out url))
                {
                    this.ImageName = url;
                    this.CurrentState = IconState.Url;

                    return true;
                }
            }

            // Couldn't parse
            return false;
        }
    }
}
