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

using System;

namespace MonogameUIStyle
{
    public partial class Style
    {
        public void Border(BasicValuesState? borderState)
        {
            this.SetProperty<BasicValuesState>(Property.Border, borderState);

            if (borderState == null)
            {
                //this.BorderWith(null);
                //this.BorderStyle(null);
                this.BorderColor(null);
            }
            else
            {
                //this.BorderWith(default(BasicWidthState));
                //this.BorderStyle(default(BasicOutlineState));
                this.BorderColor(default(ColorTransparentState));
            }
        }
        public void Border(
            BasicValuesState borderState,
            BasicWidthState borderWidthState,
            BasicOutlineState borderStyleState,
            ColorTransparentState borderColorState
            )
        {
            //this.BorderWidth(borderWidthState);
            //this.BorderStyle(borderStyleState);
            this.BorderColor(borderColorState);
        }
        public void Border(
            BasicValuesState borderState,
            int length,
            BasicOutlineState borderStyleState,
            Microsoft.Xna.Framework.Color color
            )
        {
            //this.BorderWidth(borderWidthState, length);
            //this.BorderStyle(borderStyleState);
            this.BorderColor(color);
        }

        public void BorderBottom(BasicValuesState? borderBottomState)
        {
            this.SetProperty<BasicValuesState>(Property.BorderBottom, borderBottomState);

            if (borderBottomState == null)
            {
                this.BorderBottomWidth(null);
                this.BorderBottomStyle(null);
                this.BorderBottomColor(null);
            }
            else
            {
                this.BorderBottomWidth(default(BasicWidthState));
                this.BorderBottomStyle(default(BasicOutlineState));
                this.BorderBottomColor(default(ColorTransparentState));
            }
        }
        public void BorderBottom(
            BasicValuesState borderBottomState,
            BasicWidthState borderBottomWidthState,
            BasicOutlineState borderBottomStyleState,
            ColorTransparentState borderBottomColorState
            )
        {
            this.BorderBottomWidth(borderBottomWidthState);
            this.BorderBottomStyle(borderBottomStyleState);
            this.BorderBottomColor(borderBottomColorState);
        }
        public void BorderBottom(
            BasicValuesState borderBottomState,
            int length,
            BasicOutlineState borderBottomStyleState,
            Microsoft.Xna.Framework.Color color
            )
        {
            this.BorderBottomWidth(length);
            this.BorderBottomStyle(borderBottomStyleState);
            this.BorderBottomColor(color);
        }

