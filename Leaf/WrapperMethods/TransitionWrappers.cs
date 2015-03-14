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
        public void Transition(BasicValuesState? transitionState)
        {
            this.SetProperty<BasicValuesState>(Property.Transition, transitionState);

            this.TransitionDelay(default(BasicTimeState));
            this.TransitionDuration(default(BasicTimeState));
            this.TransitionProperty(default(TransitionPropertyState));
            this.TransitionTimingFunction(default(TimingFunctionState));
        }
        public void Transition(
            BasicValuesState? transitionState,
            BasicTimeState? transitionDelayState,
            BasicTimeState? transitionDurationState,
            TransitionPropertyState? transitionPropertyState,
            TimingFunctionState? timingFunctionState
            )
        {
            this.SetProperty<BasicValuesState>(Property.Transition, transitionState);

            this.TransitionDelay(transitionDelayState);
            this.TransitionDuration(transitionDurationState);
            this.TransitionProperty(transitionPropertyState);
            this.TransitionTimingFunction(timingFunctionState);
        }


        public void TransitionDelay(BasicTimeState? transitionDelayState)
        {
            this.SetProperty<BasicTimeState>(Property.TransitionDelay, transitionDelayState);
        }
        public void TransitionDelay(int milliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.TransitionDelay, BasicTimeState.Time, (object)milliseconds);
        }

        public void TransitionDuration(BasicTimeState? transitionDurationState)
        {
            this.SetProperty<BasicTimeState>(Property.TransitionDuration, transitionDurationState);
        }
        public void TransitionDuration(int milliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.TransitionDuration, BasicTimeState.Time, (object)milliseconds);
        }

        public void TransitionProperty(TransitionPropertyState? transitionPropertyState)
        {
            this.SetProperty<TransitionPropertyState>(Property.TransitionProperty, transitionPropertyState);
        }
        public void TransitionProperty(PropertyString propertyName)
        {
            this.SetProperty<TransitionPropertyState>(
                Property.TransitionProperty,
                TransitionPropertyState.Property,
                (object)propertyName.StringValue
                );
        }
        public void TransitionProperty(PropertyStringList propertyNames)
        {
            this.SetProperty<TransitionPropertyState>(
                Property.TransitionProperty,
                TransitionPropertyState.Property,
                (object)propertyNames.StringValues
                );
        }

        public void TransitionTimingFunction(TimingFunctionState? timingFunctionState)
        {
            this.SetProperty<TimingFunctionState>(Property.TransitionTimingFunction, timingFunctionState);
        }
    }
}
