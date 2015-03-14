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
using System.Collections.Generic;

namespace LeafStyle
{
    public class BasicStyleProperty<TState> : StyleProperty
            where TState : struct, IConvertible
    {
        protected Dictionary<string, TState> StateValues;
        public Type ValueType { get; private set; }

        public virtual TState CurrentState { get; set; }
        public TState DefaultState { get; private set; }
        public TState Initial { get { return GetInitialValue(); } }

        public BasicStyleProperty(TState defaultState, bool inherited, bool animatable)
        {
            this.CurrentState = this.DefaultState = defaultState;
            this.Inherited = this.Inherit = inherited;
            this.Animatable = animatable;
            this.ValueType = typeof(TState);
        }

        protected virtual TState GetInitialValue()
        {
            return this.DefaultState;
        }

        public override bool TrySetStateValue(string value)
        {
            if (value != null)
            {
                if (this.StateValues.ContainsKey(value))
                {
                    this.CurrentState = this.StateValues[value];
                    return true;
                }
            }

            this.CurrentState = default(TState);
            return false;
        }

        /************* Used for Abondoned API ****************/
        //public override Type GetTypeOfValues()
        //{
        //    return this.ValueType;
        //}

        //public override bool TrySetCurrentState<TState>(TState currentState)
        //{
        //    if (typeof(TState) == this.ValueType)
        //    {
        //        this.CurrentState = (dynamic)currentState;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override bool TrySetValue(object value) { return false; }

        //public override bool TrySetValues(object[] values) { return false; }
        /*****************************************************/
    }
}