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
    //Needs special implementation
    //public class TransformOriginProperty : BasicStyleProperty<BasicValuesState>
    //{
    //    public Origin.X_Axis X_Axis { get; set; }
    //    public Origin.Y_Axis Y_Axis { get; set; }

    //    public OriginValuesContainer Values { get; set; }

    //    public TransformOriginProperty()
    //        : base(
    //            defaultState: default(BasicValuesState),
    //            inherited: false,
    //            animatable: true
    //        )
    //    {
    //        this.X_Axis = Origin.X_Axis.Percent;
    //        this.Y_Axis = Origin.Y_Axis.Percent;
    //        this.Values = new OriginValuesContainer()
    //        {
    //            X_Percent = .5f,
    //            Y_Percent = .5f,
    //            Z_Absolute = 0
    //        };
    //    }

    //    public override bool TrySetValue(object value)
    //    {
    //        if (value != null)
    //        {
    //            if (value.GetType() == typeof(Origin.X_Axis))
    //            {
    //                this.X_Axis = (Origin.X_Axis)value;
    //            }
    //            else if (value.GetType() == typeof(Origin.Y_Axis))
    //            {
    //                this.Y_Axis = (Origin.Y_Axis)value;
    //            }
    //            else if (value.GetType() == typeof(OriginValuesContainer))
    //            {
    //                this.Values = (OriginValuesContainer)value;
    //            }
    //        }

    //        return false;
    //    }

    //    public override bool TrySetValues(object[] values)
    //    {
    //        bool allValuesSet = true;

    //        foreach (object obj in values)
    //        {
    //            if (!this.TrySetValue(obj))
    //            {
    //                allValuesSet = false;
    //            }
    //        }

    //        return allValuesSet;
    //    }
    //}
}