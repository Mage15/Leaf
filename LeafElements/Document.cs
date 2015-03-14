/* 
    Copyright (C) 2015  Matthew Gefaller
    This file is part of LeafElements.

    LeafElements is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LeafElements is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LeafElements.  If not, see <http://www.gnu.org/licenses/>.
 */ 

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafElements
{
    class Document
    {
        public Dictionary<string, Page> Pages { get; private set; }
        public List<List<Page>> PageZIndex { get; set; }
        public Element FocusElement { get; set; }

        public Document()
        {
            Pages = new Dictionary<string, Page>();
            PageZIndex = new List<List<Page>>();
            FocusElement = null;
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            //TODO: Perform any checks needed


            foreach (Page page in Pages.Values)
            {
                if (page.Visible)
                {
                    page.Update(keyboardState, mouseState);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Page> pageList in PageZIndex)
            {
                foreach (Page page in pageList)
                {
                    if (page.Visible)
                    {
                        page.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
