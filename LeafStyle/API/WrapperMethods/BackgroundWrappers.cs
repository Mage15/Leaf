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
using Microsoft.Xna.Framework;

namespace MonogameUIStyle
{
    public partial class Style
    {
        public void Background(BasicValuesState? backgroundState)
        {
            this.SetProperty<BasicValuesState>(Property.Background, backgroundState);

            if (backgroundState == null)
            {
                this.BackgroundColor(null);
                this.BackgroundPosition(null);
                this.BackgroundSize(null);
                this.BackgroundRepeat(null);
                this.BackgroundOrigin(null);
                this.BackgroundClip(null);
                this.BackgroundAttachment(null);
                this.BackgroundImage(null);
            }
            else
            {
                this.BackgroundColor(default(ColorTransparentState));
                this.BackgroundPosition(default(BackgroundPositionState));
                this.BackgroundSize(default(BackgroundSizeState));
                this.BackgroundRepeat(default(BackgroundRepeatState));
                this.BackgroundOrigin(default(BackgroundOriginState));
                this.BackgroundClip(default(BackgroundClipState));
                this.BackgroundAttachment(default(BackgroundAttachmentState));
                this.BackgroundImage(default(BasicImageState));
            }
        }
        public void Background(
            Microsoft.Xna.Framework.Color bgColor,
            Vector2 bgPosition,
            Vector2 bgSize,
            BackgroundRepeatState backgroundRepeatState,
            BackgroundOriginState backgroundOriginState,
            BackgroundClipState backgroundClipState,
            BackgroundAttachmentState backgroundAttachmentState,
            PropertyString bgImageName
            )
        {
            this.SetProperty<BasicValuesState>(Property.Background, BasicValuesState.UseValues);

            this.BackgroundColor(bgColor);
            this.BackgroundPosition(bgPosition);
            this.BackgroundSize(bgSize);
            this.BackgroundRepeat(backgroundRepeatState);
            this.BackgroundOrigin(backgroundOriginState);
            this.BackgroundClip(backgroundClipState);
            this.BackgroundAttachment(backgroundAttachmentState);
            this.BackgroundImage(bgImageName);
        }

        public void BackgroundAttachment(BackgroundAttachmentState? backgroundAttachmentState)
        {
            this.SetProperty<BackgroundAttachmentState>(Property.BackgroundAttachment, backgroundAttachmentState);
        }

        public void BackgroundClip(BackgroundClipState? backgroundClipState)
        {
            this.SetProperty<BackgroundClipState>(Property.BackgroundClip, backgroundClipState);
        }

        public void BackgroundColor(ColorTransparentState? backgroundColorState)
        {
            this.SetProperty<ColorTransparentState>(Property.BackgroundColor, backgroundColorState);
        }
        public void BackgroundColor(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<ColorTransparentState>(Property.BackgroundColor, ColorTransparentState.Color, (object)color);
        }

        public void BackgroundImage(BasicImageState? backgroundImageState)
        {
            this.SetProperty<BasicImageState>(Property.BackgroundImage, backgroundImageState);
            this.LoadImage(Property.BackgroundImage);
        }
        public void BackgroundImage(PropertyString xnbTextureName)
        {
            this.SetProperty<BasicImageState>(Property.BackgroundImage, BasicImageState.Image, (object)xnbTextureName.StringValue);
        }

        public void BackgroundOrigin(BackgroundOriginState? backgroundOriginState)
        {
            this.SetProperty<BackgroundOriginState>(Property.BackgroundOrigin, backgroundOriginState);
        }

        public void BackgroundPosition(BackgroundPositionState? backgroundPositionState)
        {
            SetProperty<BackgroundPositionState>(Property.BackgroundPosition, backgroundPositionState);
        }
        public void BackgroundPosition(Point bgPosition)
        {
            SetProperty<BackgroundPositionState>(
                Property.BackgroundPosition,
                BackgroundPositionState.XY_Absolute,
                (object)bgPosition
                );
        }
        public void BackgroundPosition(Vector2 bgPosition)
        {
            SetProperty<BackgroundPositionState>
                (Property.BackgroundPosition,
                BackgroundPositionState.XY_Percent,
                (object)bgPosition
                );
        }

        public void BackgroundRepeat(BackgroundRepeatState? backgroundRepeatState)
        {
            this.SetProperty<BackgroundRepeatState>(Property.BackgroundRepeat, backgroundRepeatState);
        }

        public void BackgroundSize(BackgroundSizeState? backgroundSizeState)
        {
            SetProperty<BackgroundSizeState>(Property.BackgroundSize, backgroundSizeState);
        }
        public void BackgroundSize(Point bgSize)
        {
            SetProperty<BackgroundSizeState>(Property.BackgroundSize, BackgroundSizeState.Length, (object)bgSize);
        }
        public void BackgroundSize(Vector2 bgSize)
        {
            SetProperty<BackgroundSizeState>(Property.BackgroundSize, BackgroundSizeState.Percent, (object)bgSize);
        }
    }
}
