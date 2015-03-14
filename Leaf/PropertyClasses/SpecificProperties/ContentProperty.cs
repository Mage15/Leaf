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
    // Needs special implimentation
    internal class ContentProperty : BasicStyleProperty<ContentState>
    {
        public ContentValuesContainer Values { get; set; }

        public ContentProperty()
            : base(
                    defaultState: default(ContentState),
                    inherited: false,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, ContentState>()
                {
                    {"normal", ContentState.Normal},
                    {"none",ContentState. None},
                    {"counter", ContentState.Counter},
                    {"attr", ContentState.Attribute},
                    {"string", ContentState.String},
                    {"open-quote", ContentState.OpenQuote},
                    {"close-quote", ContentState.CloseQuote},
                    {"no-open-quote", ContentState.NoOpenQuote},
                    {"no-close-quote", ContentState.NoCloseQuote},
                    {"url", ContentState.Url},
                    {"initial", ContentState.Initial},
                    {"inherit", ContentState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else
            {

            }

            // Could not parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(ContentValuesContainer))
                {
                    this.Values = (ContentValuesContainer)value;
                }
            }

            return false;
        }
    }
}