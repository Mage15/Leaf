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

using System;

namespace LeafStyle
{
    internal partial class Parser
    {
        internal class QuadValuesParser
        {
            internal bool TryQuadValues<TState>(string value, out QuadValues<TState> quadValues)
            where TState : struct, IConvertible
            {
                if (value != null)
                {
                    string[] strValues = value.Split(new char[] { ' ' });
                    if (strValues.Length > 0)
                    {
                        TState[] valuesArray = new TState[strValues.Length];

                        if (typeof(TState) == typeof(int))
                        {
                            for (int i = 0; i < strValues.Length; i++)
                            {
                                int intValue;

                                // If value at strValues[i] contains "px" remove before parse.
                                if (strValues[i].Contains("px"))
                                {
                                    // If parse fails break for loop                                    
                                    if (int.TryParse(strValues[i].Remove(strValues[i].IndexOf("px")), out intValue))
                                    {
                                        // We know we are working with integer values
                                        valuesArray[i] = (dynamic)intValue;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else if (int.TryParse(strValues[i], out intValue))
                                {
                                    // We know we are working with integer values
                                    valuesArray[i] = (dynamic)intValue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (typeof(TState) == typeof(float))
                        {
                            for (int i = 0; i < strValues.Length; i++)
                            {
                                float floatValue;

                                // If value at strValues[i] contains "%" remove before parse.
                                if (strValues[i].Contains("%"))
                                {
                                    // If parse fails break for loop                                    
                                    if (float.TryParse(strValues[i].Remove(strValues[i].IndexOf("%")), out floatValue))
                                    {
                                        // We know we are working with float values
                                        valuesArray[i] = (dynamic)floatValue;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else if (float.TryParse(strValues[i], out floatValue))
                                {
                                    // We know we are working with float values
                                    valuesArray[i] = (dynamic)floatValue;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        else if (typeof(TState) == typeof(short))
                        {
                            for (int i = 0; i < strValues.Length; i++)
                            {
                                short shortValue;

                                if (short.TryParse(strValues[i], out shortValue))
                                {
                                    // We know we are working with short values
                                    valuesArray[i] = (dynamic)shortValue;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }

                        // set quadValues based on the number of int in the valuesArray
                        if (valuesArray.Length == 4)
                        {
                            quadValues = new QuadValues<TState>(valuesArray[0], valuesArray[1], valuesArray[2], valuesArray[3]);
                            return true;
                        }
                        else if (valuesArray.Length == 3)
                        {
                            quadValues = new QuadValues<TState>(valuesArray[0], valuesArray[1], valuesArray[2]);
                            return true;
                        }
                        else if (valuesArray.Length == 2)
                        {
                            quadValues = new QuadValues<TState>(valuesArray[0], valuesArray[1]);
                            return true;
                        }
                        else if (valuesArray.Length == 1)
                        {
                            quadValues = new QuadValues<TState>(valuesArray[0]);
                            return true;
                        }
                    }
                }

                // Could not be parsed
                quadValues = new QuadValues<TState>();
                return false;
            }
        }
    }
}
