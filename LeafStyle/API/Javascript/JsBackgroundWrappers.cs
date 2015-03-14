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
        /// The Background shorthand property sets all the background properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BackgroundColor</para>
        /// <para>&#160;&#160;BackgroundPosition</para>
        /// <para>&#160;&#160;BackgroundSize</para>
        /// <para>&#160;&#160;BackgroundRepeat</para>
        /// <para>&#160;&#160;BackgroundOrigin</para>
        /// <para>&#160;&#160;BackgroundClip</para>
        /// <para>&#160;&#160;BackgroundAttachment</para>
        /// <para>&#160;&#160;BackgroundImage</para>
        /// <para>&#160;</para><br />
        /// <para>Note: It does not matter if one of the values above are missing, e.g. Background = "#ff0000 
        /// url(smiley.gif)" is allowed.</para>
        /// <para>Note: If one of the properties in the shorthand declaration is the BackgroundSize property, 
        /// you must use a / (slash) to separate it from the BackgroundPostion property, e.g. 
        /// Background = "url(smiley.gif) 10px 20px/50px 50px" will result in a background image, positioned 10 pixels 
        /// from the left, 20 pixels from the top, and the size of the image will be 50 pixels wide and 50 pixels 
        /// high.</para>
        /// </summary>
        public string Background
        {
            set
            {
                Dictionary<Property, string> backgroundValues;
                if (this.parser.TryBackgroundValues(value, out backgroundValues))
                {
                    SetProperty(Property.Background, backgroundValues[Property.Background]);

                    this.BackgroundColor = backgroundValues[Property.BackgroundColor];
                    this.BackgroundPosition = backgroundValues[Property.BackgroundPosition];
                    this.BackgroundSize = backgroundValues[Property.BackgroundSize];
                    this.BackgroundRepeat = backgroundValues[Property.BackgroundRepeat];
                    this.BackgroundOrigin = backgroundValues[Property.BackgroundOrigin];
                    this.BackgroundClip = backgroundValues[Property.BackgroundClip];
                    this.BackgroundAttachment = backgroundValues[Property.BackgroundAttachment];
                    this.BackgroundImage = backgroundValues[Property.BackgroundImage];
                }
            }
        }

        /// <summary>
        /// The BackgroundAttachment property sets whether a background image is fixed or scrolls with the rest of the page.
        /// </summary>
        public string BackgroundAttachment { set { SetProperty(Property.BackgroundAttachment, value); } }

        /// <summary>
        /// The BackgroundClip property specifies the painting area of the background.
        /// </summary>
        public string BackgroundClip { set { SetProperty(Property.BackgroundClip, value); } }

        /// <summary>
        /// The BackgroundColor property sets the background color of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: The background of an element is the total size of the element, including padding and border 
        /// (but not the margin).</para>
        /// </summary>
        public string BackgroundColor { set { SetProperty(Property.BackgroundColor, value); } }

        /// <summary>
        /// The BackgroundImage property sets one or more background images for an element.
        /// <para>&#160;</para><br />
        /// <para>Note: The background of an element is the total size of the element, including padding and border 
        /// (but not the margin).</para>
        /// <para>Note: By default, a background image is placed at the top-left corner of an element, and repeated 
        /// both vertically and horizontally. </para>
        /// </summary>
        public string BackgroundImage
        {
            set
            {
                SetProperty(Property.BackgroundImage, value);
                LoadImage(Property.BackgroundImage);
            }
        }

        /// <summary>
        /// The BackgroundOrigin property specifies what the BackgroundPosition property should be relative to.
        /// <para>&#160;</para><br />
        /// <para>Note: If the BackgroundAttachment property for the background image is "fixed", this property has no 
        /// effect.</para>
        /// </summary>
        public string BackgroundOrigin { set { SetProperty(Property.BackgroundOrigin, value); } }

        /// <summary>
        /// The BackgroundPosition property sets the starting position of a background image.
        /// </summary>
        public string BackgroundPosition { set { SetProperty(Property.BackgroundPosition, value); } }

        /// <summary>
        /// The BackgroundRepeat property sets if/how a background image will be repeated.
        /// <para>&#160;</para><br />
        /// <para>Note: By default, a background image is repeated both vertically and horizontally.</para>
        /// </summary>
        public string BackgroundRepeat { set { SetProperty(Property.BackgroundRepeat, value); } }

        /// <summary>
        /// The BackgroundSize property specifies the size of the background images.
        /// </summary>
        public string BackgroundSize { set { SetProperty(Property.BackgroundSize, value); } }
    }
}
