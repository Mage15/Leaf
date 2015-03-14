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
using System.Text.RegularExpressions;

namespace LeafStyle
{
    internal partial class Parser
    {
        
        internal class TransformParser
        {
            private Parser.MatrixParser matrixParser;
            private Parser.PointParser pointParser;
            private Parser.VectorParser vectorParser;

            public TransformParser()
            {
                matrixParser = new Parser.MatrixParser();
                pointParser = new Parser.PointParser();
                vectorParser = new Parser.VectorParser();
            }

            internal bool TryTransform(string value, out TransformState transformState, out TransformContainer transformContainer)
            {
                transformContainer = new TransformContainer();

                if (value.Contains("matrix3d"))
                {
                    Microsoft.Xna.Framework.Matrix matrix3d;
                    if (this.matrixParser.TryMatrix3D(value, out matrix3d))
                    {
                        transformContainer.Matrix3D = matrix3d;
                        transformState = TransformState.Matrix3D;

                        return true;
                    }
                }
                else if (value.Contains("matrix"))
                {
                    Matrix2D matrix;
                    if (this.matrixParser.TryMatrix2D(value, out matrix))
                    {
                        transformContainer.Matrix = matrix;
                        transformState = TransformState.Matrix;

                        return true;
                    }
                }
                else if (value.Contains("translate3d"))
                {
                    Point3D translate3d;
                    if (this.pointParser.TryPoint3D(value, out translate3d))
                    {
                        transformContainer.Translate3D = translate3d;
                        transformState = TransformState.Translate3D;

                        return true;
                    }
                }
                else if (value.Contains("translateX"))
                {
                    int translateX;
                    if (int.TryParse(value, out translateX))
                    {
                        transformContainer.TranslateX = translateX;
                        transformState = TransformState.TranslateX;

                        return true;
                    }
                }
                else if (value.Contains("translateY"))
                {
                    int translateY;
                    if (int.TryParse(value, out translateY))
                    {
                        transformContainer.TranslateY = translateY;
                        transformState = TransformState.TranslateY;

                        return true;
                    }
                }
                else if (value.Contains("translateZ"))
                {
                    int translateZ;
                    if (int.TryParse(value, out translateZ))
                    {
                        transformContainer.TranslateZ = translateZ;
                        transformState = TransformState.TranslateZ;

                        return true;
                    }
                }
                else if (value.Contains("translate"))
                {
                    Point translate;
                    if (this.pointParser.TryPoint(value, out translate))
                    {
                        transformContainer.Translate = translate;
                        transformState = TransformState.Translate;
                        return true;
                    }
                }
                else if (value.Contains("scale3d"))
                {
                    Vector3 scale3d;
                    if (this.vectorParser.TryVector3(value, out scale3d))
                    {
                        transformContainer.Scale3D = scale3d;
                        transformState = TransformState.Scale3D;

                        return true;
                    }
                }
                else if (value.Contains("scaleX"))
                {
                    float scaleX;
                    if (float.TryParse(value, out scaleX))
                    {
                        transformContainer.ScaleX = scaleX;
                        transformState = TransformState.ScaleX;

                        return true;
                    }
                }
                else if (value.Contains("scaleY"))
                {
                    float scaleY;
                    if (float.TryParse(value, out scaleY))
                    {
                        transformContainer.ScaleY = scaleY;
                        transformState = TransformState.ScaleY;

                        return true;
                    }
                }
                else if (value.Contains("scaleZ"))
                {
                    float scaleZ;
                    if (float.TryParse(value, out scaleZ))
                    {
                        transformContainer.ScaleZ = scaleZ;
                        transformState = TransformState.ScaleZ;

                        return true;
                    }
                }
                else if (value.Contains("scale"))
                {
                    Vector2 scale;
                    if (this.vectorParser.TryVector2(value, out scale))
                    {
                        transformContainer.Scale = scale;
                        transformState = TransformState.Scale;

                        return true;
                    }
                }
                if (value.Contains("rotate3d"))
                {
                    Vector4 rotate3d;
                    if (this.vectorParser.TryVector4(value, out rotate3d))
                    {
                        transformContainer.Rotate3D = rotate3d;
                        transformState = TransformState.Rotate3D;

                        return true;
                    }
                }
                if (value.Contains("rotateX"))
                {
                    float rotateX;
                    if (float.TryParse(value, out rotateX))
                    {
                        transformContainer.RotateX = rotateX;
                        transformState = TransformState.RotateX;

                        return true;
                    }
                }
                if (value.Contains("rotateY"))
                {
                    float rotateY;
                    if (float.TryParse(value, out rotateY))
                    {
                        transformContainer.RotateY = rotateY;
                        transformState = TransformState.RotateY;

                        return true;
                    }
                }
                if (value.Contains("rotateZ"))
                {
                    float rotateZ;
                    if (float.TryParse(value, out rotateZ))
                    {
                        transformContainer.RotateZ = rotateZ;
                        transformState = TransformState.RotateZ;

                        return true;
                    }
                }
                if (value.Contains("rotate"))
                {
                    float rotate;
                    if (float.TryParse(value, out rotate))
                    {
                        transformContainer.Rotate = rotate;
                        transformState = TransformState.Rotate;

                        return true;
                    }
                }

                // Couldn't parse
                transformState = TransformState.None;
                return false;
            }
        }
    }
}
