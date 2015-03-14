/* 
    Copyright (C) 2015  Matthew Gefaller
    This file is part of LeafStyle.

    LeafStyle is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LeafStyle is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LeafStyle.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace LeafStyle
{
    public partial class Style
    {

        private ContentManager ContentManager;
        private Dictionary<Property, StyleProperty> StyleProperties;
        private Parser parser;
        
        public Style(ContentManager contentManager)
        {
            Initialize(contentManager);
        }


        private void Initialize(ContentManager contentManager)
        {
            this.ContentManager = contentManager;
            this.StyleProperties = new Dictionary<Property, StyleProperty>();
            parser = new Parser();
        }

        /// <summary>
        /// Takes a string array where the each index is a string in the proper CSS format.
        /// Example( background-size: auto; )
        /// </summary>
        /// <param name="propertyAnValues"></param>
        /// <returns></returns>
        public bool SetPropertiesFromCSS(string cssString)
        {
            return parser.CSSSetProperty(this, cssString);
        }

        private void AddOrOverwrite(Property key, StyleProperty Property)
        {
            if (Property != null)
            {
                if (this.StyleProperties.ContainsKey(key))
                {
                    this.StyleProperties[key] = Property;
                }
                else
                {
                    this.StyleProperties.Add(key, Property);
                }
            }
        }

        // When given a Property and a value a new instance of the associated Property type is created,
        // the value is assigned to the new instance, and it is stored.
        private void SetProperty(Property property, string value)
        {
            if (value != null)
            {
                Type newType;
                if(Value.GetPropertyType(property, out newType)) // If type is returned
                {
                    try
                    {
                        // Create new instance of type
                        var newProperty = Activator.CreateInstance(newType);

                        if (((dynamic)newProperty).TrySetStateValue(value)) // If the value is successfully set
                        {
                            this.AddOrOverwrite(property, (StyleProperty)newProperty);
                        }
                    }
                    catch { }
                }
            }
        }

        // Attempts a call on the properties LoadImage method
        private bool LoadImage(Property property)
        {
            try
            {
                return ((dynamic)StyleProperties[property]).LoadImage(ContentManager);
            }
            catch
            {
                return false;
            }
        }

        #region Javascript Properties
        
        public string alignContent { set { this.SetProperty(Property.AlignContent, value); } }
        
        public string alignItems { set { this.SetProperty(Property.AlignItems, value); } }
        
        public string alignSelf { set { this.SetProperty(Property.AlignSelf, value); } }

        public string animation
        {
            set
            {
                Dictionary<Property, string> animationValues;
                if (this.parser.TryAnimation(value, out animationValues))
                {
                    this.SetProperty(Property.Animation, animationValues[Property.Animation]);

                    this.animationName = animationValues[Property.AnimationName];
                    this.animationDuration = animationValues[Property.AnimationDuration];
                    this.animationTimingFunction = animationValues[Property.AnimationTimingFunction];
                    this.animationDelay = animationValues[Property.AnimationDelay];
                    this.animationIterationCount = animationValues[Property.AnimationIterationCount];
                    this.animationDirection = animationValues[Property.AnimationDirection];
                    this.animationFillMode = animationValues[Property.AnimationFillMode];
                    this.animationPlayState = animationValues[Property.AnimationPlayState];
                }
            }
        }

        public string animationDelay { set { SetProperty(Property.AnimationDelay, value); }       }

        public string animationDirection { set { SetProperty(Property.AnimationDirection, value); } }

        public string animationDuration { set { SetProperty(Property.AnimationDuration, value); } }

        public string animationFillMode { set { SetProperty(Property.AnimationFillMode, value); } }

        public string animationIterationCount { set { SetProperty(Property.AnimationIterationCount, value); } }

        public string animationName { set { SetProperty(Property.AnimationName, value); } }

        public string animationPlayState { set { SetProperty(Property.AnimationPlayState, value); } }

        public string animationTimingFunction { set { SetProperty(Property.AnimationTimingFunction, value); } }

        public string backfaceVisibility { set { SetProperty(Property.BackfaceVisibility, value); } }

        public string background
        {
            set
            {
                Dictionary<Property, string> backgroundValues;
                if(this.parser.TryBackgroundValues(value, out backgroundValues))
                {
                    SetProperty(Property.Background, backgroundValues[Property.Background]);

                    this.backgroundColor = backgroundValues[Property.BackgroundColor];
                    this.backgroundPosition = backgroundValues[Property.BackgroundPosition];
                    this.backgroundSize = backgroundValues[Property.BackgroundSize];
                    this.backgroundRepeat = backgroundValues[Property.BackgroundRepeat];
                    this.backgroundOrigin = backgroundValues[Property.BackgroundOrigin];
                    this.backgroundClip = backgroundValues[Property.BackgroundClip];
                    this.backgroundAttachment = backgroundValues[Property.BackgroundAttachment];
                    this.backgroundImage = backgroundValues[Property.BackgroundImage];
                }
            }
        }

        public string backgroundAttachment { set { SetProperty(Property.BackgroundAttachment, value); } }

        public string backgroundClip { set { SetProperty(Property.BackgroundClip, value); } }

        public string backgroundColor { set { SetProperty(Property.BackgroundColor, value); } }

        public string backgroundImage { set { SetProperty(Property.BackgroundImage, value); } }

        public string backgroundOrigin { set { SetProperty(Property.BackgroundOrigin, value); } }

        public string backgroundPosition { set { SetProperty(Property.BackgroundPosition, value); } }

        public string backgroundRepeat { set { SetProperty(Property.BackgroundRepeat, value); } }

        public string backgroundSize { set { SetProperty(Property.BackgroundSize, value); } }

        public string border
        {
            set
            {
                Dictionary<Property, string> borderValues;
                if (this.parser.TryBorderValues(value, out borderValues))
                {
                    SetProperty(Property.Border, borderValues[Property.Border]);

                    this.borderWidth = borderValues[Property.BorderWidth];
                    this.borderStyle = borderValues[Property.BorderStyle];
                    this.borderColor = borderValues[Property.BorderColor];
                }
            }
        }

        public string borderBottom
        {
            set
            {
                Dictionary<string, string> borderBottomValues;
                if (this.parser.TryBorderEdgeValues(value, out borderBottomValues))
                {
                    SetProperty(Property.BorderBottom, borderBottomValues["borderEdge"]);

                    this.borderBottomWidth = borderBottomValues["borderEdgeWidth"];
                    this.borderBottomStyle = borderBottomValues["borderEdgeStyle"];
                    this.borderBottomColor = borderBottomValues["borderEdgeColor"];
                }
            }
        }

        public string borderBottomColor { set { SetProperty(Property.BorderBottomColor, value); } }

        public string borderBottomLeftRadius { set { SetProperty(Property.BorderBottomLeftRadius, value); } }

        public string borderBottomRightRadius { set { SetProperty(Property.BorderBottomRightRadius, value); } }

        public string borderBottomStyle { set { SetProperty(Property.BorderBottomStyle, value); } }

        public string borderBottomWidth { set { SetProperty(Property.BorderBottomWidth, value); } }

        public string borderCollapse { set { SetProperty(Property.BorderCollapse, value); } }

        public string borderColor
        {
            set
            {
                Dictionary<Property, string> borderColorValues;
                if (this.parser.TryBorderColorValues(value, out borderColorValues))
                {
                    SetProperty(Property.BorderColor, borderColorValues[Property.BorderColor]);

                    this.borderTopColor = borderColorValues[Property.BorderTopColor];
                    this.borderLeftColor = borderColorValues[Property.BorderLeftColor];
                    this.borderBottomColor = borderColorValues[Property.BorderBottomColor];
                    this.borderRightColor = borderColorValues[Property.BorderRightColor];
                }
            }
        }

        public string borderImage { set { SetProperty(Property.BorderImage, value); } }

        public string borderImageOutset { set { SetProperty(Property.BorderImageOutset, value); } }

        public string borderImageRepeat { set { SetProperty(Property.BorderImageRepeat, value); } }

        public string borderImageSlice { set { SetProperty(Property.BorderImageSlice, value); } }

        public string borderImageSource { set { SetProperty(Property.BorderImageSource, value); } }

        public string borderImageWidth { set { SetProperty(Property.BorderImageWidth, value); } }

        public string borderLeft
        {
            set
            {
                Dictionary<string, string> borderLeftValues;
                if (this.parser.TryBorderEdgeValues(value, out borderLeftValues))
                {
                    SetProperty(Property.BorderLeft, borderLeftValues["borderEdge"]);

                    this.borderLeftWidth = borderLeftValues["borderEdgeWidth"];
                    this.borderLeftStyle = borderLeftValues["borderEdgeStyle"];
                    this.borderLeftColor = borderLeftValues["borderEdgeColor"];
                }
            }
        }

        public string borderLeftColor { set { SetProperty(Property.BorderLeftColor, value); } }

        public string borderLeftStyle { set { SetProperty(Property.BorderLeftStyle, value); } }

        public string borderLeftWidth { set { SetProperty(Property.BorderLeftWidth, value); } }

        public string borderRadius 
        { 
            set 
            {
                Dictionary<Property, string> borderRadiusValues;
                if (this.parser.TryBorderRadiusValues(value, out borderRadiusValues))
                {
                    SetProperty(Property.BorderRadius, borderRadiusValues[Property.BorderRadius]);

                    this.borderBottomLeftRadius = borderRadiusValues[Property.BorderBottomLeftRadius];
                    this.borderBottomRightRadius = borderRadiusValues[Property.BorderBottomRightRadius];
                    this.borderTopLeftRadius = borderRadiusValues[Property.BorderTopLeftRadius];
                    this.borderTopRightRadius = borderRadiusValues[Property.BorderTopRightRadius];
                }
            } 
        }

        public string borderRight
        {
            set
            {
                Dictionary<string, string> borderRightValues;
                if (this.parser.TryBorderEdgeValues(value, out borderRightValues))
                {
                    SetProperty(Property.BorderRight, borderRightValues["borderEdge"]);

                    this.borderRightWidth = borderRightValues["borderEdgeWidth"];
                    this.borderRightStyle = borderRightValues["borderEdgeStyle"];
                    this.borderRightColor = borderRightValues["borderEdgeColor"];
                }
            }
        }

        public string borderRightColor { set { SetProperty(Property.BorderRightColor, value); } }

        public string borderRightStyle { set { SetProperty(Property.BorderRightStyle, value); } }

        public string borderRightWidth { set { SetProperty(Property.BorderRightWidth, value); } }

        public string borderSpacing { set { SetProperty(Property.BorderSpacing, value); } }

        public string borderStyle { set { SetProperty(Property.BorderStyle, value); } }

        public string borderTop
        {
            set
            {
                Dictionary<string, string> borderTopValues;
                if (this.parser.TryBorderEdgeValues(value, out borderTopValues))
                {
                    SetProperty(Property.BorderTop, borderTopValues["borderEdge"]);

                    this.borderTopWidth = borderTopValues["borderEdgeWidth"];
                    this.borderTopStyle = borderTopValues["borderEdgeStyle"];
                    this.borderTopColor = borderTopValues["borderEdgeColor"];
                }
            }
        }

        public string borderTopColor { set { SetProperty(Property.BorderTopColor, value); } }

        public string borderTopLeftRadius { set { SetProperty(Property.BorderTopLeftRadius, value); } }

        public string borderTopRightRadius { set { SetProperty(Property.BorderTopRightRadius, value); } }

        public string borderTopStyle { set { SetProperty(Property.BorderTopStyle, value); } }

        public string borderTopWidth { set { SetProperty(Property.BorderTopWidth, value); } }

        public string borderWidth
        {
            set
            {
                Dictionary<Property, string> borderWidthValues;
                if (this.parser.TryBorderWidthValues(value, out borderWidthValues))
                {
                    SetProperty(Property.BorderTop, borderWidthValues[Property.BorderWidth]);

                    this.borderTopWidth = borderWidthValues[Property.BorderTopWidth];
                    this.borderLeftWidth = borderWidthValues[Property.BorderLeftWidth];
                    this.borderBottomWidth = borderWidthValues[Property.BorderBottomWidth];
                    this.borderRightWidth = borderWidthValues[Property.BorderRightWidth];
                }
            }
        }

        public string bottom { set { SetProperty(Property.Bottom, value); } }

        public string boxShadow { set { SetProperty(Property.BoxShadow, value); } }

        public string boxSizing { set { SetProperty(Property.BoxSizing, value); } }

        public string captionSide { set { SetProperty(Property.CaptionSide, value); } }

        public string clear { set { SetProperty(Property.Clear, value); } }

        public string clip { set { SetProperty(Property.Clip, value); } }

        public string color { set { SetProperty(Property.Color, value); } }

        public string columns 
        { 
            set 
            {
                Dictionary<Property, string> columnsValues;
                if (this.parser.TryColumns(value, out columnsValues))
                {
                    SetProperty(Property.Columns, columnsValues[Property.Columns]);

                    this.columnWidth = columnsValues[Property.ColumnWidth];
                    this.columnCount = columnsValues[Property.ColumnCount];
                }
            } 
        }

        public string columnCount { set { SetProperty(Property.ColumnCount, value); } }

        public string columnFill { set { SetProperty(Property.ColumnFill, value); } }

        public string columnGap { set { SetProperty(Property.ColumnGap, value); } }

        public string columnRule 
        { 
            set
            {
                Dictionary<Property, string> columnRuleValues;
                if (this.parser.TryColumnRule(value, out columnRuleValues))
                {
                    SetProperty(Property.ColumnRule, columnRuleValues[Property.ColumnRule]);

                    this.columnRuleColor = columnRuleValues[Property.ColumnRuleColor];
                    this.columnRuleStyle = columnRuleValues[Property.ColumnRuleStyle];
                    this.columnRuleWidth = columnRuleValues[Property.ColumnRuleWidth];
                }
            } 
        }

        public string columnRuleColor { set { SetProperty(Property.ColumnRuleColor, value); } }

        public string columnRuleStyle { set { SetProperty(Property.ColumnRuleStyle, value); } }

        public string columnRuleWidth { set { SetProperty(Property.ColumnRuleWidth, value); } }

        public string columnSpan { set { SetProperty(Property.ColumnSpan, value); } }

        public string columnWidth { set { SetProperty(Property.ColumnWidth, value); } }

        public string content { set { SetProperty(Property.Content, value); } }

        public string counterIncrement { set { SetProperty(Property.CounterIncrement, value); } }

        public string counterReset { set { SetProperty(Property.CounterReset, value); } }

        public string cursor 
        { 
            set 
            { 
                SetProperty(Property.Cursor, value);
                LoadImage(Property.Cursor);
            } 
        }

        public string direction { set { SetProperty(Property.Direction, value); } }

        public string display { set { SetProperty(Property.Display, value); } }

        public string emptyCells { set { SetProperty(Property.EmptyCells, value); } }

        public string flex 
        { 
            set 
            {
                Dictionary<Property, string> flexValues;
                if (this.parser.TryFlex(value, out flexValues))
                {
                    SetProperty(Property.Flex, flexValues[Property.Flex]);

                    this.flexGrow = flexValues[Property.FlexGrow];
                    this.flexShrink = flexValues[Property.FlexShrink];
                    this.flexBasis = flexValues[Property.FlexBasis];
                }
            } 
        }

        public string flexBasis { set { SetProperty(Property.FlexBasis, value); } }

        public string flexDirection { set { SetProperty(Property.FlexDirection, value); } }

        public string flexFlow 
        { 
            set 
            {
                Dictionary<Property, string> flexFlowValues;
                if (this.parser.TryFlexFlow(value, out flexFlowValues))
                {
                    SetProperty(Property.FlexFlow, flexFlowValues[Property.FlexFlow]);

                    this.flexDirection = flexFlowValues[Property.FlexDirection];
                    this.flexWrap = flexFlowValues[Property.FlexWrap];
                }
            } 
        }

        public string flexGrow { set { SetProperty(Property.FlexGrow, value); } }

        public string flexShrink { set { SetProperty(Property.FlexShrink, value); } }

        public string flexWrap { set { SetProperty(Property.FlexWrap, value); } }

        // the float property had to be changed to floating
        public string floating { set { SetProperty(Property.Float, value); } }

        public string font 
        { 
            set 
            {
                Dictionary<Property, string> fontValues;
                if(this.parser.TryFont(value, out fontValues))
                {
                    SetProperty(Property.Font, fontValues[Property.Font]);

                    this.fontStyle = fontValues[Property.FontStyle];
                    this.fontVariant = fontValues[Property.FontVariant];
                    this.fontWeight = fontValues[Property.FontWeight];
                    this.fontSize = fontValues[Property.FontSize];
                    this.fontFamily = fontValues[Property.FontFamily];
                    this.lineHeight = fontValues[Property.LineHeight];
                }
            } 
        }

        public string fontFace { set { SetProperty(Property.FontFace, value); } }

        public string fontFamily { set { SetProperty(Property.FontFamily, value); } }

        public string fontSize { set { SetProperty(Property.FontSize, value); } }

        public string fontSizeAdjust { set { SetProperty(Property.FontSizeAdjust, value); } }

        public string fontStretch { set { SetProperty(Property.FontStretch, value); } }

        public string fontStyle { set { SetProperty(Property.FontStyle, value); } }

        public string fontVariant { set { SetProperty(Property.FontVariant, value); } }

        public string fontWeight { set { SetProperty(Property.FontWeight, value); } }

        public string hangingPunctuation { set { SetProperty(Property.HangingPunctuation, value); } }

        public string height { set { SetProperty(Property.Height, value); } }

        public string icon 
        { 
            set 
            { 
                SetProperty(Property.Icon, value);
                LoadImage(Property.Icon);
            } 
        }

        public string justifyContent { set { SetProperty(Property.JustifyContent, value); } }

        public string keyframes { set { SetProperty(Property.Keyframes, value); } }

        public string left { set { SetProperty(Property.Left, value); } }

        public string letterSpacing { set { SetProperty(Property.LetterSpacing, value); } }

        public string lineHeight { set { SetProperty(Property.LineHeight, value); } }

        public string listSyle 
        { 
            set 
            {
                Dictionary<Property, string> listStyleValues;
                if (this.parser.TryListStyle(value, out listStyleValues))
                {
                    SetProperty(Property.ListStyle, listStyleValues[Property.ListStyle]);

                    this.listStyleImage = listStyleValues[Property.ListStyleImage];
                    this.listStylePosition = listStyleValues[Property.ListStylePosition];
                    this.listStyleType = listStyleValues[Property.ListStyleType];
                }
            } 
        }

        public string listStyleImage { set { SetProperty(Property.ListStyleImage, value); } }

        public string listStylePosition { set { SetProperty(Property.ListStylePosition, value); } }

        public string listStyleType { set { SetProperty(Property.ListStyleType, value); } }

        public string margin 
        {
            set
            {
                Dictionary<Property, string> marginValues;
                if (this.parser.TryMargin(value, out marginValues))
                {
                    SetProperty(Property.Margin, marginValues[Property.Margin]);

                    this.marginBottom = marginValues[Property.MarginBottom];
                    this.marginLeft = marginValues[Property.MarginLeft];
                    this.marginRight = marginValues[Property.MarginRight];
                    this.marginTop = marginValues[Property.MarginTop];
                }
            }
        }

        public string marginBottom { set { SetProperty(Property.MarginBottom, value); } }

        public string marginLeft { set { SetProperty(Property.MarginLeft, value); } }

        public string marginRight { set { SetProperty(Property.MarginRight, value); } }

        public string marginTop { set { SetProperty(Property.MarginTop, value); } }

        public string maxHeight { set { SetProperty(Property.MaxHeight, value); } }

        public string maxWidth { set { SetProperty(Property.MaxWidth, value); } }

        public string minHeight { set { SetProperty(Property.MinHeight, value); } }

        public string minWidth { set { SetProperty(Property.MinWidth, value); } }

        public string navDown { set { SetProperty(Property.NavDown, value); } }

        public string navIndex { set { SetProperty(Property.NavIndex, value); } }

        public string navLeft { set { SetProperty(Property.NavLeft, value); } }

        public string navRight { set { SetProperty(Property.NavRight, value); } }

        public string navUp { set { SetProperty(Property.NavUp, value); } }

        public string opacity { set { SetProperty(Property.Opacity, value); } }

        public string order { set { SetProperty(Property.Order, value); } }

        public string outline 
        {
            set
            {
                Dictionary<Property, string> outlineValues;
                if(this.parser.TryOutline(value, out outlineValues))
                {
                    SetProperty(Property.Outline, outlineValues[Property.Outline]);

                    this.outlineColor = outlineValues[Property.OutlineColor];
                    this.outlineStyle = outlineValues[Property.OutlineStyle];
                    this.outlineWidth = outlineValues[Property.OutlineWidth];
                }
            }
        }

        public string outlineColor { set { SetProperty(Property.OutlineColor, value); } }

        public string oulineOffset { set { SetProperty(Property.OutlineOffset, value); } }

        public string outlineStyle { set { SetProperty(Property.OutlineStyle, value); } }

        public string outlineWidth { set { SetProperty(Property.OutlineWidth, value); } }

        public string overflow { set { SetProperty(Property.Overflow, value); } }

        public string overflowX { set { SetProperty(Property.OverflowX, value); } }

        public string overflowY { set { SetProperty(Property.OverflowY, value); } }

        public string padding
        {
            set
            {
                Dictionary<Property, string> paddingValues;
                if (this.parser.TryPadding(value, out paddingValues))
                {
                    SetProperty(Property.Padding, paddingValues[Property.Padding]);

                    this.paddingBottom = paddingValues[Property.PaddingBottom];
                    this.paddingLeft = paddingValues[Property.PaddingLeft];
                    this.paddingRight = paddingValues[Property.PaddingRight];
                    this.paddingTop = paddingValues[Property.PaddingTop];
                }
            }
        }

        public string paddingBottom { set { SetProperty(Property.PaddingBottom, value); } }

        public string paddingLeft { set { SetProperty(Property.PaddingLeft, value); } }

        public string paddingRight { set { SetProperty(Property.PaddingRight, value); } }

        public string paddingTop { set { SetProperty(Property.PaddingTop, value); } }

        public string pageBreakAfter { set { SetProperty(Property.PageBreakAfter, value); } }

        public string pageBreakBefore { set { SetProperty(Property.PageBreakBefore, value); } }

        public string pageBreakInside { set { SetProperty(Property.PageBreakInside, value); } }

        public string perspective { set { SetProperty(Property.Perspective, value); } }

        public string perspectiveOrigin { set { SetProperty(Property.PerspectiveOrigin, value); } }

        public string position { set { SetProperty(Property.Position, value); } }

        public string quotes { set { SetProperty(Property.Quotes, value); } }

        public string resize { set { SetProperty(Property.Resize, value); } }

        public string right { set { SetProperty(Property.Right, value); } }

        public string tabSize { set { SetProperty(Property.TabSize, value); } }

        public string tableLayout { set { SetProperty(Property.TableLayout, value); } }

        public string textAlign { set { SetProperty(Property.TextAlign, value); } }

        public string textAlignLast { set { SetProperty(Property.TextAlignLast, value); } }

        public string textDecoration { set { SetProperty(Property.TextDecoration, value); } }

        public string textDecorationColor { set { SetProperty(Property.TextDecorationColor, value); } }

        public string textDecorationLine { set { SetProperty(Property.TextDecorationLine, value); } }

        public string textIndent { set { SetProperty(Property.TextIndent, value); } }

        public string textJustify { set { SetProperty(Property.TextJustify, value); } }

        public string textOverflow { set { SetProperty(Property.TextOverflow, value); } }

        public string textShadow { set { SetProperty(Property.TextShadow, value); } }

        public string textTransform { set { SetProperty(Property.TextTransform, value); } }

        public string top { set { SetProperty(Property.Top, value); } }

        public string transform { set { SetProperty(Property.Transform, value); } }

        public string transformOrigin { set { SetProperty(Property.TransformOrigin, value); } }

        public string transformStyle { set { SetProperty(Property.TransformStyle, value); } }

        public string transition 
        {
            set
            {
                Dictionary<Property, string> transitionValues;
                if (this.parser.TryTransition(value, out transitionValues))
                {
                    SetProperty(Property.Transition, transitionValues[Property.Transition]);

                    this.transitionDelay = transitionValues[Property.TransitionDelay];
                    this.transitionDuration = transitionValues[Property.TransitionDuration];
                    this.transitionProperty = transitionValues[Property.TransitionProperty];
                    this.transitionTimingFunction = transitionValues[Property.TransitionTimingFunction];
                }
            }
        }

        public string transitionDelay { set { SetProperty(Property.TransitionDelay, value); } }

        public string transitionDuration { set { SetProperty(Property.TransitionDuration, value); } }

        public string transitionProperty { set { SetProperty(Property.TransitionProperty, value); } }

        public string transitionTimingFunction { set { SetProperty(Property.TransitionTimingFunction, value); } }

        public string unicodeBidi { set { SetProperty(Property.UnicodeBidi, value); } }

        public string verticalAlign { set { SetProperty(Property.VerticalAlign, value); } }

        public string visibility { set { SetProperty(Property.Visibility, value); } }

        public string whiteSpace { set { SetProperty(Property.WhiteSpace, value); } }

        public string width { set { SetProperty(Property.Width, value); } }

        public string wordBreak { set { SetProperty(Property.WordBreak, value); } }

        public string wordSpacing { set { SetProperty(Property.WordSpacing, value); } }

        public string wordWrap { set { SetProperty(Property.WordWrap, value); } }

        public string zIndex { set { SetProperty(Property.ZIndex, value); } }

        #endregion
    }
}
