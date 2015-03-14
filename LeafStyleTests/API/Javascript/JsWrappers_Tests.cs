/* 
    Copyright (C) 2015  Matthew Gefaller
    This file is part of Leaf.

    Leaf is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Leaf is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Leaf.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace LeafStyle.Tests
{
    [TestClass()]
    public class JsWrappers_Tests
    {
        [TestMethod]
        public void AlignContent_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            AlignContentState currentState;

            style.AlignContent = "initial";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.Initial);

            style.AlignContent = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.Inherit);

            style.AlignContent = "stretch";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.Stretch);

            style.AlignContent = "center";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.Center);

            style.AlignContent = "flex-start";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.FlexStart);

            style.AlignContent = "flex-end";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.FlexEnd);

            style.AlignContent = "space-between";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.SpaceBetween);

            style.AlignContent = "space-around";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == AlignContentState.SpaceAround);

            // Junk sets property to default
            style.AlignContent = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<AlignContentState>(Property.AlignContent, out currentState));
            Assert.IsTrue(currentState == default(AlignContentState) && currentState == AlignContentState.Stretch);
        }

        [TestMethod]
        public void AlignItems_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            AlignItemsState currentState;

            style.AlignItems = "initial";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.Initial);

            style.AlignItems = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.Inherit);

            style.AlignItems = "stretch";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.Stretch);

            style.AlignItems = "center";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.Center);

            style.AlignItems = "flex-start";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.FlexStart);

            style.AlignItems = "flex-end";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.FlexEnd);

            style.AlignItems = "baseline";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == AlignItemsState.Baseline);

            // Junk sets property to default
            style.AlignItems = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<AlignItemsState>(Property.AlignItems, out currentState));
            Assert.IsTrue(currentState == default(AlignItemsState) && currentState == AlignItemsState.Stretch);
        }

        [TestMethod]
        public void AlignSelf_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            AlignSelfState currentState;

            style.AlignSelf = "initial";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Initial);

            style.AlignSelf = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Inherit);

            style.AlignSelf = "auto";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Auto);

            style.AlignSelf = "stretch";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Stretch);

            style.AlignSelf = "center";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Center);

            style.AlignSelf = "flex-start";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.FlexStart);

            style.AlignSelf = "flex-end";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.FlexEnd);

            style.AlignSelf = "baseline";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == AlignSelfState.Baseline);

            // Junk sets property to default
            style.AlignSelf = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<AlignSelfState>(Property.AlignSelf, out currentState));
            Assert.IsTrue(currentState == default(AlignSelfState) && currentState == AlignSelfState.Auto);
        }

        [TestMethod]
        public void BackfaceVisibility_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            BackfaceVisibilityState currentState;

            style.BackfaceVisibility = "initial";
            Assert.IsTrue(style.TryGetCurrentState<BackfaceVisibilityState>(Property.BackfaceVisibility, out currentState));
            Assert.IsTrue(currentState == BackfaceVisibilityState.Initial);

            style.BackfaceVisibility = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<BackfaceVisibilityState>(Property.BackfaceVisibility, out currentState));
            Assert.IsTrue(currentState == BackfaceVisibilityState.Inherit);

            style.BackfaceVisibility = "hidden";
            Assert.IsTrue(style.TryGetCurrentState<BackfaceVisibilityState>(Property.BackfaceVisibility, out currentState));
            Assert.IsTrue(currentState == BackfaceVisibilityState.Hidden);

            style.BackfaceVisibility = "visible";
            Assert.IsTrue(style.TryGetCurrentState<BackfaceVisibilityState>(Property.BackfaceVisibility, out currentState));
            Assert.IsTrue(currentState == BackfaceVisibilityState.Visible);

            // Junk sets property to default
            style.BackfaceVisibility = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<BackfaceVisibilityState>(Property.BackfaceVisibility, out currentState));
            Assert.IsTrue(currentState == default(BackfaceVisibilityState) && currentState == BackfaceVisibilityState.Visible);
        }

        [TestMethod]
        public void Bottom_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            LengthPercentAutoState currentState;
            LengthPercentAutoProperty bottomProperty;

            style.Bottom = "initial";
            Assert.IsTrue(style.TryGetCurrentState<LengthPercentAutoState>(Property.Bottom, out currentState));
            Assert.IsTrue(currentState == LengthPercentAutoState.Initial);

            style.Bottom = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<LengthPercentAutoState>(Property.Bottom, out currentState));
            Assert.IsTrue(currentState == LengthPercentAutoState.Inherit);

            style.Bottom = "auto";
            Assert.IsTrue(style.TryGetCurrentState<LengthPercentAutoState>(Property.Bottom, out currentState));
            Assert.IsTrue(currentState == LengthPercentAutoState.Auto);
                        
            style.Bottom = "50px";
            bottomProperty = (LengthPercentAutoProperty)style.GetProperty(Property.Bottom);
            Assert.IsTrue(bottomProperty.CurrentState == LengthPercentAutoState.LengthAbsolute);
            Assert.IsTrue(bottomProperty.LengthAbsolute == 50);
            Assert.IsTrue(bottomProperty.LengthPercent == 0f);

            style.Bottom = "20%";
            bottomProperty = (LengthPercentAutoProperty)style.GetProperty(Property.Bottom);
            Assert.IsTrue(bottomProperty.CurrentState == LengthPercentAutoState.LengthPercent);
            Assert.IsTrue(bottomProperty.LengthAbsolute == 0);
            Assert.IsTrue(bottomProperty.LengthPercent == .2f);

            style.Bottom = "-100px";
            bottomProperty = (LengthPercentAutoProperty)style.GetProperty(Property.Bottom);
            Assert.IsTrue(bottomProperty.CurrentState == LengthPercentAutoState.LengthAbsolute);
            Assert.IsTrue(bottomProperty.LengthAbsolute == -100);
            Assert.IsTrue(bottomProperty.LengthPercent == 0f);

            style.Bottom = "-75%";
            bottomProperty = (LengthPercentAutoProperty)style.GetProperty(Property.Bottom);
            Assert.IsTrue(bottomProperty.CurrentState == LengthPercentAutoState.LengthPercent);
            Assert.IsTrue(bottomProperty.LengthAbsolute == 0);
            Assert.IsTrue(bottomProperty.LengthPercent == -.75f);

            // Junk sets property to default
            style.Bottom = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<LengthPercentAutoState>(Property.Bottom, out currentState));
            Assert.IsTrue(currentState == default(LengthPercentAutoState) && currentState == LengthPercentAutoState.Auto);
        }

        [TestMethod]
        public void BoxShadow_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            BoxShadowState currentState;
            BoxShadowProperty boxShadowProperty;

            style.BoxShadow = "initial";
            Assert.IsTrue(style.TryGetCurrentState<BoxShadowState>(Property.BoxShadow, out currentState));
            Assert.IsTrue(currentState == BoxShadowState.Initial);

            style.BoxShadow = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<BoxShadowState>(Property.BoxShadow, out currentState));
            Assert.IsTrue(currentState == BoxShadowState.Inherit);

            style.BoxShadow = "none";
            Assert.IsTrue(style.TryGetCurrentState<BoxShadowState>(Property.BoxShadow, out currentState));
            Assert.IsTrue(currentState == BoxShadowState.None);

            style.BoxShadow = "10px 10px black";
            boxShadowProperty = (BoxShadowProperty)style.GetProperty(Property.BoxShadow);
            Assert.IsTrue(boxShadowProperty.CurrentState == BoxShadowState.Outset);
            Assert.IsTrue(boxShadowProperty.Location.X == 10);
            Assert.IsTrue(boxShadowProperty.Location.Y == 10);
            Assert.IsTrue(boxShadowProperty.Color == Microsoft.Xna.Framework.Color.Black);

            style.BoxShadow = "-35px -50px 50px 20px blue";
            boxShadowProperty = (BoxShadowProperty)style.GetProperty(Property.BoxShadow);
            Assert.IsTrue(boxShadowProperty.CurrentState == BoxShadowState.Outset);
            Assert.IsTrue(boxShadowProperty.Location.X == -35);
            Assert.IsTrue(boxShadowProperty.Location.Y == -50);
            Assert.IsTrue(boxShadowProperty.Blur == 50);
            Assert.IsTrue(boxShadowProperty.Spread == 20);
            Assert.IsTrue(boxShadowProperty.Color == Microsoft.Xna.Framework.Color.Blue);

            style.BoxShadow = "20px 10px 5px 10px rgba(10,65,35,0.7) inset";
            boxShadowProperty = (BoxShadowProperty)style.GetProperty(Property.BoxShadow);
            Assert.IsTrue(boxShadowProperty.CurrentState == BoxShadowState.Inset);
            Assert.IsTrue(boxShadowProperty.Location.X == 20);
            Assert.IsTrue(boxShadowProperty.Location.Y == 10);
            Assert.IsTrue(boxShadowProperty.Blur == 5);
            Assert.IsTrue(boxShadowProperty.Spread == 10);
            Assert.IsTrue(boxShadowProperty.Color == new Microsoft.Xna.Framework.Color(10, 65, 35, .7f));

            // Junk sets property to default
            style.BoxShadow = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<BoxShadowState>(Property.BoxShadow, out currentState));
            Assert.IsTrue(currentState == default(BoxShadowState) && currentState == BoxShadowState.None);
        }

        [TestMethod]
        public void BoxSizing_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            BoxSizingState currentState;

            style.BoxSizing = "initial";
            Assert.IsTrue(style.TryGetCurrentState<BoxSizingState>(Property.BoxSizing, out currentState));
            Assert.IsTrue(currentState == BoxSizingState.Initial);

            style.BoxSizing = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<BoxSizingState>(Property.BoxSizing, out currentState));
            Assert.IsTrue(currentState == BoxSizingState.Inherit);

            style.BoxSizing = "content-box";
            Assert.IsTrue(style.TryGetCurrentState<BoxSizingState>(Property.BoxSizing, out currentState));
            Assert.IsTrue(currentState == BoxSizingState.ContentBox);

            style.BoxSizing = "border-box";
            Assert.IsTrue(style.TryGetCurrentState<BoxSizingState>(Property.BoxSizing, out currentState));
            Assert.IsTrue(currentState == BoxSizingState.BorderBox);

            // Junk sets property to default
            style.BoxSizing = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<BoxSizingState>(Property.BoxSizing, out currentState));
            Assert.IsTrue(currentState == default(BoxSizingState) && currentState == BoxSizingState.ContentBox);
        }
        
        [TestMethod]
        public void CaptionSide_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            CaptionSideState currentState;

            style.CaptionSide = "initial";
            Assert.IsTrue(style.TryGetCurrentState<CaptionSideState>(Property.CaptionSide, out currentState));
            Assert.IsTrue(currentState == CaptionSideState.Initial);

            style.CaptionSide = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<CaptionSideState>(Property.CaptionSide, out currentState));
            Assert.IsTrue(currentState == CaptionSideState.Inherit);

            style.CaptionSide = "top";
            Assert.IsTrue(style.TryGetCurrentState<CaptionSideState>(Property.CaptionSide, out currentState));
            Assert.IsTrue(currentState == CaptionSideState.Top);

            style.CaptionSide = "bottom";
            Assert.IsTrue(style.TryGetCurrentState<CaptionSideState>(Property.CaptionSide, out currentState));
            Assert.IsTrue(currentState == CaptionSideState.Bottom);

            // Junk sets property to default
            style.CaptionSide = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<CaptionSideState>(Property.CaptionSide, out currentState));
            Assert.IsTrue(currentState == default(CaptionSideState) && currentState == CaptionSideState.Top);
        }

        [TestMethod]
        public void Clear_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            ClearState currentState;

            style.Clear = "initial";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.Initial);

            style.Clear = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.Inherit);

            style.Clear = "none";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.None);

            style.Clear = "left";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.Left);

            style.Clear = "right";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.Right);

            style.Clear = "both";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == ClearState.Both);

            // Junk sets property to default
            style.Clear = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<ClearState>(Property.Clear, out currentState));
            Assert.IsTrue(currentState == default(ClearState) && currentState == ClearState.None);
        }

        [TestMethod]
        public void Clip_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            ClipState currentState;
            ClipProperty clipProperty;

            style.Clip = "initial";
            Assert.IsTrue(style.TryGetCurrentState<ClipState>(Property.Clip, out currentState));
            Assert.IsTrue(currentState == ClipState.Initial);

            style.Clip = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<ClipState>(Property.Clip, out currentState));
            Assert.IsTrue(currentState == ClipState.Inherit);

            style.Clip = "auto";
            Assert.IsTrue(style.TryGetCurrentState<ClipState>(Property.Clip, out currentState));
            Assert.IsTrue(currentState == ClipState.Auto);

            style.Clip = "rect(10px,100px,50px,10px)";
            clipProperty = (ClipProperty)style.GetProperty(Property.Clip);
            Assert.IsTrue(clipProperty.CurrentState == ClipState.Shape);
            Assert.IsTrue(clipProperty.ClipRectangle == new Microsoft.Xna.Framework.Rectangle(10, 10, 100, 50));

            // Junk sets property to default
            style.Clip = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<ClipState>(Property.Clip, out currentState));
            Assert.IsTrue(currentState == default(ClipState) && currentState == ClipState.Auto);
        }

        [TestMethod]
        public void Color_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            BasicColorState currentState;
            BasicColorProperty colorProperty;

            style.Color = "initial";
            Assert.IsTrue(style.TryGetCurrentState<BasicColorState>(Property.Color, out currentState));
            Assert.IsTrue(currentState == BasicColorState.Initial);

            style.Color = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<BasicColorState>(Property.Color, out currentState));
            Assert.IsTrue(currentState == BasicColorState.Inherit);

            style.Color = "red";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == Microsoft.Xna.Framework.Color.Red);

            style.Color = "#ff0";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(255, 255, 0));

            style.Color = "#00ff00";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(0, 255, 0));

            style.Color = "rgb(254, 87, 256)";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(254, 87, 255));

            style.Color = "rgba(24, 187, 256, 0.5)";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(24, 187, 255, 0.5f));

            style.Color = "hsl(120, 100%, 50%)";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(0, 255, 0));

            style.Color = "hsla(120, 100%, 75%, 0.3)";
            colorProperty = (BasicColorProperty)style.GetProperty(Property.Color);
            Assert.IsTrue(colorProperty.Color == new Microsoft.Xna.Framework.Color(128, 255, 128));

            // Junk sets property to default
            style.Color = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<BasicColorState>(Property.Color, out currentState));
            Assert.IsTrue(currentState == default(BasicColorState) && currentState == BasicColorState.Inherit);
        }

        [TestMethod]
        public void Cursor_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

            CursorState currentState;
            CursorProperty cursorProperty;

            style.Cursor = "initial";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Initial);

            style.Cursor = "inherit";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Inherit);

            style.Cursor = "alias";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Alias);
            
            style.Cursor = "all-scroll";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.AllScroll);
            
            style.Cursor = "auto";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Auto);

            style.Cursor = "cell";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Cell);

            style.Cursor = "context-menu";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.ContextMenu);

            style.Cursor = "col-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.ColResize);

            style.Cursor = "copy";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Copy);

            style.Cursor = "crosshair";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Crosshair);

            style.Cursor = "default";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Default);

            style.Cursor = "e-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.E_Resize);

            style.Cursor = "ew-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.EW_Resize);

            style.Cursor = "grab";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Grab);

            style.Cursor = "grabbing";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Grabbing);

            style.Cursor = "help";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Help);

            style.Cursor = "move";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Move);

            style.Cursor = "n-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.N_Resize);

            style.Cursor = "ne-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NE_Rresize);

            style.Cursor = "nesw-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NESW_Resize);

            style.Cursor = "ns-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NS_Resize);

            style.Cursor = "nw-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NW_Resize);

            style.Cursor = "nwse-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NWSE_Resize);

            style.Cursor = "no-drop";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NoDrop);

            style.Cursor = "none";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.None);

            style.Cursor = "not-allowed";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.NotAllowed);

            style.Cursor = "pointer";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Pointer);

            style.Cursor = "progress";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Progress);

            style.Cursor = "row-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.RowResize);

            style.Cursor = "s-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.S_Resize);

            style.Cursor = "se-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.SE_Resize);

            style.Cursor = "sw-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.SW_Resize);

            style.Cursor = "text";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Text);
            
            style.Cursor = "vertical-text";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.VerticalText);

            style.Cursor = "w-resize";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.W_Resize);

            style.Cursor = "wait";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.Wait);

            style.Cursor = "zoom-in";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.ZoomIn);

            style.Cursor = "zoom-out";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == CursorState.ZoomOut);

            style.Cursor = "url(smiley.gif),url(myBall.cur),default";
            cursorProperty = (CursorProperty)style.GetProperty(Property.Cursor);            
            Assert.IsTrue(cursorProperty.CurrentState == CursorState.Url);
            Assert.IsTrue(cursorProperty.UrlList.Contains("smiley.gif") && 
                            cursorProperty.UrlList.Contains("myBall.cur"));
            Assert.IsTrue(cursorProperty.BackupState == CursorState.Default);

            style.Cursor = "asdf";
            Assert.IsTrue(style.TryGetCurrentState<CursorState>(Property.Cursor, out currentState));
            Assert.IsTrue(currentState == default(CursorState) && currentState == CursorState.Auto);
        }

        [TestMethod]
        public void Direction_CorrectlySetsValue()
        {
            UIStyle style = new UIStyle(null);

        }




        [TestMethod]
        public void Display_CorrectlySetsValue()
        { }





        [TestMethod]
        public void EmptyCells_CorrectlySetsValue()
        { }






        [TestMethod]
        public void Float_CorrectlySetsValue()
        { }





        [TestMethod]
        public void HangingPunctuation_CorrectlySetsValue()
        { }









        [TestMethod]
        public void Height_CorrectlySetsValue()
        { }





        [TestMethod]
        public void Icon_CorrectlySetsValue()
        { }







        [TestMethod]
        public void JustifyContent_CorrectlySetsValue()
        { }










        [TestMethod]
        public void Keyframes_CorrectlySetsValue()
        { }








        [TestMethod]
        public void Left_CorrectlySetsValue()
        { }




        [TestMethod]
        public void LetterSpacing_CorrectlySetsValue()
        { }






        [TestMethod]
        public void LineHeight_CorrectlySetsValue()
        { }







        [TestMethod]
        public void MaxHeight_CorrectlySetsValue()
        { }







        [TestMethod]
        public void MaxWidth_CorrectlySetsValue()
        { }




        [TestMethod]
        public void Media_CorrectlySetsValue()
        { }








        [TestMethod]
        public void MinHeight_CorrectlySetsValue()
        { }








        [TestMethod]
        public void MinWidth_CorrectlySetsValue()
        { }





        [TestMethod]
        public void NavDown_CorrectlySetsValue()
        { }




        [TestMethod]
        public void NavIndex_CorrectlySetsValue()
        { }





        [TestMethod]
        public void NavLeft_CorrectlySetsValue()
        { }





        [TestMethod]
        public void NavRight_CorrectlySetsValue()
        { }





        [TestMethod]
        public void NavUp_CorrectlySetsValue()
        { }






        [TestMethod]
        public void Opacity_CorrectlySetsValue()
        { }







        [TestMethod]
        public void Order_CorrectlySetsValue()
        { }




        [TestMethod]
        public void Overflow_CorrectlySetsValue()
        { }







        [TestMethod]
        public void OverflowX_CorrectlySetsValue()
        { }







        [TestMethod]
        public void OverflowY_CorrectlySetsValue()
        { }







        [TestMethod]
        public void PageBreakAfter_CorrectlySetsValue()
        { }






        [TestMethod]
        public void PageBreakBefore_CorrectlySetsValue()
        { }






        [TestMethod]
        public void PageBreakInside_CorrectlySetsValue()
        { }












        [TestMethod]
        public void Perspective_CorrectlySetsValue()
        { }










        [TestMethod]
        public void PerspectiveOrigin_CorrectlySetsValue()
        { }





        [TestMethod]
        public void Position_CorrectlySetsValue()
        { }




        [TestMethod]
        public void Quotes_CorrectlySetsValue()
        { }







        [TestMethod]
        public void Resize_CorrectlySetsValue()
        { }








        [TestMethod]
        public void Right_CorrectlySetsValue()
        { }




        [TestMethod]
        public void TabSize_CorrectlySetsValue()
        { }




        [TestMethod]
        public void TableLayout_CorrectlySetsValue()
        { }








        [TestMethod]
        public void Top_CorrectlySetsValue()
        { }





        [TestMethod]
        public void Transform_CorrectlySetsValue()
        { }








        [TestMethod]
        public void TransformOrigin_CorrectlySetsValue()
        { }






        [TestMethod]
        public void TransformStyle_CorrectlySetsValue()
        { }





        [TestMethod]
        public void UnicodeBidi_CorrectlySetsValue()
        { }




        [TestMethod]
        public void VerticalAlign_CorrectlySetsValue()
        { }







        [TestMethod]
        public void Visibility_CorrectlySetsValue()
        { }




        [TestMethod]
        public void WhiteSpace_CorrectlySetsValue()
        { }









        [TestMethod]
        public void Width_CorrectlySetsValue()
        { }






        [TestMethod]
        public void WordBreak_CorrectlySetsValue()
        { }






        [TestMethod]
        public void WordSpacing_CorrectlySetsValue()
        { }




        [TestMethod]
        public void WordWrap_CorrectlySetsValue()
        { }








        [TestMethod]
        public void ZIndex_CorrectlySetsValue()
        { }
    }
}
