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

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace LeafStyle
{
    internal partial class Parser
    {
        internal class RectangleParser
        {
            private string rectPattern = @"rect\((?<yValue>[0-9]{1,4})px,(?<width>[0-9]{1,4})px,(?<height>[0-9]{1,4})px,(?<xValue>[0-9]{1,4})px\)";

            internal bool TryRectangle(string value, out Microsoft.Xna.Framework.Rectangle rect)
            {
                if (value != null)
                {
                    try
                    {
                        var rectMatch = Regex.Match(value, rectPattern);
                        if (rectMatch.Success)
                        {
                            int x = int.Parse(rectMatch.Groups["xValue"].Value);
                            int y = int.Parse(rectMatch.Groups["yValue"].Value);
                            int width = int.Parse(rectMatch.Groups["width"].Value);
                            int height = int.Parse(rectMatch.Groups["height"].Value);
                            
                            rect = new Microsoft.Xna.Framework.Rectangle(x, y, width, height);
                            return true;
                        }
                    }
                    catch { }
                }

                // Couldn't parse
                rect = new Microsoft.Xna.Framework.Rectangle();
                return false;
            }
        }
    }
}
