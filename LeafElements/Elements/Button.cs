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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafElements
{
    public enum ButtonType { Button, Reset, Submit };

    class Button : Element
    {
        #region Properties

        /******** Properties **********/
        public bool AutoFocus { get; set; }     //Specifies that a button should automatically get focus when the page loads
        public bool Disabled { get; set; }      //Specifies that a button should be disabled
        public List<string> FormId { get; set; }//Specifies one or more forms the button belongs to
        public string Name { get; set; }        //Specifies a name for the button
        public ButtonType Type { get; set; }    //Specifies the type of button
        public string Value { get; set; }       //Specifies an initial value for the button

        //Only useful for ButtonType.Submit
        public string FormAction { get; set; }          //Specifies where(method) to send the form-data when a form is submitted. Only for type="submit"
        public Form.SendMethod FormMethod { get; set; } //Specifies how to send the form-data (which HTTP method to use). Only for type="submit"
        public bool FormNoValidation { get; set; }      //Specifies that the form-data should not be validated on submission. Only for type="submit"
        public Form.DataTarget FormTarget { get; set; } //Specifies where to display the response after submitting the form. Only for type="submit"
        public string FormTargetFrame { get; set; }     //Specifies where to display the response after submitting the form. Only for type="submit"

        #endregion

        #region Constructor

        public Button(ContentManager contentManager)
            : base(contentManager)
        {

        }

        #endregion

    }
}