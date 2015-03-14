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
    public class AlignSelfProperty : BasicStyleProperty<AlignSelfState>
    {
        public AlignSelfProperty()
            : base(
                    defaultState: default(AlignSelfState),
                    inherited: false,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, AlignSelfState>()
				{
					{"auto", AlignSelfState.Auto },
					{"stretch", AlignSelfState.Stretch },
					{"center", AlignSelfState.Center },
					{"flex-start", AlignSelfState.FlexStart },
					{"flex-end", AlignSelfState.FlexEnd },
					{"baseline", AlignSelfState.Baseline },
					{"initial", AlignSelfState.Initial },
					{"inherit", AlignSelfState.Inherit }
				};
        }
    }
}