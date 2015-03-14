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
    public class ContentValuesContainer
    {
        // Should look at using PropertyString
        public string Attribute { get; set; }
        public string String { get; set; }
        public Uri Url { get; set; }
    }

    public class QuadValues<T>
        where T : struct
    {
        public T Top { get; set; }
        public T Left { get; set; }
        public T Bottom { get; set; }
        public T Right { get; set; }

        public QuadValues(T top, T left, T bottom, T right)
        {
            this.Top = top;
            this.Left = left;
            this.Bottom = bottom;
            this.Right = right;
        }

        public QuadValues(T top, T leftAndRight, T bottom)
            : this(top, leftAndRight, bottom, leftAndRight)
        { }

        public QuadValues(T topAndBottom, T leftAndRight)
            : this(topAndBottom, leftAndRight, topAndBottom, leftAndRight)
        { }

        public QuadValues(T allValues)
            : this(allValues, allValues, allValues, allValues)
        { }

        public QuadValues() { }
    }

    public struct QuoteValuesContainer
    {
        public char FirstLevelStart;
        public char FirstLevelEnd;
        public char SecondLevelStart;
        public char SecondLevelEnd;

        public QuoteValuesContainer(char firstLevelStart, char firstLevelEnd)
        {
            FirstLevelStart = (Quotes.CharValues.ContainsValue(firstLevelStart))
                ? firstLevelStart : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            FirstLevelEnd = (Quotes.CharValues.ContainsValue(firstLevelEnd))
                ? firstLevelEnd : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelStart = Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelEnd = Quotes.CharValues[default(Quotes.QuoteCharacter)];
        }

        public QuoteValuesContainer(char firstLevelStart, char firstLevelEnd, 
            char secondLevelStart, char secondLevelEnd)
        {
            FirstLevelStart = (Quotes.CharValues.ContainsValue(firstLevelStart))
                ? firstLevelStart : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            FirstLevelEnd = (Quotes.CharValues.ContainsValue(firstLevelEnd))
                ? firstLevelEnd : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelStart = (Quotes.CharValues.ContainsValue(secondLevelStart))
                ? secondLevelStart : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelEnd = (Quotes.CharValues.ContainsValue(secondLevelEnd))
                ? secondLevelEnd : Quotes.CharValues[default(Quotes.QuoteCharacter)];
        }

        public QuoteValuesContainer(Quotes.QuoteCharacter firstLevelStart, Quotes.QuoteCharacter firstLevelEnd)
        {
            FirstLevelStart = (Quotes.CharValues.ContainsKey(firstLevelStart))
                ? Quotes.CharValues[firstLevelStart] : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            FirstLevelEnd = (Quotes.CharValues.ContainsKey(firstLevelEnd))
                ? Quotes.CharValues[firstLevelEnd] : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelStart = Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelEnd = Quotes.CharValues[default(Quotes.QuoteCharacter)];
        }

        public QuoteValuesContainer(Quotes.QuoteCharacter firstLevelStart,
            Quotes.QuoteCharacter firstLevelEnd, Quotes.QuoteCharacter secondLevelStart, Quotes.QuoteCharacter secondLevelEnd)
        {
            FirstLevelStart = (Quotes.CharValues.ContainsKey(firstLevelStart))
                ? Quotes.CharValues[firstLevelStart] : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            FirstLevelEnd = (Quotes.CharValues.ContainsKey(firstLevelEnd))
                ? Quotes.CharValues[firstLevelEnd] : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelStart = (Quotes.CharValues.ContainsKey(secondLevelStart))
                ? Quotes.CharValues[secondLevelStart] : Quotes.CharValues[default(Quotes.QuoteCharacter)];

            SecondLevelEnd = (Quotes.CharValues.ContainsKey(secondLevelEnd))
                ? Quotes.CharValues[secondLevelEnd] : Quotes.CharValues[default(Quotes.QuoteCharacter)];
        }
    }

    public class OriginValuesContainer
    {
        public int X_Absolute { get; set; }
        public float X_Percent { get; set; }
        public int Y_Absolute { get; set; }
        public float Y_Percent { get; set; }

        public int Z_Absolute { get; set; }
    }

    public static class Origin
    {
        public enum X_Axis
        {
            Percent,
            Left,
            Center,
            Right,
            Length
        }

        public enum Y_Axis
        {
            Percent,
            Top,
            Center,
            Bottom,
            Length
        }
    }
}
