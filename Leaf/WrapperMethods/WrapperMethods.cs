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
using System.Linq;

namespace LeafStyle
{
    public partial class Style
    {
        //Needs more testing
        //If state is null remove from StyleProperties
        private bool SetProperty<TState>(Property property, TState? stateValue)
            where TState : struct, IConvertible
        {
            if (typeof(TState).IsEnum)
            {
                if (stateValue != null)
                {
                    Type newType; // Stores the retrieved Type of the StyleProperty
                    if (this.StyleProperties.ContainsKey(property))
                    {
                        if (typeof(TState) == ((dynamic)this.StyleProperties[property]).GetTypeOfValues())
                        {
                            ((dynamic)this.StyleProperties[property])
                                .CurrentState = (TState)stateValue; //Cast to remove ability to nullify when setting

                            return true;
                        }
                        else
                        {
                            // The TState type dosen't match the type of the property's values
                            return false;
                        }
                    }
                    else
                    {
                        if (Value.GetPropertyType(property, out newType)) // If type is returned
                        {
                            try
                            {
                                var newObj = Activator.CreateInstance(newType);
                                ((dynamic)newObj).CurrentState = (TState)stateValue; //Cast to remove ability to nullify when setting

                                this.AddOrOverwrite(property, (StyleProperty)newObj);
                            }
                            catch
                            {
                                // Something went wrong so return false
                                return false;
                            }
                        }
                        else
                        {
                            // Couldn't find type
                            return false;
                        }
                    }

                    // Check to make sure the property was set correctly
                    return (StyleProperties[property].GetType() == newType);
                }
                else // The state value is null so remove property from Dictionary
                {
                    if (this.StyleProperties.Keys.Contains(property))
                        this.StyleProperties.Remove(property);

                    // return whether the Key is still in the Dictionary
                    return StyleProperties.Keys.Contains(property);
                }
            }
            else
            {
                // Wasn't an Enum so the values was not set
                return false;
            }
        }

        // First calls SetProperty<> then passes the boxed value along to the property object
        private bool SetProperty<TState>(Property property, TState? stateValue, object value)
            where TState : struct, IConvertible
        {
            if (this.SetProperty<TState>(property, stateValue)) // Will create the porperty and add to StyleProperties if doesn't exist
            {
                return StyleProperties[property].TrySetValue(value);
            }
            else
            {
                return false;
            }
        }

        // First calls the SetProperty<> then passes the boxed values along to the property object
        private bool SetProperty<TState>(Property property, TState? stateValue, object[] values)
            where TState : struct, IConvertible
        {
            if (this.SetProperty<TState>(property, stateValue))// Will create the porperty and add to StyleProperties if doesn't exist
            {
                return StyleProperties[property].TrySetValues(values);
            }
            else
            {
                return false;
            }
        }

        public void AlignContent(AlignContentState? alignContentState)
        {
            this.SetProperty<AlignContentState>(Property.AlignContent, alignContentState);
        }

        public void AlignItems(AlignItemsState? alignItemsState)
        {
            this.SetProperty<AlignItemsState>(Property.AlignItems, alignItemsState);
        }

        public void AlignSelf(AlignSelfState? alignSelfState)
        {
            this.SetProperty<AlignSelfState>(Property.AlignSelf, alignSelfState);
        }

        public void BackfaceVisibility(BackfaceVisibilityState? backfaceVisibilityState)
        {
            this.SetProperty<BackfaceVisibilityState>(Property.BackfaceVisibility, backfaceVisibilityState);
        }

