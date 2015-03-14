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
    public class FontWeightProperty : BasicStyleProperty<FontWeightState>
    {
        private int number;
        public int Number
        {
            get { return this.number; }
            set
            {
                switch (value)
                {
                    case 100:
                        this.number = 100;
                        break;
                    case 200:
                        this.number = 200;
                        break;
                    case 300:
                        this.number = 300;
                        break;
                    case 400:
                        this.number = 400;
                        break;
                    case 500:
                        this.number = 500;
                        break;
                    case 600:
                        this.number = 600;
                        break;
                    case 700:
                        this.number = 700;
                        break;
                    case 800:
                        this.number = 800;
                        break;
                    case 900:
                        this.number = 900;
                        break;
                    default:
                        this.number = 0;
                        break;
                }
            }
        }

        public FontWeightProperty()
            : base(
                defaultState: default(FontWeightState),
                inherited: true,
                animatable: true
            )
        {
            this.StateValues = new Dictionary<string, FontWeightState>()
                {
                    {"normal", FontWeightState.Normal},
                    {"bold", FontWeightState.Bold},
                    {"bolder", FontWeightState.Bolder},
                    {"lighter", FontWeightState.Lighter},
                    {"number", FontWeightState.Number},
                    {"initial", FontWeightState.Initial},
                    {"inherit", FontWeightState.Inherit}
                };
        }

        public override bool TrySetStateValue(string value)
        {
            if (base.TrySetStateValue(value))
            {
                return true;
            }
            else if (value != null)
            {
                // Number can only be set to specific number values. If the default logic is hit
                // Number is set to 0 and false is returned. Otherwise the logic continues on.
                switch (value)
                {
                    case "100":
                        this.Number = 100;
                        break;
                    case "200":
                        this.Number = 200;
                        break;
                    case "300":
                        this.Number = 300;
                        break;
                    case "400":
                        this.Number = 400;
                        break;
                    case "500":
                        this.Number = 500;
                        break;
                    case "600":
                        this.Number = 600;
                        break;
                    case "700":
                        this.Number = 700;
                        break;
                    case "800":
                        this.Number = 800;
                        break;
                    case "900":
                        this.Number = 900;
                        break;
                    default:
                        this.Number = 0;
                        return false;
                }

                this.CurrentState = FontWeightState.Number;
                return true;
            }

            // Couldn't parse
            return false;
        }
    }
}