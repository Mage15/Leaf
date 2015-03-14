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
        internal class MatrixParser
        {
            internal bool TryMatrix2D(string value, out Matrix2D matrix)
            {
                if (value != null)
                {
                    const string Group_row0X = "row0X";
                    const string Group_row0Y = "row0Y";
                    const string Group_row1X = "row1X";
                    const string Group_row1Y = "row1Y";
                    const string Group_posDeltaX = "posDeltaX";
                    const string Group_posDeltaY = "posDeltaY";

                    const string matrixPattern = @"^(\s)?matrix\((?<" + Group_row0X + @">.+),\s{0,1}(?<" + Group_row0Y + @">.+),\s{0,1}(?<" + Group_row1X + @">.+),\s{0,1}(?<" + Group_row1Y + @">.+),\s{0,1}(?<" + Group_posDeltaX + @">.+),\s{0,1}(?<" + Group_posDeltaY + @">.+)\)";

                    Regex regex = new Regex(matrixPattern, RegexOptions.ExplicitCapture);
                    Match match;

                    try
                    {
                        match = regex.Match(value);
                    }
                    catch
                    {
                        // Something went wrong
                        matrix = new Matrix2D();
                        return false;
                    }

                    if (match.Success) // Set all the captured values
                    {
                        float row0X;
                        float row0Y;
                        float row1X;
                        float row1Y;
                        int posDeltaX;
                        int posDeltaY;

                        if (
                            float.TryParse(match.Groups[Group_row0X].Value, out row0X) &&
                            float.TryParse(match.Groups[Group_row0Y].Value, out row0Y) &&
                            float.TryParse(match.Groups[Group_row1X].Value, out row1X) &&
                            float.TryParse(match.Groups[Group_row1Y].Value, out row1Y) &&
                            int.TryParse(match.Groups[Group_posDeltaX].Value, out posDeltaX) &&
                            int.TryParse(match.Groups[Group_posDeltaY].Value, out posDeltaY)
                            )
                        {
                            matrix = new Matrix2D(row0X, row0Y, row1X, row1Y, posDeltaX, posDeltaY);
                            return true;
                        }

                    }
                }

                // Couldn't parse
                matrix = new Matrix2D();
                return false;
            }

            internal bool TryMatrix3D(string value, out Microsoft.Xna.Framework.Matrix matrix3d)
            {
                if (value != null)
                {
                    const string Group_m11 = "m11";
                    const string Group_m12 = "m12";
                    const string Group_m13 = "m13";
                    const string Group_m14 = "m14";
                    const string Group_m21 = "m21";
                    const string Group_m22 = "m22";
                    const string Group_m23 = "m23";
                    const string Group_m24 = "m24";
                    const string Group_m31 = "m31";
                    const string Group_m32 = "m32";
                    const string Group_m33 = "m33";
                    const string Group_m34 = "m34";
                    const string Group_m41 = "m41";
                    const string Group_m42 = "m42";
                    const string Group_m43 = "m43";
                    const string Group_m44 = "m44";

                    const string matrix3dPattern = @"^(\s)?matrix3d\((?<" + Group_m11 + @">.+),\s{0,1}(?<" + Group_m12 + @">.+),\s{0,1}(?<" + Group_m13 + @">.+),\s{0,1}(?<" + Group_m14 + @">.+),\s{0,1}(?<" + Group_m21 + @">.+),\s{0,1}(?<" + Group_m22 + @">.+),\s{0,1}(?<" + Group_m23 + @">.+),\s{0,1}(?<" + Group_m24 + @">.+),\s{0,1}(?<" + Group_m31 + @">.+),\s{0,1}(?<" + Group_m32 + @">.+),\s{0,1}(?<" + Group_m33 + @">.+),\s{0,1}(?<" + Group_m34 + @">.+),\s{0,1}(?<" + Group_m41 + @">.+),\s{0,1}(?<" + Group_m42 + @">.+),\s{0,1}(?<" + Group_m43 + @">.+),\s{0,1}(?<" + Group_m44 + @">.+)\)";

                    Regex regex = new Regex(matrix3dPattern, RegexOptions.ExplicitCapture);
                    Match match;

                    try
                    {
                        match = regex.Match(value);
                    }
                    catch
                    {
                        // Something went wrong
                        matrix3d = new Microsoft.Xna.Framework.Matrix();
                        return false;
                    }

                    if (match.Success) // Set all the captured values
                    {
                        float m11;
                        float m12;
                        float m13;
                        float m14;
                        float m21;
                        float m22;
                        float m23;
                        float m24;
                        float m31;
                        float m32;
                        float m33;
                        float m34;
                        float m41;
                        float m42;
                        float m43;
                        float m44;

                        if (
                            float.TryParse(match.Groups[Group_m11].Value, out m11) &&
                            float.TryParse(match.Groups[Group_m12].Value, out m12) &&
                            float.TryParse(match.Groups[Group_m13].Value, out m13) &&
                            float.TryParse(match.Groups[Group_m14].Value, out m14) &&
                            float.TryParse(match.Groups[Group_m21].Value, out m21) &&
                            float.TryParse(match.Groups[Group_m22].Value, out m22) &&
                            float.TryParse(match.Groups[Group_m23].Value, out m23) &&
                            float.TryParse(match.Groups[Group_m24].Value, out m24) &&
                            float.TryParse(match.Groups[Group_m31].Value, out m31) &&
                            float.TryParse(match.Groups[Group_m32].Value, out m32) &&
                            float.TryParse(match.Groups[Group_m33].Value, out m33) &&
                            float.TryParse(match.Groups[Group_m34].Value, out m34) &&
                            float.TryParse(match.Groups[Group_m41].Value, out m41) &&
                            float.TryParse(match.Groups[Group_m42].Value, out m42) &&
                            float.TryParse(match.Groups[Group_m43].Value, out m43) &&
                            float.TryParse(match.Groups[Group_m44].Value, out m44)
                            )
                        {
                            matrix3d = new Microsoft.Xna.Framework.Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
                            return true;
                        }
                    }
                }

                // Couldn't parse
                matrix3d = new Microsoft.Xna.Framework.Matrix();
                return false;
            }
        }
    }
}
