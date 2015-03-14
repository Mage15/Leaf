/* 
    Copyright (C) 2015 Matthew Gefaller
    This file is part of Leaf.

    Leaf is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Leaf is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Leaf.  If not, see <http://www.gnu.org/licenses/>.
 */ 

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    class Page : LeafElement
    {
        #region Properties

        public Dictionary<string, LeafElement> ChildElements { get; private set; }
        public List<List<LeafElement>> ElementZIndex { get; set; }

        #endregion

        #region Constructor

        public Page(ContentManager contentManager)
            : base(contentManager)
        {
            ChildElements = new Dictionary<string, LeafElement>();
            ElementZIndex = new List<List<LeafElement>>();
        }

        #endregion

        #region Events

        public event EventHandler OnAfterPrint; //Raised after the document is printed
        public event EventHandler OnBeforePrint;//Raised before the document is printed
        public event EventHandler OnBeforeUnload;//Raised before the document is unloaded
        public event EventHandler OnError;      //Raised when an error occur
        public event EventHandler OnHasChange;  //Raised when the document has changed
        public event EventHandler OnLoad;       //Raised after the page is finished loading
        public event EventHandler OnMessage;    //Raised when the message is triggered
        public event EventHandler OnOffline;    //Raised when the document goes offline
        public event EventHandler OnOnline;     //Raised when the document comes online
        public event EventHandler OnPageHide;   //Raised when the page's Visible property is changed to false
        public event EventHandler OnPageShow;   //Raised when the pages's Visible property is changed to true
        public event EventHandler OnPopState;   //Raised when the pages's history changes
        public event EventHandler OnRedo;       //Raised when the document performs a redo
        public event EventHandler OnResize;     //Raised when the browser window is resized
        public event EventHandler OnStorage;    //Raised when a Web Storage area is updated
        public event EventHandler OnUndo;       //Raised when the document performs an undo
        public event EventHandler OnUnload;     //Raised once a page has unloaded (or the browser window has been closed)

        #endregion

        #region Methods

        public override void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (this.Visible)
            {
                foreach (LeafElement element in ChildElements.Values)
                {
                    if (element.Visible)
                    {
                        element.Update(keyboardState, mouseState);
                    }
                }


                //TODO: Perform any event checks needed



                base.Update(keyboardState, mouseState);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Visible)
            {
                base.Draw(spriteBatch);

                foreach (List<LeafElement> elemList in ElementZIndex)
                {
                    foreach (LeafElement element in elemList)
                    {
                        if (element.Visible)
                        {
                            element.Draw(spriteBatch);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
