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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LeafStyle;

namespace Leaf
{
    public enum DirectionKind { Up, Down, Left, Right };
    public enum DropKind { Copy, Move, Link };
    public enum Language { English };
    public enum Events 
    { 
        OnBlur,       
        OnChange,     
        OnContextMenu,
        OnFocus,      
        OnInput,      
        OnInvalid,    
        OnSelect,
        OnClick,      
        OnDoubleClick,
        OnRightClick,
        OnDrag,       
        OnDragEnd,    
        OnDragEnter,  
        OnDragLeave,  
        OnDragOver,   
        OnDragStart,  
        OnDrop,       
        OnMouseDown,  
        OnMouseMove,  
        OnMouseOut,   
        OnMouseOver,  
        OnMouseUp,    
        OnMouseWheel, 
        OnScroll,
        OnKeyDown,    
        OnKeyPress,   
        OnKeyUp    
    };

    public class LeafElement
    {
        #region Objects

        protected ContentManager ContentManager;
        public UIStyle Style;                       //Specifies an inline CSS style for an element. CSS classes are handled at the global document level.
        //delegate void ListenerDelegate (Element element, KeyboardState keyboardState, MouseState mouseState);
        delegate void StyleHandlerDelegate (StyleProperty styleProperty);

        #endregion

        #region Properties

        private Vector2 position;                   //Specifies the location of the top left corner of the element
        private Vector2 size;                       //Specifies the height and width of the element
        private Vector2 scale;
        private int maxHeight;                      //Specifies the max height of the element which can override the height to keep it uder the max
        private int maxWidth;                       //Specifies the max width of the element which can override the width to keep it under the max
        private int minHeight;                      //Specifies the min height of the element which can override the height ad maxHeight to keep over the min
        private int minWidth;                       //Specifies the min width of the element which can override the width ad maxWidth to keep over the min
        private Texture2D backgroundImage;          //Specifies the Texture2D chosen to use as the elements background image
        private Microsoft.Xna.Framework.Color backgroundColor; //Specifies the background color of the element 
        private Texture2D texture;
        private Nullable<Microsoft.Xna.Framework.Rectangle> sourceRectangle; //Always use this for the background image because ther may be clipping and such
        private Microsoft.Xna.Framework.Color color; // This will be the color of the font to match HTML behavior
        private float rotation;                     
        private Vector2 origin;
        private SpriteEffects effects;
        private float layerDepth;
        private bool hasFocus;
        private string content;
        private Dictionary<string, int> counters;
        private List<Events> listenedEvents;
        //private Dictionary<Events, ListenerDelegate> listenerDelegates; // Used to control the amount of checks performed by the objectelement. The delegates 
        //                                                                //contain all the checks that need to be performed to see if the event needs to be raised.
        private Dictionary<Type, StyleHandlerDelegate> styleHandlerDelegates; // Used to apply the requested style property to the element.

        /// <summary>
        /// Specifies a unique id for an element
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Specifies a shortcut key to activate/focus an element
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Specifies one or more classnames for an element
        /// </summary>
        public List<string> ClassList { get; set; }

        /// <summary>
        /// The element's string content
        /// </summary>
        public string Content 
        {
            // Needs further special implementation
            get { return content; }
            set { if (ContentEditable) { content = value; } }
        }

        /// <summary>
        /// Specifies whether the content of an element is editable or not
        /// </summary>
        public bool ContentEditable { get; protected set; }

        public string CounterIncrement 
        {
            set { if (counters.Keys.Contains(value)) { counters[value]++; } }
        }

        public string CounterRest
        {
            set { if (counters.Keys.Contains(value)) { counters[value] = 0; } }
        }

        /// <summary>
        /// Specifies a context menu for an element. The context menu appears when a user right-clicks on the element
        /// </summary>
        public LeafElement ContextMenu { get; set; }

        /// <summary>
        /// Specifies the text direction for the content in an element
        /// </summary>
        public DirectionKind ContentDirection { get; set; }

        /// <summary>
        /// Specifies whether an element is draggable or not
        /// </summary>
        public bool Draggable { get; set; }

        /// <summary>
        /// Specifies if an element can receive a dropped element
        /// </summary>
        public bool DropZone { get; set; }

        /// <summary>
        /// Specifies whether the dragged data is copied, moved, or linked, when dropped
        /// </summary>
        public DropKind Drop { get; set; }

        /// <summary>
        /// Specifies that an element is not yet, or is no longer, relevant
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Specifies the language of the element's content
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Specifies whether the element is to have its spelling and grammar checked or not
        /// </summary>
        public bool SpellCheck { get; set; }

        /// <summary>
        /// Specifies the tabbing order of an element
        /// </summary>
        public int TabIndex { get; set; }

