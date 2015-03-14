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
    public class AnimationNameProperty : BasicStyleProperty<AnimationNameState>
    {
        public string Name { get; set; }

        public AnimationNameProperty()
            : base(
                    defaultState: default(AnimationNameState),
                    inherited: false,
                    animatable: false
            )
        {
            this.Name = "";

            this.StateValues = new Dictionary<string, AnimationNameState>()
				{
					{"none", AnimationNameState.None },
					{"keyframe", AnimationNameState.KeyFrameName },
					{"initial", AnimationNameState.Initial },
					{"inherit", AnimationNameState.Inherit }
				};
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value)) // Check if and set if StateValues key
            {
                return true;
            }
            else if (value != null) // If not StateValues key assume a name was provided
            {
                this.Name = value;
                this.CurrentState = AnimationNameState.KeyFrameName;

                return true;
            }

            // value was null
            return false;
        }
    }
}