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
        /// The TextAlign property specifies the horizontal alignment of text in an element.
        /// </summary>
        public string TextAlign { set { SetProperty(Property.TextAlign, value); } }

        /// <summary>
        /// The TextAlignLast property specifies how to align the last line of a text.
        /// <para>&#160;</para><br />
        /// <para>Note: The TextAlignLast property will only work for elements with the TextAlign property 
        /// set to "justify".</para>
        /// </summary>
        public string TextAlignLast { set { SetProperty(Property.TextAlignLast, value); } }

        /// <summary>
        /// The TextDecoration property specifies the decoration added to text. It is a shorthand property for:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;TextDecorationLine</para>
        /// <para>&#160;&#160;TextDecorationColor</para>
        /// <para>&#160;&#160;TextDecorationStyle</para>
        /// <para>&#160;</para><br />
        /// <para>Note: You can use the TextDecorationColor property to change the color of the decoration, 
        /// otherwise the color is the same as the color of the text.</para>
        /// </summary>
        public string TextDecoration 
        {
            set 
            {
                Dictionary<Property, string> textDecorationValues;
                if (this.parser.TryTextDecoration(value, out textDecorationValues))
                {
                    this.SetProperty(Property.TextDecoration, textDecorationValues[Property.TextDecoration]);

                    this.TextDecorationLine = textDecorationValues[Property.TextDecorationLine];
                    this.TextDecorationColor = textDecorationValues[Property.TextDecorationColor];
                    this.TextDecorationStyle = textDecorationValues[Property.TextDecorationStyle];
                }
            } 
        }

        /// <summary>
        /// The TextDecorationColor property specifies the color of the TextDecoration (underlines, overlines, 
        /// linethroughs).
        /// <para>&#160;</para><br />
        /// <para>Note: The TextDecorationColor property will only have an effect on elements with a visible 
        /// TextDecoration.</para>
        /// </summary>
        public string TextDecorationColor { set { SetProperty(Property.TextDecorationColor, value); } }

        /// <summary>
        /// The TextDecorationLine property specifies what type of line, if any, the decoration will have.
        /// <para>&#160;</para><br />
        /// <para>Note: You can combine more than one value, like underline and overline to display lines both 
        /// under and over the text.</para>
        /// </summary>
        public string TextDecorationLine { set { SetProperty(Property.TextDecorationLine, value); } }

        /// <summary>
        /// The TextDecorationStyle property specifies how the line, if any, will display.
        /// </summary>
        public string TextDecorationStyle { set { SetProperty(Property.TextDecorationStyle, value); } }

        /// <summary>
        /// The TextIndent property specifies the indentation of the first line in a text-block.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are allowed. The first line will be indented to the left if the value 
        /// is negative.</para>
        /// </summary>
        public string TextIndent { set { SetProperty(Property.TextIndent, value); } }

        /// <summary>
        /// The TextJustify property specifies the justification method to use when TextAlign is set to 
        /// "justify". It specifies how justified text should be aligned and spaced.</para>
        /// </summary>
        public string TextJustify { set { SetProperty(Property.TextJustify, value); } }

        /// <summary>
        /// The TextOverflow property specifies what should happen when text overflows the containing element.
        /// </summary>
        public string TextOverflow { set { SetProperty(Property.TextOverflow, value); } }

        /// <summary>
        /// The TextShadow property adds shadow to text. This property accepts a comma-separated list of 
        /// shadows to be applied to the text.
        /// </summary>
        public string TextShadow { set { SetProperty(Property.TextShadow, value); } }

        /// <summary>
        /// The TextTransform property controls the capitalization of text.
        /// </summary>
        public string TextTransform { set { SetProperty(Property.TextTransform, value); } }
    }
}
