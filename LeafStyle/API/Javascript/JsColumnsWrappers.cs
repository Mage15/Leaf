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
        /// The Columns property is a shorthand property for setting:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;ColumnWidth</para>
        /// <para>&#160;&#160;ColumnCount</para>
        /// <para>&#160;</para><br />
        /// </summary>
        public string Columns
        {
            set
            {
                Dictionary<Property, string> columnsValues;
                if (this.parser.TryColumns(value, out columnsValues))
                {
                    SetProperty(Property.Columns, columnsValues[Property.Columns]);

                    this.ColumnWidth = columnsValues[Property.ColumnWidth];
                    this.ColumnCount = columnsValues[Property.ColumnCount];
                }
            }
        }

        /// <summary>
        /// The ColumnCount property specifies the number of columns an element should be divided into.
        /// </summary>
        public string ColumnCount { set { SetProperty(Property.ColumnCount, value); } }

        /// <summary>
        /// The ColumnFill property specifies how to fill columns, balanced or not.
        /// </summary>
        public string ColumnFill { set { SetProperty(Property.ColumnFill, value); } }

        /// <summary>
        /// The ColumnGap property specifies the gap between the columns.
        /// </summary>
        public string ColumnGap { set { SetProperty(Property.ColumnGap, value); } }

        /// <summary>
        /// The ColumnRule property is a shorthand property for setting all the ColumnRule* properties.
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;ColumnRuleWidth</para>
        /// <para>&#160;&#160;ColumnRuleStyle</para>
        /// <para>&#160;&#160;ColumnRuleColor</para>
        /// <para>&#160;</para><br />
        /// </summary>
        public string ColumnRule
        {
            set
            {
                Dictionary<Property, string> columnRuleValues;
                if (this.parser.TryColumnRule(value, out columnRuleValues))
                {
                    SetProperty(Property.ColumnRule, columnRuleValues[Property.ColumnRule]);

                    this.ColumnRuleColor = columnRuleValues[Property.ColumnRuleColor];
                    this.ColumnRuleStyle = columnRuleValues[Property.ColumnRuleStyle];
                    this.ColumnRuleWidth = columnRuleValues[Property.ColumnRuleWidth];
                }
            }
        }

        /// <summary>
        /// The ColumnRuleColor property specifies the color of the rule between columns.
        /// </summary>
        public string ColumnRuleColor { set { SetProperty(Property.ColumnRuleColor, value); } }

        /// <summary>
        /// The ColumnRuleStyle property specifies the style of the rule between columns.
        /// </summary>
        public string ColumnRuleStyle { set { SetProperty(Property.ColumnRuleStyle, value); } }

        /// <summary>
        /// The ColumnRuleWidth property specifies the width of the rule between columns.
        /// </summary>
        public string ColumnRuleWidth { set { SetProperty(Property.ColumnRuleWidth, value); } }

        /// <summary>
        /// The ColumnSpan property specifies how many columns an element should span across.
        /// </summary>
        public string ColumnSpan { set { SetProperty(Property.ColumnSpan, value); } }

        /// <summary>
        /// The ColumnWidth property specifies the width of the columns.
        /// </summary>
        public string ColumnWidth { set { SetProperty(Property.ColumnWidth, value); } }
    }
}
