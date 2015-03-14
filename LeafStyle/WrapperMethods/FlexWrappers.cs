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
        public void Flex(BasicValuesState? flexState)
        {
            this.SetProperty<BasicValuesState>(Property.Flex, flexState);

            if (flexState == null)
            {
                this.FlexBasis(null);
                this.FlexGrow(null);
                this.FlexShrink(null);
            }
            else
            {
                this.FlexBasis(default(LengthPercentAutoState));
                this.FlexGrow(default(BasicNumberState));
                this.FlexShrink(default(BasicNumberState));
            }
        }
        public void Flex(
            LengthPercentAutoState flexBasisState,
            BasicNumberState flexGrowNumber,
            BasicNumberState flexShrinkNumber
            )
        {
            this.SetProperty<BasicValuesState>(Property.Flex, BasicValuesState.UseValues);

            this.FlexBasis(flexBasisState);
            this.FlexGrow(flexGrowNumber);
            this.FlexShrink(flexShrinkNumber);
        }
        public void Flex(
            int flexBasisLength,
            int flexGrowNumber,
            int flexShrinkNumber
            )
        {
            this.SetProperty<BasicValuesState>(Property.Flex, BasicValuesState.UseValues);

            this.FlexBasis(flexBasisLength);
            this.FlexGrow(flexGrowNumber);
            this.FlexShrink(flexShrinkNumber);
        }
        public void Flex(
            float flexBasisLength,
            int flexGrowNumber,
            int flexShrinkNumber
            )
        {
            this.SetProperty<BasicValuesState>(Property.Flex, BasicValuesState.UseValues);

            this.FlexBasis(flexBasisLength);
            this.FlexGrow(flexGrowNumber);
            this.FlexShrink(flexShrinkNumber);
        }

        public void FlexBasis(LengthPercentAutoState? flexBasisState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.FlexBasis, flexBasisState);
        }
        public void FlexBasis(int length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.FlexBasis, LengthPercentAutoState.LengthAbsolute, (object)length);
        }
        public void FlexBasis(float length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.FlexBasis, LengthPercentAutoState.LengthPercent, (object)length);
        }

        public void FlexDirection(FlexDirectionState? flexDirectionState)
        {
            this.SetProperty<FlexDirectionState>(Property.FlexDirection, flexDirectionState);
        }

        public void FlexFlow(BasicValuesState? flexFlowState)
        {
            this.SetProperty<BasicValuesState>(Property.FlexFlow, flexFlowState);

            if (flexFlowState == null)
            {
                this.FlexDirection(null);
                this.FlexWrap(null);
            }
            else
            {
                this.FlexDirection(default(FlexDirectionState));
                this.FlexWrap(default(FlexWrapState));
            }
        }
        public void FlexFlow(
            FlexDirectionState flexDirectionState,
            FlexWrapState flexWrapState
            )
        {
            this.SetProperty<BasicValuesState>(Property.FlexFlow, BasicValuesState.UseValues);

            this.FlexDirection(flexDirectionState);
            this.FlexWrap(flexWrapState);
        }

        public void FlexGrow(BasicNumberState? flexGrowState)
        {
            this.SetProperty<BasicNumberState>(Property.FlexGrow, flexGrowState);
        }
        public void FlexGrow(int number)
        {
            this.SetProperty<BasicNumberState>(Property.FlexGrow, BasicNumberState.Number, (object)number);
        }

        public void FlexShrink(BasicNumberState? flexShrinkState)
        {
            this.SetProperty<BasicNumberState>(Property.FlexShrink, flexShrinkState);
        }
        public void FlexShrink(int number)
        {
            this.SetProperty<BasicNumberState>(Property.FlexShrink, BasicNumberState.Number, (object)number);
        }

        public void FlexWrap(FlexWrapState? flexWrapState)
        {
            this.SetProperty<FlexWrapState>(Property.FlexWrap, flexWrapState);
        }
    }
}
