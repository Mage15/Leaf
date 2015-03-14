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
using System.Globalization;

namespace LeafStyle
{
    internal partial class Parser
    {
        internal class ColorParser
        {
            private string hexPattern = @"#(?<red>[0-9a-fA-F]{1,2})(?<green>[0-9a-fA-F]{1,2})(?<blue>[0-9a-fA-F]{1,2})";
            private string rgbPattern = @"rgb[\s]{0,1}\((?<red>[0-9]{1,3}),[\s]{0,1}(?<green>[0-9]{1,3}),[\s]{0,1}(?<blue>[0-9]{1,3})\)";
            private string rgbaPattern = @"rgba[\s]{0,1}\((?<red>[0-9]{1,3}),[\s]{0,1}(?<green>[0-9]{1,3}),[\s]{0,1}(?<blue>[0-9]{1,3}),[\s]{0,1}(?<alpha>[0-9]{0,1}[\.]{0,1}[0-9]*)\)";
            private string hslPattern = @"hsl[\s]{0,1}\((?<hue>[0-9]{1,3}),[\s]{0,1}(?<saturation>[0-9]{1,3})[%]?,[\s]{0,1}(?<lightness>[0-9]{1,3})[%]?\)";
            private string hslaPattern = @"hsla[\s]{0,1}\((?<hue>[0-9]{1,3}),[\s]{0,1}(?<saturation>[0-9]{1,3})[%]?,[\s]{0,1}(?<lightness>[0-9]{1,3})[%]?,[\s]{0,1}(?<alpha>[0-9]{0,1}[.]{0,1}[0-9]*)\)";

