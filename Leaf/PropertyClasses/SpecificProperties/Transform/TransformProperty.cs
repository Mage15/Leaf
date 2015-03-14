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
using System.Collections.Generic;

namespace LeafStyle
{
    //Investigate use of  Microsoft.Xna.Framework.Martix object
    internal class TransformProperty : BasicStyleProperty<TransformState>
    {
        private Parser.MatrixParser matrixParser = new Parser.MatrixParser();
        private Parser.PointParser pointParser = new Parser.PointParser();
        private Parser.VectorParser vectorParser = new Parser.VectorParser();

        public Matrix2D Matrix { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix.Transform
        public Microsoft.Xna.Framework.Matrix Matrix3D { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix object
        public Point Translate { get; set; }
        public Point3D Translate3D { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix.Translation
        public int TranslateX { get; set; }
        public int TranslateY { get; set; }
        public int TranslateZ { get; set; }
        public Vector2 Scale { get; set; }
        public Vector3 Scale3D { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float ScaleZ { get; set; }
        public float Rotate { get; set; }
        public Vector4 Rotate3D { get; set; }
        public float RotateX { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix.CreateRotationX(RotateX) or CreateFromAxisAngle
        public float RotateY { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix.CreateRotationY(RotateY) or CreateFromAxisAngle
        public float RotateZ { get; set; } // Investigate use of  Microsoft.Xna.Framework.Martix.CreateRotationZ(RotateZ) or CreateFromAxisAngle
        //public Transform.Skew Skew { get; set; }
        //public Transform.SkewX SkewX { get; set; }
        //public Transform.SkewY SkewY { get; set; }
        //public Transform.Perspective Perspective { get; set; }

        public TransformProperty()
            : base(
                defaultState: default(TransformState),
                inherited: false,
                animatable: true
                )
        {
            this.StateValues = new Dictionary<string, TransformState>()
                {
                    {"none", TransformState.None},
                    {"matrix", TransformState.Matrix},
                    {"matrix3d", TransformState.Matrix3D},
                    {"translate", TransformState.Translate},
                    {"translate3d", TransformState.Translate3D},
                    {"translateX", TransformState.TranslateX},
                    {"translateY", TransformState.TranslateY},
                    {"translateZ", TransformState.TranslateZ},
                    {"scale", TransformState.Scale},
                    {"scale3d", TransformState.Scale3D},
                    {"scaleX", TransformState.ScaleX},
                    {"scaleY", TransformState.ScaleY},
                    {"scaleZ", TransformState.ScaleZ},
                    {"rotate", TransformState.Rotate},
                    {"rotate3d", TransformState.Rotate3D},
                    {"rotateX", TransformState.RotateX},
                    {"rotateY", TransformState.RotateY},
                    {"rotateZ", TransformState.RotateZ},
                    //{"skew", TransformState.Skew},
                    //{"skewX", TransformState.SkewX},
                    //{"skewY", TransformState.SkewY},
                    //{"perspective", TransformState.Perspective},
                    {"initial", TransformState.Initial},
                    {"inherit", TransformState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null)
            {
                if (value.Contains("matrix3d"))
                {
                    Microsoft.Xna.Framework.Matrix matrix3d;
                    if (this.matrixParser.TryMatrix3D(value, out matrix3d))
                    {
                        this.Matrix3D = matrix3d;
                        this.CurrentState = TransformState.Matrix3D;

                        return true;
                    }
                }
                else if (value.Contains("matrix"))
                {
                    Matrix2D matrix;
                    if (this.matrixParser.TryMatrix2D(value, out matrix))
                    {
                        this.Matrix = matrix;
                        this.CurrentState = TransformState.Matrix;

                        return true;
                    }
                }
                else if (value.Contains("translate3d"))
                {
                    Point3D translate3d;
                    if (this.pointParser.TryPoint3D(value, out translate3d))
                    {
                        this.Translate3D = translate3d;
                        this.CurrentState = TransformState.Translate3D;

                        return true;
                    }
                }
                else if (value.Contains("translateX"))
                {
                    int translateX;
                    if (int.TryParse(value, out translateX))
                    {
                        this.TranslateX = translateX;
                        this.CurrentState = TransformState.TranslateX;

                        return true;
                    }
                }
                else if (value.Contains("translateY"))
                {
                    int translateY;
                    if (int.TryParse(value, out translateY))
                    {
                        this.TranslateY = translateY;
                        this.CurrentState = TransformState.TranslateY;

                        return true;
                    }
                }
                else if (value.Contains("translateZ"))
                {
                    int translateZ;
                    if (int.TryParse(value, out translateZ))
                    {
                        this.TranslateZ = translateZ;
                        this.CurrentState = TransformState.TranslateZ;

                        return true;
                    }
                }
                else if (value.Contains("translate"))
                {
                    Point translate;
                    if (this.pointParser.TryPoint(value, out translate))
                    {
                        this.Translate = translate;
                        this.CurrentState = TransformState.Translate;
                        return true;
                    }
                }
                else if (value.Contains("scale3d"))
                {
                    Vector3 scale3d;
                    if (this.vectorParser.TryVector3(value, out scale3d))
                    {
                        this.Scale3D = scale3d;
                        this.CurrentState = TransformState.Scale3D;

                        return true;
                    }
                }
                else if (value.Contains("scaleX"))
                {
                    float scaleX;
                    if (float.TryParse(value, out scaleX))
                    {
                        this.ScaleX = scaleX;
                        this.CurrentState = TransformState.ScaleX;

                        return true;
                    }
                }
                else if (value.Contains("scaleY"))
                {
                    float scaleY;
                    if (float.TryParse(value, out scaleY))
                    {
                        this.ScaleY = scaleY;
                        this.CurrentState = TransformState.ScaleY;

                        return true;
                    }
                }
                else if (value.Contains("scaleZ"))
                {
                    float scaleZ;
                    if (float.TryParse(value, out scaleZ))
                    {
                        this.ScaleZ = scaleZ;
                        this.CurrentState = TransformState.ScaleZ;

                        return true;
                    }
                }
                else if (value.Contains("scale"))
                {
                    Vector2 scale;
                    if (this.vectorParser.TryVector2(value, out scale))
                    {
                        this.Scale = scale;
                        this.CurrentState = TransformState.Scale;

                        return true;
                    }
                }
                if (value.Contains("rotate3d"))
                {
                    Vector4 rotate3d;
                    if (this.vectorParser.TryVector4(value, out rotate3d))
                    {
                        this.Rotate3D = rotate3d;
                        this.CurrentState = TransformState.Rotate3D;

                        return true;
                    }
                }
                if (value.Contains("rotateX"))
                {
                    float rotateX;
                    if (float.TryParse(value, out rotateX))
                    {
                        this.RotateX = rotateX;
                        this.CurrentState = TransformState.RotateX;

                        return true;
                    }
                }
                if (value.Contains("rotateY"))
                {
                    float rotateY;
                    if (float.TryParse(value, out rotateY))
                    {
                        this.RotateY = rotateY;
                        this.CurrentState = TransformState.RotateY;

                        return true;
                    }
                }
                if (value.Contains("rotateZ"))
                {
                    float rotateZ;
                    if (float.TryParse(value, out rotateZ))
                    {
                        this.RotateZ = rotateZ;
                        this.CurrentState = TransformState.RotateZ;

                        return true;
                    }
                }
                if (value.Contains("rotate"))
                {
                    float rotate;
                    if (float.TryParse(value, out rotate))
                    {
                        this.Rotate = rotate;
                        this.CurrentState = TransformState.Rotate;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            //if (value != null)
            //{
            //    if (value.GetType() == typeof(Transform.Matrix))
            //    {
            //        this.Matrix = (Transform.Matrix)value;
            //        this.CurrentState = TransformState.Matrix;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Matrix3D))
            //    {
            //        this.Matrix3D = (Transform.Matrix3D)value;
            //        this.CurrentState = TransformState.Matrix3D;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Translate))
            //    {
            //        this.Translate = (Transform.Translate)value;
            //        this.CurrentState = TransformState.Translate;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Translate3D))
            //    {
            //        this.Translate3D = (Transform.Translate3D)value;
            //        this.CurrentState = TransformState.Translate3D;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.TranslateX))
            //    {
            //        this.TranslateX = (Transform.TranslateX)value;
            //        this.CurrentState = TransformState.TranslateX;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.TranslateY))
            //    {
            //        this.TranslateY = (Transform.TranslateY)value;
            //        this.CurrentState = TransformState.TranslateY;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.TranslateZ))
            //    {
            //        this.TranslateZ = (Transform.TranslateZ)value;
            //        this.CurrentState = TransformState.TranslateZ;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Scale))
            //    {
            //        this.Scale = (Transform.Scale)value;
            //        this.CurrentState = TransformState.Scale;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Scale3D))
            //    {
            //        this.Scale3D = (Transform.Scale3D)value;
            //        this.CurrentState = TransformState.Scale3D;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.ScaleX))
            //    {
            //        this.ScaleX = (Transform.ScaleX)value;
            //        this.CurrentState = TransformState.ScaleX;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.ScaleY))
            //    {
            //        this.ScaleY = (Transform.ScaleY)value;
            //        this.CurrentState = TransformState.ScaleY;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.ScaleZ))
            //    {
            //        this.ScaleZ = (Transform.ScaleZ)value;
            //        this.CurrentState = TransformState.ScaleZ;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Rotate))
            //    {
            //        this.Rotate = (Transform.Rotate)value;
            //        this.CurrentState = TransformState.Rotate;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Rotate3D))
            //    {
            //        this.Rotate3d = (Transform.Rotate3D)value;
            //        this.CurrentState = TransformState.Rotate3D;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.RotateX))
            //    {
            //        this.RotateX = (Transform.RotateX)value;
            //        this.CurrentState = TransformState.RotateX;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.RotateY))
            //    {
            //        this.RotateY = (Transform.RotateY)value;
            //        this.CurrentState = TransformState.RotateY;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.RotateZ))
            //    {
            //        this.RotateZ = (Transform.RotateZ)value;
            //        this.CurrentState = TransformState.RotateZ;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Skew))
            //    {
            //        this.Skew = (Transform.Skew)value;
            //        this.CurrentState = TransformState.Skew;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.SkewX))
            //    {
            //        this.SkewX = (Transform.SkewX)value;
            //        this.CurrentState = TransformState.SkewX;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.SkewY))
            //    {
            //        this.SkewY = (Transform.SkewY)value;
            //        this.CurrentState = TransformState.SkewY;

            //        return true;
            //    }
            //    else if (value.GetType() == typeof(Transform.Perspective))
            //    {
            //        this.Perspective = (Transform.Perspective)value;
            //        this.CurrentState = TransformState.Perspective;

            //        return true;
            //    }
            //}

            return false;
        }
    }
}