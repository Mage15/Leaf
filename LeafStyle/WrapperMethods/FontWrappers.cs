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
        public void Font(FontState? fontState)
        {
            this.SetProperty<FontState>(Property.Font, fontState);

            if (fontState == null)
            {
                //this.FontFamily(null);
                this.FontSize(null);
                this.FontStyle(null);
                this.FontVariant(null);
                this.FontWeight(null);
                this.LineHeight(null);
            }
            else
            {
                //this.FontFamily(default(FontFamilyState));
                this.FontSize(default(FontSizeState));
                this.FontStyle(default(FontStyleState));
                this.FontVariant(default(FontVariantState));
                this.FontWeight(default(FontWeightState));
                this.LineHeight(default(LineHeightState));
            }
        }
        public void Font(
            FontSizeState fontSizeState,
            FontStyleState fontStyleState,
            FontVariantState fontVariantState,
            FontWeightState fontWeightState,
            LineHeightState lineHeightState
            )
        {
            this.FontSize(fontSizeState);
            this.FontStyle(fontStyleState);
            this.FontVariant(fontVariantState);
            this.FontWeight(fontWeightState);
            this.LineHeight(lineHeightState);
        }
        public void Font(
            int fontSizeLength,
            FontStyleState fontStyleState,
            FontVariantState fontVariantState,
            int fontWeightNumber,
            int lineHeightLength
            )
        {
            this.FontSize(fontSizeLength);
            this.FontStyle(fontStyleState);
            this.FontVariant(fontVariantState);
            this.FontWeight(fontWeightNumber);
            this.LineHeight(lineHeightLength);
        }

        //public void FontFace() { }

        //public void FontFamily() { }

        public void FontSize(FontSizeState? fontSizeState)
        {
            this.SetProperty<FontSizeState>(Property.FontSize, fontSizeState);
        }
        public void FontSize(int length)
        {
            this.SetProperty<FontSizeState>(Property.FontSize, FontSizeState.LengthAbsolute, (object)length);
        }
        public void FontSize(float length)
        {
            this.SetProperty<FontSizeState>(Property.FontSize, FontSizeState.LengthPercent, (object)length);
        }

        public void FontSizeAdjust(FontSizeAdjustState? fontSizeAdjustState)
        {
            this.SetProperty<FontSizeAdjustState>(Property.FontSizeAdjust, fontSizeAdjustState);
        }
        public void FontSizeAdjust(float number)
        {
            this.SetProperty<FontSizeAdjustState>(Property.FontSizeAdjust, FontSizeAdjustState.Number, (object)number);
        }

        public void FontStrecth(FontStretchState? fontStreatchState)
        {
            this.SetProperty<FontStretchState>(Property.FontStretch, fontStreatchState);
        }

        public void FontStyle(FontStyleState? fontStyleState)
        {
            this.SetProperty<FontStyleState>(Property.FontStyle, fontStyleState);
        }

        public void FontVariant(FontVariantState? fontVariantState)
        {
            this.SetProperty<FontVariantState>(Property.FontVariant, fontVariantState);
        }

        public void FontWeight(FontWeightState? fontWeightState)
        {
            this.SetProperty<FontWeightState>(Property.FontWeight, fontWeightState);
        }
        public void FontWeight(int number)
        {
            this.SetProperty<FontWeightState>(Property.FontWeight, FontWeightState.Number, (object)number);
        }
    }
}
