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
        /// The ListStyle shorthand property sets all the list properties in one declaration. If one of the values above are missing, 
        /// e.g. ListStyle= = "circle inside", the default value, if any, for the missing property will be inserted.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;ListStyleType</para>
        /// <para>&#160;&#160;ListStylePosition</para>
        /// <para>&#160;&#160;ListStyleImage</para>
        /// <para>&#160;</para><br />
        /// </summary>
        public string ListSyle
        {
            set
            {
                Dictionary<Property, string> listStyleValues;
                if (this.parser.TryListStyle(value, out listStyleValues))
                {
                    SetProperty(Property.ListStyle, listStyleValues[Property.ListStyle]);

                    this.ListStyleImage = listStyleValues[Property.ListStyleImage];
                    this.ListStylePosition = listStyleValues[Property.ListStylePosition];
                    this.ListStyleType = listStyleValues[Property.ListStyleType];
                }
            }
        }

        /// <summary>
        /// The ListStyleImage property replaces the ListItem marker with an image.
        /// <para>&#160;</para><br />
        /// <para>Tip: Specify the ListStyleType property in addition, because it will be used if the image for some 
        /// reason is unavailable.</para>
        /// </summary>
        public string ListStyleImage
        {
            set
            {
                SetProperty(Property.ListStyleImage, value);
                LoadImage(Property.ListStyleImage);
            }
        }

        /// <summary>
        /// The ListStylePosition property specifies if the ListItem markers should appear inside or outside the 
        /// content flow.
        /// </summary>
        public string ListStylePosition { set { SetProperty(Property.ListStylePosition, value); } }

        /// <summary>
        /// The ListStyleType specifies the type of ListItem marker in a list.
        /// </summary>
        public string ListStyleType { set { SetProperty(Property.ListStyleType, value); } }

    }
}
