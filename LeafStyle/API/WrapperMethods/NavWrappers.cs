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
        public void NavDown(BasicNavState? navDownState)
        {
            this.SetProperty<BasicNavState>(Property.NavDown, navDownState);
        }
        public void NavDown(NavValuesContainer navValues)
        {
            // Use default(BasicNavState) because Current State will be reset by object when setting value
            this.SetProperty<BasicNavState>(Property.NavDown, default(BasicNavState), (object)navValues);
        }

        public void NavIndex(NumberAutoState? navIndexState) 
        {
            this.SetProperty<NumberAutoState>(Property.NavIndex, navIndexState);
        }
        public void NavIndex(int number)
        {
            this.SetProperty<NumberAutoState>(Property.NavIndex, NumberAutoState.Number, (object)number);
        }

        public void NavLeft(BasicNavState? navLeftState)
        {
            this.SetProperty<BasicNavState>(Property.NavLeft, navLeftState);
        }
        public void NavLeft(NavValuesContainer navValues)
        {
            // Use default(BasicNavState) because Current State will be reset by object when setting value
            this.SetProperty<BasicNavState>(Property.NavLeft, default(BasicNavState), (object)navValues);
        }

        public void NavRight(BasicNavState? navRightState)
        {
            this.SetProperty<BasicNavState>(Property.NavRight, navRightState);
        }
        public void NavRight(NavValuesContainer navValues)
        {
            // Use default(BasicNavState) because Current State will be reset by object when setting value
            this.SetProperty<BasicNavState>(Property.NavRight, default(BasicNavState), (object)navValues);
        }

        public void NavUp(BasicNavState? navUpState)
        {
            this.SetProperty<BasicNavState>(Property.NavUp, navUpState);
        }
        public void NavUp(NavValuesContainer navValues)
        {
            // Use default(BasicNavState) because Current State will be reset by object when setting value
            this.SetProperty<BasicNavState>(Property.NavUp, default(BasicNavState), (object)navValues);
        }
    }
}