        /// <summary>
        /// Specifies extra information about an element
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Specifies whether the content of an element should be translated or not
        /// </summary>
        public bool Translate { get; set; }

        /// <summary>
        /// Returns a list of child elements
        /// </summary>
        public List<LeafElement> Children { get; set; }

        /// <summary>
        /// Returns the number of child elements
        /// </summary>
        public int ChildElementCount { get { return Children.Count; } }
        
        /// <summary>
        /// The ClientHeight property returns the viewable height of an element, including padding, but not the 
        /// border, scrollbar or margin.
        /// </summary>
        public float ClientHeight { get { return size.Y; } }

        /// <summary>
        /// The ClientLeft property returns the width of the left border of an element. This property does not 
        /// include the element's left padding or the left margin.
        /// </summary>
        public int ClientLeft 
        { 
            get 
            {
                var width = Style.GetProperty(Property.BorderLeftWidth);
                
                return (width != null) ? ((BasicWidthProperty)width).Length : 0;
            } 
        }

        /// <summary>
        /// The ClientTop property returns the width of the top border of an element. This property does not 
        /// include the element's top padding or the top margin.
        /// </summary>
        public int ClientTop
        {
            get
            {
                var width = Style.GetProperty(Property.BorderTopWidth);

                return (width != null) ? ((BasicWidthProperty)width).Length : 0;
            }
        }

        /// <summary>
        /// The ClientWidth property returns the viewable width of an element, including padding, but not the 
        /// border, scrollbar or margin.
        /// </summary>
        public float ClientWidth { get { return size.X; } }

        /// <summary>
        /// Returns the first child element. If there are no children null is returned.
        /// </summary>
        public LeafElement FirstChild { get { return (Children.Count > 0) ? Children[0] : null; } }

        
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
        public event EventHandler OnRightClick;
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

        public LeafElement(ContentManager contentManager)
        {
            ContentManager = contentManager;
            Style = new UIStyle(contentManager);
            ClassList = new List<string>();
            Children = new List<LeafElement>();
            counters = new Dictionary<string,int>();
            listenedEvents = new List<Events>();
            //listenerDelegates = new Dictionary<Events, ListenerDelegate>(); // Since these will have set values maybe call an init for this.
            styleHandlerDelegates = new Dictionary<Type, StyleHandlerDelegate>(); // Since these will have set values maybe call an init for this.
        }

        #endregion

        #region Methods
        
        // Have each elemet handle updating itself
        public virtual void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (this.Visible)
            {
                // Check if any Events need to be raised
                foreach(var e in listenedEvents)
                {
                    //switch (e)
                    //{
                    //    case Events.OnBlur:
                    //        break;
                    //    case Events.OnChange:
                    //        break;
                    //    case Events.OnContextMenu:
                    //        break;
                    //    case Events.OnFocus:
                    //        break;
                    //    case Events.OnInput:
                    //        break;
                    //    case Events.OnInvalid:
                    //        break;
                    //    case Events.OnSelect:
                    //        break;
                    //    case Events.OnClick:
                    //        break;
                    //    case Events.OnDoubleClick:
                    //        break;
                    //    case Events.OnRightClick:
                    //        break;
                    //    case Events.OnDrag:
                    //        break;
                    //    case Events.OnDragEnd:
                    //        break;
                    //    case Events.OnDragEnter:
                    //        break;
                    //    case Events.OnDragLeave:
                    //        break;
                    //    case Events.OnDragOver:
                    //        break;
                    //    case Events.OnDragStart:
                    //        break;
                    //    case Events.OnDrop:
                    //        break;
                    //    case Events.OnMouseDown:
                    //        break;
                    //    case Events.OnMouseMove:
                    //        break;
                    //    case Events.OnMouseOut:
                    //        break;
                    //    case Events.OnMouseOver:
                    //        break;
                    //    case Events.OnMouseUp:
                    //        break;
                    //    case Events.OnMouseWheel:
                    //        break;
                    //    case Events.OnScroll:
                    //        break;
                    //    case Events.OnKeyDown:
                    //        break;
                    //    case Events.OnKeyPress:
                    //        break;
                    //    case Events.OnKeyUp:
                    //        break;
                    //};
                }

                // Global classes will probably be handled at the global document level
                //foreach (string globalClassName in ClassList)
                //{
                //    UIStyle globalClass = UIDocument.GlobalStyleClasses[globalClassName];
                //    foreach (StyleProperty styleProperty in globalClass.GetCurrentPropertyObjects())
                //    {
                //        // apply style settings
                //        //this.StylePropertyHandler[typeof(StyleProperty)](styleProperty);
                //    }
                //}

                // Apply style settings
                foreach (StyleProperty styleProperty in this.Style.GetCurrentPropertyObjects())
                { 
                    this.styleHandlerDelegates[typeof(StyleProperty)](styleProperty);
                }
            }
        }

