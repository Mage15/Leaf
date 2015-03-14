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

namespace LeafStyle
{
    internal partial class Parser
    {
        internal class ColorParser
        {
            //Needs Validation checks added
            internal bool TryColor(string value, out Microsoft.Xna.Framework.Color color)
            {
                if (value != null)
                {
                    try
                    {
                        if (Value.ColorContainer.Keys.Contains(value))
                        {
                            color = Value.ColorContainer[value];
                            return true;
                        }
                        else if (value[0] == '#' && (value.Length == 7 || value.Length == 4))
                        {
                            int red = 0, green = 0, blue = 0;
                            string strValue = value.Substring(1);

                            if (strValue.Length == 3)
                            {
                                red = int.Parse(
                                    strValue.Substring(0, 1) + strValue.Substring(0, 1),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                                green = int.Parse(
                                    strValue.Substring(1, 1) + strValue.Substring(1, 1),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                                blue = int.Parse(
                                    strValue.Substring(2, 1) + strValue.Substring(2, 1),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                            }
                            else
                            {
                                red = int.Parse(
                                    strValue.Substring(0, 2),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                                green = int.Parse(
                                    strValue.Substring(2, 2),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                                blue = int.Parse(
                                    strValue.Substring(4, 2),
                                    System.Globalization.NumberStyles.HexNumber
                                    );
                            }

                            color = new Microsoft.Xna.Framework.Color(red, green, blue);
                        }
                        else if (value.Contains(","))
                        {
                            string[] strValues = value.Split(',');

                            color = new Microsoft.Xna.Framework.Color(int.Parse(strValues[0]), int.Parse(strValues[1]), int.Parse(strValues[2]));
                        }
                    }
                    catch { }
                }

                color = Microsoft.Xna.Framework.Color.Black;
                return false;
            }

            internal bool TryColorTransparent(string value, out ColorTransparentState state, out Microsoft.Xna.Framework.Color color)
            {
                string colorValue = "";

                // Parse values

                if (TryColor(colorValue, out color))
                {
                    state = ColorTransparentState.Color;
                    return true;
                }
                else
                {
                    //Add the TryGetStateValue() of the ColorTransparent class
                }

                state = default(ColorTransparentState);
                return false;
            }
        }
    }
}
