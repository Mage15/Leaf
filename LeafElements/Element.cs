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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using LeafStyle;
using Microsoft.Xna.Framework.Content;

namespace LeafElements
{
    public enum DirectionKind { Up, Down, Left, Right };
    public enum DropKind { Copy, Move, Link };
    public enum Language { English };

    public class Element
    {
        #region Objects

        private ContentManager Content;
        public Style Style;

        #endregion

        #region Properties

        public Point Position { get; set; }         //Specifies the location of the top left corner of the element
        public int Height { get; set; }             //Specifies the height of the element
        public int Width { get; set; }              //Specifies the width of the element
        public Texture2D BackgroundImage { get; set; } //Specifies the Texture2D chosen to use as the elements background image
        //public Color BackgroundColor { get; set; }  //Specifies the background color of the element 

        public string Id { get; set; }              //Specifies a unique id for an element
        public string Key { get; set; }             //Specifies a shortcut key to activate/focus an element
        public List<string> StyleClasses { get; set; }//Specifies one or more classnames for an element (refers to a class in a style sheet)
        public bool ContentEditable { get; set; }   //Specifies whether the content of an element is editable or not
        public Element ContextMenu { get; set; }  //Specifies a context menu for an element. The context menu appears when a user right-clicks on the element
        public DirectionKind ContentDirection { get; set; }	//Specifies the text direction for the content in an element
        public bool Draggable { get; set; } 	    //Specifies whether an element is draggable or not
        public bool DropZone { get; set; }          //Specifies if an element can receive a dropped element 
        public DropKind Drop { get; set; }          //Specifies whether the dragged data is copied, moved, or linked, when dropped
        public bool Visible { get; set; }           //Specifies that an element is not yet, or is no longer, relevant
        public Language Language { get; set; }      //Specifies the language of the element's content
        public bool SpellCheck { get; set; }        //Specifies whether the element is to have its spelling and grammar checked or not
        //public string Style { get; set; }    	    //Specifies an inline CSS style for an element
        public int TabIndex { get; set; }           //Specifies the tabbing order of an element
        public string Title { get; set; }           //Specifies extra information about an element
        public bool Translate { get; set; }	        //Specifies whether the content of an element should be translated or not

        #endregion

        #region Events

        /******** Element Events **********/
        public event EventHandler OnBlur;           //Raised the moment that the element loses focus
        public event EventHandler OnChange;         //Raised the moment when the value of the element is changed
        public event EventHandler OnContextMenu;    //Raised when a context menu is triggered
        public event EventHandler OnFocus;          //Raised the moment when the element gets focus
        public event EventHandler OnInput;          //Raised when an element gets user input
        public event EventHandler OnInvalid;        //Raised when an element is invalid
        public event EventHandler OnSelect;         //Raised after some text has been selected in an element

        /******** Mouse Events ************/
        public event EventHandler OnClick;          //Raised when a mouse clicks on the element
        public event EventHandler OnDoubleClick;    //Raised when a mouse double-clicks on the element
        public event EventHandler OnDrag;           //Raised when an element is dragged
        public event EventHandler OnDragEnd;        //Raised at the end of a drag operation
        public event EventHandler OnDragEnter;      //Raised when an element has been dragged to a valid DropZone
        public event EventHandler OnDragLeave;      //Raised when an element leaves a valid drop target
        public event EventHandler OnDragOver;       //Raised when an element is being dragged over a valid DropZone
        public event EventHandler OnDragStart;      //Raised at the start of a drag operation
        public event EventHandler OnDrop;           //Raised when dragged element is being dropped
        public event EventHandler OnMouseDown;      //Raised when a mouse button is pressed down on an element
        public event EventHandler OnMouseMove;      //Raised when the mouse pointer moves over an element
        public event EventHandler OnMouseOut;       //Raised when the mouse pointer moves out of an element
        public event EventHandler OnMouseOver;      //Raised when the mouse pointer moves over an element
        public event EventHandler OnMouseUp;        //Raised when a mouse button is released over an element
        public event EventHandler OnMouseWheel;     //Raised when the mouse wheel is being rotated
        public event EventHandler OnScroll;         //Raised when an element's scrollbar is being scrolled

        /******** Keyboard Events ********/
        public event EventHandler OnKeyDown;        //Raised when a user is pressing a key
        public event EventHandler OnKeyPress;       //Raised when a user presses a key
        public event EventHandler OnKeyUp;          //Raised when a user releases a key

        #endregion

        #region Constructor

        public Element(ContentManager contentManager)
        {
            Content = contentManager;
            Style = new Style(contentManager);
        }

        #endregion

        #region Methods

        public virtual void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (this.Visible)
            {
                //Check if any Events need to be raised
            }
        }

        //Have each Element handle drawing itself
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this.Visible)
            {
                //Draw element
            }
        }

        #endregion
    }
}
