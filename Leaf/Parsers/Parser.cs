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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeafStyle
{
    internal partial class Parser
    {
        /// <summary>
        /// Sets the StyleProperties and their values with the provided CSS string of property names and 
        /// desired values.
        /// </summary>
        /// <param name="styleObject"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        internal bool CSSSetProperty(Style styleObject, string value)
        {
            if (value != null)
            {
                const string Group_Property = "property";
                const string Group_Values = "values";
                const string cssPattern = @"(?<" + Group_Property + @">[a-zA-Z\-]+)\s*:\s*(?<" + Group_Values + @">[a-zA-Z1-9#\(\)\.\s\,]+)\s*;";
            
                Regex regex = new Regex(cssPattern, RegexOptions.ExplicitCapture);
                MatchCollection matchCollection = regex.Matches(value);

                foreach(Match match in matchCollection)
                {
                    string propName = Value.GetJSNameFromCSSName(match.Groups[Group_Property].Value);
                    
                    // Since float will not work as a property name it has been chaged to floating
                    if (propName == "float")
                    {
                        propName = "floating";
                    }

                    try
                    {
                        styleObject
                            .GetType()
                            .GetProperty(propName)
                            .SetValue(styleObject, match.Groups[Group_Values].Value);
                    }
                    catch { } // If setting one of the properties fails just keep going
                }

                return true;
            }

            // value was null
            return false;
        }
            
        // Animation
        internal bool TryAnimation(string values, out Dictionary<Property, string> animationValues)
        {
            animationValues = new Dictionary<Property, string>();

            animationValues.Add(Property.Animation, "");
            animationValues.Add(Property.AnimationDelay, "");
            animationValues.Add(Property.AnimationDirection, "");
            animationValues.Add(Property.AnimationDuration, "");
            animationValues.Add(Property.AnimationFillMode, "");
            animationValues.Add(Property.AnimationIterationCount, "");
            animationValues.Add(Property.AnimationName, "");
            animationValues.Add(Property.AnimationPlayState, "");
            animationValues.Add(Property.AnimationTimingFunction, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Background
        internal bool TryBackgroundValues(string values, out Dictionary<Property, string> backgroundValues)
        {
            backgroundValues = new Dictionary<Property, string>();

            backgroundValues.Add(Property.Background, "");
            backgroundValues.Add(Property.BackgroundAttachment, "");
            backgroundValues.Add(Property.BackgroundClip, "");
            backgroundValues.Add(Property.BackgroundColor, "");
            backgroundValues.Add(Property.BackgroundImage, "");
            backgroundValues.Add(Property.BackgroundOrigin, "");
            backgroundValues.Add(Property.BackgroundPosition, "");
            backgroundValues.Add(Property.BackgroundRepeat, "");
            backgroundValues.Add(Property.BackgroundSize, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Border
        internal bool TryBorderValues(string values, out Dictionary<Property, string> borderValues)
        {
            borderValues = new Dictionary<Property, string>();

            borderValues.Add(Property.Border, "");
            borderValues.Add(Property.BorderWidth, "");
            borderValues.Add(Property.BorderStyle, "");
            borderValues.Add(Property.BorderColor, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // BorderEdges
        internal bool TryBorderEdgeValues(string values, out Dictionary<string, string> borderEdgeValues)
        {
            borderEdgeValues = new Dictionary<string, string>();

            borderEdgeValues.Add("borderEdge", "");
            borderEdgeValues.Add("borderEdgeWidth", "");
            borderEdgeValues.Add("borderEdgeStyle", "");
            borderEdgeValues.Add("borderEdgeColor", "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // BorderColors
        internal bool TryBorderColorValues(string values, out Dictionary<Property, string> borderColorValues)
        {
            borderColorValues = new Dictionary<Property, string>();

            borderColorValues.Add(Property.BorderColor, "");
            borderColorValues.Add(Property.BorderTopColor, "");
            borderColorValues.Add(Property.BorderLeftColor, "");
            borderColorValues.Add(Property.BorderBottomColor, "");
            borderColorValues.Add(Property.BorderRightColor, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // BorderRadii
        internal bool TryBorderRadiusValues(string values, out Dictionary<Property, string> borderRadiusValues)
        {
            borderRadiusValues = new Dictionary<Property, string>();

            borderRadiusValues.Add(Property.BorderRadius, "");
            borderRadiusValues.Add(Property.BorderTopLeftRadius, "");
            borderRadiusValues.Add(Property.BorderTopRightRadius, "");
            borderRadiusValues.Add(Property.BorderBottomLeftRadius, "");
            borderRadiusValues.Add(Property.BorderBottomRightRadius, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // BorderWidths
        internal bool TryBorderWidthValues(string values, out Dictionary<Property, string> borderWidthValues)
        {
            borderWidthValues = new Dictionary<Property, string>();

            borderWidthValues.Add(Property.BorderWidth, "");
            borderWidthValues.Add(Property.BorderTopWidth, "");
            borderWidthValues.Add(Property.BorderLeftWidth, "");
            borderWidthValues.Add(Property.BorderRightWidth, "");
            borderWidthValues.Add(Property.BorderLeftWidth, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // ColumnRule
        internal bool TryColumnRule(string values, out Dictionary<Property, string> columnRuleValues)
        {
            columnRuleValues = new Dictionary<Property, string>();

            columnRuleValues.Add(Property.ColumnRule, "");
            columnRuleValues.Add(Property.ColumnRuleColor, "");
            columnRuleValues.Add(Property.ColumnRuleStyle, "");
            columnRuleValues.Add(Property.ColumnRuleWidth, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Columns
        internal bool TryColumns(string values, out Dictionary<Property, string> columnsValues)
        {
            columnsValues = new Dictionary<Property, string>();

            columnsValues.Add(Property.Columns, "");
            columnsValues.Add(Property.ColumnWidth, "");
            columnsValues.Add(Property.ColumnCount, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Flex
        internal bool TryFlex(string values, out Dictionary<Property, string> flexValues)
        {
            flexValues = new Dictionary<Property, string>();

            flexValues.Add(Property.Flex, "");
            flexValues.Add(Property.FlexGrow, "");
            flexValues.Add(Property.FlexShrink, "");
            flexValues.Add(Property.FlexBasis, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // FlexFlow
        internal bool TryFlexFlow(string values, out Dictionary<Property, string> flexFlowValues)
        {
            flexFlowValues = new Dictionary<Property, string>();

            flexFlowValues.Add(Property.FlexFlow, "");
            flexFlowValues.Add(Property.FlexDirection, "");
            flexFlowValues.Add(Property.FlexWrap, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Font
        internal bool TryFont(string values, out Dictionary<Property, string> fontValues)
        {
            fontValues = new Dictionary<Property, string>();

            fontValues.Add(Property.Font, "");
            fontValues.Add(Property.FontStyle, "");
            fontValues.Add(Property.FontVariant, "");
            fontValues.Add(Property.FontWeight, "");
            fontValues.Add(Property.FontSize, "");
            fontValues.Add(Property.FontFamily, "");
            fontValues.Add(Property.LineHeight, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // ListStyle
        internal bool TryListStyle(string values, out Dictionary<Property, string> listStyleValues)
        {
            listStyleValues = new Dictionary<Property, string>();

            listStyleValues.Add(Property.ListStyle, "");
            listStyleValues.Add(Property.ListStyleImage, "");
            listStyleValues.Add(Property.ListStylePosition, "");
            listStyleValues.Add(Property.ListStyleType, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Margin
        internal bool TryMargin(string values, out Dictionary<Property, string> marginValues)
        {
            marginValues = new Dictionary<Property, string>();

            marginValues.Add(Property.Margin, "");
            marginValues.Add(Property.MarginBottom, "");
            marginValues.Add(Property.MarginLeft, "");
            marginValues.Add(Property.MarginRight, "");
            marginValues.Add(Property.MarginTop, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Outline
        internal bool TryOutline(string values, out Dictionary<Property, string> outlineValues)
        {
            outlineValues = new Dictionary<Property, string>();

            outlineValues.Add(Property.Outline, "");
            outlineValues.Add(Property.OutlineColor, "");
            outlineValues.Add(Property.OutlineStyle, "");
            outlineValues.Add(Property.OutlineWidth, "");

            if (!String.IsNullOrEmpty(values))
            {

                // Use Regex for parse

                return true;
            }

            // Couldn't parse                
            return false;
        }

        // Padding
        internal bool TryPadding(string values, out Dictionary<Property, string> paddingValues)
        {
            throw new NotImplementedException();
        }

        // Transition
        internal bool TryTransition(string values, out Dictionary<Property, string> transitionValues)
        {
            throw new NotImplementedException();
        }
    }

}