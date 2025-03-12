using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4MAUI.Models
{
    public partial class Case : ObservableObject
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string Value { get; private set; }
        [ObservableProperty]
        public Color color;


        public Case(int row, int column)
        {
            Row = row;
            Column = column;
            Value = "";
            this.Color = Colors.White;
        }



        public void UpdateValue(string value)
        {
            Value = value;
            Color = value switch
            {
                "Rouge" => Colors.Red,
                "Jaune" => Colors.Yellow,
                _ => Colors.White
            };
        }
    }
}
