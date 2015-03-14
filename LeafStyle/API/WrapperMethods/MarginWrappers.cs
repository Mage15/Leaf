/*
Copyright (C) 2014 Matthew Gefaller
This file is part of MonoGameUIStyle.

MonoGameUIStyle is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MonoGameUIStyle is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MonoGameUIStyle. If not, see <http://www.gnu.org/licenses/>.
*/

using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace MonogameUIStyle
{
    public partial class Style
    {
        public void Margin(LengthPercentAutoState? marginStates)
        {
            if (marginStates == null)
            {
                this.SetProperty<BasicValuesState>(Property.Margin, null);

                this.MarginBottom(null);
                this.MarginLeft(null);
                this.MarginRight(null);
                this.MarginTop(null);
            }
            else
            {
                this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

                this.MarginBottom(marginStates);
                this.MarginLeft(marginStates);
                this.MarginRight(marginStates);
                this.MarginTop(marginStates);
            }
        }
        public void Margin(int length)
        {
            this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

            this.MarginBottom(length);
            this.MarginLeft(length);
            this.MarginRight(length);
            this.MarginTop(length);
        }
        public void Margin(float length)
        {
            this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

            this.MarginBottom(length);
            this.MarginLeft(length);
            this.MarginRight(length);
            this.MarginTop(length);
        }

        public void Margin(
            LengthPercentAutoState topMarginStates, 
            LengthPercentAutoState bottomMarginStates,
            LengthPercentAutoState leftMarginStates,
            LengthPercentAutoState rightMarginStates)
        {
            this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

            this.MarginBottom(bottomMarginStates);
            this.MarginLeft(leftMarginStates);
            this.MarginRight(rightMarginStates);
            this.MarginTop(topMarginStates);
        }
        public void Margin(
            int topLength, 
            int bottomLength, 
            int leftLength,
            int rightLength)
        {
            this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

            this.MarginBottom(bottomLength);
            this.MarginLeft(leftLength);
            this.MarginRight(rightLength);
            this.MarginTop(topLength);
        }
        public void Margin(
            float topLength,
            float bottomLength,
            float leftLength,
            float rightLength)
        {
            this.SetProperty<BasicValuesState>(Property.Margin, BasicValuesState.UseValues);

            this.MarginBottom(bottomLength);
            this.MarginLeft(leftLength);
            this.MarginRight(rightLength);
            this.MarginTop(topLength);
        }

        public void MarginBottom(LengthPercentAutoState? marginBottomState) 
        {
            this.SetProperty<LengthPercentAutoState>(Property.MarginBottom, marginBottomState);
        }
        public void MarginBottom(int length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginBottom, 
                LengthPercentAutoState.LengthAbsolute, 
                (object)length);
        }
        public void MarginBottom(float length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginBottom,
                LengthPercentAutoState.LengthPercent,
                (object)length);
        }

        public void MarginLeft(LengthPercentAutoState? marginLeftState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.MarginLeft, marginLeftState);
        }
        public void MarginLeft(int length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginLeft,
                LengthPercentAutoState.LengthAbsolute,
                (object)length);
        }
        public void MarginLeft(float length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginLeft,
                LengthPercentAutoState.LengthPercent,
                (object)length);
        }

        public void MarginRight(LengthPercentAutoState? marginRightState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.MarginRight, marginRightState);
        }
        public void MarginRight(int length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginRight,
                LengthPercentAutoState.LengthAbsolute,
                (object)length);
        }
        public void MarginRight(float length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginRight,
                LengthPercentAutoState.LengthPercent,
                (object)length);
        }

        public void MarginTop(LengthPercentAutoState? marginTopState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.MarginTop, marginTopState);
        }
        public void MarginTop(int length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginTop,
                LengthPercentAutoState.LengthAbsolute,
                (object)length);
        }
        public void MarginTop(float length)
        {
            this.SetProperty<LengthPercentAutoState>(
                Property.MarginTop,
                LengthPercentAutoState.LengthPercent,
                (object)length);
        }
    }
}
