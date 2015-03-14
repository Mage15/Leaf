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
        /// The AlignContent property aligns the flexible container's items when the items do not use all 
        /// available space on the vertical-axis.
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the JustifyContent property to align the items on the horizontal-axis.</para>
        /// <para>Note: There must be multiple lines for this property to have any effect.</para> 
        /// </summary>
        public string AlignContent { set { this.SetProperty(Property.AlignContent, value); } }

        /// <summary>
        /// The AlignItems property specifies the default alignment for items inside the flexible container.
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the AlignSelf property of each item to override the AlignItems property. </para>
        /// </summary>
        public string AlignItems { set { this.SetProperty(Property.AlignItems, value); } }

        /// <summary>
        /// The AlignSelf property specifies the alignment for the selected item inside the flexible container.
        /// <para>&#160;</para><br />
        /// <para>Note: The AlignSelf property overrides the flexible container's AlignItems property.</para>
        /// </summary>
        public string AlignSelf { set { this.SetProperty(Property.AlignSelf, value); } }

        /// <summary>
        /// The BackfaceVisibility property defines whether or not an element should be visible when not facing the screen.
        /// <para>This property is useful when an element is rotated, and you do not want to see its backside.</para>
        /// </summary>
        public string BackfaceVisibility { set { SetProperty(Property.BackfaceVisibility, value); } }

        /// <summary>
        /// For absolutely positioned elements, the Bottom property sets the bottom edge of an element to the bottom edge of its 
        /// containing element. For relatively positioned elements, the Bottom property sets the bottom edge of an element to 
        /// a unit to the bottom to its normal position.
        /// <para>&#160;</para><br />
        /// <para>Note: If Position = "static", the Bottom property has no effect.</para>
        /// </summary>
        public string Bottom { set { SetProperty(Property.Bottom, value); } }

        /// <summary>
        /// The BoxShadow property attaches one or more drop-shadows to the box. The property is a list of 
        /// shadows, each specified by 2-4 length values, an optional color, and an optional inset keyword. 
        /// Omitted lengths are 0. 
        /// </summary>
        public string BoxShadow { set { SetProperty(Property.BoxShadow, value); } }

        /// <summary>
        /// The BoxSizing property allows you to define certain elements to fit an area in a certain way.
        /// <para>&#160;</para><br />
        /// <para>Example: If you want two bordered boxes side by side, it can be achieved through setting 
        /// BoxSizing to "border-box". This will render the box with the specified width and height, and place 
        /// the border and padding inside the box.</para>
        /// </summary>
        public string BoxSizing { set { SetProperty(Property.BoxSizing, value); } }

        /// <summary>
        /// The CaptionSide property specifies the placement of a table caption.
        /// </summary>
        public string CaptionSide { set { SetProperty(Property.CaptionSide, value); } }

        /// <summary>
        /// The Clear property specifies which side(s) of an element other floating elements are not allowed.
        /// </summary>
        public string Clear { set { SetProperty(Property.Clear, value); } }

        /// <summary>
        /// The Clip property lets you specify a rectangle to clip an absolutely positioned element. The 
        /// rectangle is specified as four coordinates, all from the top-left corner of the element to be clipped.
        /// <para>&#160;</para><br />
        /// <para>Example: Clip="rect(0px,50px,50px,0px)".</para>
        /// </summary>
        public string Clip { set { SetProperty(Property.Clip, value); } }

        /// <summary>
        /// The Color property specifies the color of text.
        /// </summary>
        public string Color { set { SetProperty(Property.Color, value); } }

        /// <summary>
        /// The cursor property specifies the type of cursor to be displayed when pointing on an element.
        /// </summary>
        public string Cursor
        {
            set
            {
                SetProperty(Property.Cursor, value);
                LoadImage(Property.Cursor);
            }
        }

        /// <summary>
        /// The Direction property specifies the text direction/writing direction.
        /// <para>&#160;</para><br />
        /// <para>Tip: Use this property together with the UnicodeBidi property to set or return whether the text should be 
        /// overridden to support multiple languages in the same document.</para>
        /// </summary>
        public string Direction { set { SetProperty(Property.Direction, value); } }

        /// <summary>
        /// The Display property specifies the type of box used for an element.
        /// </summary>
        public string Display { set { SetProperty(Property.Display, value); } }

        /// <summary>
        /// The EmptyCells property sets whether or not to display borders and background on empty cells in a table (only for 
        /// the "separated borders" model).
        /// </summary>
        public string EmptyCells { set { SetProperty(Property.EmptyCells, value); } }
        
        /// <summary>
        /// The Float property specifies whether or not a box (an element) should be floating.
        /// <para>&#160;</para><br />
        /// <para>Note: Absolutely positioned elements ignore the Float property!</para>
        /// </summary>
        public string Float { set { SetProperty(Property.Float, value); } }

        /// <summary>
        /// The HangingPunctuation property specifies whether a punctuation mark may be placed outside the line box at the 
        /// start or at the end of a full line of text.
        /// </summary>
        public string HangingPunctuation { set { SetProperty(Property.HangingPunctuation, value); } }

        /// <summary>
        /// The Height property sets the height of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: The Height property does not include padding, borders, or margins; it sets the height of the area 
        /// inside the padding, border, and margin of the element!</para>
        /// <para>&#160;</para><br />
        /// <para>Note: The MinHeight and MaxHeight properties override the Height property.</para>
        /// </summary>
        public string Height { set { SetProperty(Property.Height, value); } }

        /// <summary>
        /// The Icon property provides the author the ability to style an element with an iconic equivalent.
        /// <para>&#160;</para><br />
        /// <para>Note: An element's icon is not used unless the Content property is set to the value "icon"!</para>
        /// </summary>
        public string Icon
        {
            set
            {
                SetProperty(Property.Icon, value);
                LoadImage(Property.Icon);
            }
        }

        /// <summary>
        /// The JustifyContent property aligns the flexible container's items when the items do not use all available space 
        /// on the main-axis (horizontally).
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the AlignContent property to align the items on the cross-axis (vertically).</para>
        /// </summary>
        public string JustifyContent { set { SetProperty(Property.JustifyContent, value); } }

        /// <summary>
        /// With the Keyframes property, you can create animations. The animation is created by gradually changing from one 
        /// set of styles to another. During the animation, you can change the set of styles many times. Specify when the 
        /// change will happen in percent, or use the keywords "from" and "to", which is the same as 0% and 100% respectively.
        /// 0% being the beginning of the animation, 100% being when the animation is complete.
        /// <para>&#160;</para><br />
        /// <para>Note: Use the Animation properties to control the appearance of the animation, and also to bind the animation 
        /// to selectors.</para>
        /// </summary>
        public string Keyframes { set { SetProperty(Property.Keyframes, value); } }

        /// <summary>
        /// For absolutely positioned elements, the Left property sets the left edge of an element to the left edge of its 
        /// containing element. For relatively positioned elements, the Left property sets the left edge of an element to 
        /// a unit to the left to its normal position.
        /// <para>&#160;</para><br />
        /// <para>Note: If Position = "static", the Left property has no effect.</para>
        /// </summary>
        public string Left { set { SetProperty(Property.Left, value); } }

        /// <summary>
        /// The LetterSpacing property increases or decreases the space between characters in a text.
        /// </summary>
        public string LetterSpacing { set { SetProperty(Property.LetterSpacing, value); } }

        /// <summary>
        /// The LineHeight property specifies the line height.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are not allowed.</para>
        /// </summary>
        public string LineHeight { set { SetProperty(Property.LineHeight, value); } }
        
        /// <summary>
        /// The MaxHeight property is used to set the maximum height of an element. This prevents the value of 
        /// the Height property from becoming larger than MaxHeight.
        /// <para>&#160;</para><br />
        /// <para>Note: The value of the MaxHeight property can override the Height property. </para>
        /// </summary>
        public string MaxHeight { set { SetProperty(Property.MaxHeight, value); } }

        /// <summary>
        /// The MaxWidth property is used to set the maximum width of an element. This prevents the value of 
        /// the Width property from becoming larger than MaxWidth.
        /// <para>&#160;</para><br />
        /// <para>Note: The value of the MaxWidth property can override the Width property. </para>
        /// </summary>
        public string MaxWidth { set { SetProperty(Property.MaxWidth, value); } }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        public string Media { set { SetProperty(Property.Media, value); } }

        /// <summary>
        /// The MinHeight property is used to set the minimum height of an element. This prevents the value 
        /// of the Height property from becoming smaller than MinHeight.
        /// <para>&#160;</para><br />
        /// <para>Note: The value of the MinHeight property can override both the MaxHeight property 
        /// and the Height property.</para>
        /// </summary>
        public string MinHeight { set { SetProperty(Property.MinHeight, value); } }

        /// <summary>
        /// The MinWidth property is used to set the minimum width of an element. This prevents the value of 
        /// the Width property from becoming smaller than MinWidth.
        /// <para>&#160;</para><br />
        /// <para>Note: The value of the MinWidth property can override both the MaxWidth property and 
        /// the Width property.</para>
        /// </summary>
        public string MinWidth { set { SetProperty(Property.MinWidth, value); } }

        /// <summary>
        /// The NavDown property specifies where to navigate focus when the "arrow down" key is pressed while 
        /// this object currently has focus.
        /// </summary>
        public string NavDown { set { SetProperty(Property.NavDown, value); } }

        /// <summary>
        /// The NavIndex property specifies the sequential navigation order ("tabbing order") for an element.
        /// </summary>
        public string NavIndex { set { SetProperty(Property.NavIndex, value); } }

        /// <summary>
        /// The NavLeft property specifies where to navigate focus when the "arrow left" key is pressed while 
        /// this object currently has focus.
        /// </summary>
        public string NavLeft { set { SetProperty(Property.NavLeft, value); } }

        /// <summary>
        /// The NavRight property specifies where to navigate focus when the "arrow right" key is pressed while 
        /// this object currently has focus.
        /// </summary>
        public string NavRight { set { SetProperty(Property.NavRight, value); } }

        /// <summary>
        /// The NavUp property specifies where to navigate focus when the "arrow up" key is pressed while 
        /// this object currently has focus.
        /// </summary>
        public string NavUp { set { SetProperty(Property.NavUp, value); } }

        /// <summary>
        /// The Opacity property sets the opacity level for an element. The opacity level describes the 
        /// transparency level, where 1 is not transparant, 0.5 is 50% see through, and 0 is completely 
        /// transparent.
        /// </summary>
        public string Opacity { set { SetProperty(Property.Opacity, value); } }

        /// <summary>
        /// The Order property specifies the order of a flexible item relative to the rest of the flexible 
        /// items inside the same container.
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the Order property has no effect.</para>
        /// </summary>
        public string Order { set { SetProperty(Property.Order, value); } }

        /// <summary>
        /// The Overflow property specifies what happens if the content overflows an element's box.
        /// </summary>
        public string Overflow { set { SetProperty(Property.Overflow, value); } }

        /// <summary>
        /// The OverflowX property specifies what to do with the left/right edges of the content - if it 
        /// overflows the element's content area.
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the OverflowY property to determine clipping at the top and bottom edges.</para>
        /// </summary>
        public string OverflowX { set { SetProperty(Property.OverflowX, value); } }

        /// <summary>
        /// The OverflowY property specifies what to do with the top/bottom edges of the content - if it 
        /// overflows the element's content area.
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the OverflowX property to determine clipping at the left and right edges.</para>
        /// </summary>
        public string OverflowY { set { SetProperty(Property.OverflowY, value); } }

        /// <summary>
        /// The PageBreakAfter property sets whether a page break should occur AFTER a specified element.
        /// <para>&#160;</para><br />
        /// <para>Note: You cannot use this property on an empty 'div' or on absolutely positioned
        /// elements.</para> 
        /// </summary>
        public string PageBreakAfter { set { SetProperty(Property.PageBreakAfter, value); } }

        /// <summary>
        /// The PageBreakBefore property sets whether a page break should occur BEFORE a specified element.
        /// <para>&#160;</para><br />
        /// <para>Note: You cannot use this property on an empty 'div' or on absolutely positioned elements.</para>
        /// </summary>
        public string PageBreakBefore { set { SetProperty(Property.PageBreakBefore, value); } }

        /// <summary>
        /// The PageBreakInside property sets whether a page break is allowed inside a specified element.
        /// <para>&#160;</para><br />
        /// <para>Note: You cannot use this property on absolutely positioned elements.</para>
        /// </summary>
        public string PageBreakInside { set { SetProperty(Property.PageBreakInside, value); } }

        /// <summary>
        /// The Perspective property defines how many pixels a 3D element is placed from the view. This
        /// property allows you to change the perspective on how 3D elements are viewed. When defining 
        /// the perspective property for an element, it is the CHILD elements that get the perspective 
        /// view, NOT the element itself.
        /// <para>&#160;</para><br />
        /// <para>Note: The perspective property only affects 3D transformed elements!</para>
        /// <para>&#160;</para><br />
        /// <para>Tip: Use this property together with the PerspectiveOrigin property, which allows you 
        /// to change the bottom position of 3D elements.</para>
        /// </summary>
        public string Perspective { set { SetProperty(Property.Perspective, value); } }

        /// <summary>
        /// The PerspectiveOrigin property defines where a 3D element is based in the x- and the y-axis. 
        /// This property allows you to change the bottom position of 3D elements. When defining the 
        /// PerspectiveOrigin property for an element, it is the CHILD elements that are positioned, NOT 
        /// the element itself.
        /// <para>&#160;</para><br />
        /// <para>Note: This property must be used together with the Perspective property, and only affects 
        /// 3D transformed elements!</para>
        /// </summary>
        public string PerspectiveOrigin { set { SetProperty(Property.PerspectiveOrigin, value); } }

        /// <summary>
        /// The Position property specifies the type of positioning method used for an element (static,
        /// relative, absolute or fixed).
        /// </summary>
        public string Position { set { SetProperty(Property.Position, value); } }

        /// <summary>
        /// The Quotes property sets the type of quotation marks for quotations.
        /// </summary>
        public string Quotes { set { SetProperty(Property.Quotes, value); } }

        /// <summary>
        /// The Resize property specifies whether or not an element is resizable by the user.
        /// <para>&#160;</para><br />
        /// <para>Note: The Resize property applies to elements whose computed overflow value is 
        /// something other than "visible".</para>
        /// </summary>
        public string Resize { set { SetProperty(Property.Resize, value); } }

        /// <summary>
        /// For absolutely positioned elements, the Right property sets the right edge of an element to the right edge of its 
        /// containing element. For relatively positioned elements, the Right property sets the right edge of an element to 
        /// a unit to the right to its normal position.
        /// <para>&#160;</para><br />
        /// <para>Note: If Position = "static", the Right property has no effect.</para>
        /// </summary>
        public string Right { set { SetProperty(Property.Right, value); } }

        /// <summary>
        /// The TabSize property specifies the length of the space used for the tab character.
        /// </summary>
        public string TabSize { set { SetProperty(Property.TabSize, value); } }

        /// <summary>
        /// The TableLayout property sets the table layout algorithm to be used for a table.
        /// </summary>
        public string TableLayout { set { SetProperty(Property.TableLayout, value); } }

        /// <summary>
        /// For absolutely positioned elements, the Top property sets the top edge of an element to the top edge of its 
        /// containing element. For relatively positioned elements, the Top property sets the top edge of an element to 
        /// a unit to the top to its normal position.
        /// <para>&#160;</para><br />
        /// <para>Note: If Position = "static", the Top property has no effect. </para>
        /// </summary>
        public string Top { set { SetProperty(Property.Top, value); } }

        /// <summary>
        /// The Transform property applies a 2D or 3D transformation to an element. This property allows you 
        /// to rotate, scale, move, skew, etc., elements.
        /// </summary>
        public string Transform { set { SetProperty(Property.Transform, value); } }

        /// <summary>
        /// The TransformOrigin property allows you to change the position on transformed elements. 2D 
        /// transformed element can change the x- and y-axis of the element. 3D transformed element can also 
        /// change the z-axis of the element.
        /// <para>&#160;</para><br />
        /// <para>Note: This property must be used together with the Transform property.</para>
        /// </summary>
        public string TransformOrigin { set { SetProperty(Property.TransformOrigin, value); } }

        /// <summary>
        /// The TransformStyle property specifies how nested elements are rendered in 3D space.
        /// <para>&#160;</para><br />
        /// <para>Note: This property must be used together with the Transform property.</para>
        /// </summary>
        public string TransformStyle { set { SetProperty(Property.TransformStyle, value); } }

        /// <summary>
        /// The UnicodeBidi property is used together with the Direction property to set or return whether 
        /// the text should be overridden to support multiple languages in the same document.
        /// </summary>
        public string UnicodeBidi { set { SetProperty(Property.UnicodeBidi, value); } }

        /// <summary>
        /// The VerticalAlign property sets the vertical alignment of an element.
        /// </summary>
        public string VerticalAlign { set { SetProperty(Property.VerticalAlign, value); } }

        /// <summary>
        /// The Visibility property specifies whether or not an element is visible. 
        /// <para>&#160;</para><br />
        /// <para>Tip: Even invisible elements take up space on the page. Use the Display property to create 
        /// invisible elements that do not take up space!</para>
        /// </summary>
        public string Visibility { set { SetProperty(Property.Visibility, value); } }

        /// <summary>
        /// The WhiteSpace property specifies how white space inside an element is handled.
        /// </summary>
        public string WhiteSpace { set { SetProperty(Property.WhiteSpace, value); } }

        /// <summary>
        /// The Width property sets the width of an element.
        /// <para>&#160;</para><br />
        /// <para>Note: The Width property does not include padding, borders, or margins; it sets the width of 
        /// the area inside the padding, border, and margin of the element!</para>
        /// <para>&#160;</para><br />
        /// <para>Note: The MinWidth and MaxWidth properties override width.</para>
        /// </summary>
        public string Width { set { SetProperty(Property.Width, value); } }

        /// <summary>
        /// The WordBreak property specifies line breaking rules for non-CJK scripts.
        /// <para>&#160;</para><br />
        /// <para>Tip: CJK scripts are Chinese, Japanese and Korean ("CJK") scripts.</para>
        /// </summary>
        public string WordBreak { set { SetProperty(Property.WordBreak, value); } }

        /// <summary>
        /// The WordSpacing property increases or decreases the white space between words.
        /// <para>&#160;</para><br />
        /// <para>Note: Negative values are allowed.</para>
        /// </summary>
        public string WordSpacing { set { SetProperty(Property.WordSpacing, value); } }

        /// <summary>
        /// The WordWrap property allows long words to be able to be broken and wrap onto the next line.
        /// </summary>
        public string WordWrap { set { SetProperty(Property.WordWrap, value); } }

        /// <summary>
        /// The ZIndex property specifies the stack order of an element. An element with greater stack order is 
        /// always in front of an element with a lower stack order.
        /// <para>&#160;</para><br />
        /// <para>Note: ZIndex only works on positioned elements (position = "absolute", position = "relative", or 
        /// position = "fixed").</para>
        /// </summary>
        public string ZIndex { set { SetProperty(Property.ZIndex, value); } }
    }
}
