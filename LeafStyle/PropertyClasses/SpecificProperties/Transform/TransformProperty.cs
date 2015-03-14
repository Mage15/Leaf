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
    public class TransformProperty : BasicStyleProperty<TransformState>
    {
        private TransformContainer transformContainer;
        private Parser.TransformParser transformParser;

        public TransformProperty()
            : base(
                defaultState: default(TransformState),
                inherited: false,
                animatable: true
                )
        {
            transformContainer = new TransformContainer();
            transformParser = new Parser.TransformParser();

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
                TransformState currentState;
                TransformContainer container;

                if(transformParser.TryTransform(value, out currentState, out container))
                {
                    this.CurrentState = currentState;
                    this.transformContainer = container;

                    return true;
                }
            }

            // Couldn't parse
            return false;
        }
    }
}