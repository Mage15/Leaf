/*
Copyright (C) 2015 Matthew Gefaller
This file is part of LeafStyle.

LeafStyle is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

LeafStyle is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LeafStyle. If not, see <http://www.gnu.org/licenses/>.
*/

using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace LeafStyle
{
    public partial class Style
    {
        public void Columns(BasicValuesState? columnsState)
        {
            this.SetProperty<BasicValuesState>(Property.Columns, columnsState);

            if (columnsState == null)
            {
                this.ColumnCount(null);
                this.ColumnWidth(null);
            }
            else
            {
                this.ColumnCount(default(NumberAutoState));
                this.ColumnWidth(default(LengthAutoState));
            }
        }
        public void Columns(
            int columnCount,
            int columnWidth
            )
        {
            this.SetProperty<BasicValuesState>(Property.Columns, BasicValuesState.UseValues);

            this.ColumnCount(columnCount);
            this.ColumnWidth(columnWidth);
        }

        public void ColumnCount(NumberAutoState? columnCountState)
        {
            this.SetProperty<NumberAutoState>(Property.ColumnCount, columnCountState);
        }
        public void ColumnCount(int number)
        {
            this.SetProperty<NumberAutoState>(Property.ColumnCount, NumberAutoState.Number, (object)number);
        }

        public void ColumnFill(ColumnFillState? columnFillState)
        {
            this.SetProperty<ColumnFillState>(Property.ColumnFill, columnFillState);
        }

        public void ColumnGap(BasicSpacingState? columnGapState)
        {
            this.SetProperty<BasicSpacingState>(Property.ColumnGap, columnGapState);
        }
        public void ColumnGap(int length)
        {
            this.SetProperty<BasicSpacingState>(Property.ColumnGap, BasicSpacingState.Length, (object)length);
        }

        public void ColumnRule(BasicValuesState? columnRuleState)
        {
            this.SetProperty<BasicValuesState>(Property.ColumnRule, columnRuleState);

            if (columnRuleState == null)
            {
                this.ColumnRuleColor(null);
                this.ColumnRuleStyle(null);
                this.ColumnRuleWidth(null);
            }
            else
            {
                this.ColumnRuleColor(Microsoft.Xna.Framework.Color.Black);
                this.ColumnRuleStyle(default(BasicOutlineState));
                this.ColumnRuleWidth(default(BasicWidthState));
            }
        }
        public void ColumnRule(
            Microsoft.Xna.Framework.Color columnRuleColor,
            BasicOutlineState columnRuleStyle,
            int columnRuleWidth
            )
        {
            this.SetProperty<BasicValuesState>(Property.ColumnRule, BasicValuesState.UseValues);

            this.ColumnRuleColor(columnRuleColor);
            this.ColumnRuleStyle(columnRuleStyle);
            this.ColumnRuleWidth(columnRuleWidth);
        }

        public void ColumnRuleColor(BasicColorState? columnRuleColorState)
        {
            this.SetProperty<BasicColorState>(Property.ColumnRuleColor, columnRuleColorState);
        }
        public void ColumnRuleColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<BasicColorState>(Property.ColumnRuleColor, BasicColorState.Color, (object)color);
        }

        public void ColumnRuleStyle(BasicOutlineState? columnRuleStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.ColumnRuleStyle, columnRuleStyleState);
        }

        public void ColumnRuleWidth(BasicWidthState? columnRuleWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.ColumnRuleWidth, columnRuleWidthState);
        }
        public void ColumnRuleWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.ColumnRuleWidth, BasicWidthState.Length, (object)length);
        }

        public void ColumnSpan(ColumnSpanState? columnSpanState)
        {
            this.SetProperty<ColumnSpanState>(Property.ColumnSpan, columnSpanState);
        }

        public void ColumnWidth(LengthAutoState? columnWidth)
        {
            this.SetProperty<LengthAutoState>(Property.ColumnWidth, columnWidth);
        }
        public void ColumnWidth(int length)
        {
            this.SetProperty<LengthAutoState>(Property.ColumnWidth, LengthAutoState.Length, (object)length);
        }
    }
}
