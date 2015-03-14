/* 
    Copyright (C) 2015 Matthew Gefaller
    This file is part of LeafStyle.

    LeafStyle is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LeafStyle is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LeafStyle.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace LeafStyle
{
    public partial class UIStyle
    {
        /// <summary>
        /// The Animation property is a shorthand property for six of the animation properties:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;AnimationName</para>
        /// <para>&#160;&#160;AnimationDuration</para>
        /// <para>&#160;&#160;AnimationTimingFunction</para>
        /// <para>&#160;&#160;AnimationDelay</para>
        /// <para>&#160;&#160;AnimationIterationCount</para>
        /// <para>&#160;&#160;AnimationDirection</para>
        /// <para>&#160;</para><br />
        /// <para>Note: Always specify the animationDuration property, otherwise the duration is 0, and will 
        /// never be played.</para>
        /// </summary>
        public string Animation
        {
            set
            {
                Dictionary<Property, string> animationValues;
                if (this.parser.TryAnimation(value, out animationValues))
                {
                    this.SetProperty(Property.Animation, animationValues[Property.Animation]);

                    this.AnimationName = animationValues[Property.AnimationName];
                    this.AnimationDuration = animationValues[Property.AnimationDuration];
                    this.AnimationTimingFunction = animationValues[Property.AnimationTimingFunction];
                    this.AnimationDelay = animationValues[Property.AnimationDelay];
                    this.AnimationIterationCount = animationValues[Property.AnimationIterationCount];
                    this.AnimationDirection = animationValues[Property.AnimationDirection];
                    this.AnimationFillMode = animationValues[Property.AnimationFillMode];
                    this.AnimationPlayState = animationValues[Property.AnimationPlayState];
                }
            }
        }

        /// <summary>
        /// <para>The AnimationDelay property defines when the animation will start.</para>
        /// <para>The value is defined in seconds (s) or milliseconds (ms).</para>
        /// <para>&#160;</para><br />
        /// <para>Tip: Negative values are allowed, -2s makes the animation start at once, but starts 2 seconds 
        /// into the animation.</para>
        /// </summary>
        public string AnimationDelay { set { SetProperty(Property.AnimationDelay, value); } }

        /// <summary>
        /// The AnimationDirection property defines whether or not the animation should play in reverse on alternate cycles.
        /// <para>&#160;</para><br />
        /// <para>Note: If the animation is set to play only once, this property will have no effect.</para>
        /// </summary>
        public string AnimationDirection { set { SetProperty(Property.AnimationDirection, value); } }

        /// <summary>
        /// The AnimationDuration property defines how many seconds or milliseconds an animation takes to 
        /// complete one cycle.
        /// </summary>
        public string AnimationDuration { set { SetProperty(Property.AnimationDuration, value); } }

        /// <summary>
        /// The AnimationFillMode property specifies what styles will apply for the element when the animation 
        /// is not playing (when it is finished, or when it has a "delay").
        /// <para>&#160;</para><br />
        /// <para>By default, animations will not affect the element you are animating until the first keyframe is 
        /// "played", and then stops affecting it once the last keyframe has completed. The AnimationFillMode 
        /// property can override this behavior.</para>
        /// </summary>
        public string AnimationFillMode { set { SetProperty(Property.AnimationFillMode, value); } }

        /// <summary>
        /// The AnimationIterationCount property defines how many times an animation should be played.
        /// </summary>
        public string AnimationIterationCount { set { SetProperty(Property.AnimationIterationCount, value); } }

        /// <summary>
        /// The AnimationName property specifies the name of the keyframe you want to bind to the selector.
        /// </summary>
        public string AnimationName { set { SetProperty(Property.AnimationName, value); } }

        /// <summary>
        /// The AnimationPlayState property specifies whether the animation is running or paused.
        /// <para>&#160;</para><br />
        /// <para>Tip: You can use this property to pause an animation in the middle of a cycle.</para>
        /// </summary>
        public string AnimationPlayState { set { SetProperty(Property.AnimationPlayState, value); } }

        /// <summary>
        /// The AnimationTimingFunction specifies the speed curve of the animation.
        /// <para>&#160;</para><br />
        /// <para>Note: The speed curve defines the amount of time an animation uses to change from one set of style 
        /// properties to another. This speed curve is used to make the changes smoothly.</para>
        /// </summary>
        public string AnimationTimingFunction { set { SetProperty(Property.AnimationTimingFunction, value); } }
    }
}
