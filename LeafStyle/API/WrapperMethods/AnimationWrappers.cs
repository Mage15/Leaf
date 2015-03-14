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
        /// <summary>
        /// The Animation method is a shorthand method for six of the Animation StyleProperty methods:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;AnimationName</para>
        /// <para>&#160;&#160;AnimationDuration</para>
        /// <para>&#160;&#160;AnimationTimingFunction</para>
        /// <para>&#160;&#160;AnimationDelay</para>
        /// <para>&#160;&#160;AnimationIterationCount</para>
        /// <para>&#160;&#160;AnimationDirection.</para>
        /// <para>&#160;</para><br />
        /// <para>Note: AnimationDuration default is 0, which will cause the animation to not play.</para>
        /// <para>Note: A null value will remove all six StyleProperties from storage.</para>
        /// <para>Note: This method will set all six properties to their default values.</para>
        /// </summary>
        /// <param name="animationState"></param>
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

        /// <summary>
        /// The Animation method is a shorthand method for six of the Animation StyleProperty methods:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;AnimationName</para>
        /// <para>&#160;&#160;AnimationDuration</para>
        /// <para>&#160;&#160;AnimationTimingFunction</para>
        /// <para>&#160;&#160;AnimationDelay</para>
        /// <para>&#160;&#160;AnimationIterationCount</para>
        /// <para>&#160;&#160;AnimationDirection.</para>
        /// <para>&#160;</para><br />
        /// <para>Note: An AnimationDuration of 0, which will cause the animation to not play.</para>
        /// </summary>
        /// <param name="animationState"></param>
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

        /// <summary>
        /// Sets the AnimationDelay to either Initial, Inherit, or to use the Time.
        /// </summary>
        /// <param name="animationDelayState"></param>
        public void AnimationDelay(BasicTimeState? animationDelayState)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDelay, animationDelayState);
        }

        /// <summary>
        /// Defines when the animation will start.
        /// <para>&#160;</para><br />
        /// <para>Tip: Negative values are allowed, a -200 makes the animation start at once, but starts 
        /// 200 milliseconds into the animation.</para>
        /// </summary>
        /// <param name="animationDelayState"></param>
        public void AnimationDelay(int delayMilliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDelay, BasicTimeState.Time, (object)delayMilliseconds);
        }

        /// <summary>
        /// Defines whether or not the animation should play in reverse on alternate cycles.
        /// <para>&#160;</para><br />
        /// <para>Note: If the animation is set to play only once, this property will have no effect.</para>
        /// </summary>
        public void AnimationDirection(AnimationDirectionState? animationDirectionState)
        {
            this.SetProperty<AnimationDirectionState>(Property.AnimationDirection, animationDirectionState);
        }

        /// <summary>
        /// Sets the AnimationDuration to either Initial, Inherit, or to use the Time.
        /// </summary>
        /// <param name="animationDurationState"></param>
        public void AnimationDuration(BasicTimeState? animationDurationState)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDuration, animationDurationState);
        }

        /// <summary>
        /// Defines how many milliseconds an animation takes to complete one cycle.
        /// </summary>
        /// <param name="animationDurationState"></param>
        public void AnimationDuration(int durationMilliseconds)
        {
            this.SetProperty<BasicTimeState>(Property.AnimationDuration, BasicTimeState.Time, (object)durationMilliseconds);
        }

        /// <summary>
        /// Specifies what StyleProperties will apply for the element when the animation is not playing (when it is 
        /// finished, or when it has a "delay").
        /// <para>&#160;</para><br />
        /// By default, the animations will not affect the element you are animating until the first keyframe is 
        /// "played", and then stops affecting it once the last keyframe has completed. The AnimationFillMode can 
        /// override this behavior. 
        /// </summary>
        /// <param name="animationFillModeState"></param>
        public void AnimationFillMode(AnimationFillModeState? animationFillModeState)
        {
            this.SetProperty<AnimationFillModeState>(Property.AnimationFillMode, animationFillModeState);
        }

        /// <summary>
        /// Defines how many times an animation should be played.
        /// </summary>
        /// <param name="animationIterationCountState"></param>
        public void AnimationIterationCount(AnimationIterationCountState? animationIterationCountState)
        {
            this.SetProperty<AnimationIterationCountState>(Property.AnimationIterationCount, animationIterationCountState);
        }
        
        /// <summary>
        /// The number of times an animation should be played.
        /// </summary>
        /// <param name="iterationCount"></param>
        public void AnimationIterationCount(int iterationCount)
        {
            this.SetProperty<AnimationIterationCountState>(
                Property.AnimationDelay,
                AnimationIterationCountState.Number,
                (object)iterationCount
                );
        }

        /// <summary>
        /// Specifies the name of the keyframe you want to bind to the selector
        /// </summary>
        /// <param name="animationNameState"></param>
        public void AnimationName(AnimationNameState? animationNameState)
        {
            this.SetProperty<AnimationNameState>(Property.AnimationName, animationNameState);
        }
        
        /// <summary>
        /// Specifies the name of the keyframe you want to bind to the selector
        /// </summary>
        /// <param name="name"></param>
        public void AnimationName(PropertyString name)
        {
            this.SetProperty<AnimationNameState>(Property.AnimationName, AnimationNameState.KeyFrameName, (object)name.StringValue);
        }

        /// <summary>
        /// Specifies whether the animation is running or paused.
        /// <para>&#160;</para><br />
        /// <para>Tip: You can use this method to pause an animation in the middle of a cycle.</para>
        /// </summary>
        public void AnimationPlayState(AnimationPlayStates? animationPlayStates)
        {
            this.SetProperty<AnimationPlayStates>(Property.AnimationPlayState, animationPlayStates);
        }

        /// <summary>
        /// Specifies the speed curve of the animation.
        /// <para>&#160;</para><br />
        /// <para>Note: The speed curve defines the amount of time an animation uses to change from one set of 
        /// StyleProperties to another. This speed curve is used to make the changes smoothly.</para>
        /// </summary>
        public void AnimationTimingFunction(TimingFunctionState? animationTimingFunctionState)
        {
            this.SetProperty<TimingFunctionState>(Property.AnimationTimingFunction, animationTimingFunctionState);
        }

    }
}