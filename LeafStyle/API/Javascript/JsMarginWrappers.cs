/* 
    Copyright (C) 2015 Matthew Gefaller
    This file is part of LeafStyle.

    LeafStyle is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LeafStyle is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LeafStyle.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace LeafStyle
{
    public partial class UIStyle
    {
        /// <summary>
        /// The Margin shorthand property sets all the margin properties in one declaration. This property can have 
        /// from one to four values.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;MarginTop</para>
        /// <para>&#160;&#160;MarginRight</para>
        /// <para>&#160;&#160;MarginBottom</para>
        /// <para>&#160;&#160;MarginLeft</para>
        /// <para>&#160;</para><br />
        /// </summary>
        public string Margin
        {
            set
            {
                Dictionary<Property, string> marginValues;
                if (this.parser.TryMargin(value, out marginValues))
                {
                    SetProperty(Property.Margin, marginValues[Property.Margin]);

                    this.MarginBottom = marginValues[Property.MarginBottom];
                    this.MarginLeft = marginValues[Property.MarginLeft];
                    this.MarginRight = marginValues[Property.MarginRight];
                    this.MarginTop = marginValues[Property.MarginTop];
                }
            }
        }

        /// <summary>
        /// The MarginBottom property sets the bottom margin of an element.
        /// </summary>
        public string MarginBottom { set { SetProperty(Property.MarginBottom, value); } }

        /// <summary>
        /// The marginLeft property sets the left margin of an element.
        /// </summary>
        public string MarginLeft { set { SetProperty(Property.MarginLeft, value); } }

        /// <summary>
        /// The MarginRight property sets the right margin of an element.
        /// </summary>
        public string MarginRight { set { SetProperty(Property.MarginRight, value); } }

        /// <summary>
        /// The MarginTop property sets the top margin of an element.
        /// </summary>
        public string MarginTop { set { SetProperty(Property.MarginTop, value); } }
    }
}
