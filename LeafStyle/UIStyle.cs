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
        private ContentManager ContentManager; //Used for loading images
        private Dictionary<Property, StyleProperty> StyleProperties;
        private Parser parser;


        public UIStyle(ContentManager contentManager)
        {
            Initialize(contentManager);
        }


        private void Initialize(ContentManager contentManager)
        {
            this.ContentManager = contentManager;
            this.StyleProperties = new Dictionary<Property, StyleProperty>();
            parser = new Parser();
        }

        // If the StyleProperties dictionary doesn't contain the specified Property key then add Styleproperty object,
        // if it does contain the key remove current StyleProperty object and add the new one.
        private void AddOrOverwrite(Property key, StyleProperty Property)
        {
            if (Property != null)
            {
                if (this.StyleProperties.ContainsKey(key))
                {
                    this.StyleProperties[key] = Property;
                }
                else
                {
                    this.StyleProperties.Add(key, Property);
                }
            }
        }

        // Attempts a call on the properties LoadImage method
        private bool LoadImage(Property property)
        {
            try
            {
                return ((dynamic)StyleProperties[property]).LoadImage(ContentManager);
            }
            catch
            {
                return false;
            }
        }

        // When given a Property and a value a new instance of the associated Property type is created,
        // the value is assigned to the new instance, and it is stored.
        private void SetProperty(Property property, string value)
        {
            if (value != null)
            {
                Type newType;
                if (Value.TryGetPropertyType(property, out newType)) // If type is returned
                {
                    try
                    {
                        // Create new instance of type
                        var newProperty = Activator.CreateInstance(newType);

                        ((StyleProperty)newProperty).TrySetStateValue(value);
                        this.AddOrOverwrite(property, (StyleProperty)newProperty);
                    }
                    catch { }
                }
            }
        }

    }
}
