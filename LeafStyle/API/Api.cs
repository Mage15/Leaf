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
using System.Linq;
using System.Collections.Generic;

namespace LeafStyle
{
    public partial class UIStyle
    {
        public StyleProperty GetProperty(Property property)
        {
            return (StyleProperties.Keys.Contains(property)) ? StyleProperties[property] : null;
        }
        
        /// <summary>
        /// Retrieves all the properties that currently contain a value
        /// </summary>
        public List<Property> GetCurrentProperties()
        {
            return StyleProperties.Keys.ToList();
        }

        /// <summary>
        /// Retrieves all the style property objects that are currently set
        /// </summary>
        public List<StyleProperty> GetCurrentPropertyObjects()
        {
            return StyleProperties.Values.ToList();
        }

        /// <summary>
        /// Attempts to retrieve the state of the property specified
        /// </summary>
        public TState GetCurrentState<TState>(Property property)
            where TState : struct, IConvertible
        {
            return ((BasicStyleProperty<TState>)StyleProperties[property]).CurrentState;
        }

        /// <summary>
        /// Attempts to retrieve the state of the property specified
        /// </summary>
        public bool TryGetCurrentState<TState>(Property property, out TState state)
            where TState : struct, IConvertible
        {
            if (StyleProperties.ContainsKey(property))
            {
                state = ((BasicStyleProperty<TState>)StyleProperties[property]).CurrentState;
                return true;
            }
            else
            {
                state = default(TState);
                return false;
            }
        }

        /// <summary>
        /// Clears out all style properties and their current states
        /// </summary>
        public void ClearStyle()
        {
            this.StyleProperties.Clear();
        }
    }
}
