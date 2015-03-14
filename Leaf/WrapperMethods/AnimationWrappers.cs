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

using System;

namespace LeafStyle
{
    public partial class Style
    {
        public void Animation(BasicValuesState? animationState)
        {
            this.SetProperty<BasicValuesState>(Property.Animation, animationState);

            if (animationState == null)
            {
                this.AnimationName(null);
                this.AnimationDuration(null);
                this.AnimationTimingFunction(null);
                this.AnimationDelay(null);
                this.AnimationIterationCount(null);
                this.AnimationDirection(null);
                this.AnimationFillMode(null);
                this.AnimationPlayState(null);
            }
            else
            {
                this.AnimationName(default(AnimationNameState));
                this.AnimationDuration(default(BasicTimeState));
                this.AnimationTimingFunction(default(TimingFunctionState));
                this.AnimationDelay(default(BasicTimeState));
                this.AnimationIterationCount(default(AnimationIterationCountState));
                this.AnimationDirection(default(AnimationDirectionState));
                this.AnimationFillMode(default(AnimationFillModeState));
                this.AnimationPlayState(default(AnimationPlayStates));
            }

        }
        public void Animation(
            AnimationNameState animationNameState,
            int durationMilliseconds,
            TimingFunctionState animationTimingFunctionState,
            int delayMilliseconds,
            int iterationCount,
            AnimationDirectionState animationDirectionState,
            AnimationFillModeState animationFillModeState,
            AnimationPlayStates animationPlayStates
            )
        {
            this.SetProperty<BasicValuesState>(Property.Animation, BasicValuesState.UseValues);

            this.AnimationName(animationNameState);
            this.AnimationDuration(durationMilliseconds);
            this.AnimationTimingFunction(animationTimingFunctionState);
            this.AnimationDelay(delayMilliseconds);
            this.AnimationIterationCount(iterationCount);
            this.AnimationDirection(animationDirectionState);
            this.AnimationFillMode(animationFillModeState);
            this.AnimationPlayState(animationPlayStates);
        }

        public void AnimationDelay(BasicTimeState? animationDelayState)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDelay, animationDelayState);
        }
        public void AnimationDelay(int delayMilliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDelay, BasicTimeState.Time, (object)delayMilliseconds);
        }

        public void AnimationDirection(AnimationDirectionState? animationDirectionState)
        {
            this.SetProperty<AnimationDirectionState>(Property.AnimationDirection, animationDirectionState);
        }

        public void AnimationDuration(BasicTimeState? animationDurationState)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDuration, animationDurationState);
        }
        public void AnimationDuration(int durationMilliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDuration, BasicTimeState.Time, (object)durationMilliseconds);
        }

        public void AnimationFillMode(AnimationFillModeState? animationFillModeState)
        {
            this.SetProperty<AnimationFillModeState>(Property.AnimationFillMode, animationFillModeState);
        }

        public void AnimationIterationCount(AnimationIterationCountState? animationIterationCountState)
        {
            this.SetProperty<AnimationIterationCountState>(Property.AnimationIterationCount, animationIterationCountState);
        }
        public void AnimationIterationCount(int iterationCount)
        {
            this.SetProperty<AnimationIterationCountState>(
                Property.AnimationDelay,
                AnimationIterationCountState.Number,
                (object)iterationCount
                );
        }

        public void AnimationName(AnimationNameState? animationNameState)
        {
            this.SetProperty<AnimationNameState>(Property.AnimationName, animationNameState);
        }
        public void AnimationName(PropertyString name)
        {
            this.SetProperty<AnimationNameState>(Property.AnimationName, AnimationNameState.KeyFrameName, (object)name.StringValue);
        }

        public void AnimationPlayState(AnimationPlayStates? animationPlayStates)
        {
            this.SetProperty<AnimationPlayStates>(Property.AnimationPlayState, animationPlayStates);
        }

        public void AnimationTimingFunction(TimingFunctionState? animationTimingFunctionState)
        {
            this.SetProperty<TimingFunctionState>(Property.AnimationTimingFunction, animationTimingFunctionState);
        }

    }
}
