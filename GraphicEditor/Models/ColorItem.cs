using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Models
{
    public class ColorItem
    {
        ISolidColorBrush color = new SolidColorBrush(Colors.Black);
        public ISolidColorBrush Color {
            get { return color; }
            set { color = value; }
        }
    }
}
