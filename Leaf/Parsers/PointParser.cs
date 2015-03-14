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
        internal class PointParser
        {
            internal bool TryPoint(string value, out Point point)
            {
                if (value != null)
                {
                    string[] values = value.Split(new char[] { ' ' });
                    if (values.Length > 1)
                    {
                        int x, y;

                        if (values[0].Contains("px"))
                        {
                            if (int.TryParse(values[0].Remove(values[0].IndexOf("px")), out x) &&
                                int.TryParse(values[1].Remove(values[1].IndexOf("px")), out y))
                            {
                                point = new Point(x, y);
                                return true;
                            }
                        }
                        else
                        {
                            if (int.TryParse(values[0], out x) &&
                                int.TryParse(values[1], out y))
                            {
                                point = new Point(x, y);
                                return true;
                            }
                        }
                    }
                    else if (values.Length == 1)
                    {
                        int xy;

                        if (values[0].Contains("px"))
                        {
                            if (int.TryParse(values[0].Remove(values[0].IndexOf("px")), out xy))
                            {
                                point = new Point(xy, xy);
                                return true;
                            }
                        }
                        else
                        {
                            if (int.TryParse(values[0], out xy))
                            {
                                point = new Point(xy, xy);
                                return true;
                            }
                        }
                    }
                }

                point = new Point();
                return false;
            }

            internal bool TryPoint3D(string value, out Point3D translate3d)
            {
                throw new NotImplementedException();
            }
        }
    }
}
