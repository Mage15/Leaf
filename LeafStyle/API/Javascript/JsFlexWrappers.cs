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
        /// The Flex property specifies the length of the item, relative to the rest of the flexible items inside the same container.
        /// It is a shorthand for:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;FlexGrow</para>
        /// <para>&#160;&#160;FlexShrink</para>
        /// <para>&#160;&#160;FlexBasis</para>
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the Flex property has no effect.</para>
        /// </summary>
        public string Flex
        {
            set
            {
                Dictionary<Property, string> flexValues;
                if (this.parser.TryFlex(value, out flexValues))
                {
                    SetProperty(Property.Flex, flexValues[Property.Flex]);

                    this.FlexGrow = flexValues[Property.FlexGrow];
                    this.FlexShrink = flexValues[Property.FlexShrink];
                    this.FlexBasis = flexValues[Property.FlexBasis];
                }
            }
        }

        /// <summary>
        /// The FlexBasis property specifies the initial length of a flexible item.
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the FlexBasis property has no effect.</para>
        /// </summary>
        public string FlexBasis { set { SetProperty(Property.FlexBasis, value); } }

        /// <summary>
        /// The FlexDirection property specifies the direction of the flexible items.
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the FlexDirection property has no effect.</para>
        /// </summary>
        public string FlexDirection { set { SetProperty(Property.FlexDirection, value); } }

        /// <summary>
        /// The FlexFlow property is a shorthand property for:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;FlexDirection</para>
        /// <para>&#160;&#160;FlexWrap</para>
        /// <para>&#160;</para><br />
        /// <para>&#160;</para><br />
        /// <para>Note: If the elements are not flexible items, the flex-flow property has no effect.</para>
        /// </summary>
        public string FlexFlow
        {
            set
            {
                Dictionary<Property, string> flexFlowValues;
                if (this.parser.TryFlexFlow(value, out flexFlowValues))
                {
                    SetProperty(Property.FlexFlow, flexFlowValues[Property.FlexFlow]);

                    this.FlexDirection = flexFlowValues[Property.FlexDirection];
                    this.FlexWrap = flexFlowValues[Property.FlexWrap];
                }
            }
        }

        /// <summary>
        /// The FlexGrow property specifies how much the item will grow relative to the rest of the flexible items inside the same container.
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the FlexGrow property has no effect.</para>
        /// </summary>
        public string FlexGrow { set { SetProperty(Property.FlexGrow, value); } }

        /// <summary>
        /// The FlexShrink property specifies how the item will shrink relative to the rest of the flexible items inside the same container.
        /// <para>&#160;</para><br />
        /// <para>Note: If the element is not a flexible item, the FlexShrink property has no effect.</para>
        /// </summary>
        public string FlexShrink { set { SetProperty(Property.FlexShrink, value); } }

        /// <summary>
        /// The FlexWrap property specifies whether the flexible items should wrap or not.
        /// <para>&#160;</para><br />
        /// <para>Note: If the elements are not flexible items, the FlexWrap property has no effect.</para>
        /// </summary>
        public string FlexWrap { set { SetProperty(Property.FlexWrap, value); } }
    }
}
