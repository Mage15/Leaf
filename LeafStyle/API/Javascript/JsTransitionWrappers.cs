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
        /// The Transition property is a shorthand property for the four transition properties:
        /// <para>&#160;</para><br />
        /// <para>&#160;&#160;TransitionProperty</para>
        /// <para>&#160;&#160;TransitionDuration</para>
        /// <para>&#160;&#160;TransitionTimingFunction</para>
        /// <para>&#160;&#160;TransitionDelay</para>
        /// <para>&#160;</para><br />
        /// <para>Note: Always specify the TransitionDuration property, otherwise the duration is 0, and the 
        /// transition will have no effect.</para>
        /// </summary>
        public string Transition
        {
            set
            {
                Dictionary<Property, string> transitionValues;
                if (this.parser.TryTransition(value, out transitionValues))
                {
                    SetProperty(Property.Transition, transitionValues[Property.Transition]);

                    this.TransitionDelay = transitionValues[Property.TransitionDelay];
                    this.TransitionDuration = transitionValues[Property.TransitionDuration];
                    this.TransitionProperty = transitionValues[Property.TransitionProperty];
                    this.TransitionTimingFunction = transitionValues[Property.TransitionTimingFunction];
                }
            }
        }

        /// <summary>
        /// The TransitionDelay property specifies when the transition effect will start. The TransitionDelay value 
        /// is defined in seconds (s) or milliseconds (ms).
        /// </summary>
        public string TransitionDelay { set { SetProperty(Property.TransitionDelay, value); } }

        /// <summary>
        /// The TransitionDuration property specifies how many seconds (s) or milliseconds (ms) a transition effect 
        /// takes to complete.
        /// </summary>
        public string TransitionDuration { set { SetProperty(Property.TransitionDuration, value); } }

        /// <summary>
        /// The TransitionProperty property specifies the name of the property the transition effect is for 
        /// (the transition effect will start when the specified property changes).
        /// <para>&#160;</para><br />
        /// <para>Tip: A transition effect could occur when a user hovers over an element.</para>
        /// <para>&#160;</para><br />
        /// <para>Note: Always specify the TransitionDuration property, otherwise the duration is 0, and the transition 
        /// will have no effect.</para>
        /// </summary>
        public string TransitionProperty { set { SetProperty(Property.TransitionProperty, value); } }

        /// <summary>
        /// The TransitionTimingFunction property specifies the speed curve of the transition effect. This property 
        /// allows a transition effect to change speed over its duration.
        /// </summary>
        public string TransitionTimingFunction { set { SetProperty(Property.TransitionTimingFunction, value); } }
    }
}
