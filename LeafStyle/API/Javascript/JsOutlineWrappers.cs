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
        /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out". 
        /// The Outline shorthand property sets all the outline properties in one declaration. If one of the values are 
        /// missing, (e.g. Outline = "solid #ff0000"), the default value, if any, for the missing property will be 
        /// inserted.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;OutlineColor</para>
        /// <para>&#160;&#160;OutlineStyle</para>
        /// <para>&#160;&#160;OutlineWidth</para>
        /// <para>&#160;</para><br />
        /// <para>Note: Outlines differ from borders in two ways: Outlines do not take up space, Outlines may be non-rectangular.</para>
        /// <para>&#160;</para><br />
        /// <para>Note: The outline is not a part of the element's dimensions, therefore the element's width and 
        /// height properties do not contain the width of the outline.</para>
        /// </summary>
        public string Outline
        {
            set
            {
                Dictionary<Property, string> outlineValues;
                if (this.parser.TryOutline(value, out outlineValues))
                {
                    SetProperty(Property.Outline, outlineValues[Property.Outline]);

                    this.OutlineColor = outlineValues[Property.OutlineColor];
                    this.OutlineStyle = outlineValues[Property.OutlineStyle];
                    this.OutlineWidth = outlineValues[Property.OutlineWidth];
                }
            }
        }

        /// <summary>
        /// The OutlineColor property specifies the color of an outline.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the OutlineStyle property before the OutlineColor property. An 
        /// element must have an outline before you change the color of it.</para>
        /// </summary>
        public string OutlineColor { set { SetProperty(Property.OutlineColor, value); } }

        /// <summary>
        /// The OutlineOffset property offsets an outline, and draws it beyond the border edge.
        /// </summary>
        public string OulineOffset { set { SetProperty(Property.OutlineOffset, value); } }

        /// <summary>
        /// The OutlineStyle property specifies the style of an outline.
        /// </summary>
        public string OutlineStyle { set { SetProperty(Property.OutlineStyle, value); } }

        /// <summary>
        /// The OutlineWidth specifies the width of an outline.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the OutlineStyle property before the OutlineWidth property. An 
        /// element must have an outline before you change the width of it.</para>
        /// </summary>
        public string OutlineWidth { set { SetProperty(Property.OutlineWidth, value); } }
    }
}
