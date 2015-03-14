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
        /// The Padding shorthand property sets all the Padding* properties in one declaration. This property can have 
        /// from one to four values.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;PaddingTop</para>
        /// <para>&#160;&#160;PaddingRight</para>
        /// <para>&#160;&#160;PaddingBottom</para>
        /// <para>&#160;&#160;PaddingLeft</para>
        /// <para>&#160;</para><br />
        /// </summary>
        public string Padding
        {
            set
            {
                Dictionary<Property, string> paddingValues;
                if (this.parser.TryPadding(value, out paddingValues))
                {
                    SetProperty(Property.Padding, paddingValues[Property.Padding]);

                    this.PaddingBottom = paddingValues[Property.PaddingBottom];
                    this.PaddingLeft = paddingValues[Property.PaddingLeft];
                    this.PaddingRight = paddingValues[Property.PaddingRight];
                    this.PaddingTop = paddingValues[Property.PaddingTop];
                }
            }
        }

        /// <summary>
        /// The PaddingBottom property sets the bottom padding (space) of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are not allowed.</para>
        /// </summary>
        public string PaddingBottom { set { SetProperty(Property.PaddingBottom, value); } }

        /// <summary>
        /// The PaddingLeft property sets the left padding (space) of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are not allowed.</para>
        /// </summary>
        public string PaddingLeft { set { SetProperty(Property.PaddingLeft, value); } }

        /// <summary>
        /// The PaddingRight property sets the right padding (space) of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are not allowed.</para>
        /// </summary>
        public string PaddingRight { set { SetProperty(Property.PaddingRight, value); } }

        /// <summary>
        /// The PaddingTop property sets the top padding (space) of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are not allowed.</para>
        /// </summary>
        public string PaddingTop { set { SetProperty(Property.PaddingTop, value); } }
    }
}
