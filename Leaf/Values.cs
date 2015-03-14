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
using System.Linq;

namespace LeafStyle
{
    internal class ValuesContainer
    {
        public Type PropertyType { get; private set; }
        public string CssName { get; private set; }
        public string JsName { get; set; }

        public ValuesContainer(Type propType, string cssString, string jsString)
        {
            this.PropertyType = propType;
            this.CssName = cssString;
            this.JsName = jsString;
        }
    }

    public static partial class Value
    {
        #region Values
        private static Dictionary<Property, ValuesContainer> Values = new Dictionary<Property, ValuesContainer>()
        {
            {Property.AlignContent, new ValuesContainer(typeof(AlignContentProperty), "align-content", "alignContent")},
            {Property.AlignItems, new ValuesContainer(typeof(AlignItemsProperty), "align-items", "alignItems")},
            {Property.AlignSelf, new ValuesContainer(typeof(AlignSelfProperty), "align-self", "alignSelf")},
            {Property.Animation, new ValuesContainer(typeof(BasicValuesProperty), "animation", "animation")},
            {Property.AnimationDelay, new ValuesContainer(typeof(BasicTimeProperty), "animation-delay", "animationDelay")},
            {Property.AnimationDirection, new ValuesContainer(typeof(AnimationDirectionProperty), "animation-direction", "animationDirection")},
            {Property.AnimationDuration, new ValuesContainer(typeof(BasicTimeProperty), "animation-duration", "animationDuration")},
            {Property.AnimationFillMode, new ValuesContainer(typeof(AnimationFillModeProperty), "animation-fill-mode", "animationFillMode")},
            {Property.AnimationIterationCount, new ValuesContainer(typeof(AnimationIterationCountProperty), "animation-iteration-count", "animationIterationCount")},
            {Property.AnimationName, new ValuesContainer(typeof(AnimationNameProperty), "animation-name", "animationName")},
            {Property.AnimationPlayState, new ValuesContainer(typeof(AnimationPlayStateProperty), "animation-play-state", "animationPlayState")},
            {Property.AnimationTimingFunction, new ValuesContainer(typeof(TimingFunctionProperty), "animation-timing-function", "animationTimingFunction")},
            {Property.BackfaceVisibility, new ValuesContainer(typeof(BackfaceVisibilityProperty), "backface-visibility", "backfaceVisibility")},
            {Property.Background, new ValuesContainer(typeof(BasicValuesProperty), "background", "background")},
            {Property.BackgroundAttachment, new ValuesContainer(typeof(BackgroundAttachmentProperty), "background-attachment", "backgroundAttachment")},
            {Property.BackgroundClip, new ValuesContainer(typeof(BackgroundClipProperty), "background-clip", "backgroundClip")},
            {Property.BackgroundColor, new ValuesContainer(typeof(ColorTransparentProperty), "background-color", "backgroundColor")},
            {Property.BackgroundImage, new ValuesContainer(typeof(BasicImageProperty), "background-image", "backgroundImage")},
            {Property.BackgroundOrigin, new ValuesContainer(typeof(BackgroundOriginProperty), "background-origin", "backgroundOrigin")},
            {Property.BackgroundPosition, new ValuesContainer(typeof(BackgroundPositionProperty), "background-position", "backgroundPosition")},
            {Property.BackgroundRepeat, new ValuesContainer(typeof(BackgroundRepeatProperty), "background-repeat", "backgroundRepeat")},
            {Property.BackgroundSize, new ValuesContainer(typeof(BackgroundSizeProperty), "background-size", "backgroundSize")},
            {Property.Border, new ValuesContainer(typeof(BasicValuesProperty), "border", "border")},
            {Property.BorderBottom, new ValuesContainer(typeof(BasicValuesProperty), "border-bottom", "borderBottom")},
            {Property.BorderBottomColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-bottom-color", "borderBottomColor")},
            {Property.BorderBottomLeftRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-bottom-left-radius", "borderBottomLeftRadius")},
            {Property.BorderBottomRightRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-bottom-right-radius", "borderBottomRightRadius")},
            {Property.BorderBottomStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-bottom-style", "borderBottomStyle")},
            {Property.BorderBottomWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-bottom-width", "borderBottomWidth")},
            {Property.BorderCollapse, new ValuesContainer(typeof(BorderCollapseProperty), "border-collapse", "borderCollapse")},
            {Property.BorderColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-color", "borderColor")},
            {Property.BorderImage, new ValuesContainer(typeof(BasicValuesProperty), "border-image", "borderImage")},
            {Property.BorderImageOutset, new ValuesContainer(typeof(NumberLengthProperty), "border-image-outset", "borderImageOutset")},
            {Property.BorderImageRepeat, new ValuesContainer(typeof(BorderImageRepeatProperty), "border-image-repeat", "borderImageRepeat")},
            {Property.BorderImageSlice, new ValuesContainer(typeof(BorderImageSliceProperty), "border-image-slice", "borderImageSlice")},
            {Property.BorderImageSource, new ValuesContainer(typeof(BasicImageProperty), "border-image-source", "borderImageSource")},
            {Property.BorderImageWidth, new ValuesContainer(typeof(BorderImageWidthProperty), "border-image-width", "borderImageWidth")},
            {Property.BorderLeft, new ValuesContainer(typeof(BasicValuesProperty), "border-left", "borderLeft")},
            {Property.BorderLeftColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-left-color", "borderLeftColor")},
            {Property.BorderLeftStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-left-style", "borderLeftStyle")},
            {Property.BorderLeftWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-left-width", "borderLeftWidth")},
            {Property.BorderRadius, new ValuesContainer(typeof(LengthPercentProperty), "border-radius", "borderRadius")},
            {Property.BorderRight, new ValuesContainer(typeof(BasicValuesProperty), "border-right", "borderRight")},
            {Property.BorderRightColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-right-color", "borderRightColor")},
            {Property.BorderRightStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-right-style", "borderRightStyle")},
            {Property.BorderRightWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-right-width", "borderRightWidth")},
            {Property.BorderSpacing, new ValuesContainer(typeof(BorderSpacingProperty), "border-spacing", "borderSpacing")},
            {Property.BorderStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-style", "borderStyle")},
            {Property.BorderTop, new ValuesContainer(typeof(BasicValuesProperty), "border-top", "borderTop")},
            {Property.BorderTopColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-top-color", "borderTopColor")},
            {Property.BorderTopLeftRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-top-left-radius", "borderTopLeftRadius")},
            {Property.BorderTopRightRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-top-right-radius", "borderTopRightRadius")},
            {Property.BorderTopStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-top-style", "borderTopStyle")},
            {Property.BorderTopWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-top-width", "borderTopWidth")},
            {Property.BorderWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-width", "borderWidth")},
            {Property.Bottom, new ValuesContainer(typeof(LengthPercentAutoProperty), "bottom", "bottom")},
            {Property.BoxShadow, new ValuesContainer(typeof(BoxShadowProperty), "box-shadow", "boxShadow")},
            {Property.BoxSizing, new ValuesContainer(typeof(BoxSizingProperty), "box-sizing", "boxSizing")},
            {Property.CaptionSide, new ValuesContainer(typeof(CaptionSideProperty), "caption-side", "captionSide")},
            {Property.Clear, new ValuesContainer(typeof(ClearProperty), "clear", "clear")},
            {Property.Clip, new ValuesContainer(typeof(ClipProperty), "clip", "clip")},
            {Property.Color, new ValuesContainer(typeof(BasicColorProperty), "color", "color")},
            {Property.ColumnCount, new ValuesContainer(typeof(NumberAutoProperty), "column-count", "coulmnCount")},
            {Property.ColumnFill, new ValuesContainer(typeof(ColumnFillProperty), "column-fill", "columnFill")},
            {Property.ColumnGap, new ValuesContainer(typeof(BasicSpacingProperty), "column-gap", "coulmnGap")},
            {Property.ColumnRule, new ValuesContainer(typeof(BasicValuesProperty), "column-rule", "columnRule")},
            {Property.ColumnRuleColor, new ValuesContainer(typeof(BasicColorProperty), "column-rule-color", "columnRuleColor")},
            {Property.ColumnRuleStyle, new ValuesContainer(typeof(BasicOutlineProperty), "column-rule-style", "coulmnRuleStyle")},
            {Property.ColumnRuleWidth, new ValuesContainer(typeof(BasicWidthProperty), "column-rule-width", "coulmnRuleWidth")},
            {Property.ColumnSpan, new ValuesContainer(typeof(ColumnSpanProperty), "column-span", "columnSpan")},
            {Property.ColumnWidth, new ValuesContainer(typeof(LengthAutoProperty), "column-width", "columnWidth")},
            {Property.Columns, new ValuesContainer(typeof(BasicValuesProperty), "columns", "columns")},
            //{Property.Content, new ValuesContainer(typeof(ContentProperty), "content", "content")},
            {Property.CounterIncrement, new ValuesContainer(typeof(CounterIncrementProperty), "counter-increment", "counterIncrement")},
            {Property.CounterReset, new ValuesContainer(typeof(CounterResetProperty), "counter-reset", "counterReset")},
            {Property.Cursor, new ValuesContainer(typeof(CursorProperty), "cursor", "cursor")},
            {Property.Direction, new ValuesContainer(typeof(DirectionProperty), "direction", "direction")},
            {Property.Display, new ValuesContainer(typeof(DisplayProperty), "display", "display")},
            {Property.EmptyCells, new ValuesContainer(typeof(EmptyCellsProperty), "empty-cells", "emptyCells")},
            {Property.Flex, new ValuesContainer(typeof(FlexProperty), "flex", "Flex")},
            {Property.FlexBasis, new ValuesContainer(typeof(LengthPercentAutoProperty), "flex-basis", "flexBasis")},
            {Property.FlexDirection, new ValuesContainer(typeof(FlexDirectionProperty), "flex-direction", "flexDirection")},
            {Property.FlexFlow, new ValuesContainer(typeof(BasicValuesProperty), "flex-flow", "flexFlow")},
            {Property.FlexGrow, new ValuesContainer(typeof(BasicNumberProperty), "flex-grow", "flexGrow")},
            {Property.FlexShrink, new ValuesContainer(typeof(BasicNumberProperty), "flex-shrink", "flexShrink")},
            {Property.FlexWrap, new ValuesContainer(typeof(FlexWrapProperty), "flex-wrap", "flexWrap")},
            {Property.Float, new ValuesContainer(typeof(FloatProperty), "float", "float")},
            {Property.Font, new ValuesContainer(typeof(FontProperty), "font", "font")},
            //{Properties.FontFace, new ValuesContainer(typeof(FontFaceProperty), "@font-face", "fontFace")},
            //{Properties.FontFamily, new ValuesContainer(typeof(FontFamilyProperty), "font-family", "fontFamily")},
            {Property.FontSize, new ValuesContainer(typeof(FontSizeProperty), "font-size", "fontSize")},
            {Property.FontSizeAdjust, new ValuesContainer(typeof(FontSizeAdjustProperty), "font-size-adjust", "fontSizeAdjust")},
            {Property.FontStretch, new ValuesContainer(typeof(FontStretchProperty), "font-stretch", "fontStretch")},
            {Property.FontStyle, new ValuesContainer(typeof(FontStyleProperty), "font-style", "fontStyle")},
            {Property.FontVariant, new ValuesContainer(typeof(FontVariantProperty), "font-variant", "fontVariant")},
            {Property.FontWeight, new ValuesContainer(typeof(FontWeightProperty), "font-weight", "fontWeight")},
            {Property.HangingPunctuation, new ValuesContainer(typeof(HangingPunctuationProperty), "hanging-punctuation", "hangingPunctuation")},
            {Property.Height, new ValuesContainer(typeof(LengthPercentAutoProperty), "height", "height")},
            {Property.Icon, new ValuesContainer(typeof(IconProperty), "icon", "icon")},
            {Property.JustifyContent, new ValuesContainer(typeof(JustifyContentProperty), "justify-content", "justifyContent")},
            //{Properties.Keyframes, new ValuesContainer(typeof(KeyframesProperty), "@keyframes", "keyframes")},
            {Property.Left, new ValuesContainer(typeof(LengthPercentAutoProperty), "left", "left")},
            {Property.LetterSpacing, new ValuesContainer(typeof(BasicSpacingProperty), "letter-spacing", "letterSpacing")},
            {Property.LineHeight, new ValuesContainer(typeof(LineHeightProperty), "line-height", "lineHeight")},
            {Property.ListStyle, new ValuesContainer(typeof(BasicValuesProperty), "list-style", "listStyle")},
            {Property.ListStyleImage, new ValuesContainer(typeof(ListStyleImageProperty), "list-style-image", "listStyleImage")},
            {Property.ListStylePosition, new ValuesContainer(typeof(ListStylePositionProperty), "list-style-position", "listStylePosition")},
            {Property.ListStyleType, new ValuesContainer(typeof(ListStyleTypeProperty), "list-style-type", "listStyleType")},
            {Property.Margin, new ValuesContainer(typeof(BasicValuesProperty), "margin", "margin")},
            {Property.MarginBottom, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-bottom", "marginBottom")},
            {Property.MarginLeft, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-left", "marginLeft")},
            {Property.MarginRight, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-right", "marginRight")},
            {Property.MarginTop, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-top", "marginTop")},
            {Property.MaxHeight, new ValuesContainer(typeof(LengthPercentNoneProperty), "max-height", "maxHeight")},
            {Property.MaxWidth, new ValuesContainer(typeof(LengthPercentNoneProperty), "max-width", "maxWidth")},
            {Property.MinHeight, new ValuesContainer(typeof(LengthPercentProperty), "min-height", "minHeight")},
            {Property.MinWidth, new ValuesContainer(typeof(LengthPercentProperty), "min-width", "minWidth")},
            {Property.NavDown, new ValuesContainer(typeof(BasicNavProperty), "nav-down", "navDown")},
            {Property.NavIndex, new ValuesContainer(typeof(NumberAutoProperty), "nav-index", "navIndex")},
            {Property.NavLeft, new ValuesContainer(typeof(BasicNavProperty), "nav-left", "navLeft")},
            {Property.NavRight, new ValuesContainer(typeof(BasicNavProperty), "nav-right", "navRight")},
            {Property.NavUp, new ValuesContainer(typeof(BasicNavProperty), "nav-up", "navUp")},
            {Property.Opacity, new ValuesContainer(typeof(OpacityProperty), "opacity", "opacity")},
            {Property.Order, new ValuesContainer(typeof(BasicNumberProperty), "order", "order")},
            {Property.Outline, new ValuesContainer(typeof(BasicValuesProperty), "outline", "outline")},
            {Property.OutlineColor, new ValuesContainer(typeof(OutlineColorProperty), "outline-color", "outlineColor")},
            {Property.OutlineOffset, new ValuesContainer(typeof(BasicLengthProperty), "outline-offset", "oulineOffset")},
            {Property.OutlineStyle, new ValuesContainer(typeof(BasicOutlineProperty), "outline-style", "outlineStyle")},
            {Property.OutlineWidth, new ValuesContainer(typeof(BasicWidthProperty), "outline-width", "outlineWidth")},
            {Property.Overflow, new ValuesContainer(typeof(BasicOverflowProperty), "overflow", "overflow")},
            {Property.OverflowX, new ValuesContainer(typeof(BasicOverflowProperty), "overflow-x", "overflowX")},
            {Property.OverflowY, new ValuesContainer(typeof(BasicOverflowProperty), "overflow-y", "overflowY")},
            {Property.Padding, new ValuesContainer(typeof(LengthPercentProperty), "padding", "padding")},
            {Property.PaddingBottom, new ValuesContainer(typeof(LengthPercentProperty), "padding-bottom", "paddingBottom")},
            {Property.PaddingLeft, new ValuesContainer(typeof(LengthPercentProperty), "padding-left", "paddingLeft")},
            {Property.PaddingRight, new ValuesContainer(typeof(LengthPercentProperty), "padding-right", "paddingRight")},
            {Property.PaddingTop, new ValuesContainer(typeof(LengthPercentProperty), "padding-top", "paddingTop")},
            {Property.PageBreakAfter, new ValuesContainer(typeof(BasicPageBreakProperty), "page-break-after", "pageBreakAfter")},
            {Property.PageBreakBefore, new ValuesContainer(typeof(BasicPageBreakProperty), "page-break-before", "pageBreakBefore")},
            {Property.PageBreakInside, new ValuesContainer(typeof(PageBreakInsideProperty), "page-break-inside", "pageBreakInside")},
            {Property.Perspective, new ValuesContainer(typeof(LengthNoneProperty), "perspective", "perspective")},
            //{Properties.PerspectiveOrigin, new ValuesContainer(typeof(PerspectiveOriginProperty), "perspective-origin", "perspectiveOrigin")},
            {Property.Position, new ValuesContainer(typeof(PositionProperty), "position", "position")},
            {Property.Quotes, new ValuesContainer(typeof(QuotesProperty), "quotes", "quotes")},
            {Property.Resize, new ValuesContainer(typeof(ResizeProperty), "resize", "resize")},
            {Property.Right, new ValuesContainer(typeof(LengthPercentAutoProperty), "right", "right")},
            {Property.TabSize, new ValuesContainer(typeof(NumberLengthProperty), "tab-size", "tabSize")},
            {Property.TableLayout, new ValuesContainer(typeof(TableLayoutProperty), "table-layout", "tableLayout")},
            {Property.TextAlign, new ValuesContainer(typeof(TextAlignProperty), "text-align", "textAlign")},
            {Property.TextAlignLast, new ValuesContainer(typeof(TextAlignLastProperty), "text-align-last", "textAlignLast")},
            {Property.TextDecoration, new ValuesContainer(typeof(TextDecorationProperty), "text-decoration", "textDecoration")},
            {Property.TextDecorationColor, new ValuesContainer(typeof(BasicColorProperty), "text-decoration-color", "textDecorationColor")},
            {Property.TextDecorationLine, new ValuesContainer(typeof(TextDecorationProperty), "text-decoration-line", "textDecorationLine")},
            {Property.TextIndent, new ValuesContainer(typeof(LengthPercentProperty), "text-indent", "textIndent")},
            {Property.TextJustify, new ValuesContainer(typeof(TextJustifyProperty), "text-justify", "textJustify")},
            {Property.TextOverflow, new ValuesContainer(typeof(TextOverflowProperty), "text-overflow", "textOverflow")},
            {Property.TextShadow, new ValuesContainer(typeof(TextShadowProperty), "text-shadow", "textShadow")},
            {Property.TextTransform, new ValuesContainer(typeof(TextTransformProperty), "text-transform", "textTransform")},
            {Property.Top, new ValuesContainer(typeof(LengthPercentAutoProperty), "top", "top")},
            {Property.Transform, new ValuesContainer(typeof(TransformProperty), "transform", "transform")},
            //{Properties.TransformOrigin, new ValuesContainer(typeof(TransformOriginProperty), "transform-origin", "transformOrigin")},
            //{Property.TransformStyle new ValuesContainer(typeof(Transformroperty), "transform-style", "transformStyle")},
            {Property.Transition, new ValuesContainer(typeof(BasicValuesProperty), "transition", "transition")},
            {Property.TransitionDelay, new ValuesContainer(typeof(BasicTimeProperty), "transition-delay", "transitionDelay")},
            {Property.TransitionDuration, new ValuesContainer(typeof(BasicTimeProperty), "transition-duration", "transitionDuration")},
            {Property.TransitionProperty, new ValuesContainer(typeof(TransitionPropertyProperty), "transition-property", "transitionProperty")},
            {Property.TransitionTimingFunction, new ValuesContainer(typeof(TimingFunctionProperty), "transition-timing-function", "transitionTimingFunction")},
            {Property.UnicodeBidi, new ValuesContainer(typeof(UnicodeBidiProperty), "unicode-bidi", "unicodeBidi")},
            {Property.VerticalAlign, new ValuesContainer(typeof(VerticalAlignProperty), "vertical-align", "verticalAlign")},
            {Property.Visibility, new ValuesContainer(typeof(VisibilityProperty), "visibility", "visibility")},
            {Property.WhiteSpace, new ValuesContainer(typeof(WhiteSpaceProperty), "white-space", "whiteSpace")},
            {Property.Width, new ValuesContainer(typeof(LengthPercentAutoProperty), "width", "width")},
            {Property.WordBreak, new ValuesContainer(typeof(WordBreakProperty), "word-break", "wordBreak")},
            {Property.WordSpacing, new ValuesContainer(typeof(BasicSpacingProperty), "word-spacing", "wordSpacing")},
            {Property.WordWrap, new ValuesContainer(typeof(WordWrapProperty), "word-wrap", "wordWrap")},
            {Property.ZIndex, new ValuesContainer(typeof(NumberAutoProperty), "z-index", "zIndex")}
        };

        #endregion

        public static string GetJSNameFromCSSName(string cssName)
        {
            try
            {
                return Values[
                    Values.Keys.First(str => Values[str].CssName.Equals(cssName))
                    ]
                    .JsName;
            }
            catch
            {
                return "";
            }
        }

        public static string GetCSSName(Property property)
        {
            return Values[property].CssName;
        }

        public static string GetJSName(Property property)
        {
            return Values[property].JsName;
        }

        /// <summary>
        /// If Type is found propType is set to Type associated with the Property and true is returned. Otherwise
        /// propType is set to null and false is returned.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propType"></param>
        /// <returns></returns>
        public static bool GetPropertyType(Property property, out Type propType)
        {
            if (Values.ContainsKey(property))
            {
                propType = Values[property].PropertyType;
                return true;
            }

            // Didn't contain property
            propType = null;
            return false;
        }
    }
}