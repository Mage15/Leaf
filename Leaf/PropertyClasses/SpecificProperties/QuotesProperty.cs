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
    internal class QuotesProperty : BasicStyleProperty<QuotesState>
    {
        public QuoteValuesContainer Values { get; set; }

        public QuotesProperty()
            : base(
                defaultState: default(QuotesState),
                inherited: true,
                animatable: false
                )
        {
            this.StateValues = new Dictionary<string, QuotesState>
                {
                    {"none", QuotesState.None}, 
                    {"use-values", QuotesState.UseValues}, 
                    {"initial", QuotesState.Initial},
                    {"inhert", QuotesState.Inherit }
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
                string[] valueArray = value.Split(new char[] { ' ' });
                foreach (string str in valueArray)
                {
                    if (valueArray.Length == 4)
                    {
                        this.Values = new QuoteValuesContainer(
                            valueArray[0][0], valueArray[1][0], valueArray[2][0], valueArray[3][0]);
                        this.CurrentState = QuotesState.UseValues;

                        return true;
                    }
                    else if (valueArray.Length == 2)
                    {
                        this.Values = new QuoteValuesContainer(
                            valueArray[0][0], valueArray[1][0]);
                        this.CurrentState = QuotesState.UseValues;

                        return true;
                    }
                }
            }

            // Couldn't parse
            return false;
        }

        public override bool TrySetValue(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(QuoteValuesContainer))
                {
                    this.Values = (QuoteValuesContainer)value;
                    this.CurrentState = QuotesState.UseValues;

                    return true;
                }
            }

            return false;
        }
    }
}