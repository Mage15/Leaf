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
        public void Outline(BasicValuesState? outlineState)
        {
            this.SetProperty<BasicValuesState>(Property.Outline, outlineState);

            if (outlineState == null)
            {
                this.OutlineColor(null);
                this.OutlineStyle(null);
                this.OutlineWidth(null);
            }
            else
            {
                this.OutlineColor(default(OutlineColorState));
                this.OutlineStyle(default(BasicOutlineState));
                this.OutlineWidth(default(BasicWidthState));
            }
        }
        public void Outline(
            OutlineColorState outlineColorState,
            BasicOutlineState outlineStyleState,
            BasicWidthState outlineWidthState
            )
        {
            this.SetProperty<BasicValuesState>(Property.Outline, BasicValuesState.UseValues);

            this.OutlineColor(outlineColorState);
            this.OutlineStyle(outlineStyleState);
            this.OutlineWidth(outlineWidthState);
        }
        public void Outline(
            Microsoft.Xna.Framework.Color color,
            BasicOutlineState outlineStyleState,
            int length
            )
        {
            this.SetProperty<BasicValuesState>(Property.Outline, BasicValuesState.UseValues);

            this.OutlineColor(color);
            this.OutlineStyle(outlineStyleState);
            this.OutlineWidth(length);
        }

        public void OutlineColor(OutlineColorState? outlineColorState)
        {
            this.SetProperty<OutlineColorState>(Property.OutlineColor, outlineColorState);
        }
        public void OutlineColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<OutlineColorState>(Property.OutlineColor, OutlineColorState.Color, (object)color);
        }

        public void OutlineOffset() { }

        public void OutlineStyle(BasicOutlineState? outlineStyleState)
        {
            this.SetProperty<BasicOutlineState>(Property.OutlineStyle, outlineStyleState);
        }

        public void OutlineWidth(BasicWidthState? outlineWidthState)
        {
            this.SetProperty<BasicWidthState>(Property.OutlineWidth, outlineWidthState);
        }
        public void OutlineWidth(int length)
        {
            this.SetProperty<BasicWidthState>(Property.OutlineWidth, BasicWidthState.Length, (object)length);
        }
    }
}
