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
        /// The Font property is a shorthand property sets all the font properties in one declaration.
        /// <para>The FontSize and FontFamily values are required. If one of the other values are missing, the default values, if any, will be 
        /// inserted.</para>
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;FontStyle</para>
        /// <para>&#160;&#160;FontVariant</para>
        /// <para>&#160;&#160;FontWeight</para>
        /// <para>&#160;&#160;FontSize / LineHeight</para>
        /// <para>&#160;&#160;FontFamily</para>
        /// <para>&#160;</para><br />
        /// <para>Note: The LineHeight property sets the space between lines.</para>
        /// </summary>
        public string Font
        {
            set
            {
                Dictionary<Property, string> fontValues;
                if (this.parser.TryFont(value, out fontValues))
                {
                    SetProperty(Property.Font, fontValues[Property.Font]);

                    this.FontStyle = fontValues[Property.FontStyle];
                    this.FontVariant = fontValues[Property.FontVariant];
                    this.FontWeight = fontValues[Property.FontWeight];
                    this.FontSize = fontValues[Property.FontSize];
                    this.FontFamily = fontValues[Property.FontFamily];
                    this.LineHeight = fontValues[Property.LineHeight];
                }
            }
        }

        /// <summary>
        /// The FontFace property loads a custom name and custom font, you must specify the name font and the file 
        /// path of font file. e.g. FontFace = "myFirstFont, c:\\myFirstFont.ttf"
        /// <para>&#160;</para><br />
        /// <para>Tip: To use the font for an element, refer to the name of the font (myFirstFont) through the FontFamily 
        /// property: FontFamily = "myFirstFont"</para>
        /// </summary>
        public string FontFace { set { SetProperty(Property.FontFace, value); } }

        /// <summary>
        /// The FontFamily property specifies the font to be used for an element.
        /// </summary>
        public string FontFamily { set { SetProperty(Property.FontFamily, value); } }

        /// <summary>
        /// The FontSize property sets the size of a font.
        /// </summary>
        public string FontSize { set { SetProperty(Property.FontSize, value); } }

        //public string fontSizeAdjust { set { SetProperty(Property.FontSizeAdjust, value); } }

        /// <summary>
        /// The FontStretch property allows you to make text wider or narrower.
        /// </summary>
        public string FontStretch { set { SetProperty(Property.FontStretch, value); } }

        /// <summary>
        /// The FontStyle property specifies the font style for a text. Such as normal, italic, or oblique.
        /// </summary>
        public string FontStyle { set { SetProperty(Property.FontStyle, value); } }

        /// <summary>
        /// The FontVariant property specifies whether or not a text should be displayed in a small-caps font.
        /// </summary>
        public string FontVariant { set { SetProperty(Property.FontVariant, value); } }

        /// <summary>
        /// The FontWeight property sets how thick or thin characters in text should be displayed.
        /// </summary>
        public string FontWeight { set { SetProperty(Property.FontWeight, value); } }
    }
}
