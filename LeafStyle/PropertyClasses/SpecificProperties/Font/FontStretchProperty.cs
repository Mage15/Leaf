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
    public class FontStretchProperty : BasicStyleProperty<FontStretchState>
    {
        public FontStretchProperty()
            : base(
                defaultState: default(FontStretchState),
                inherited: true,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, FontStretchState>()
                {
                    {"none", FontStretchState.None},
                    {"wider", FontStretchState.Wider},
                    {"narrower", FontStretchState.Narrower},
                    {"ultra-condensed", FontStretchState.UltraCondensed},
                    {"extra-condensed", FontStretchState.ExtraCondensed},
                    {"condensed", FontStretchState.Condensed},
                    {"semi-condensed", FontStretchState.SemiCondensed},
                    {"normal", FontStretchState.Normal},
                    {"semi-expanded", FontStretchState.SemiExpanded},
                    {"expanded", FontStretchState.Expanded},
                    {"extra-expanded", FontStretchState.ExtraExpanded},
                    {"ultra-expanded", FontStretchState.UltraExpanded},
                    {"initial", FontStretchState.Initial},
                    {"inherit", FontStretchState.Inherit}
                };
        }
    }
}