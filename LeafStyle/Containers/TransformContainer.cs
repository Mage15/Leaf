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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LeafStyle
{
    public struct Matrix2D
    {
        public Vector4 BoxCorners;
        public Point ShiftXY;

        public Matrix2D(float row0X, float row0Y, float row1X, float row1Y, int shiftX, int shiftY)
        {
            this.BoxCorners = new Vector4(row0X, row0Y, row1X, row1Y);
            this.ShiftXY = new Point(shiftX, shiftY);
        }
    }
    
    public struct Point3D
    {
        public int X;
        public int Y;
        public int Z;

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    class TransformContainer
    {
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
    }
}
