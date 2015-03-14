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

using System.Collections.Generic;

namespace LeafStyle
{
    public class DisplayProperty : BasicStyleProperty<DisplayState>
    {
        public DisplayProperty()
            : base(
                    defaultState: default(DisplayState),
                    inherited: false,
                    animatable: false
            )
        {
            this.StateValues = new Dictionary<string, DisplayState>()
				{
					{"inline", DisplayState.Inline },
					{"block", DisplayState.Block },
					{"flex", DisplayState.Flex },
					{"inline-block", DisplayState.InlineBlock },
					{"inline-flex", DisplayState.InlineFlex },
					{"inline-table", DisplayState.InlineTable },
					{"list-item", DisplayState.ListItem },
					{"run-in", DisplayState.RunIn },
					{"table", DisplayState.Table },
					{"table-caption", DisplayState.TableCaption },
					{"table-column-group", DisplayState.TableColumnGroup },
					{"table-header-group", DisplayState.TableHeaderGroup },
					{"table-footer-group", DisplayState.TableFooterGroup },
					{"table-row-group", DisplayState.TableRowGroup },
					{"table-cell", DisplayState.TableCell },
					{"table-column", DisplayState.TableColumn },
					{"table-row", DisplayState.TableRow },
					{"none", DisplayState.None },
					{"initial", DisplayState.Initial },
					{"inherit", DisplayState.Inherit }
				};
        }
    }
}