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
        /// The Border shorthand property sets all the border properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderWidth</para>
        /// <para>&#160;&#160;BorderStyle</para>
        /// <para>&#160;&#160;BorderColor</para>
        /// <para>&#160;</para><br />
        /// <para>Note: It does not matter if one of the values above are missing, e.g. Border = "solid #ff0000" 
        /// is allowed.</para>
        /// </summary>
        public string Border
        {
            set
            {
                Dictionary<Property, string> borderValues;
                if (this.parser.TryBorderValues(value, out borderValues))
                {
                    SetProperty(Property.Border, borderValues[Property.Border]);

                    this.BorderWidth = borderValues[Property.BorderWidth];
                    this.BorderStyle = borderValues[Property.BorderStyle];
                    this.BorderColor = borderValues[Property.BorderColor];
                }
            }
        }

        /// <summary>
        /// The BorderBottom shorthand property sets all the bottom border properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderBottom-wWidth</para>
        /// <para>&#160;&#160;BorderBottomStyle</para>
        /// <para>&#160;&#160;BorderBottomColor</para>
        /// <para>&#160;</para><br />
        /// <para>Note: It does not matter if one of the values above are missing, e.g. BorderBottom = "solid #ff0000" 
        /// is allowed.</para>
        /// </summary>
        public string BorderBottom
        {
            set
            {
                Dictionary<string, string> borderBottomValues;
                if (this.parser.TryBorderEdgeValues(value, out borderBottomValues))
                {
                    SetProperty(Property.BorderBottom, borderBottomValues["borderEdge"]);

                    this.BorderBottomWidth = borderBottomValues["borderEdgeWidth"];
                    this.BorderBottomStyle = borderBottomValues["borderEdgeStyle"];
                    this.BorderBottomColor = borderBottomValues["borderEdgeColor"];
                }
            }
        }

        /// <summary>
        /// The BorderBottomColor property sets the color of an element's bottom border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderBottomColor property. An element 
        /// must have borders before you can change the color.</para>
        /// </summary>
        public string BorderBottomColor { set { SetProperty(Property.BorderBottomColor, value); } }

        /// <summary>
        /// The BorderBottomLeftRadius property defines the shape of the border of the bottom left corner. The 
        /// two length or percentage values define the radii of a quarter ellipse that defines the shape of the 
        /// corner of the outer border edge. If the second value is omitted it is copied from the first.
        /// <para>&#160;</para><br />
        /// <para>Note: If either length is zero, the corner will become square.</para>
        /// </summary>
        public string BorderBottomLeftRadius { set { SetProperty(Property.BorderBottomLeftRadius, value); } }

        /// <summary>
        /// The BorderBottomRightRadius property defines the shape of the border of the bottom right corner. The 
        /// two length or percentage values define the radii of a quarter ellipse that defines the shape of the 
        /// corner of the outer border edge. If the second value is omitted it is copied from the first.
        /// <para>&#160;</para><br />
        /// <para>Note: If either length is zero, the corner will become square.</para>
        /// </summary>
        public string BorderBottomRightRadius { set { SetProperty(Property.BorderBottomRightRadius, value); } }

        /// <summary>
        /// The BorderBottomStyle property sets the style of an element's bottom border.
        /// </summary>
        public string BorderBottomStyle { set { SetProperty(Property.BorderBottomStyle, value); } }

        /// <summary>
        /// The BorderBottomWidth property sets the width of an element's bottom border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderBottomWidth property. An 
        /// element must have borders before you can change the width.</para>
        /// </summary>
        public string BorderBottomWidth { set { SetProperty(Property.BorderBottomWidth, value); } }

        /// <summary>
        /// The BorderCollapse property sets whether the table borders are collapsed into a single border or 
        /// detached.
        /// </summary>
        public string BorderCollapse { set { SetProperty(Property.BorderCollapse, value); } }

        /// <summary>
        /// The BorderColor property sets the color of an element's four borders. This property can have from 
        /// one to four values.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderColor property. An element 
        /// must have borders before you can change the color.</para>
        /// <para>&#160;</para><br />
        /// <para>Note: If the fourth value is omitted, it is the same as the second. If the third one is 
        /// also omitted, it is the same as the first. If the second one is also omitted, it is the same 
        /// as the first.</para>
        /// </summary>
        public string BorderColor
        {
            set
            {
                Dictionary<Property, string> borderColorValues;
                if (this.parser.TryBorderColorValues(value, out borderColorValues))
                {
                    SetProperty(Property.BorderColor, borderColorValues[Property.BorderColor]);

                    this.BorderTopColor = borderColorValues[Property.BorderTopColor];
                    this.BorderLeftColor = borderColorValues[Property.BorderLeftColor];
                    this.BorderBottomColor = borderColorValues[Property.BorderBottomColor];
                    this.BorderRightColor = borderColorValues[Property.BorderRightColor];
                }
            }
        }

        /// <summary>
        /// The BorderImage property is a shorthand property for setting:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderImageSource</para>
        /// <para>&#160;&#160;BorderImageSlice</para>
        /// <para>&#160;&#160;BorderImageWidth</para>
        /// <para>&#160;&#160;BorderImageOutset</para>
        /// <para>&#160;&#160;BorderImageRepeat</para>
        /// <para>&#160;</para><br />
        /// <para>Omitted values are set to their default values.</para>
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the BorderImage* properties to construct beautiful scalable buttons!</para>
        /// </summary>
        public string BorderImage
        {
            set
            {
                Dictionary<Property, string> borderImageValues;
                if (this.parser.TryBorderImageValues(value, out borderImageValues))
                {
                    SetProperty(Property.BorderImage, borderImageValues[Property.BorderImage]);

                    this.BorderImageSource = borderImageValues[Property.BorderImageSource];
                    this.BorderImageSlice = borderImageValues[Property.BorderImageSlice];
                    this.BorderImageWidth = borderImageValues[Property.BorderImageWidth];
                    this.BorderImageOutset = borderImageValues[Property.BorderImageOutset];
                    this.BorderImageRepeat = borderImageValues[Property.BorderImageRepeat];
                }
            }
        }

        /// <summary>
        /// The BorderImageOutset property specifies the amount by which the border image area extends 
        /// beyond the border box.
        /// <para>&#160;</para><br />
        /// <para>Note: If the fourth value is omitted, it is the same as the second. If the third one is 
        /// also omitted, it is the same as the first. If the second one is also omitted, it is the same 
        /// as the first. Negative values are not allowed for any of the BorderImageOutset values.</para>
        /// </summary>
        public string BorderImageOutset { set { SetProperty(Property.BorderImageOutset, value); } }

        /// <summary>
        /// The BorderImageRepeat property specifies whether the image border should be repeated, rounded 
        /// or stretched.
        /// </summary>
        public string BorderImageRepeat { set { SetProperty(Property.BorderImageRepeat, value); } }

        /// <summary>
        /// The Border Image Slice property specifies the inward offsets of the image border.
        /// </summary>
        public string BorderImageSlice { set { SetProperty(Property.BorderImageSlice, value); } }

        /// <summary>
        /// The Border Image Source property specifies an image to be used, instead of the border styles given 
        /// by the BorderStyle properties.
        /// <para>&#160;</para><br />
        /// <para>Tip: If the value is "none", or if the image cannot be displayed, the border styles will be 
        /// used.</para>
        /// </summary>
        public string BorderImageSource
        {
            set
            {
                SetProperty(Property.BorderImageSource, value);
                LoadImage(Property.BorderImageSource);
            }
        }

        /// <summary>
        /// The BorderImageWidth property specifies the offsets that are used to divide the border image area 
        /// into nine parts. They represent the inward distances from the the top, right, bottom, and left sides 
        /// of the area.
        /// <para>&#160;</para><br />
        /// <para>Note: If the fourth value is omitted, it is the same as the second. If the third one is also 
        /// omitted, it is the same as the first. If the second one is also omitted, it is the same as the 
        /// first. Negative values are not allowed for any BorderImageWidth values.</para>
        /// </summary>
        public string BorderImageWidth { set { SetProperty(Property.BorderImageWidth, value); } }

        /// <summary>
        /// The BorderLeft shorthand property sets all the left border properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderLeftWidth</para>
        /// <para>&#160;&#160;BorderLeftStyle</para>
        /// <para>&#160;&#160;BorderLeftColor</para>
        /// <para>&#160;</para><br />
        /// <para>It does not matter if one of the values above are missing, e.g. BorderLeft = "solid #ff0000" is 
        /// allowed.</para>
        /// </summary>
        public string BorderLeft
        {
            set
            {
                Dictionary<string, string> borderLeftValues;
                if (this.parser.TryBorderEdgeValues(value, out borderLeftValues))
                {
                    SetProperty(Property.BorderLeft, borderLeftValues["borderEdge"]);

                    this.BorderLeftWidth = borderLeftValues["borderEdgeWidth"];
                    this.BorderLeftStyle = borderLeftValues["borderEdgeStyle"];
                    this.BorderLeftColor = borderLeftValues["borderEdgeColor"];
                }
            }
        }

        /// <summary>
        /// The BorderLeftColor property sets the color of an element's left border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderLeftColor property. An 
        /// element must have borders before you can change the color.</para>
        /// </summary>
        public string BorderLeftColor { set { SetProperty(Property.BorderLeftColor, value); } }

        /// <summary>
        /// The BorderLeftStyle property sets the style of an element's left border.
        /// </summary>
        public string BorderLeftStyle { set { SetProperty(Property.BorderLeftStyle, value); } }

        /// <summary>
        /// The BorderLeftWidth property sets the width of an element's left border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderLeftWidth property. An 
        /// element must have borders before you can change the width.</para>
        /// </summary>
        public string BorderLeftWidth { set { SetProperty(Property.BorderLeftWidth, value); } }

        /// <summary>
        /// The BorderRadius property is a shorthand property for setting the four Border*Radius 
        /// properties.
        /// <para>&#160;</para><br />
        /// <para>Note: The four values for each radii are given in the order top-left, top-right, 
        /// bottom-right, bottom-left. If bottom-left is omitted it is the same as top-right. If bottom-right 
        /// is omitted it is the same as top-left. If top-right is omitted it is the same as top-left.
        /// </summary>
        public string BorderRadius
        {
            set
            {
                Dictionary<Property, string> borderRadiusValues;
                if (this.parser.TryBorderRadiusValues(value, out borderRadiusValues))
                {
                    SetProperty(Property.BorderRadius, borderRadiusValues[Property.BorderRadius]);

                    this.BorderBottomLeftRadius = borderRadiusValues[Property.BorderBottomLeftRadius];
                    this.BorderBottomRightRadius = borderRadiusValues[Property.BorderBottomRightRadius];
                    this.BorderTopLeftRadius = borderRadiusValues[Property.BorderTopLeftRadius];
                    this.BorderTopRightRadius = borderRadiusValues[Property.BorderTopRightRadius];
                }
            }
        }

        /// <summary>
        /// The BorderRight shorthand property sets all the right border properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderRightWidth</para>
        /// <para>&#160;&#160;BorderRightStyle</para>
        /// <para>&#160;&#160;BorderRightColor</para>
        /// <para>&#160;</para><br />
        /// <para>It does not matter if one of the values above are missing, e.g. BorderRight = "solid #ff0000" is 
        /// allowed.</para>
        /// </summary>
        public string BorderRight
        {
            set
            {
                Dictionary<string, string> borderRightValues;
                if (this.parser.TryBorderEdgeValues(value, out borderRightValues))
                {
                    SetProperty(Property.BorderRight, borderRightValues["borderEdge"]);

                    this.BorderRightWidth = borderRightValues["borderEdgeWidth"];
                    this.BorderRightStyle = borderRightValues["borderEdgeStyle"];
                    this.BorderRightColor = borderRightValues["borderEdgeColor"];
                }
            }
        }

        /// <summary>
        /// The BorderRightColor property sets the color of an element's right border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderRightColor property. An 
        /// element must have borders before you can change the color.</para>
        /// </summary>
        public string BorderRightColor { set { SetProperty(Property.BorderRightColor, value); } }

        /// <summary>
        /// The BorderRightStyle property sets the style of an element's right border.
        /// </summary>
        public string BorderRightStyle { set { SetProperty(Property.BorderRightStyle, value); } }

        /// <summary>
        /// The BorderRightWidth property sets the width of an element's right border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderRightWidth property. An 
        /// element must have borders before you can change the width.</para>
        /// </summary>
        public string BorderRightWidth { set { SetProperty(Property.BorderRightWidth, value); } }

        /// <summary>
        /// The BorderSpacing property sets the distance between the borders of adjacent cells (only 
        /// for the "separated borders" model).
        /// </summary>
        public string BorderSpacing { set { SetProperty(Property.BorderSpacing, value); } }

        /// <summary>
        /// The BorderStyle property sets the style of an element's four borders. This property can 
        /// have from one to four values.
        /// </summary>
        public string BorderStyle { set { SetProperty(Property.BorderStyle, value); } }

        /// <summary>
        /// The BorderTop shorthand property sets all the top border properties in one declaration.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;BorderTopWidth</para>
        /// <para>&#160;&#160;BorderTopStyle</para> 
        /// <para>&#160;&#160;BorderTopColor</para>
        /// <para>&#160;</para><br />
        /// <para>If one of the values above are missing, e.g. BorderTop = "solid #ff0000", the default value for 
        /// the missing property will be inserted, if any.</para>
        /// </summary>
        public string BorderTop
        {
            set
            {
                Dictionary<string, string> borderTopValues;
                if (this.parser.TryBorderEdgeValues(value, out borderTopValues))
                {
                    SetProperty(Property.BorderTop, borderTopValues["borderEdge"]);

                    this.BorderTopWidth = borderTopValues["borderEdgeWidth"];
                    this.BorderTopStyle = borderTopValues["borderEdgeStyle"];
                    this.BorderTopColor = borderTopValues["borderEdgeColor"];
                }
            }
        }

        /// <summary>
        /// The BorderTopColor property sets the color of an element's top border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderTopColor property. An 
        /// element must have borders before you can change the color.</para>
        /// </summary>
        public string BorderTopColor { set { SetProperty(Property.BorderTopColor, value); } }

        /// <summary>
        /// The BorderTopLeftRadius property defines the shape of the border of the top-left corner. The 
        /// two length or percentage values define the radii of a quarter ellipse that defines the shape of the 
        /// corner of the outer border edge. If the second value is omitted it is copied from the first.
        /// <para>&#160;</para><br />
        /// <para>Note: If either length is zero, the corner will become square.</para>
        /// </summary>
        public string BorderTopLeftRadius { set { SetProperty(Property.BorderTopLeftRadius, value); } }

        /// <summary>
        /// The BorderTopRightRadius property defines the shape of the border of the top-right corner. The 
        /// two length or percentage values define the radii of a quarter ellipse that defines the shape of the 
        /// corner of the outer border edge. If the second value is omitted it is copied from the first.
        /// <para>&#160;</para><br />
        /// <para>Note: If either length is zero, the corner will become square.</para>
        /// </summary>
        public string BorderTopRightRadius { set { SetProperty(Property.BorderTopRightRadius, value); } }

        /// <summary>
        /// The BorderTopStyle property sets the style of an element's top border.
        /// </summary>
        public string BorderTopStyle { set { SetProperty(Property.BorderTopStyle, value); } }

        /// <summary>
        /// The BorderTopWidth property sets the width of an element's top border.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderTopWidth property. An 
        /// element must have borders before you can change the width.</para>
        /// </summary>
        public string BorderTopWidth { set { SetProperty(Property.BorderTopWidth, value); } }

        /// <summary>
        /// The BorderWidth property sets the width of an element's four borders. This property can have from 
        /// one to four values.
        /// <para>&#160;</para><br />
        /// <para>Note: Always declare the BorderStyle property before the BorderWidth property. An element 
        /// must have borders before you can change the color.</para>
        /// </summary>
        public string BorderWidth
        {
            set
            {
                Dictionary<Property, string> borderWidthValues;
                if (this.parser.TryBorderWidthValues(value, out borderWidthValues))
                {
                    SetProperty(Property.BorderTop, borderWidthValues[Property.BorderWidth]);

                    this.BorderTopWidth = borderWidthValues[Property.BorderTopWidth];
                    this.BorderLeftWidth = borderWidthValues[Property.BorderLeftWidth];
                    this.BorderBottomWidth = borderWidthValues[Property.BorderBottomWidth];
                    this.BorderRightWidth = borderWidthValues[Property.BorderRightWidth];
                }
            }
        }
    }
}