        public void BorderBottomColor(ColorTransparentState? borderBottomColorState)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderBottomColor, borderBottomColorState);
        }
        public void BorderBottomColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderBottomColor, ColorTransparentState.Color, (object)color);
        }

        public void BorderBottomLeftRadius(BasicRadiusState? borderBottomLeftRadiusState)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomLeftRadius, borderBottomLeftRadiusState);
        }
        public void BorderBottomLeftRadius(int length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomLeftRadius, BasicRadiusState.LengthAbsolute, (object)length);
        }
        public void BorderBottomLeftRadius(float length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomLeftRadius, BasicRadiusState.LengthPercent, (object)length);
        }

        public void BorderBottomRightRadius(BasicRadiusState? borderBottomRightRadiusState)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomRightRadius, borderBottomRightRadiusState);
        }
        public void BorderBottomRightRadius(int length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomRightRadius, BasicRadiusState.LengthAbsolute, (object)length);
        }
        public void BorderBottomRightRadius(float length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderBottomRightRadius, BasicRadiusState.LengthPercent, (object)length);
        }

        public void BorderBottomStyle(BasicOutlineState? borderBottomStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.BorderBottomStyle, borderBottomStyleState);
        }

        public void BorderBottomWidth(BasicWidthState? borderBottomWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.BorderBottomWidth, borderBottomWidthState);
        }
        public void BorderBottomWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.BorderBottomWidth, BasicWidthState.Length, (object)length);
        }

        public void BorderCollapse(BasicOutlineState? borderCollapseState)
        {
            this.SetProperty<BasicOutlineState>(Property.BorderCollapse, borderCollapseState);
        }

        public void BorderColor(ColorTransparentState? colorTransparentState)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderColor, colorTransparentState);
        }
        public void BorderColor(Microsoft.Xna.Framework.Color color)
        {
            this.BorderColor(color, color, color, color);
        }
        public void BorderColor(
            Microsoft.Xna.Framework.Color topColor,
            Microsoft.Xna.Framework.Color leftColor,
            Microsoft.Xna.Framework.Color bottomColor,
            Microsoft.Xna.Framework.Color rightColor)
        {
            this.BorderTopColor(topColor);
            this.BorderLeftColor(leftColor);
            this.BorderBottomColor(bottomColor);
            this.BorderRightColor(rightColor);
        }

        public void BorderImage()
        {

        }

        public void BorderImageOutset()
        {

        }

        public void BorderImageRepeat()
        {

        }

        public void BorderImageSlice()
        {

        }

        public void BorderImageSource()
        {

        }

        public void BorderImageWidth()
        {

        }

        public void BorderLeft(BasicValuesState? borderLeftState)
        {
            this.SetProperty<BasicValuesState>(Property.BorderLeft, borderLeftState);

            if (borderLeftState == null)
            {
                this.BorderLeftWidth(null);
                this.BorderLeftStyle(null);
                this.BorderLeftColor(null);
            }
            else
            {
                this.BorderLeftWidth(default(BasicWidthState));
                this.BorderLeftStyle(default(BasicOutlineState));
                this.BorderLeftColor(default(ColorTransparentState));
            }
        }
        public void BorderLeft(
            BasicValuesState borderLeftState,
            BasicWidthState borderLeftWidthState,
            BasicOutlineState borderLeftStyleState,
            ColorTransparentState borderLeftColorState
            )
        {
            this.BorderLeftWidth(borderLeftWidthState);
            this.BorderLeftStyle(borderLeftStyleState);
            this.BorderLeftColor(borderLeftColorState);
        }
        public void BorderLeft(
            BasicValuesState borderLeftState,
            int length,
            BasicOutlineState borderLeftStyleState,
            Microsoft.Xna.Framework.Color color
            )
        {
            this.BorderLeftWidth(length);
            this.BorderLeftStyle(borderLeftStyleState);
            this.BorderLeftColor(color);
        }

        public void BorderLeftColor(ColorTransparentState? borderLeftColorState)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderLeftColor, borderLeftColorState);
        }
        public void BorderLeftColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderLeftColor, ColorTransparentState.Color, (object)color);
        }

        public void BorderLeftStyle(BasicOutlineState? borderLeftStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.BorderLeftStyle, borderLeftStyleState);
        }

        public void BorderLeftWidth(BasicWidthState? borderLeftWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.BorderLeftWidth, borderLeftWidthState);
        }
        public void BorderLeftWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.BorderLeftWidth, BasicWidthState.Length, (object)length);
        }

        public void BorderRadius()
        {

        }

        public void BorderRight(BasicValuesState? borderRightState)
        {
            this.SetProperty<BasicValuesState>(Property.BorderRight, borderRightState);

            if (borderRightState == null)
            {
                this.BorderRightWidth(null);
                this.BorderRightStyle(null);
                this.BorderRightColor(null);
            }
            else
            {
                this.BorderRightWidth(default(BasicWidthState));
                this.BorderRightStyle(default(BasicOutlineState));
                this.BorderRightColor(default(ColorTransparentState));
            }
        }
        public void BorderRight(
            BasicValuesState borderRightState,
            BasicWidthState borderRightWidthState,
            BasicOutlineState borderRightStyleState,
            ColorTransparentState borderRightColorState
            )
        {
            this.BorderRightWidth(borderRightWidthState);
            this.BorderRightStyle(borderRightStyleState);
            this.BorderRightColor(borderRightColorState);
        }
        public void BorderRight(
            BasicValuesState borderRightState,
            int length,
            BasicOutlineState borderRightStyleState,
            Microsoft.Xna.Framework.Color color
            )
        {
            this.BorderRightWidth(length);
            this.BorderRightStyle(borderRightStyleState);
            this.BorderRightColor(color);
        }

        public void BorderRightColor(ColorTransparentState? borderRightColorState)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderRightColor, borderRightColorState);
        }
        public void BorderRightColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderRightColor, ColorTransparentState.Color, (object)color);
        }

        public void BorderRightStyle(BasicOutlineState? borderRightStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.BorderRightStyle, borderRightStyleState);
        }

        public void BorderRightWidth(BasicWidthState? borderRightWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.BorderRightWidth, borderRightWidthState);
        }
        public void BorderRightWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.BorderRightWidth, BasicWidthState.Length, (object)length);
        }

        public void BorderSpacing()
        {

        }

        public void BorderStyle()
        {

        }

        public void BorderTop(BasicValuesState? borderTopState)
        {
            this.SetProperty<BasicValuesState>(Property.BorderTop, borderTopState);

            if (borderTopState == null)
            {
                this.BorderTopWidth(null);
                this.BorderTopStyle(null);
                this.BorderTopColor(null);
            }
            else
            {
                this.BorderTopWidth(default(BasicWidthState));
                this.BorderTopStyle(default(BasicOutlineState));
                this.BorderTopColor(default(ColorTransparentState));
            }
        }
        public void BorderTop(
            BasicValuesState borderTopState,
            BasicWidthState borderTopWidthState,
            BasicOutlineState borderTopStyleState,
            ColorTransparentState borderTopColorState
            )
        {
            this.BorderTopWidth(borderTopWidthState);
            this.BorderTopStyle(borderTopStyleState);
            this.BorderTopColor(borderTopColorState);
        }
        public void BorderTop(
            BasicValuesState borderTopState,
            int length,
            BasicOutlineState borderTopStyleState,
            Microsoft.Xna.Framework.Color color
            )
        {
            this.BorderTopWidth(length);
            this.BorderTopStyle(borderTopStyleState);
            this.BorderTopColor(color);
        }

        public void BorderTopColor(ColorTransparentState? borderTopColorState)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderTopColor, borderTopColorState);
        }
        public void BorderTopColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<ColorTransparentState>(Property.BorderTopColor, ColorTransparentState.Color, (object)color);
        }

        public void BorderTopLeftRadius(BasicRadiusState? borderTopLeftRadiusState)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopLeftRadius, borderTopLeftRadiusState);
        }
        public void BorderTopLeftRadius(int length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopLeftRadius, BasicRadiusState.LengthAbsolute, (object)length);
        }
        public void BorderTopLeftRadius(float length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopLeftRadius, BasicRadiusState.LengthPercent, (object)length);
        }

        public void BorderTopRightRadius(BasicRadiusState? borderTopRightRadiusState)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopRightRadius, borderTopRightRadiusState);
        }
        public void BorderTopRightRadius(int length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopRightRadius, BasicRadiusState.LengthAbsolute, (object)length);
        }
        public void BorderTopRightRadius(float length)
        {
            this.SetProperty<BasicRadiusState>(Property.BorderTopRightRadius, BasicRadiusState.LengthPercent, (object)length);
        }

        public void BorderTopStyle(BasicOutlineState? borderTopStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.BorderTopStyle, borderTopStyleState);
        }

        public void BorderTopWidth(BasicWidthState? borderTopWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.BorderTopWidth, borderTopWidthState);
        }
        public void BorderTopWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.BorderTopWidth, BasicWidthState.Length, (object)length);
        }

        public void BorderWidth(BasicWidthState? borderWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.BorderWidth, borderWidthState);
        }
        public void BorderWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.BorderWidth, BasicWidthState.Length, (object)length);
        }

    }
}
