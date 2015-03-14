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

using System.Collections.Generic;

namespace LeafStyle
{
    internal class BasicTimeProperty : BasicStyleProperty<BasicTimeState>
    {
        // Negative values are allowed, -2s makes the animation start at once, 
        // but starts 2 seconds into the animation.
        public int Milliseconds { get; set; }

        public BasicTimeProperty()
            : base(
                defaultState: default(BasicTimeState),
                inherited: false,
                animatable: false
                )
        {
            this.Milliseconds = 0;

            StateValues = new Dictionary<string, BasicTimeState>()
                {
                    {"time", BasicTimeState.Time},
                    {"inherit", BasicTimeState.Inherit},
                    {"initial", BasicTimeState.Initial}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null && value.Contains("ms"))
            {
                int time;
                if (int.TryParse(value.Remove(value.IndexOf("ms")), out time))
                {
                    this.Milliseconds = time;
                    this.CurrentState = BasicTimeState.Time;

                    return true;
                }
            }
            else if (value.Contains("s"))
            {
                int time;
                if (int.TryParse(value.Remove(value.IndexOf("s")), out time))
                {
                    // Convert to milliseconds
                    this.Milliseconds = time * 1000;
                    this.CurrentState = BasicTimeState.Time;

                    return true;
                }
            }

            // Could not be parsed
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(int))
                {
                    this.Milliseconds = (int)value;
                    this.CurrentState = BasicTimeState.Time;

                    return true;
                }
            }

            return false;
        }
    }
}