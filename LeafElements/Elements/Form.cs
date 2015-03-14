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

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafElements
{
    class Form : Element
    {
        #region Enums

        //public enum CharSet {};
        public enum SendMethod { Get, Post };
        public enum DataTarget { Blank, Self, Parent, Top };

        #endregion

        #region Properties

        //public CharSet AcceptCharSet { get; set; }  //Specifies the character encodings that are to be used for the form submission
        public string Action { get; set; }          //Specifies where(method) to send the form-data when a form is submitted
        public bool AutoComplete { get; set; }      //Specifies whether a form should have autocomplete on or off
        public SendMethod Method { get; set; }      //Specifies the method to use when sending form-data
        public string Name { get; set; }             //Specifies the name of a form
        public bool NoValidation { get; set; }      //Specifies that the form should or should not be validated when submitted
        public DataTarget Target { get; set; }      //Specifies where to display the response that is received after submitting the form

        #endregion

        #region Constructor

        public Form(ContentManager contentManager)
            : base(contentManager)
        {
            
        }

        #endregion

        #region Events

        public event EventHandler OnFormChange; //Raised when a form changes
        public event EventHandler OnFormInput;  //Raised when a form gets user input
        //public event EventHandler OnReset;      //Raised when the Reset button in a form is clicked (Not supported in HTML5)
        public event EventHandler OnSubmit;     //Raised when a form is submitted

        #endregion

        #region Methods

        public override void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (this.Visible)
            {
                //TODO check if any Form specific events need to be raised


                base.Update(keyboardState, mouseState);
            }
        }

        #endregion
    }
}