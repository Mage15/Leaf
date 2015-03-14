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
    internal class ListStyleImageProperty : ImageStyleProperty<ListStyleImageState>
    {
        private Parser.StringParser stringParser = new Parser.StringParser();

        public ListStyleImageProperty()
            : base(
                defaultState: default(ListStyleImageState),
                inherited: true,
                animatable: false
            )
        {
            this.StateValues = new Dictionary<string, ListStyleImageState>()
                {
                    {"none", ListStyleImageState.None},
                    {"url", ListStyleImageState.Image},
                    {"initial", ListStyleImageState.Initial},
                    {"inherit", ListStyleImageState.Inherit}
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
                if (value.Contains("url"))
                {
                    string imageName;
                    if (this.stringParser.TryUrl(value, out imageName))
                    {
                        this.ImageName = imageName;
                        this.CurrentState = ListStyleImageState.Image;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(PropertyString))
                {
                    this.ImageName = ((PropertyString)value).StringValue;
                }
            }

            return false;
        }
    }
}