        public void Bottom(LengthPercentAutoState? bottomState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Bottom, bottomState);
        }
        public void Bottom(int length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Bottom, LengthPercentAutoState.LengthAbsolute, (object)length);
        }
        public void Bottom(float length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Bottom, LengthPercentAutoState.LengthPercent, (object)length);
        }

        public void BoxShadow(BoxShadowState? boxShadowState)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, boxShadowState);
        }
        public void BoxShadow(Point location)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, BoxShadowState.Outset, (object)location);
        }
        public void BoxShadow(Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, BoxShadowState.Outset, (object)color);
        }
        public void BoxShadow(BoxShadowState? boxShadowState, Point location)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, boxShadowState, (object)location);
        }
        public void BoxShadow(BoxShadowState? boxShadowState, Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, boxShadowState, (object)color);
        }
        public void BoxShadow(BoxShadowState? boxShadowState, Point location, Microsoft.Xna.Framework.Color color)
        {
            this.SetProperty<BoxShadowState>(Property.BoxShadow, boxShadowState, new object[] { (object)location, (object)color });
        }

        public void BoxSizing(BoxSizingState? boxSizingState)
        {
            this.SetProperty<BoxSizingState>(Property.BoxSizing, boxSizingState);
        }

        public void CaptionSide(CaptionSideState? captionSideState)
        {
            this.SetProperty<CaptionSideState>(Property.CaptionSide, captionSideState);
        }

        public void Clear(ClearState? clearState)
        {
            this.SetProperty<ClearState>(Property.Clear, clearState);
        }

        public void Clip(ClipState? clipState)
        {
            this.SetProperty<ClipState>(Property.Clip, clipState);
        }

        public void Color(BasicColorState? colorState)
        {
            this.SetProperty<BasicColorState>(Property.Color, colorState);
        }
        public void Color(Microsoft.Xna.Framework.Color textColor)
        {
            this.SetProperty<BasicColorState>(Property.Color, BasicColorState.Color, (object)textColor);
        }

        //public void Content(ContentState? contentState)
        //{
        //    this.SetProperty<ContentState>(Property.Content, contentState);
        //}
        //public void Content(ContentState contentState, ContentValuesContainer contentValues)
        //{
        //    this.SetProperty<ContentState>(Property.Content, contentState, (object)contentValues);
        //}

        public void CounterIncrement(CounterIncrementState? counterIncrementState)
        {
            this.SetProperty<CounterIncrementState>(Property.CounterIncrement, counterIncrementState);
        }
        public void CounterIncrement(PropertyString id)
        {
            this.SetProperty<CounterIncrementState>(Property.CounterIncrement, CounterIncrementState.Id, (object)id.StringValue);
        }

        public void CounterReset(CounterResetState? counterResetState)
        {
            this.SetProperty<CounterResetState>(Property.CounterReset, counterResetState);
        }
        public void CounterReset(PropertyString counterName)
        {
            this.SetProperty<CounterResetState>(Property.CounterReset, CounterResetState.Name_Number,
                new object[] { counterName.StringValue, 0 });
        }
        public void CounterReset(PropertyString counterName, int number)
        {
            this.SetProperty<CounterResetState>(Property.CounterReset, CounterResetState.Name_Number,
                new object[] { counterName.StringValue, number });
        }

        public void Cursor(CursorState? cursorState)
        {
            this.SetProperty<CursorState>(Property.Cursor, cursorState);
        }
        public void Cursor(PropertyStringList urlList, CursorState backupCursor)
        {
            this.SetProperty<CursorState>(Property.Cursor, CursorState.Url, new object[] { urlList, backupCursor });
        }

        public void Direction(DirectionState? directionState)
        {
            SetProperty<DirectionState>(Property.Direction, directionState);
        }

        public void Display(DisplayState? displayState)
        {
            SetProperty<DisplayState>(Property.Display, displayState);
        }

        public void EmptyCells(EmptyCellsState? emptyCellsState)
        {
            this.SetProperty<EmptyCellsState>(Property.EmptyCells, emptyCellsState);
        }

        // float is not going to work so the javascript property was changed to floating 
        // the Wrapper Method was changed also to reflect the javascript property change
        public void Floating(FloatState? floatState)
        {
            this.SetProperty<FloatState>(Property.Float, floatState);
        }

        public void HangingPunctuation(HangingPunctuationState? hangingPunctuationState)
        {
            this.SetProperty<HangingPunctuationState>(Property.HangingPunctuation, hangingPunctuationState);
        }

        public void Height(LengthPercentAutoState? heightState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Height, heightState);
        }
        public void Height(int height)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Height, LengthPercentAutoState.LengthAbsolute, (object)height);
        }
        public void Height(float height)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Height, LengthPercentAutoState.LengthPercent, (object)height);
        }

        public void Icon(IconState? iconState)
        {
            this.SetProperty<IconState>(Property.Icon, iconState);
        }
        public void Icon(PropertyString imageName)
        {
            this.SetProperty<IconState>(Property.Icon, IconState.Url, (object)imageName);
        }

        public void JustifyContent(JustifyContentState? justifyContentState)
        {
            this.SetProperty<JustifyContentState>(Property.JustifyContent, justifyContentState);
        }

        //public void KeyFrames() { }

        public void Left(LengthPercentAutoState? leftState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Left, leftState);
        }
        public void Left(int length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Left, LengthPercentAutoState.LengthAbsolute, (object)length);
        }
        public void Left(float length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Left, LengthPercentAutoState.LengthPercent, (object)length);
        }

        public void LetterSpacing(BasicSpacingState? letterSpacingState)
        {
            this.SetProperty<BasicSpacingState>(Property.LetterSpacing, letterSpacingState);
        }
        public void LetterSpacing(int length)
        {
            this.SetProperty<BasicSpacingState>(Property.LetterSpacing, BasicSpacingState.Length, (object)length);
        }

        public void LineHeight(LineHeightState? lineHeightState)
        {
            this.SetProperty<LineHeightState>(Property.LineHeight, lineHeightState);
        }
        public void LineHeight(short number)
        {
            this.SetProperty<LineHeightState>(Property.LineHeight, LineHeightState.Number, (object)number);
        }
        public void LineHeight(int length)
        {
            this.SetProperty<LineHeightState>(Property.LineHeight, LineHeightState.Number, (object)length);
        }
        public void LineHeight(float length)
        {
            this.SetProperty<LineHeightState>(Property.LineHeight, LineHeightState.Number, (object)length);
        }

        public void MaxHeight(LengthPercentNoneState? maxHeightState) 
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxHeight, maxHeightState);
        }
        public void MaxHeight(int height)
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxHeight, LengthPercentNoneState.LengthAbsolute, (object)height);
        }
        public void MaxHeight(float height)
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxHeight, LengthPercentNoneState.LengthPercent, (object)height);
        }

        public void MaxWidth(LengthPercentNoneState? maxWidthState)
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxWidth, maxWidthState);
        }
        public void MaxWidth(int width)
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxWidth, LengthPercentNoneState.LengthAbsolute, (object)width);
        }
        public void MaxWidth(float width)
        {
            this.SetProperty<LengthPercentNoneState>(Property.MaxWidth, LengthPercentNoneState.LengthPercent, (object)width);
        }

        public void MinHeight(LengthPercentState? minHeightState) 
        {
            this.SetProperty<LengthPercentState>(Property.MinHeight, minHeightState);
        }
        public void MinHeight(int height)
        {
            this.SetProperty<LengthPercentState>(Property.MinHeight, LengthPercentState.LengthAbsolute, (object)height);
        }
        public void MinHeight(float height)
        {
            this.SetProperty<LengthPercentState>(Property.MinHeight, LengthPercentState.LengthPercent, (object)height);
        }

        public void MinWidth(LengthPercentState? minWidthState)
        {
            this.SetProperty<LengthPercentState>(Property.MinWidth, minWidthState);
        }
        public void MinWidth(int width)
        {
            this.SetProperty<LengthPercentState>(Property.MinWidth, LengthPercentState.LengthAbsolute, (object)width);
        }
        public void MinWidth(float width)
        {
            this.SetProperty<LengthPercentState>(Property.MinWidth, LengthPercentState.LengthPercent, (object)width);
        }

        public void Opacity(BasicNumberState? opacityState) 
        {
            this.SetProperty<BasicNumberState>(Property.Opacity, opacityState);
        }
        public void Opacity(float number)
        {
            this.SetProperty<BasicNumberState>(Property.Opacity, BasicNumberState.Number, (object)number);
        }

        public void Order(BasicNumberState? orderState)
        {
            this.SetProperty<BasicNumberState>(Property.Order, orderState);
        }
        public void Order(int number)
        {
            this.SetProperty<BasicNumberState>(Property.Order, BasicNumberState.Number, (object)number);
        }

        public void Overflow(BasicOverflowState? overflowState) 
        {
            this.SetProperty<BasicOverflowState>(Property.Overflow, overflowState);
        }

        public void OverflowX(BasicOverflowState? overflowXState)
        {
            this.SetProperty<BasicOverflowState>(Property.OverflowX, overflowXState);
        }

        public void OverflowY(BasicOverflowState? overflowYState)
        {
            this.SetProperty<BasicOverflowState>(Property.OverflowY, overflowYState);
        }

        public void PageBreakAfter(BasicPageBreakState? pageBreakAfterState) 
        {
            this.SetProperty<BasicPageBreakState>(Property.PageBreakAfter, pageBreakAfterState);
        }

        public void PageBreakBefore(BasicPageBreakState? pageBreakBeforeState) 
        {
            this.SetProperty<BasicPageBreakState>(Property.PageBreakBefore, pageBreakBeforeState);
        }

        public void PageBreakInside(PageBreakInsideState? pageBreakInsideState)
        {
            this.SetProperty<PageBreakInsideState>(Property.PageBreakInside, pageBreakInsideState);
        }

        public void Perspective(LengthNoneState? perspectiveState) 
        {
            this.SetProperty<LengthNoneState>(Property.Perspective, perspectiveState);
        }
        public void Perspective(int length)
        {
            this.SetProperty<LengthNoneState>(Property.Perspective, LengthNoneState.Length, (object)length);
        }

        //public void PerspectiveOrigin() { }

        public void Position(PositionState? positionState) 
        {
            this.SetProperty<PositionState>(Property.Position, positionState);
        }

        public void Quotes(QuotesState? quotesState) 
        {
            this.SetProperty<QuotesState>(Property.Quotes, quotesState);
        }
        public void Quotes(QuoteValuesContainer quotesValuesContainer)
        {
            this.SetProperty<QuotesState>(Property.Quotes, QuotesState.UseValues, (object)quotesValuesContainer);
        }

        public void Resize(ResizeState? resizeState) 
        {
            this.SetProperty<ResizeState>(Property.Resize, resizeState);
        }

        public void Right(LengthPercentAutoState? rightState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Right, rightState);
        }
        public void Right(int length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Right, LengthPercentAutoState.LengthAbsolute, (object)length);
        }
        public void Right(float length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Right, LengthPercentAutoState.LengthPercent, (object)length);
        }

        public void TabSize(NumberLengthState? tabSizeState)
        {
            this.SetProperty<NumberLengthState>(Property.TabSize, tabSizeState);
        }
        public void TabSize(int length)
        {
            this.SetProperty<NumberLengthState>(Property.TabSize, NumberLengthState.Length, (object)length);
        }
        public void TabSize(short numberOfSpaces)
        {
            this.SetProperty<NumberLengthState>(Property.TabSize, NumberLengthState.Number, (object)numberOfSpaces);
        }

        public void TableLayout(TableLayoutState? tableLayoutState) 
        {
            this.SetProperty<TableLayoutState>(Property.TableLayout, tableLayoutState);
        }

        public void Top(LengthPercentAutoState? topState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Top, topState);
        }
        public void Top(int length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Top, LengthPercentAutoState.LengthAbsolute, (object)length);
        }
        public void Top(float length)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Top, LengthPercentAutoState.LengthPercent, (object)length);
        }

        public void UnicodeBidi(UnicodeBidiState? unicodeBidiState)
        {
            this.SetProperty<UnicodeBidiState>(Property.UnicodeBidi, unicodeBidiState);
        }

        public void VerticalAlign(VerticalAlignState? verticalAlignState)
        {
            this.SetProperty<VerticalAlignState>(Property.VerticalAlign, verticalAlignState);
        }
        public void VerticalAlign(int length)
        {
            this.SetProperty<VerticalAlignState>(Property.VerticalAlign, VerticalAlignState.LengthAbsolute, (object)length);
        }
        public void VerticalAlign(float length)
        {
            this.SetProperty<VerticalAlignState>(Property.VerticalAlign, VerticalAlignState.LengthPercent, (object)length);
        }

        public void Visibility(VisibilityState? visibilityState)
        {
            this.SetProperty<VisibilityState>(Property.Visibility, visibilityState);
        }

        public void WhiteSpace(WhiteSpaceState? whiteSpaceState)
        {
            this.SetProperty<WhiteSpaceState>(Property.WhiteSpace, whiteSpaceState);
        }

        public void Width(LengthPercentAutoState? widthState)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Width, widthState);
        }
        public void Width(int lengthAbsolute)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Width, LengthPercentAutoState.LengthAbsolute, (object)lengthAbsolute);
        }
        public void Width(float lengthPercent)
        {
            this.SetProperty<LengthPercentAutoState>(Property.Width, LengthPercentAutoState.LengthPercent, (object)lengthPercent);
        }

        public void WordBreak(WordBreakState? wordBreakState)
        {
            this.SetProperty<WordBreakState>(Property.WordBreak, wordBreakState);
        }

        public void WordSpacing(BasicSpacingState? wordSpacingState)
        {
            this.SetProperty<BasicSpacingState>(Property.WordSpacing, wordSpacingState);
        }
        public void WordSpacing(int length)
        {
            this.SetProperty<BasicSpacingState>(Property.WordSpacing, BasicSpacingState.Length, (object)length);
        }

        public void WordWrap(WordWrapState? wordWrapState)
        {
            this.SetProperty<WordWrapState>(Property.WordWrap, wordWrapState);
        }

        public void ZIndex(NumberAutoState? zIndexState)
        {
            this.SetProperty<NumberAutoState>(Property.ZIndex, zIndexState);
        }
        public void ZIndex(int index)
        {
            this.SetProperty<NumberAutoState>(Property.ZIndex, NumberAutoState.Number, (object)index);
        }
    }
}