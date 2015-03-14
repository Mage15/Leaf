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

using System.Collections.Generic;

namespace LeafStyle
{
    public class ListStyleTypeProperty : BasicStyleProperty<ListStyleTypeState>
    {
        public ListStyleTypeProperty()
            : base(
                defaultState: default(ListStyleTypeState),
                inherited: true,
                animatable: false
            )
        {
            this.StateValues = new Dictionary<string, ListStyleTypeState>()
                {
                    {"disc", ListStyleTypeState.Disc},
                    {"armenian", ListStyleTypeState.Armenian},
                    {"circle", ListStyleTypeState.Circle},
                    {"cjk-ideographic", ListStyleTypeState.CJK_Ideographic},
                    {"decimal", ListStyleTypeState.Decimal},
                    {"decimal-leading-zero", ListStyleTypeState.DecimalLeadingZero},
                    {"georgian", ListStyleTypeState.Georgian},
                    {"hebrew", ListStyleTypeState.Hebrew},
                    {"hiragana", ListStyleTypeState.Hiragana},
                    {"hiragana-iroha", ListStyleTypeState.HiraganaIroha},
                    {"katakana", ListStyleTypeState.Katakana},
                    {"katakana-iroha", ListStyleTypeState.KatakanaIroha},
                    {"lower-alpha", ListStyleTypeState.LowerAlpha},
                    {"lower-greek", ListStyleTypeState.LowerGreek},
                    {"lower-latin", ListStyleTypeState.LowerLatin},
                    {"lower-roman", ListStyleTypeState.LowerRoman},
                    {"none", ListStyleTypeState.None},
                    {"square", ListStyleTypeState.Square},
                    {"upper-alpha", ListStyleTypeState.UpperAlpha},
                    {"upper-latin", ListStyleTypeState.UpperLatin},
                    {"upper-roman", ListStyleTypeState.UpperRoman},
                    {"initial", ListStyleTypeState.Initial},
                    {"inherit", ListStyleTypeState.Inherit}
                };
        }
    }
}