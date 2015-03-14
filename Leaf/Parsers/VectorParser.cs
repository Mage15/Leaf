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

namespace LeafStyle
{
    internal partial class Parser
    {
        internal class VectorParser
        {
            internal bool TryVector2(string value, out Vector2 vector2)
            {
                if (value != null)
                {
                    string[] values;

                    if (value.Contains(","))
                    {
                        values = value.Split(new char[] { ',' });
                    }
                    else
                    {
                        values = value.Split(new char[] { ' ' });
                    }

                    if (values.Length > 1)
                    {
                        if (values[0].Contains("%"))
                        {
                            values[0] = values[0].Remove(values[0].IndexOf("%"));
                        }
                        if (values[1].Contains("%"))
                        {
                            values[1] = values[1].Remove(values[1].IndexOf("%"));
                        }

                        float x, y;
                        if (float.TryParse(values[0], out x) &&
                            float.TryParse(values[0], out y))
                        {
                            // Convert to decimal form
                            vector2 = new Vector2(x / 100, y / 100);
                            return true;
                        }
                    }
                    else if (values.Length == 1)
                    {
                        if (values[0].Contains("%"))
                        {
                            values[0] = values[0].Remove(values[0].IndexOf("%"));
                        }

                        float xy;
                        if (float.TryParse(values[0], out xy))
                        {
                            // Convert to decimal form
                            vector2 = new Vector2(xy / 100, xy / 100);
                            return true;
                        }
                    }
                }

                vector2 = new Vector2();
                return false;
            }

            internal bool TryVector3(string value, out Vector3 vector3)
            {
                throw new NotImplementedException();
            }

            internal bool TryVector4(string value, out Vector4 rotate3d)
            {
                throw new NotImplementedException();
            }
        }
    }
}
