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
        internal class StringParser
        {
            internal bool TryImageName(string value, out string imageName)
            {
                imageName = "";

                // Parse value string and image name

                if (!String.IsNullOrEmpty(imageName))
                {
                    return true;
                }

                return false;
            }

            internal bool TryStringList(string value, out List<string> propertyNames)
            {
                throw new NotImplementedException();
            }

            internal bool TryUrl(string value, out string urlString)
            {
                if (value != null && value.Contains("url"))
                {
                    if (value.Contains("(") && value.Contains(")"))
                    {
                        urlString = value.Substring(value.IndexOf("(") + 1, value.IndexOf(")") - value.IndexOf("(") - 1);
                        return true;
                    }
                }

                // Could not parse
                urlString = "";
                return false;
            }
        }
    }
}
