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
    internal class BasicNavProperty : BasicStyleProperty<BasicNavState>
    {
        public string Id { get; set; }
        public string TargetName { get; set; }

        public BasicNavProperty()
            : base(
                defaultState: default(BasicNavState),
                inherited: false,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, BasicNavState>()
                {
                    {"auto", BasicNavState.Auto},
                    {"id", BasicNavState.Id},
                    {"target", BasicNavState.TargetName},
                    {"initial", BasicNavState.Initial},
                    {"inherit", BasicNavState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))  //Check and set if key for StateValues
            {
                return true;
            }
            else if (value != null)
            {
                if (value.Contains("#"))  // If not key for StateValues try parse as Id
                {
                    this.Id = value.Remove(value.IndexOf("#"), 1);
                    this.CurrentState = BasicNavState.Id;

                    return true;
                }
                else  // Assume TargetName was provided
                {
                    this.TargetName = value;
                    this.CurrentState = BasicNavState.TargetName;

                    return true;
                }
            }

            // Value is null return false
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(NavValuesContainer))
                {
                    if (!((NavValuesContainer)value).Id.IsEmpty()) // If Id is not empty
                    {
                        this.Id = ((NavValuesContainer)value).Id.StringValue;
                        this.CurrentState = BasicNavState.Id;

                        return true;
                    }
                    else if (!((NavValuesContainer)value).TargetName.IsEmpty()) // If TargetName is not empty
                    {
                        this.TargetName = ((NavValuesContainer)value).TargetName.StringValue;
                        this.CurrentState = BasicNavState.TargetName;

                        return true;
                    }
                }
            }

            return false;
        }
    }
}