            internal bool TryColor(string value, out Microsoft.Xna.Framework.Color color)
            {
                if (value != null)
                {
                    try
                    {
                        // Check if we are working with a named color
                        if (Value.ColorContainer.Keys.Contains(value.ToLowerInvariant()))
                        {
                            color = Value.ColorContainer[value];
                            return true;
                        }
                        else
                        {
                            int red = 0, green = 0, blue = 0;
                            
                            /*************
                             * Hex Color *
                             *************/
                            var hexMatch = Regex.Match(value, hexPattern);
                            if (hexMatch.Success)
                            {
                                string groupRed = hexMatch.Groups["red"].Value;
                                string groupGreen = hexMatch.Groups["green"].Value;
                                string groupBlue = hexMatch.Groups["blue"].Value;

                                // If each value contains the same number of digits 
                                if (
                                    groupRed.Length == groupGreen.Length &&
                                    groupRed.Length == groupBlue.Length)
                                {
                                    // Do we need insert a second hex value. (i.e. DEF becomes DDEEFF)
                                    if (groupRed.Length == 1)
                                    {
                                        red = int.Parse(groupRed + groupRed, NumberStyles.HexNumber);
                                        green = int.Parse(groupGreen + groupGreen, NumberStyles.HexNumber);
                                        blue = int.Parse(groupBlue + groupBlue, NumberStyles.HexNumber);
                                    }
                                    else if (groupRed.Length == 2)
                                    {
                                        red = int.Parse(groupRed,NumberStyles.HexNumber);
                                        green = int.Parse(groupGreen, NumberStyles.HexNumber);
                                        blue = int.Parse(groupBlue, NumberStyles.HexNumber);
                                    }

                                    color = new Microsoft.Xna.Framework.Color(red, green, blue);
                                    return true;
                                }
                            }

                            /*************
                             * RGB Color *
                             *************/
                            var rgbMatch = Regex.Match(value, rgbPattern);
                            if (rgbMatch.Success)
                            {
                                red = int.Parse(rgbMatch.Groups["red"].Value);
                                green = int.Parse(rgbMatch.Groups["green"].Value);
                                blue = int.Parse(rgbMatch.Groups["blue"].Value);

                                // Check if any value exceeds max value
                                if (red > 255) { red = 255; }
                                if (green > 255) { green = 255; }
                                if(blue > 255) { blue = 255; }

                                // No need to check negative values since the regex won't accept a '-' in front 
                                // of a number

                                color = new Microsoft.Xna.Framework.Color(red, green, blue);

                                return true;
                            }

                            /**************
                             * RGBA Color *
                             **************/
                            var rgbaMatch = Regex.Match(value, rgbaPattern);
                            if (rgbaMatch.Success)
                            {
                                red = int.Parse(rgbaMatch.Groups["red"].Value);
                                green = int.Parse(rgbaMatch.Groups["green"].Value);
                                blue = int.Parse(rgbaMatch.Groups["blue"].Value);
                                float alpha = float.Parse(rgbaMatch.Groups["alpha"].Value);

                                // Check if any value exceeds max value
                                if (red > 255) { red = 255; }
                                if (green > 255) { green = 255; }
                                if (blue > 255) { blue = 255; }
                                if (alpha > 1) { alpha = 1.0f; }

                                // No need to check negative values since the regex won't accept a '-' in front 
                                // of a number

                                color = new Microsoft.Xna.Framework.Color(red, green, blue, alpha);

                                return true;
                            }

                            /*******
                             * HSL *
                             *******/
                            var hslMatch = Regex.Match(value, hslPattern);
                            if (hslMatch.Success)
                            { 
                                decimal h = (int.Parse(hslMatch.Groups["hue"].Value) / 360m); 
                                decimal s = (int.Parse(hslMatch.Groups["saturation"].Value) / 100m);
                                decimal l = (int.Parse(hslMatch.Groups["lightness"].Value) / 100m);

                                HslToRgb(h, s, l, out red, out green, out blue);
                                
                                color = new Microsoft.Xna.Framework.Color(red, green, blue);

                                return true;
                            }

                            /********
                             * HSLA *
                             ********/
                            var hslaMatch = Regex.Match(value, hslaPattern);
                            if (hslaMatch.Success)
                            {
                                decimal h = (int.Parse(hslaMatch.Groups["hue"].Value) / 360m);
                                decimal s = (int.Parse(hslaMatch.Groups["saturation"].Value) / 100m);
                                decimal l = (int.Parse(hslaMatch.Groups["lightness"].Value) / 100m);
                                float alpha = float.Parse(hslaMatch.Groups["alpha"].Value);

                                // Check if alpha exceeds max value
                                if (alpha > 1) { alpha = 1.0f; }

                                HslToRgb(h, s, l, out red, out green, out blue);

                                color = new Microsoft.Xna.Framework.Color(red, green, blue);

                                return true;
                            }
                        }
                    }
                    catch { }
                }

                // Something blew up somewhere so set to default color
                color = Microsoft.Xna.Framework.Color.Black;
                return false;
            }

            // Adapted from http://axonflux.com/handy-rgb-to-hsl-and-rgb-to-hsv-color-model-c
            delegate decimal hueConverter(decimal p, decimal q, decimal t);            
            private void HslToRgb(decimal h, decimal s, decimal l, out int red, out int green, out int blue)
            {
                decimal r, g, b;

                if(s == 0){
                    r = g = b = l; // achromatic
                }else{
                    hueConverter hue2rgb = (p, q, t) => {
                        if(t < 0) t += 1;
                        if(t > 1) t -= 1;
                        if (t < 1 / 6m) return p + (q - p) * 6 * t;
                        if (t < 1 / 2m) return q;
                        if (t < 2 / 3m) return p + (q - p) * (2 / 3m - t) * 6;
                        return p;
                    };

                    var sat = (l < 0.5m) ? l * (1 + s) : l + s - l * s;
                    var lum = 2 * l - sat;
                    r = hue2rgb(lum, sat, h + (1 / 3m));
                    g = hue2rgb(lum, sat, h);
                    b = hue2rgb(lum, sat, h - (1 / 3m));
                }

                red = (int)Math.Round(r * 255); 
                green = (int)Math.Round(g * 255); 
                blue = (int)Math.Round(b * 255);
            }
        }
    }
}
