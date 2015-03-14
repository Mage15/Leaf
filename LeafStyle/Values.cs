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
        public string PropertyName { get; set; }

        public ValuesContainer(Type propType, string cssString, string jsString, string propertyName)
        {
            this.PropertyType = propType;
            this.CssName = cssString;
            this.JsName = jsString;
            this.PropertyName = propertyName;
        }
    }

    public static partial class Value
    {
        #region Values
        private static Dictionary<Property, ValuesContainer> Values = new Dictionary<Property, ValuesContainer>()
        {
            {Property.AlignContent, new ValuesContainer(typeof(AlignContentProperty), "align-content", "alignContent", "AlignContent")},
            {Property.AlignItems, new ValuesContainer(typeof(AlignItemsProperty), "align-items", "alignItems", "AlignItems")},
            {Property.AlignSelf, new ValuesContainer(typeof(AlignSelfProperty), "align-self", "alignSelf", "AlignSelf")},
            {Property.Animation, new ValuesContainer(typeof(BasicValuesProperty), "animation", "animation", "Animation")},
            {Property.AnimationDelay, new ValuesContainer(typeof(BasicTimeProperty), "animation-delay", "animationDelay", "AnimationDelay")},
            {Property.AnimationDirection, new ValuesContainer(typeof(AnimationDirectionProperty), "animation-direction", "animationDirection", "AnimationDirection")},
            {Property.AnimationDuration, new ValuesContainer(typeof(BasicTimeProperty), "animation-duration", "animationDuration", "AnimationDuration")},
            {Property.AnimationFillMode, new ValuesContainer(typeof(AnimationFillModeProperty), "animation-fill-mode", "animationFillMode", "AnimationFillMode")},
            {Property.AnimationIterationCount, new ValuesContainer(typeof(AnimationIterationCountProperty), "animation-iteration-count", "animationIterationCount", "AnimationIterationCount")},
            {Property.AnimationName, new ValuesContainer(typeof(AnimationNameProperty), "animation-name", "animationName", "AnimationName")},
            {Property.AnimationPlayState, new ValuesContainer(typeof(AnimationPlayStateProperty), "animation-play-state", "animationPlayState", "AnimationPlayState")},
            {Property.AnimationTimingFunction, new ValuesContainer(typeof(TimingFunctionProperty), "animation-timing-function", "animationTimingFunction", "AnimationTimingFunction")},
            {Property.BackfaceVisibility, new ValuesContainer(typeof(BackfaceVisibilityProperty), "backface-visibility", "backfaceVisibility", "BackfaceVisibility")},
            {Property.Background, new ValuesContainer(typeof(BasicValuesProperty), "background", "background", "Background")},
            {Property.BackgroundAttachment, new ValuesContainer(typeof(BackgroundAttachmentProperty), "background-attachment", "backgroundAttachment", "BackgroundAttachment")},
            {Property.BackgroundClip, new ValuesContainer(typeof(BackgroundClipProperty), "background-clip", "backgroundClip", "BackgroundClip")},
            {Property.BackgroundColor, new ValuesContainer(typeof(ColorTransparentProperty), "background-color", "backgroundColor", "BackgroundColor")},
            {Property.BackgroundImage, new ValuesContainer(typeof(BasicImageProperty), "background-image", "backgroundImage", "BackgroundImage")},
            {Property.BackgroundOrigin, new ValuesContainer(typeof(BackgroundOriginProperty), "background-origin", "backgroundOrigin", "BackgroundOrigin")},
            {Property.BackgroundPosition, new ValuesContainer(typeof(BackgroundPositionProperty), "background-position", "backgroundPosition", "BackgroundPosition")},
            {Property.BackgroundRepeat, new ValuesContainer(typeof(BackgroundRepeatProperty), "background-repeat", "backgroundRepeat", "BackgroundRepeat")},
            {Property.BackgroundSize, new ValuesContainer(typeof(BackgroundSizeProperty), "background-size", "backgroundSize", "BackgroundSize")},
            {Property.Border, new ValuesContainer(typeof(BasicValuesProperty), "border", "border", "Border")},
            {Property.BorderBottom, new ValuesContainer(typeof(BasicValuesProperty), "border-bottom", "borderBottom", "BorderBottom")},
            {Property.BorderBottomColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-bottom-color", "borderBottomColor", "BorderBottomColor")},
            {Property.BorderBottomLeftRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-bottom-left-radius", "borderBottomLeftRadius", "BorderBottomLeftRadius")},
            {Property.BorderBottomRightRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-bottom-right-radius", "borderBottomRightRadius", "BorderBottomRightRadius")},
            {Property.BorderBottomStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-bottom-style", "borderBottomStyle", "BorderBottomStyle")},
            {Property.BorderBottomWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-bottom-width", "borderBottomWidth", "BorderBottomWidth")},
            {Property.BorderCollapse, new ValuesContainer(typeof(BorderCollapseProperty), "border-collapse", "borderCollapse", "BorderCollapse")},
            {Property.BorderColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-color", "borderColor", "BorderColor")},
            {Property.BorderImage, new ValuesContainer(typeof(BasicValuesProperty), "border-image", "borderImage", "BorderImage")},
            {Property.BorderImageOutset, new ValuesContainer(typeof(NumberLengthProperty), "border-image-outset", "borderImageOutset", "BorderImageOutset")},
            {Property.BorderImageRepeat, new ValuesContainer(typeof(BorderImageRepeatProperty), "border-image-repeat", "borderImageRepeat", "BorderImageRepeat")},
            {Property.BorderImageSlice, new ValuesContainer(typeof(BorderImageSliceProperty), "border-image-slice", "borderImageSlice", "BorderImageSlice")},
            {Property.BorderImageSource, new ValuesContainer(typeof(BasicImageProperty), "border-image-source", "borderImageSource", "BorderImageSource")},
            {Property.BorderImageWidth, new ValuesContainer(typeof(BorderImageWidthProperty), "border-image-width", "borderImageWidth", "BorderImageWidth")},
            {Property.BorderLeft, new ValuesContainer(typeof(BasicValuesProperty), "border-left", "borderLeft", "BorderLeft")},
            {Property.BorderLeftColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-left-color", "borderLeftColor", "BorderLeftColor")},
            {Property.BorderLeftStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-left-style", "borderLeftStyle", "BorderLeftStyle")},
            {Property.BorderLeftWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-left-width", "borderLeftWidth", "BorderLeftWidth")},
            {Property.BorderRadius, new ValuesContainer(typeof(LengthPercentProperty), "border-radius", "borderRadius", "BorderRadius")},
            {Property.BorderRight, new ValuesContainer(typeof(BasicValuesProperty), "border-right", "borderRight", "BorderRight")},
            {Property.BorderRightColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-right-color", "borderRightColor", "BorderRightColor")},
            {Property.BorderRightStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-right-style", "borderRightStyle", "BorderRightStyle")},
            {Property.BorderRightWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-right-width", "borderRightWidth", "BorderRightWidth")},
            {Property.BorderSpacing, new ValuesContainer(typeof(BorderSpacingProperty), "border-spacing", "borderSpacing", "BorderSpacing")},
            {Property.BorderStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-style", "borderStyle", "BorderStyle")},
            {Property.BorderTop, new ValuesContainer(typeof(BasicValuesProperty), "border-top", "borderTop", "BorderTop")},
            {Property.BorderTopColor, new ValuesContainer(typeof(ColorTransparentProperty), "border-top-color", "borderTopColor", "BorderTopColor")},
            {Property.BorderTopLeftRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-top-left-radius", "borderTopLeftRadius", "BorderTopLeftRadius")},
            {Property.BorderTopRightRadius, new ValuesContainer(typeof(BasicRadiusProperty), "border-top-right-radius", "borderTopRightRadius", "BorderTopRightRadius")},
            {Property.BorderTopStyle, new ValuesContainer(typeof(BasicOutlineProperty), "border-top-style", "borderTopStyle", "BorderTopStyle")},
            {Property.BorderTopWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-top-width", "borderTopWidth", "BorderTopWidth")},
            {Property.BorderWidth, new ValuesContainer(typeof(BasicWidthProperty), "border-width", "borderWidth", "BorderWidth")},
            {Property.Bottom, new ValuesContainer(typeof(LengthPercentAutoProperty), "bottom", "bottom", "Bottom")},
            {Property.BoxShadow, new ValuesContainer(typeof(BoxShadowProperty), "box-shadow", "boxShadow", "BoxShadow")},
            {Property.BoxSizing, new ValuesContainer(typeof(BoxSizingProperty), "box-sizing", "boxSizing", "BoxSizing")},
            {Property.CaptionSide, new ValuesContainer(typeof(CaptionSideProperty), "caption-side", "captionSide", "CaptionSide")},
            {Property.Clear, new ValuesContainer(typeof(ClearProperty), "clear", "clear", "Clear")},
            {Property.Clip, new ValuesContainer(typeof(ClipProperty), "clip", "clip", "Clip")},
            {Property.Color, new ValuesContainer(typeof(BasicColorProperty), "color", "color", "Color")},
            {Property.ColumnCount, new ValuesContainer(typeof(NumberAutoProperty), "column-count", "coulmnCount", "CoulmnCount")},
            {Property.ColumnFill, new ValuesContainer(typeof(ColumnFillProperty), "column-fill", "columnFill", "ColumnFill")},
            {Property.ColumnGap, new ValuesContainer(typeof(BasicSpacingProperty), "column-gap", "coulmnGap", "CoulmnGap")},
            {Property.ColumnRule, new ValuesContainer(typeof(BasicValuesProperty), "column-rule", "columnRule", "ColumnRule")},
            {Property.ColumnRuleColor, new ValuesContainer(typeof(BasicColorProperty), "column-rule-color", "columnRuleColor", "ColumnRuleColor")},
            {Property.ColumnRuleStyle, new ValuesContainer(typeof(BasicOutlineProperty), "column-rule-style", "coulmnRuleStyle", "CoulmnRuleStyle")},
            {Property.ColumnRuleWidth, new ValuesContainer(typeof(BasicWidthProperty), "column-rule-width", "coulmnRuleWidth", "CoulmnRuleWidth")},
            {Property.ColumnSpan, new ValuesContainer(typeof(ColumnSpanProperty), "column-span", "columnSpan", "ColumnSpan")},
            {Property.ColumnWidth, new ValuesContainer(typeof(LengthAutoProperty), "column-width", "columnWidth", "ColumnWidth")},
            {Property.Columns, new ValuesContainer(typeof(BasicValuesProperty), "columns", "columns", "Columns")},
            {Property.Cursor, new ValuesContainer(typeof(CursorProperty), "cursor", "cursor", "Cursor")},
            {Property.Direction, new ValuesContainer(typeof(DirectionProperty), "direction", "direction", "Direction")},
            {Property.Display, new ValuesContainer(typeof(DisplayProperty), "display", "display", "Display")},
            {Property.EmptyCells, new ValuesContainer(typeof(EmptyCellsProperty), "empty-cells", "emptyCells", "EmptyCells")},
            {Property.Flex, new ValuesContainer(typeof(FlexProperty), "flex", "Flex", "Flex")},
            {Property.FlexBasis, new ValuesContainer(typeof(LengthPercentAutoProperty), "flex-basis", "flexBasis", "FlexBasis")},
            {Property.FlexDirection, new ValuesContainer(typeof(FlexDirectionProperty), "flex-direction", "flexDirection", "FlexDirection")},
            {Property.FlexFlow, new ValuesContainer(typeof(BasicValuesProperty), "flex-flow", "flexFlow", "FlexFlow")},
            {Property.FlexGrow, new ValuesContainer(typeof(BasicNumberProperty), "flex-grow", "flexGrow", "FlexGrow")},
            {Property.FlexShrink, new ValuesContainer(typeof(BasicNumberProperty), "flex-shrink", "flexShrink", "FlexShrink")},
            {Property.FlexWrap, new ValuesContainer(typeof(FlexWrapProperty), "flex-wrap", "flexWrap", "FlexWrap")},
            {Property.Float, new ValuesContainer(typeof(FloatProperty), "float", "float", "Float")},
            {Property.Font, new ValuesContainer(typeof(FontProperty), "font", "font", "Font")},
            //{Properties.FontFace, new ValuesContainer(typeof(FontFaceProperty), "@font-face", "FontFace")},
            //{Properties.FontFamily, new ValuesContainer(typeof(FontFamilyProperty), "font-family", "fontFamily", "FontFamily")},
            {Property.FontSize, new ValuesContainer(typeof(FontSizeProperty), "font-size", "fontSize", "FontSize")},
            {Property.FontSizeAdjust, new ValuesContainer(typeof(FontSizeAdjustProperty), "font-size-adjust", "fontSizeAdjust", "FontSizeAdjust")},
            {Property.FontStretch, new ValuesContainer(typeof(FontStretchProperty), "font-stretch", "fontStretch", "FontStretch")},
            {Property.FontStyle, new ValuesContainer(typeof(FontStyleProperty), "font-style", "fontStyle", "FontStyle")},
            {Property.FontVariant, new ValuesContainer(typeof(FontVariantProperty), "font-variant", "fontVariant", "FontVariant")},
            {Property.FontWeight, new ValuesContainer(typeof(FontWeightProperty), "font-weight", "fontWeight", "FontWeight")},
            {Property.HangingPunctuation, new ValuesContainer(typeof(HangingPunctuationProperty), "hanging-punctuation", "hangingPunctuation", "HangingPunctuation")},
            {Property.Height, new ValuesContainer(typeof(LengthPercentAutoProperty), "height", "height", "Height")},
            {Property.Icon, new ValuesContainer(typeof(IconProperty), "icon", "icon", "Icon")},
            {Property.JustifyContent, new ValuesContainer(typeof(JustifyContentProperty), "justify-content", "justifyContent", "JustifyContent")},
            //{Properties.Keyframes, new ValuesContainer(typeof(KeyframesProperty), "@keyframes", "Keyframes")},
            {Property.Left, new ValuesContainer(typeof(LengthPercentAutoProperty), "left", "left", "Left")},
            {Property.LetterSpacing, new ValuesContainer(typeof(BasicSpacingProperty), "letter-spacing", "letterSpacing", "LetterSpacing")},
            {Property.LineHeight, new ValuesContainer(typeof(LineHeightProperty), "line-height", "lineHeight", "LineHeight")},
            {Property.ListStyle, new ValuesContainer(typeof(BasicValuesProperty), "list-style", "listStyle", "ListStyle")},
            {Property.ListStyleImage, new ValuesContainer(typeof(ListStyleImageProperty), "list-style-image", "listStyleImage", "ListStyleImage")},
            {Property.ListStylePosition, new ValuesContainer(typeof(ListStylePositionProperty), "list-style-position", "listStylePosition", "ListStylePosition")},
            {Property.ListStyleType, new ValuesContainer(typeof(ListStyleTypeProperty), "list-style-type", "listStyleType", "ListStyleType")},
            {Property.Margin, new ValuesContainer(typeof(BasicValuesProperty), "margin", "margin", "Margin")},
            {Property.MarginBottom, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-bottom", "marginBottom", "MarginBottom")},
            {Property.MarginLeft, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-left", "marginLeft", "MarginLeft")},
            {Property.MarginRight, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-right", "marginRight", "MarginRight")},
            {Property.MarginTop, new ValuesContainer(typeof(LengthPercentAutoProperty), "margin-top", "marginTop", "MarginTop")},
            {Property.MaxHeight, new ValuesContainer(typeof(LengthPercentNoneProperty), "max-height", "maxHeight", "MaxHeight")},
            {Property.MaxWidth, new ValuesContainer(typeof(LengthPercentNoneProperty), "max-width", "maxWidth", "MaxWidth")},
            //{Property.Media, new ValuesContainer()},
            {Property.MinHeight, new ValuesContainer(typeof(LengthPercentProperty), "min-height", "minHeight", "MinHeight")},
            {Property.MinWidth, new ValuesContainer(typeof(LengthPercentProperty), "min-width", "minWidth", "MinWidth")},
            {Property.NavDown, new ValuesContainer(typeof(BasicNavProperty), "nav-down", "navDown", "NavDown")},
            {Property.NavIndex, new ValuesContainer(typeof(NumberAutoProperty), "nav-index", "navIndex", "NavIndex")},
            {Property.NavLeft, new ValuesContainer(typeof(BasicNavProperty), "nav-left", "navLeft", "NavLeft")},
            {Property.NavRight, new ValuesContainer(typeof(BasicNavProperty), "nav-right", "navRight", "NavRight")},
            {Property.NavUp, new ValuesContainer(typeof(BasicNavProperty), "nav-up", "navUp", "NavUp")},
            {Property.Opacity, new ValuesContainer(typeof(OpacityProperty), "opacity", "opacity", "Opacity")},
            {Property.Order, new ValuesContainer(typeof(BasicNumberProperty), "order", "order", "Order")},
            {Property.Outline, new ValuesContainer(typeof(BasicValuesProperty), "outline", "outline", "Outline")},
            {Property.OutlineColor, new ValuesContainer(typeof(OutlineColorProperty), "outline-color", "outlineColor", "OutlineColor")},
            {Property.OutlineOffset, new ValuesContainer(typeof(BasicLengthProperty), "outline-offset", "oulineOffset", "OulineOffset")},
            {Property.OutlineStyle, new ValuesContainer(typeof(BasicOutlineProperty), "outline-style", "outlineStyle", "OutlineStyle")},
            {Property.OutlineWidth, new ValuesContainer(typeof(BasicWidthProperty), "outline-width", "outlineWidth", "OutlineWidth")},
            {Property.Overflow, new ValuesContainer(typeof(BasicOverflowProperty), "overflow", "overflow", "Overflow")},
            {Property.OverflowX, new ValuesContainer(typeof(BasicOverflowProperty), "overflow-x", "overflowX", "OverflowX")},
            {Property.OverflowY, new ValuesContainer(typeof(BasicOverflowProperty), "overflow-y", "overflowY", "OverflowY")},
            {Property.Padding, new ValuesContainer(typeof(LengthPercentProperty), "padding", "padding", "Padding")},
            {Property.PaddingBottom, new ValuesContainer(typeof(LengthPercentProperty), "padding-bottom", "paddingBottom", "PaddingBottom")},
            {Property.PaddingLeft, new ValuesContainer(typeof(LengthPercentProperty), "padding-left", "paddingLeft", "PaddingLeft")},
            {Property.PaddingRight, new ValuesContainer(typeof(LengthPercentProperty), "padding-right", "paddingRight", "PaddingRight")},
            {Property.PaddingTop, new ValuesContainer(typeof(LengthPercentProperty), "padding-top", "paddingTop", "PaddingTop")},
            {Property.PageBreakAfter, new ValuesContainer(typeof(BasicPageBreakProperty), "page-break-after", "pageBreakAfter", "PageBreakAfter")},
            {Property.PageBreakBefore, new ValuesContainer(typeof(BasicPageBreakProperty), "page-break-before", "pageBreakBefore", "PageBreakBefore")},
            {Property.PageBreakInside, new ValuesContainer(typeof(PageBreakInsideProperty), "page-break-inside", "pageBreakInside", "PageBreakInside")},
            {Property.Perspective, new ValuesContainer(typeof(LengthNoneProperty), "perspective", "perspective", "Perspective")},
            //{Properties.PerspectiveOrigin, new ValuesContainer(typeof(PerspectiveOriginProperty), "perspective-origin", "perspectiveOrigin", "PerspectiveOrigin")},
            {Property.Position, new ValuesContainer(typeof(PositionProperty), "position", "position", "Position")},
            {Property.Quotes, new ValuesContainer(typeof(QuotesProperty), "quotes", "quotes", "Quotes")},
            {Property.Resize, new ValuesContainer(typeof(ResizeProperty), "resize", "resize", "Resize")},
            {Property.Right, new ValuesContainer(typeof(LengthPercentAutoProperty), "right", "right", "Right")},
            {Property.TabSize, new ValuesContainer(typeof(NumberLengthProperty), "tab-size", "tabSize", "TabSize")},
            {Property.TableLayout, new ValuesContainer(typeof(TableLayoutProperty), "table-layout", "tableLayout", "TableLayout")},
            {Property.TextAlign, new ValuesContainer(typeof(TextAlignProperty), "text-align", "textAlign", "TextAlign")},
            {Property.TextAlignLast, new ValuesContainer(typeof(TextAlignLastProperty), "text-align-last", "textAlignLast", "TextAlignLast")},
            {Property.TextDecoration, new ValuesContainer(typeof(BasicValuesProperty), "text-decoration", "textDecoration", "TextDecoration")},
            {Property.TextDecorationColor, new ValuesContainer(typeof(BasicColorProperty), "text-decoration-color", "textDecorationColor", "TextDecorationColor")},
            {Property.TextDecorationLine, new ValuesContainer(typeof(TextDecorationLineProperty), "text-decoration-line", "textDecorationLine", "TextDecorationLine")},
            {Property.TextDecorationStyle, new ValuesContainer(typeof(TextDecorationStyleProperty), "text-decoration-style", "textDecorationStyle", "TextDecorationStyle")},
            {Property.TextIndent, new ValuesContainer(typeof(LengthPercentProperty), "text-indent", "textIndent", "TextIndent")},
            {Property.TextJustify, new ValuesContainer(typeof(TextJustifyProperty), "text-justify", "textJustify", "TextJustify")},
            {Property.TextOverflow, new ValuesContainer(typeof(TextOverflowProperty), "text-overflow", "textOverflow", "TextOverflow")},
            {Property.TextShadow, new ValuesContainer(typeof(TextShadowProperty), "text-shadow", "textShadow", "TextShadow")},
            {Property.TextTransform, new ValuesContainer(typeof(TextTransformProperty), "text-transform", "textTransform", "TextTransform")},
            {Property.Top, new ValuesContainer(typeof(LengthPercentAutoProperty), "top", "top", "Top")},
            {Property.Transform, new ValuesContainer(typeof(TransformProperty), "transform", "transform", "Transform")},
            //{Properties.TransformOrigin, new ValuesContainer(typeof(TransformOriginProperty), "transform-origin", "transformOrigin", "TransformOrigin")},
            //{Property.TransformStyle new ValuesContainer(typeof(Transformroperty), "transform-style", "transformStyle", "TransformStyle")},
            {Property.Transition, new ValuesContainer(typeof(BasicValuesProperty), "transition", "transition", "Transition")},
            {Property.TransitionDelay, new ValuesContainer(typeof(BasicTimeProperty), "transition-delay", "transitionDelay", "TransitionDelay")},
            {Property.TransitionDuration, new ValuesContainer(typeof(BasicTimeProperty), "transition-duration", "transitionDuration", "TransitionDuration")},
            {Property.TransitionProperty, new ValuesContainer(typeof(TransitionPropertyProperty), "transition-property", "transitionProperty", "TransitionProperty")},
            {Property.TransitionTimingFunction, new ValuesContainer(typeof(TimingFunctionProperty), "transition-timing-function", "transitionTimingFunction", "TransitionTimingFunction")},
            {Property.UnicodeBidi, new ValuesContainer(typeof(UnicodeBidiProperty), "unicode-bidi", "unicodeBidi", "UnicodeBidi")},
            {Property.VerticalAlign, new ValuesContainer(typeof(VerticalAlignProperty), "vertical-align", "verticalAlign", "VerticalAlign")},
            {Property.Visibility, new ValuesContainer(typeof(VisibilityProperty), "visibility", "visibility", "Visibility")},
            {Property.WhiteSpace, new ValuesContainer(typeof(WhiteSpaceProperty), "white-space", "whiteSpace", "WhiteSpace")},
            {Property.Width, new ValuesContainer(typeof(LengthPercentAutoProperty), "width", "width", "Width")},
            {Property.WordBreak, new ValuesContainer(typeof(WordBreakProperty), "word-break", "wordBreak", "WordBreak")},
            {Property.WordSpacing, new ValuesContainer(typeof(BasicSpacingProperty), "word-spacing", "wordSpacing", "WordSpacing")},
            {Property.WordWrap, new ValuesContainer(typeof(WordWrapProperty), "word-wrap", "wordWrap", "WordWrap")},
            {Property.ZIndex, new ValuesContainer(typeof(NumberAutoProperty), "z-index", "zIndex", "ZIndex")}
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
        public static bool TryGetPropertyType(Property property, out Type propType)
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

        public static Type GetPropertyType(Property property)
        {
            return Values[property].PropertyType;
        }
    }
}