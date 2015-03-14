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
    //General
    public enum BasicColorState { Color, Initial, Inherit }

    public enum BasicImageState { None, Image, Initial, Inherit }

    public enum BasicLengthState { Length, Initial, Inherit }

    public enum BasicNavState { Auto, Id, TargetName, Initial, Inherit }

    public enum BasicNumberState { Number, Initial, Inherit }

    public enum BasicOutlineState { None, Hidden, Dotted, Dashed, Solid, Double, Groove, Ridge, Inset, Outset, Initial, Inherit }

    public enum BasicOverflowState { Visible, Hidden, Scroll, Auto, Initial, Inherit }

    public enum BasicPageBreakState { Auto, Always, Avoid, Left, Right, Initial, Inherit }

    public enum BasicRadiusState { LengthAbsolute, LengthPercent, Initial, Inherit }

    public enum BasicSpacingState { Normal, Length, Initial, Inherit }

    public enum BasicTimeState { Time, Initial, Inherit }

    public enum BasicValuesState { UseValues, Initial, Inherit }

    public enum BasicWidthState { Medium, Thin, Thick, Length, Initial, Inherit }

    public enum ColorTransparentState { Color, Transparent, Initial, Inherit }

    public enum LengthAutoState { Auto, Length, Initial, Inherit }

    public enum LengthNoneState { None, Length, Initial, Inherit }

    public enum LengthPercentState { LengthAbsolute, LengthPercent, Initial, Inherit }

    public enum LengthPercentNoneState { None, LengthAbsolute, LengthPercent, Initial, Inherit }

    public enum LengthPercentAutoState { Auto, LengthAbsolute, LengthPercent, Initial, Inherit }

    public enum NumberAutoState { Auto, Number, Initial, Inherit }

    public enum NumberLengthState { Number, Length, Initial, Inherit }

    public enum TextDecorationState { None, Underline, Overline, LineThrough, Initial, Inherit }

    public enum TimingFunctionState { Linear, Ease, EaseIn, EaseOut, EaseInOut, CubicBezier, Initial, Inherit }


    //Specific
    public enum AlignContentState { Stretch, Center, FlexStart, FlexEnd, SpaceBetween, SpaceAround, Initial, Inherit }

    public enum AlignItemsState { Stretch, Center, FlexStart, FlexEnd, Baseline, Initial, Inherit }

    public enum AlignSelfState { Auto, Stretch, Center, FlexStart, FlexEnd, Baseline, Initial, Inherit }

    public enum AnimationDirectionState { Normal, Reverse, Alternate, AlternateReverse, Initial, Inherit }

    public enum AnimationFillModeState { None, Forwards, Backwards, Both, Initial, Inherit }

    public enum AnimationIterationCountState { Number, Infinite, Initial, Inherit }

    public enum AnimationNameState { None, KeyFrameName, Initial, Inherit }

    public enum AnimationPlayStates { Paused, Running, Initial, Inherit }

    public enum BackfaceVisibilityState { Visible, Hidden, Initial, Inherit }

    public enum BackgroundAttachmentState { Scroll, Fixed, Local, Initial, Inherit }

    /******* Same thing but with different default values **************/
    public enum BackgroundClipState { BorderBox, PaddingBox, ContentBox, Initial, Inherit }

    public enum BackgroundOriginState { PaddingBox, BorderBox, ContentBox, Initial, Inherit }
    /*******************************************************************/

    public enum BackgroundPositionState
    {
        XY_Percent,
        XY_Absolute,
        LeftTop,
        LeftCenter,
        LeftBottom,
        RightTop,
        RightCenter,
        RightBottom,
        CenterTop,
        CenterCenter,
        CenterBottom,
        Initial,
        Inherit
    }

    public enum BackgroundRepeatState { Repeat, None, Repeat_X, Repeat_Y, Initial, Inherit }

    public enum BackgroundSizeState { Auto, Length, Percent, Cover, Contain, Initial, Inherit }

    public enum BorderCollapseState { Separate, Collapse, Initial, Inherit }

    public enum BorderImageRepeatState { Stretch, Repeat, Round, Initial, Inherit }

    public enum BorderImageSliceState { Number, Percent, Fill, Initial, Inherit }

    public enum BorderImageWidthState { Number, Length, Percent, Auto, Initial, Inherit }

    public enum BoxShadowState { None, Outset, Inset, Initial, Inherit }

    public enum BoxSizingState { ContentBox, BorderBox, Initial, Inherit }

    public enum CaptionSideState { Top, Bottom, Initial, Inherit }

    public enum ClearState { None, Left, Right, Both, Initial, Inherit }

    public enum ClipState { Auto, Shape, Initial, Inherit }

    public enum ColumnFillState { Balance, Auto, Initial, Inherit }

    public enum ColumnSpanState { One, All, Initial, Inherit }

    public enum ContentState
    {
        Normal,
        None,
        Counter,
        Attribute,
        String,
        OpenQuote,
        CloseQuote,
        NoOpenQuote,
        NoCloseQuote,
        Url,
        Initial,
        Inherit
    }

    public enum CounterIncrementState { None, Id, Initial, Inherit }

    public enum CounterResetState { None, Name_Number, Initial, Inherit }

    public enum CursorState
    {
        Alias,
        AllScroll,
        Auto,
        Cell,
        ContextMenu,
        ColResize,
        Copy,
        Crosshair,
        Default,
        E_Resize,
        EW_Resize,
        Help,
        Move,
        N_Resize,
        NE_Rresize,
        NESW_Resize,
        NS_Resize,
        NW_Resize,
        NWSE_Resize,
        NoDrop,
        None,
        NotAllowed,
        Pointer,
        Progress,
        RowResize,
        S_Resize,
        SE_Resize,
        SW_Resize,
        Text,
        Url,
        VerticalText,
        W_Resize,
        Wait,
        ZoomIn,
        ZoomOut,
        Initial,
        Inherit
    }

    public enum DirectionState { LeftToRight, RightToLeft, Initial, Inherit }

    public enum DisplayState
    {
        Inline,
        Block,
        Flex,
        InlineBlock,
        InlineFlex,
        InlineTable,
        ListItem,
        RunIn,
        Table,
        TableCaption,
        TableColumnGroup,
        TableHeaderGroup,
        TableFooterGroup,
        TableRowGroup,
        TableCell,
        TableColumn,
        TableRow,
        None,
        Initial,
        Inherit
    }

    public enum EmptyCellsState { Show, Hide, Initial, Inherit }

    public enum FlexState { Grow_Shrink_Basis, Auto, None, Initial, Inherit }

    public enum FlexDirectionState { Row, RowReverse, Column, ColumnReverse, Initial, Inherit }

    public enum FlexWrapState { NoWrap, Wrap, WrapReverse, Initial, Inherit }

    public enum FloatState { None, Left, Right, Initial, Inherit }

    public enum FontState { UseValues, Caption, Icon, Menu, MessageBox, SmallCaption, StatusBar, Initial, Inherit }

    public enum FontSizeState
    {
        Medium,
        XXSmall,
        XSmall,
        Small,
        Large,
        XLarge,
        XXLarge,
        Smaller,
        Larger,
        LengthAbsolute,
        LengthPercent,
        Initial,
        Inherit
    }

    public enum FontSizeAdjustState { Number, None, Initial, Inherit }

    public enum FontStretchState
    {
        None,
        Wider,
        Narrower,
        UltraCondensed,
        ExtraCondensed,
        Condensed,
        SemiCondensed,
        Normal,
        SemiExpanded,
        Expanded,
        ExtraExpanded,
        UltraExpanded,
        Initial,
        Inherit
    }

    public enum FontStyleState { Normal, Italic, Oblique, Initial, Inherit }

    public enum FontVariantState { Normal, SmallCaps, Initial, Inherit }

    public enum FontWeightState { Normal, Bold, Bolder, Lighter, Number, Initial, Inherit }

    public enum HangingPunctuationState { None, First, Last, AllowEnd, ForceEnd, Initial, Inherit }

    public enum IconState { Auto, Url, Initial, Inherit }

    public enum JustifyContentState { FlexStart, FlexEnd, Center, SpaceBetween, SpaceAround, Initial, Inherit }

    public enum LineHeightState { Normal, Number, LengthAbsolute, LengthPercent, Initial, Inherit }

    public enum ListStyleImageState { None, Image, Initial, Inherit }

    public enum ListStylePositionState { Inside, Outside, Initial, Inherit }

    public enum ListStyleTypeState
    {
        Disc,
        Armenian,
        Circle,
        CJK_Ideographic,
        Decimal,
        DecimalLeadingZero,
        Georgian,
        Hebrew,
        Hiragana,
        HiraganaIroha,
        Katakana,
        KatakanaIroha,
        LowerAlpha,
        LowerGreek,
        LowerLatin,
        LowerRoman,
        None,
        Square,
        UpperAlpha,
        UpperLatin,
        UpperRoman,
        Initial,
        Inherit
    }

    public enum OutlineColorState { Invert, Color, Initial, Inherit }

    public enum PageBreakInsideState { Auto, Avoid, Initial, Inherit }

    public enum PositionState { Static, Absolute, Fixed, Relative, Initial, Inherit }

    public enum QuotesState { Initial, None, UseValues, Inherit }

    public enum ResizeState { None, Both, Horizontal, Vertical, Initial, Inherit }

    public enum TableLayoutState { Auto, Fixed, Initial, Inherit }

    public enum TextAlignState { Left, Right, Center, Justify, Initial, Inherit }

    public enum TextAlignLastState { Auto, Left, Right, Center, Justify, Start, End, Initial, Inherit }

    public enum TextJustifyState
    {
        Auto,
        None,
        InterWord,
        InterIdeograph,
        InterCluster,
        Distribute,
        Kashida,
        Trim,
        Initial,
        Inherit
    }

    public enum TextOverflowState { Clip, Ellipsis, String, Initial, Inherit }

    public enum TextShadowState { UseValues, None, Initial, Inherit }

    public enum TextTransformState { None, Capitalize, Uppercase, Lowercase, Initial, Inherit }

    public enum TransformState
    {
        None,
        Matrix,
        Matrix3D,
        Translate,
        Translate3D,
        TranslateX,
        TranslateY,
        TranslateZ,
        Scale,
        Scale3D,
        ScaleX,
        ScaleY,
        ScaleZ,
        Rotate,
        Rotate3D,
        RotateX,
        RotateY,
        RotateZ,
        Skew,
        SkewX,
        SkewY,
        Perspective,
        Initial,
        Inherit
    }

    public enum TransformStyleState { Flat, Preserve3D, Initial, Inherit }

    public enum TransitionPropertyState { All, None, Property, Initial, Inherit }

    public enum UnicodeBidiState { Normal, Embed, BidiOverride, Initial, Inherit }

    public enum VerticalAlignState
    {
        Baseline,
        LengthAbsolute,
        LengthPercent,
        Sub,
        Super,
        Top,
        TextTop,
        Middle,
        Bottom,
        TextBottom,
        Initial,
        Inherit
    }

    public enum VisibilityState { Visible, Hidden, Collapse, Initial, Inherit }

    public enum WhiteSpaceState { Normal, Nowrap, Pre, PreLine, PreWrap, Initial, Inherit }

    public enum WordBreakState { Normal, BreakAll, KeepAll, Initial, Inherit }

    public enum WordWrapState { Normal, BreakWord, Initial, Inherit }
}