        //Have each Element handle drawing itself
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this.Visible)
            {
                // Refresh values based on Style object

                // Texture2D texture,
                // Vector2 position,
                // Nullable<Rectangle> sourceRectangle,
                // Color color,
                // float rotation,
                // Vector2 origin,
                // Vector2 scale,
                // SpriteEffects effects,
                // float layerDepth

                // Draw element
                // spriteBatch.Draw(texture, this.Position, sourceRectangle, this.BackgroundColor, rotation, origin, scale, effects, layerDepth)                
            }
        }

        /// <summary>
        /// Used to specify a defined set of checks for the eventListener provided. Only the events specified through this method 
        /// will be listened for.
        /// </summary>
        public void AddEventListener(Events e, EventHandler eventHandler)
        {
            switch(e)
            {
                case Events.OnBlur:
                    this.OnBlur += eventHandler;                    
                    break;
                case Events.OnChange:
                    this.OnChange += eventHandler;
                    break;
                case Events.OnContextMenu:
                    this.OnContextMenu += eventHandler;
                    break;
                case Events.OnFocus:
                    this.OnFocus += eventHandler;
                    break;
                case Events.OnInput:
                    this.OnInput += eventHandler;
                    break;
                case Events.OnInvalid:
                    this.OnInvalid += eventHandler;
                    break;
                case Events.OnSelect:
                    this.OnSelect += eventHandler;
                    break;
                case Events.OnClick:
                    this.OnClick += eventHandler;
                    break;
                case Events.OnDoubleClick:
                    this.OnDoubleClick += eventHandler;
                    break;
                case Events.OnRightClick:
                    this.OnRightClick += eventHandler;
                    break;
                case Events.OnDrag:
                    this.OnDrag += eventHandler;
                    break;
                case Events.OnDragEnd:    
                    this.OnDragEnd += eventHandler;
                    break;
                case Events.OnDragEnter:
                    this.OnDragEnter += eventHandler;
                    break;
                case Events.OnDragLeave:
                    this.OnDragLeave += eventHandler;
                    break;
                case Events.OnDragOver:
                    this.OnDragOver += eventHandler;
                    break;
                case Events.OnDragStart:
                    this.OnDragStart += eventHandler;
                    break;
                case Events.OnDrop:
                    this.OnDrop += eventHandler;
                    break;
                case Events.OnMouseDown:
                    this.OnMouseDown += eventHandler;
                    break;
                case Events.OnMouseMove:
                    this.OnMouseMove += eventHandler;
                    break;
                case Events.OnMouseOut:
                    this.OnMouseOut += eventHandler;
                    break;
                case Events.OnMouseOver:
                    this.OnMouseOver += eventHandler;
                    break;
                case Events.OnMouseUp:
                    this.OnMouseUp += eventHandler;
                    break;
                case Events.OnMouseWheel:
                    this.OnMouseWheel += eventHandler;
                    break;
                case Events.OnScroll:
                    this.OnScroll += eventHandler;
                    break;
                case Events.OnKeyDown:
                    this.OnKeyDown += eventHandler;
                    break;
                case Events.OnKeyPress:
                    this.OnKeyPress += eventHandler;
                    break;
                case Events.OnKeyUp:
                    this.OnKeyUp += eventHandler;
                    break;
            };

            if (!listenedEvents.Contains(e)) { listenedEvents.Add(e); }
        }

        /// <summary>
        /// Adds a new child element, to elements Children, as the last child in the list
        /// </summary>
        public void AppendChild(LeafElement element)
        {
            Children.Add(element);
        }

        /// <summary>
        /// Removes focus from element
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the Focus() method to give an element focus.</para>
        /// </summary>
        public void Blur()
        {
            hasFocus = false;

            if(listenedEvents.Contains(Events.OnBlur) &&
                this.OnBlur != null)
            {
                this.OnBlur(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Simulates a mouse-click on an element
        /// </summary>
        public virtual void Click()
        {
            if (this.OnClick != null)
            {
                this.OnClick(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Simulates a mouse-click on an element
        /// </summary>
        public virtual void Click(EventArgs e)
        {
            if (this.OnClick != null)
            {
                this.OnClick(this, e);
            }
        }

        //public Element Clone()
        
        /// <summary>
        /// Gives focus to an element (if it can be focused).
        /// <para>&#160;</para><br />
        /// <para>Tip: Use the Blur() method to remove focus from an element.</para>
        /// </summary>
        public void Focus()
        {
            if(listenedEvents.Contains(Events.OnFocus) &&
                this.OnFocus != null)
            {
                this.OnFocus(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Returns the string value of the specified attribute. If the attribute has no value a String.Empty 
        /// is returned.
        /// </summary>
        public string GetAttribute(string attributeName)
        {
            return "";
        }
        #endregion
    }
}
