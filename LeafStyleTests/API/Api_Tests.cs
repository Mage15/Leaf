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
namespace LeafStyle.Tests
{
    [TestClass()]
    public class Api_Tests
    {
        [TestMethod]
        public void GetCurrentProperties_ReturnsCorrectProperties()
        {
            UIStyle style = new UIStyle(null);

            style.ColumnCount = "3";
            style.MarginBottom = "100px";
            style.PaddingRight = "50px";

            var propList = style.GetCurrentProperties();

            Assert.IsTrue(propList.Count == 3);
            Assert.IsTrue(propList[0] == Property.ColumnCount);
            Assert.IsTrue(propList[1] == Property.MarginBottom);
            Assert.IsTrue(propList[2] == Property.PaddingRight);
        }

        [TestMethod]
        public void ClearStyle_ClearsOutAllProperties()
        {
            UIStyle style = new UIStyle(null);

            style.ColumnCount = "3";
            style.MarginBottom = "100px";
            style.PaddingRight = "50px";

            var propList = style.GetCurrentProperties();

            Assert.IsTrue(propList.Count == 3);

            style.ClearStyle();
            propList = style.GetCurrentProperties();

            Assert.IsTrue(propList.Count == 0);
        }
        
        
    }
}
