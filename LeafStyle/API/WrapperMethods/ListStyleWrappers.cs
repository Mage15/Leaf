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
        public void ListStyle(BasicValuesState? listStyleState)
        {
            this.SetProperty<BasicValuesState>(Property.ListStyle, listStyleState);

            if (listStyleState == null)
            {
                ListStyleImage(null);
                ListStylePosition(null);
                ListStyleType(null);
            }
            else
            {
                ListStyleImage(default(ListStyleImageState));
                ListStylePosition(default(ListStylePositionState));
                ListStyleType(default(ListStyleTypeState));
            }
        }
        public void ListStyle(
            ListStyleImageState listStyleImageState,
            ListStylePositionState listStylePositionState,
            ListStyleTypeState listStyleTypeState
            )
        {
            this.SetProperty<BasicValuesState>(Property.ListStyle, BasicValuesState.UseValues);

            ListStyleImage(listStyleImageState);
            ListStylePosition(listStylePositionState);
            ListStyleType(listStyleTypeState);
        }
        public void ListStyle(
            PropertyString listStyleImageName,
            ListStylePositionState listStylePositionState,
            ListStyleTypeState listStyleTypeState
            )
        {
            this.SetProperty<BasicValuesState>(Property.ListStyle, BasicValuesState.UseValues);

            ListStyleImage(listStyleImageName);
            ListStylePosition(listStylePositionState);
            ListStyleType(listStyleTypeState);
        }

        public void ListStyleImage(ListStyleImageState? listStyleImageState)
        {
            this.SetProperty<ListStyleImageState>(Property.ListStyleImage, listStyleImageState);
        }
        public void ListStyleImage(PropertyString imageName)
        {
            this.SetProperty<ListStyleImageState>(Property.ListStyleImage, ListStyleImageState.Image, (object)imageName);
        }

        public void ListStylePosition(ListStylePositionState? listStylePositionState)
        {
            this.SetProperty<ListStylePositionState>(Property.ListStylePosition, listStylePositionState);
        }

        public void ListStyleType(ListStyleTypeState? listStyleTypeState)
        {
            this.SetProperty<ListStyleTypeState>(Property.ListStyleType, listStyleTypeState);
        }
    }
}
