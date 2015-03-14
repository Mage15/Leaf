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

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LeafStyle
{
    public class ImageStyleProperty<TState> : BasicStyleProperty<TState>
            where TState : struct, IConvertible
    {
        protected string ImageName { get; set; }
        public Texture2D Image { get; set; }

        public ImageStyleProperty(TState defaultState, bool inherited, bool animatable)
            : base(defaultState, inherited, animatable)
        {
            this.ImageName = "";
        }

        public virtual bool LoadImage(ContentManager contentManager)
        {
            try
            {
                this.Image = contentManager.Load<Texture2D>(this.ImageName);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public virtual bool LoadImage(ContentManager contentManager, string xnbTextureName)
        {
            this.ImageName = xnbTextureName;
            return this.LoadImage(contentManager);
        }
    }
}