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

using System.Collections.Generic;

namespace LeafStyle
{
    internal class CursorProperty : ImageStyleProperty<CursorState>
    {
        private Parser.StringParser stringParser = new Parser.StringParser();

        public List<string> UrlList { get; set; }
        public CursorState BackupState { get; set; }

        public CursorProperty()
            : base(
                    defaultState: default(CursorState),
                    inherited: true,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, CursorState>()
                {
                    {"alias", CursorState.Alias},
		            {"all-scroll", CursorState.AllScroll},
		            {"auto", CursorState.Auto},
		            {"cell", CursorState.Cell},
		            {"context-menu", CursorState.ContextMenu},
		            {"col-resize", CursorState.ColResize},
		            {"copy", CursorState.Copy},
		            {"crosshair", CursorState.Crosshair},
		            {"default", CursorState.Default},
		            {"e-resize", CursorState.E_Resize},
		            {"ew-resize", CursorState.EW_Resize},
		            {"help", CursorState.Help},
		            {"move", CursorState.Move},
		            {"n-resize", CursorState.N_Resize},
		            {"ne-resize", CursorState.NE_Rresize},
		            {"nesw-resize", CursorState.NESW_Resize},
		            {"ns-resize", CursorState.NS_Resize},
		            {"nw-resize", CursorState.NW_Resize},
		            {"nwse-resize", CursorState.NWSE_Resize},
		            {"no-drop", CursorState.NoDrop},
		            {"none", CursorState.None},
		            {"not-allowed", CursorState.NotAllowed},
		            {"pointer", CursorState.Pointer},
		            {"progress", CursorState.Progress},
		            {"row-resize", CursorState.RowResize},
		            {"s-resize", CursorState.S_Resize},
		            {"se-resize", CursorState.SE_Resize},
		            {"sw-resize", CursorState.SW_Resize},
                    {"text", CursorState.Text},
                    {"url", CursorState.Url},
		            {"vertical-text", CursorState.VerticalText},
		            {"w-resize", CursorState.W_Resize},
		            {"wait", CursorState.Wait},
		            {"zoom-in", CursorState.ZoomIn},
		            {"zoom-out", CursorState.ZoomOut},
		            {"initial", CursorState.Initial},
                    {"inherit", CursorState.Inherit}
                };
        }

        public override bool LoadImage(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            if (this.UrlList.Count > 0)
            {
                foreach (string str in UrlList)
                {
                    if (base.LoadImage(contentManager))
                    {
                        return true;
                    }
                }
            }

            // Couldn't find an image that would work
            return false;
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null)
            {
                string[] strValues = value.Split(new char[] { ',' });
                this.UrlList = new List<string>();

                foreach (string str in strValues)
                {
                    if (str.Contains("url"))
                    {
                        string strValue;
                        if (this.stringParser.TryUrl(str, out strValue))
                        {
                            this.UrlList.Add(strValue);
                        }
                    }
                    else
                    {
                        if (this.StateValues.ContainsKey(str))
                        {
                            this.BackupState = StateValues[str];
                        }
                    }
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(PropertyStringList))
                {
                    this.UrlList = ((PropertyStringList)value).StringValues;
                    return true;
                }
                else if (value.GetType() == typeof(CursorState))
                {
                    this.BackupState = (CursorState)value;
                    return true;
                }
            }

            return false;
        }

        public override bool TrySetValues(object[] values)
        {
            bool allValuesSet = true;

            foreach (object obj in values)
            {
                if (!this.TrySetValue(obj))
                {
                    allValuesSet = false;
                }
            }

            return allValuesSet;
        }
    }
}